
using System.ComponentModel.DataAnnotations;

namespace Heikal.Lubricant.Core.Entities
{
    public class Role: BaseEntity
    {
        [Required]
        public string RoleName { get; set; }
    }
}
