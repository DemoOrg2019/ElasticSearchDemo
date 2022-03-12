using Nest;
using NOV.ES.MDMSearch.API.Infrastructure;
using NOV.ES.MDMSearch.API.Models;
using System.Diagnostics;

namespace NOV.ES.MDMSearch.API.Services
{
    public class MDMSearchIndexService
        : IMDMSearchIndexService
    {
        private readonly ILogger<MDMSearchModel> logger;
        private readonly IElasticClient elasticClient;
        private readonly MdmDBContext mdmDBContext;

        public MDMSearchIndexService(ILogger<MDMSearchModel> logger,
            IElasticClient elasticClient,
            MdmDBContext mdmDBContext
            )
        {
            this.logger = logger;
            this.elasticClient = elasticClient;
            this.mdmDBContext = mdmDBContext;
        }

        private string MdmRegisterIndexNameAlias
        {
            get
            {
                string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Substring(0, 3).ToLower();
                var env = string.IsNullOrEmpty(environment) ? "lcl" : environment.ToLower();
                // return $"mdm-register-{env}".ToLower();
                return $"mdm-register-lcl-01".ToLower();
            }
        }

        public Task<IndexResponse> IndexMdmDocumentAsync(MDMSearchModel mdmSearchModel)
        {
            IndexRequest<MDMSearchModel> req = new IndexRequest<MDMSearchModel>(mdmSearchModel, MdmRegisterIndexNameAlias);
            return elasticClient.IndexAsync(req);
        }

        public async Task PublishMdmSearchModelsToElasticSearchAsync()
        {
            // Asset Search Model
            var result = GetMdmtSearchModelsFromDbAsync();
            logger.LogInformation($"Total record count of MDM Search Model is {result.Count}");

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            await Task.Run(() => PublishMdmSearchModelsToElasticSearchAsync(result, stopWatch));

        }

        public async Task<ISearchResponse<MDMSearchModel>> SearchAsync(MDMTable table, string query)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var searchRequest = new SearchRequest<MDMSearchModel>(MdmRegisterIndexNameAlias)
            {
                //From = (assetAdvanceSearch.PageEvent.PageIndex) * assetAdvanceSearch.PageEvent.PageSize,
                Size = 100,
                Query = PrepareSearchQuery(table, query),
                //Aggregations = PrepareAggregations(),
                //Sort = PrepareAssetSort(assetAdvanceSearch)
            };
            sw.Stop();
            logger.LogInformation($"Time taken to build search request is {sw.ElapsedMilliseconds}ms");

            sw.Start();
            var queryResult = await elasticClient.SearchAsync<MDMSearchModel>(searchRequest);
            sw.Stop();
            logger.LogInformation($"Time taken to fetch search result is {sw.ElapsedMilliseconds}ms");

            //<TODO> Remove after testing </TODO>
            var jsonBody = System.Text.Encoding.UTF8.GetString(queryResult.ApiCall.RequestBodyInBytes);
            logger.LogInformation(jsonBody);

            if (!queryResult.IsValid)
            {
                logger.LogError($"Request is not successful. {queryResult.OriginalException}");
                return null;
            }

            return queryResult;
        }

        private QueryContainer PrepareSearchQuery(MDMTable table, string query)
        {
            var bquery = new BoolQuery
            {                
                Must = new QueryContainer[] 
                { 
                    new TermQuery 
                    { 
                        Field = "mDMTable",
                        Value = table
                    },
                    
                    new MatchPhrasePrefixQuery
                    {
                        Field = "code",
                        Query = query
                    }
                }
                
            };
            return bquery;
        }


        public List<MDMSearchModel> GetMdmtSearchModelsFromDbAsync()
        {
            var result = new List<MDMSearchModel>();
            List<MDMSearchModel> brandInfoData = GetBrandInfo();

            if (brandInfoData != null)
            {
                result.AddRange(brandInfoData);
            }

            List<MDMSearchModel> businessUnits = GetBusinessUnits();

            if (brandInfoData != null)
            {
                result.AddRange(businessUnits);
            }

            return result;
        }

        private List<MDMSearchModel> GetBrandInfo()
        {
            return mdmDBContext.BrandInfo.Where(x => x.IsActive == true)
                .Select(x => new MDMSearchModel
                {
                    MDMTable = MDMTable.BrandInfo,
                    Id = x.Id,
                    Code = x.Name,
                    Name = x.Name,
                }).ToList();
        }

        private List<MDMSearchModel> GetBusinessUnits()
        {
            return mdmDBContext.BusinessUnits.Where(x => x.IsActive == true)
                .Select(x => new MDMSearchModel
                {
                    MDMTable = MDMTable.BusinessUnit,
                    Id = x.Id,
                    Code = x.BusinessUnitCode,
                    Name = x.BusinessUnitName,
                }).ToList();
        }

        private void PublishMdmSearchModelsToElasticSearchAsync(List<MDMSearchModel> mdmDocs, Stopwatch stopWatch)
        {
            var countdownEvent = new CountdownEvent(1);
            // Exception exception = null;
            var bulkAllObserver = new BulkAllObserver(
                onNext: response =>
                {
                    logger.LogInformation($"Indexed {response.Page * 1000} with {response.Retries} retries");
                },
                onError: ex =>
                {
                    logger.LogError("BulkAll Error : {0}", ex);
                    stopWatch.Stop();
                    countdownEvent.Signal();
                },
                () =>
                {
                    logger.LogInformation("BulkAll Finished");
                    stopWatch.Stop();
                    logger.LogInformation($"Time taken to push Mdm Search Model to elasticsearch is {stopWatch.ElapsedMilliseconds} ms");
                    countdownEvent.Signal();
                });

            logger.LogInformation($"Starting indexing mdm {mdmDocs.Count}");

            var bulkAllObservable = elasticClient.BulkAll(mdmDocs, b => b
                    .Index(MdmRegisterIndexNameAlias)
                    // how long to wait between retries
                    .BackOffTime("30s")
                    // how many retries are attempted if a failure occurs
                    .BackOffRetries(2)
                    // refresh the index once the bulk operation completes
                    .RefreshOnCompleted()
                    // how many concurrent bulk requests to make
                    .MaxDegreeOfParallelism(Environment.ProcessorCount)
                    // number of items per bulk request
                    .Size(1000)
                )
                .Subscribe(bulkAllObserver);
        }



        public Task<bool> DeleteMDMSearchDocuments(MDMTable table, List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetElasticSearchDocumentId(MDMTable table, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<string, Guid>> GetElasticSearchMDMIdDocIdMapping(MDMTable table, List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> UpdateAssetDocument(MDMSearchModel mdmSearchModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMDMDocumentByQuery(MDMTable table, List<Guid> ids, string queryString)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMultipleMDMDocuments(List<MDMSearchModel> mdmlSearchModels)
        {
            throw new NotImplementedException();
        }
    }
}
