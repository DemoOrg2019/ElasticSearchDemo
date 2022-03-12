using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV.ES.TAT.MDM.Domain
{
    [Table("SalesPerson")]
    public class SalesPerson : BaseEntity
    {
        [Required,MaxLength(80)]
        public string Name { get; set; }     
        [MaxLength(8)]
        public double Code { get; set; }
        [MaxLength(4)]
        public string OrderTypeX { get; set; }        
        public DateTime DateEffectiveX { get; set; }   
        public DateTime DateExpireX { get; set; }   
    }
}
