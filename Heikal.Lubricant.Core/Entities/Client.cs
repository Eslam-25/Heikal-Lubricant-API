
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heikal.Lubricant.Core.Entities
{
    public class Client: BaseEntity
    {
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [ForeignKey("LineId")]
        public int LineId { get; set; }
        public Line Line { get; set; }
    }
}
