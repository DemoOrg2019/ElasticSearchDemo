using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV.ES.TAT.MDM.Domain
{
    [Table("Currency")]
    public class Currency : BaseEntity
    {
        [MaxLength(8)]
        public double? ConversionRateSpot { get; set; }
        [MaxLength(8)]
        public double? ConversionRateDivsor { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(6)]
        public string CodeFrom { get; set; }
        [MaxLength(6)]
        public string CodeTo { get; set; }
    }
}