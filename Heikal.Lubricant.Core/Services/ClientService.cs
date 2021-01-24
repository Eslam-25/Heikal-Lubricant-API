using AutoMapper;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Core.Interfaces;
using Heikal.Lubricant.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Core.Services
{
     public class ClientService : GenericService<ClientDto, Client>, IClientService
    {
        private readonly IRepository<Client> _repository;
        private readonly IDayService _dayService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        public ClientService(
            IMapper mapper, 
            IRepository<Client> repository, 
            ILoggerManager loggerManager,
            IDayService dayService
            )
            : base(mapper, repository, loggerManager)
        {
            _repository = repository;
            _dayService = dayService;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }

        public async Task<IEnumerable<ClientViewDto>> GetClients() 
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var clients = await _repository.GetAllAsync("Line");
                logger.LogInformation("All clients are retrieved");
                ClientViewDto[] clientViewDtos = new ClientViewDto[clients.Count()];
                for (int i = 0; i < clients.Count(); i++)
                {
                    ClientViewDto mappedLine = _mapper.Map<ClientViewDto>(clients.ElementAt(i));
                    mappedLine.Day = await _dayService.GetByIdAsync(clients.ElementAt(i).Line.DayId);
                    clientViewDtos[i] = mappedLine;
                }
                logger.LogInformation("All clients are mapped successfully");

                return clientViewDtos;
            }
        }
    }
}
