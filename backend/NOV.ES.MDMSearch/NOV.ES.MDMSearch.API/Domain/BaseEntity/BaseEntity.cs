using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NOV.ES.TAT.MDM.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Source { get; set; }
        [MaxLength(200)]
        public string SourceId { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
