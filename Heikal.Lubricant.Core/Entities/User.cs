using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heikal.Lubricant.Core.Entities
{
    public class User: BaseEntity
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
