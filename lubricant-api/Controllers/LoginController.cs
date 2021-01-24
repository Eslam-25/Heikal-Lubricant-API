using Heikal.Lubricant.Core.Dtos.ViewModels;
using Heikal.Lubricant.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace lubricant_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILoggerManager _loggerManager;
        public LoginController(IUserService userService, ILoggerManager loggerManager)
        {
            _userService = userService;
            _loggerManager = loggerManager;
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel userLoginViewModel)
        {
            var loggedUser = await _userService.CheckUser(userLoginViewModel);
            return Ok(loggedUser);
        }
    }
}