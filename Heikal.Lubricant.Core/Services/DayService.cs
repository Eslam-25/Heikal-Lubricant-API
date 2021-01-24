using AutoMapper;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Core.Interfaces;
using Heikal.Lubricant.Core.Interfaces.Repositories;

namespace Heikal.Lubricant.Core.Services
{
    public class DayService: GenericService<DaysDto, Days>, IDayService
    {
        public DayService(IMapper mapper, IRepository<Days> repository, ILoggerManager loggerManager)
            :base(mapper, repository, loggerManager)
        {
        }
    }
}
