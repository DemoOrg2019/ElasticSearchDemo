using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV.ES.TAT.MDM.Domain
{
    [Table("BusinessUnit")]
    public class BusinessUnit:BaseEntity
    {
        [Column("BusinessUnit")]
        [Required,MaxLength(24)]
        public string BusinessUnitCode { get; set; }
        [Required, MaxLength(60)]
        public string BusinessUnitName { get; set; }
        [MaxLength(10)]
        public string Company { get; set; }
        [MaxLength(24)]
        public string RelatedBu { get; set; }
    }
}
