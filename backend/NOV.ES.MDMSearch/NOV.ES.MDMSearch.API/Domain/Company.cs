using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV.ES.TAT.MDM.Domain
{
    [Table("Company")]
    public class Company : BaseEntity
    {
        [MaxLength(28)]
        public string Code { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(4)]
        public string UserDefinedCodesX { get; set; }
        [MaxLength(8)]
        public string ProductCodeX { get; set; }
        [MaxLength(20)]
        public string UserdefinedCodeX { get; set; }
    }
}
