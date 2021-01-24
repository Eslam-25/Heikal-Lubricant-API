using System.ComponentModel.DataAnnotations;

namespace Heikal.Lubricant.Core.Entities
{
    public class Days: BaseEntity
    {
        [Required]
        public string DayName { get; set; }
    }
}
