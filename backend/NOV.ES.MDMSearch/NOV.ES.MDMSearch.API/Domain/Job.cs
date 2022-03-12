using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV.ES.TAT.MDM.Domain
{
    [Table("Job")]
    public class Job : BaseEntity
    {
        public int JobId { get; set; }
        public int? CustomerId { get; set; }
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [MaxLength(24)]
        public string RevenueBU { get; set; }
        [MaxLength(50)]
        public string RevenueBuName { get; set; }
        [MaxLength(24)]
        public string SendingBU { get; set; }
        [MaxLength(50)]
        public string SendingBuName { get; set; }
        [MaxLength(50)]
        public string CorpRigId { get; set; }
        [MaxLength(100)]
        public string RigName { get; set; }
        [MaxLength(100)]
        public string JobDescription { get; set; }
        [MaxLength(100)]
        public string ContactName { get; set; }
        [MaxLength(50)]
        public string ContactNumber { get; set; }
        [MaxLength(100)]
        public string Capex { get; set; }
        public DateTime? DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        [MaxLength(100)]
        public string CustomerPo { get; set; }
        [MaxLength(100)]
        public string CustomerLocation { get; set; }
        [MaxLength(50)]
        public string CustomerContact { get; set; }
        public double? ShipTo { get; set; }
        public int? ErpJobStatusCode { get; set; }
        [MaxLength(100)]
        public string RentalAgreement { get; set; }
        public bool? ActiveStatus { get; set; }
    }
}
