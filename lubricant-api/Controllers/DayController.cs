using System.Linq;
using System.Threading.Tasks;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lubricant_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DayController : Controller
    {
        private readonly IDayService _dayService;
        private readonly ILoggerManager _loggerManager;
        public DayController(IDayService dayService, ILoggerManager loggerManager)
        {
            _dayService = dayService;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _dayService.GetAllAsync();
                if (result.Any())
                {
                    logger.LogInformation($"Retrieve [{result.ToList().Count}] of days from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No days retreived from database.");
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _dayService.GetByIdAsync(id);
                if (result != null)
                {
                    logger.LogInformation($"The day is retreived from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No day is retreived from database.");
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(DaysDto dayDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _dayService.AddAsync(dayDto);
                logger.LogInformation($"Day {dayDto.DayName} is added successfully.");
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(DaysDto dayDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _dayService.UpdateAsync(dayDto);
                logger.LogInformation($"Day {dayDto.DayName} is updated successfully.");
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(DaysDto dayDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _dayService.RemoveAsync(dayDto);
                logger.LogInformation($"Day {dayDto.DayName} is deleted successfully.");
                return Ok();
            }
        }
    }
}