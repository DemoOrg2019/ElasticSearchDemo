using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOV.ES.TAT.MDM.Domain
{
    [Table("Rig")]
    public class Rig : BaseEntity
    {
        [Required,MaxLength(50)]
        public string RigName { get; set; }
        [MaxLength(20)]
        public string RigJDEName { get; set; }
        [MaxLength(100)]
        public string RigType { get; set; }
        [Required,MaxLength(100)]
        public string ContractorName { get; set; }
        [Required]
        public Guid RigConfigId { get; set; }
        public Guid ContractorId { get; set; }
        public Guid ActualRigConfigId { get; set; }
    }
}
