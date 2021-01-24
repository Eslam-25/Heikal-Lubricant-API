using AutoMapper;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Core.Interfaces;
using Heikal.Lubricant.Core.Interfaces.Repositories;

namespace Heikal.Lubricant.Core.Services
{
    public class ProductService: GenericService<ProductDto, Product>, IProductService
    {
        public ProductService(IMapper mapper, IRepository<Product> repository, ILoggerManager loggerManager)
            : base(mapper, repository, loggerManager)
        {

        }
    }
}
