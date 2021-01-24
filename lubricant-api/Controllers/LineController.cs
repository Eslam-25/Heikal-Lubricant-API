using System.Linq;
using System.Threading.Tasks;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lubricant_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LineController : Controller
    {
        private readonly ILineService _lineService;
        private readonly ILoggerManager _loggerManager;
        public LineController(ILineService lineService, ILoggerManager loggerManager)
        {
            _lineService = lineService;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var logger = _loggerManager.CreateLogger()) 
            {
                var result = await _lineService.GetLines();
                if (result.Any())
                {
                    logger.LogInformation($"Retrieve [{result.ToList().Count}] of lines from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No lines retreived from database.");
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _lineService.GetLine(id);
                if (result != null)
                {
                    logger.LogInformation($"The line is retreived from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No line is retreived from database.");
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(LineDto lineDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _lineService.AddAsync(lineDto);
                logger.LogInformation($"Line {lineDto.LineName} is added successfully.");
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(LineDto lineDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _lineService.UpdateAsync(lineDto);
                logger.LogInformation($"Line {lineDto.LineName} is updated successfully.");
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(LineDto lineDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _lineService.RemoveAsync(lineDto);
                logger.LogInformation($"Line {lineDto.LineName} is deleted successfully.");
                return Ok();
            }
        }
    }
}