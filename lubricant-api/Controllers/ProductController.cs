using System.Linq;
using System.Threading.Tasks;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lubricant_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILoggerManager _loggerManager;
        public ProductController(IProductService productService, ILoggerManager loggerManager)
        {
            _productService = productService;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _productService.GetAllAsync();
                if (result.Any())
                {
                    logger.LogInformation($"Retrieve [{result.ToList().Count}] of products from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No products retreived from database.");
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _productService.GetByIdAsync(id);
                if (result != null)
                {
                    logger.LogInformation($"The product is retreived from database.");
                    return Ok(result);
                }
                logger.LogInformation($"No product is retreived from database.");
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProductDto productDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _productService.AddAsync(productDto);
                logger.LogInformation($"Product {productDto.ProductName} is added successfully.");
                return Ok();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductDto productDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _productService.UpdateAsync(productDto);
                logger.LogInformation($"Product {productDto.ProductName} is updated successfully.");
                return Ok();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(ProductDto productDto)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                await _productService.RemoveAsync(productDto);
                logger.LogInformation($"Product {productDto.ProductName} is deleted successfully.");
                return Ok();
            }
        }
    }
}