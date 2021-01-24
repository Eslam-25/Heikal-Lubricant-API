
namespace Heikal.Lubricant.Core.Dtos
{
    public class ClientDto: BaseDto
    {
        public string ClientName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int LineId { get; set; }
    }
}
