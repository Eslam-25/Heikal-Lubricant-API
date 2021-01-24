
using System.ComponentModel.DataAnnotations;

namespace Heikal.Lubricant.Core.Entities
{
    public class Product: BaseEntity
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Liter { get; set; }
        [Required]
        public decimal KileMeter { get; set; }
        [Required]
        public decimal NumberOfUnit { get; set; }
        [Required]
        public decimal BuyPrice { get; set; }
        [Required]
        public decimal SellingPrice { get; set; }
        [Required]
        public string SAE { get; set; }
        [Required]
        public string API { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
