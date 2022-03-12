using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV.ES.TAT.MDM.Domain
{
    [Table("BrandInfo")]
    public class BrandInfo : BaseEntity
    {
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(4)]
        public string UserDefinedCodesX { get; set; }
        [MaxLength(20)]
        public string SpecialHandlingCodeX { get; set; }
        [MaxLength(8)]
        public string ProductCodeX { get; set; }

    }
}
