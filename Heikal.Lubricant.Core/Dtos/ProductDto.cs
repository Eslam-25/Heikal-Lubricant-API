namespace Heikal.Lubricant.Core.Dtos
{
    public class ProductDto: BaseDto
    {
        public string ProductName { get; set; }
        public decimal Liter { get; set; }
        public decimal KileMeter { get; set; }
        public decimal NumberOfUnit { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string SAE { get; set; }
        public string API { get; set; }
        public string ImagePath { get; set; }
    }
}
