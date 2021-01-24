using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Dtos.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Core.Interfaces
{
    public interface IUserService: IGenericService<UserDto>
    {
        Task<IEnumerable<UserViewModel>> GetUserViewModels();
        Task RemoveUser(int userId);
        Task<UserLoginViewModel> CheckUser(UserLoginViewModel userLoginViewModel);
    }
}
