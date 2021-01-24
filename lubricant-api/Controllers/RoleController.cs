using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace lubricant_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly ILoggerManager _loggerManager;
        public RoleController(IRoleService roleService, ILoggerManager loggerManager)
        {
            _roleService = roleService;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _roleService.GetAllAsync();
                if (result.Any())
                {
                    logger.LogInformation($"Retrieve [{result.ToList().Count}] of roles from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No roles retreived from database.");
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _roleService.GetByIdAsync(id);
                if (result != null)
                {
                    logger.LogInformation($"The role is retreived from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No role is retreived from database.");
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleDto roleDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _roleService.AddAsync(roleDto);
                logger.LogInformation($"Role {roleDto.RoleName} is added successfully.");
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleDto roleDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _roleService.UpdateAsync(roleDto);
                logger.LogInformation($"Role {roleDto.RoleName} is updated successfully.");
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(RoleDto roleDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _roleService.RemoveAsync(roleDto);
                logger.LogInformation($"Role {roleDto.RoleName} is deleted successfully.");
                return Ok();
            }
        }
    }
}