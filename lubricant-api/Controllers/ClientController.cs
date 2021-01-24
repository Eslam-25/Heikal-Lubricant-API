using System.Linq;
using System.Threading.Tasks;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lubricant_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly ILoggerManager _loggerManager;
        public ClientController(IClientService clientService, ILoggerManager loggerManager)
        {
            _clientService = clientService;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _clientService.GetClients();
                if (result.Any())
                {
                    logger.LogInformation($"Retrieve [{result.ToList().Count}] of clients from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No clients retreived from database.");
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _clientService.GetByIdAsync(id);
                if (result != null)
                {
                    logger.LogInformation($"The client is retreived from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No client is retreived from database.");
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ClientDto clientDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _clientService.AddAsync(clientDto);
                logger.LogInformation($"Client {clientDto.ClientName} is added successfully.");
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ClientDto clientDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _clientService.UpdateAsync(clientDto);
                logger.LogInformation($"Client {clientDto.ClientName} is updated successfully.");
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(ClientDto clientDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _clientService.RemoveAsync(clientDto);
                logger.LogInformation($"Client {clientDto.ClientName} is deleted successfully.");
                return Ok();
            }
        }
    }
}