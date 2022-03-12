using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV.ES.TAT.MDM.Domain
{
    [Table("CustomerAddress")]
    public class CustomerAddress : BaseEntity
    {
        [MaxLength(8)]
        public Double? AddressNumber { get; set; }
        [MaxLength(8)]
        public Double? CustomerId { get; set; }
        [MaxLength(80)]
        public string AddressLine1 { get; set; }
        [MaxLength(80)]
        public string AddressLine2 { get; set; }
        [MaxLength(80)]
        public string AddressLine3 { get; set; }
        [MaxLength(80)]
        public string AddressLine4 { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(6)]
        public string State { get; set; }
        [MaxLength(20)]
        public string ZipCode { get; set; }
        [MaxLength(6)]
        public string Country { get; set; }
        [MaxLength(24)]
        public string CompanyErpAbCode { get; set; }
        [MaxLength(6)]
        public string AddressType1X { get; set; }
        [MaxLength(10)]
        public string CompanyX { get; set; }

    }
}
