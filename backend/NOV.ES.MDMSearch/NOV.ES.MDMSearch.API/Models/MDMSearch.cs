using Nest;

namespace NOV.ES.MDMSearch.API.Models
{
    public enum MDMTable
    {
        BrandInfo,
        BusinessUnit
    }
    public class MDMSearchModel
    {
        public MDMTable MDMTable { get; set; }
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? DependOnId { get; set; }

    }

    public class ElasticSearchResult
    {
        public long Took { get; set; }
        public bool TimedOut { get; set; }
        //public ShardStatistics Shards { get; set; }
        public IList<IHit<MDMSearchModel>> Hits { get; set; }
    }
}
