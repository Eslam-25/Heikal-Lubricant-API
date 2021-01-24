using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Dtos.ViewModels;
using Heikal.Lubricant.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace lubricant_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILoggerManager _loggerManager;
        public UserController(IUserService userService, ILoggerManager loggerManager)
        {
            _userService = userService;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _userService.GetUserViewModels();
                if (result.Any())
                {
                    logger.LogInformation($"Retrieve [{result.ToList().Count}] of users from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No users retreived from database.");
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _userService.GetByIdAsync(id);
                if (result != null)
                {
                    logger.LogInformation($"The user is retreived from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No user is retreived from database.");
                return NoContent();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserDto userDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _userService.AddAsync(userDto);
                logger.LogInformation($"User {userDto.UserName} is added successfully.");
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _userService.UpdateAsync(userDto);
                logger.LogInformation($"User {userDto.UserName} is updated successfully.");
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(UserViewModel viewModel)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _userService.RemoveUser(viewModel.Id);
                logger.LogInformation($"User {viewModel.Id} is deleted successfully.");
                return Ok();
            }
        }
    }
}