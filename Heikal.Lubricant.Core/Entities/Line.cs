
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heikal.Lubricant.Core.Entities
{
    public class Line: BaseEntity
    {
        [Required]
        public string LineName { get; set; }
        [Required]

        [ForeignKey("DayId")]
        public int DayId { get; set; }
        public virtual Days Day { get; set; }
    }
}
