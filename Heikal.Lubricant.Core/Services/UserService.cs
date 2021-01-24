using AutoMapper;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Dtos.ViewModels;
using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Core.Interfaces;
using Heikal.Lubricant.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Core.Services
{
    public class UserService: GenericService<UserDto, User>, IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        public UserService(IMapper mapper, IRepository<User> repository, ILoggerManager loggerManager)
            : base(mapper, repository, loggerManager)
        {
            _mapper = mapper;
            _repository = repository;
            _loggerManager = loggerManager;
        }

        public async Task<IEnumerable<UserViewModel>> GetUserViewModels()
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var users = await _repository.GetAllAsync("Role");
                logger.LogInformation("Users are retreived successfully.");
                var mappedUsers = _mapper.Map<IEnumerable<UserViewModel>>(users.ToList());
                logger.LogInformation("Users are mapped successfully.");
                return mappedUsers;
            }
        }

        public async Task RemoveUser(int userId)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var user = await _repository.GetByIdAsync(userId);
                logger.LogInformation($"User {userId} is retreived successfully.");
                user.IsActive = false;
                _repository.Update(user);
                logger.LogInformation($"User {userId} is removed successfully.");
                await _repository.SaveAsync();
            }
        }

        public async Task<UserLoginViewModel> CheckUser(UserLoginViewModel userLoginViewModel)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var loggedInUser = await _repository
                    .GetByCondition(user => user.UserName == userLoginViewModel.UserName && user.Password == userLoginViewModel.Password && user.IsActive, "Role");
                logger.LogInformation($"User {loggedInUser.ToList()[0]} is logged in successfully.");

                return _mapper.Map<UserLoginViewModel>(loggedInUser.ToList()[0]);
            }
        }
    }
}
