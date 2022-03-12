using Nest;
using NOV.ES.MDMSearch.API.Models;

namespace NOV.ES.MDMSearch.API.Services
{
    public interface IMDMSearchIndexService
    {
        Task<IndexResponse> IndexMdmDocumentAsync(MDMSearchModel mdmSearchModel);

        List<MDMSearchModel> GetMdmtSearchModelsFromDbAsync();

        Task PublishMdmSearchModelsToElasticSearchAsync();

        Task<ISearchResponse<MDMSearchModel>> SearchAsync(MDMTable table, string query);

        Task<bool> UpdateAssetDocument(MDMSearchModel mdmSearchModel);
        Task<bool> DeleteMDMSearchDocuments(MDMTable table, List<Guid> ids);
        Task<string> GetElasticSearchDocumentId(MDMTable table, Guid id);
        Task<Dictionary<string, Guid>> GetElasticSearchMDMIdDocIdMapping(MDMTable table, List<Guid> ids);
        Task<bool> UpdateMultipleMDMDocuments(List<MDMSearchModel> mdmlSearchModels);
        Task<bool> UpdateMDMDocumentByQuery(MDMTable table, List<Guid> ids, string queryString);
    }
}
