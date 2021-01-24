namespace Heikal.Lubricant.Core.Dtos
{
    public class ClientViewDto: BaseDto
    {
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public LineDto Line { get; set; }
        public DaysDto Day { get; set; }
    }
}
