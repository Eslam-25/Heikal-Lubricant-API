
namespace Heikal.Lubricant.Core.Dtos
{
    public class UserDto: BaseDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}
