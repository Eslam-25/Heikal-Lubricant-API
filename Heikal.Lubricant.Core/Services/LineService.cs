using AutoMapper;
using Heikal.Lubricant.Core.BusinessException;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Core.Interfaces;
using Heikal.Lubricant.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Core.Services
{
    public class LineService: GenericService<LineDto, Line> , ILineService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IRepository<Line> _repository;
        public LineService(
            IMapper mapper, 
            IRepository<Line> repository, 
            ILoggerManager loggerManager)
            :base(mapper, repository, loggerManager)
        {
            _mapper = mapper;
            _repository = repository;
            _loggerManager = loggerManager;
        }

        public async Task<IEnumerable<LineViewDto>> GetLines()
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var result = await _repository.GetAllAsync("Day");
                var mappedLineDto = _mapper.Map<IEnumerable<LineViewDto>>(result.ToList());
                logger.LogInformation($"The Lines are retrieved successfully.");
                return mappedLineDto;
            }
        }

        public async Task<LineDto> GetLine(int id) 
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                if (id < 0)
                    throw new LineServiceException("Line Id must be more than 1.");

                var result = await _repository.GetByCondition(l => l.Id == id, "Day");
                var mappedLineDto = _mapper.Map<LineDto>(result.ToList()[0]);
                logger.LogInformation($"The Line {mappedLineDto.Id} is retrieved successfully.");
                return mappedLineDto;
            }
        }
    }
}
