using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV.ES.TAT.MDM.Domain
{
    [Table("Customer")]
    public class Customer : BaseEntity
    {
        public double CustomerId { get; set; }
        [MaxLength(40)]
        public string AlternateAddressKey { get; set; }
        [MaxLength(40)]
        public string TaxId { get; set; }
        [MaxLength(80)]
        public string CustomerName { get; set; }
        [MaxLength(80)]
        public string DescripCompressed { get; set; }
        [MaxLength(24)]
        public string CostCenter { get; set; }
        [MaxLength(20)]
        public string StandardIndustryCode { get; set; }
        [MaxLength(4)]
        public string LanguagePreference { get; set; }
        [MaxLength(6)]
        public string AddressType1 { get; set; }
        [MaxLength(4)]
        public string CreditMessage { get; set; }
        [MaxLength(2)]
        public string PersonCoporationCode { get; set; }
        [MaxLength(2)]
        public string AddressType2 { get; set; }
        [MaxLength(2)]
        public string AddressType3 { get; set; }
        [MaxLength(2)]
        public string AddressType4 { get; set; }
        [MaxLength(2)]
        public string AddressType5 { get; set; }
        [MaxLength(2)]
        public string AddressTypePayables { get; set; }
        [MaxLength(2)]
        public string AddressTypeReceivables { get; set; }
        [MaxLength(2)]
        public string AddressTypePayablesr { get; set; }
        [MaxLength(2)]
        public string MiscCode3 { get; set; }
        [MaxLength(2)]
        public string AddressTypeEmployee { get; set; }
        [MaxLength(2)]
        public string SubledgerInactiveCode { get; set; }      
        [Column(TypeName ="numeric")]
        public decimal? DateBeginningEffective { get; set; }      
        public double? AddressNumber1 { get; set; }      
        public double? AddressNumber2 { get; set; }      
        public double? AddressNumber3 { get; set; }      
        public double? AddressNumber4 { get; set; }     
        public double? AddressNumber6 { get; set; }       
        public double? AddressNumber5 { get; set; }      
        public string ReportCodeAddBook001 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook002 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook003 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook004 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook005 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook006 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook007 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook008 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook009 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook010 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook011 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook012 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook013 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook014 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook015 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook016 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook017 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook018 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook019 { get; set; }
        [MaxLength(6)]
        public string ReportCodeAddBook020 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk21 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk22 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk23 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk24 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk25 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk26 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk27 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk28 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk29 { get; set; }
        [MaxLength(6)]
        public string CategoryCodeAddressBk30 { get; set; }
        [MaxLength(16)]
        public string GlBankAccount { get; set; }     
        public double? TimeScheduledIn { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? DateScheduledIn { get; set; }
        [MaxLength(2)]
        public string ActionMessageControl { get; set; }
        [MaxLength(60)]
        public string NameRemark { get; set; }
        [MaxLength(40)]
        public string CertificateTaxExempt { get; set; }
        [MaxLength(40)]
        public string TaxId2 { get; set; }
        [MaxLength(80)]
        public string Kanjialpha { get; set; }
        [MaxLength(4)]
        public string UsedReservedCode { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? UsedReservedDate { get; set; }      
        public double? UsedReservedAmount { get; set; }       
        public double? UsedReservedAccount { get; set; }
        [MaxLength(30)]
        public string HcmCode { get; set; }
        [MaxLength(20)]
        public string UserId { get; set; }
        [MaxLength(20)]
        public string ProgramId { get; set; }
        [Column(TypeName = "numeric")]
        public decimal? DateUpdated { get; set; }
        [MaxLength(20)]
        public string WorkStationId { get; set; }       
        public double? TimeLastUpdated { get; set; }
        [MaxLength(10)]
        public string CompanyX { get; set; }
    }
}
