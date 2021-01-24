using AutoMapper;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Core.Interfaces;
using Heikal.Lubricant.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Core.Services
{
    public class GenericService<T, B> : IGenericService<T> where T : BaseDto where B : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IRepository<B> _repository;
        private readonly ILoggerManager _loggerManager;

        public GenericService(IMapper mapper, IRepository<B> repository, ILoggerManager loggerManager)
        {
            _mapper = mapper;
            _repository = repository;
            _loggerManager = loggerManager;
        }

        public async Task AddAsync(T entity)
        {
            using (var logger = _loggerManager.CreateLogger()) 
            {
                entity.IsActive = true;
                entity.CreationDate = DateTime.Now;

                var mapped = _mapper.Map<B>(entity);
                logger.LogInformation($"The {typeof(B)} mapped successfully.");
                _repository.Add(mapped);
                await _repository.SaveAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                IEnumerable<B> result = await _repository.GetAllAsync();
                logger.LogInformation($"The data of {typeof(B)} are retreived successfully.");
                return _mapper.Map<IEnumerable<T>>(result);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                B result = await _repository.GetByIdAsync(id );
                logger.LogInformation($"The data of {typeof(B)} are retreived successfully.");

                return _mapper.Map<T>(result);
            }
        }

        public async Task RemoveAsync(T entity)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var mapped = _mapper.Map<B>(entity);
                mapped.IsActive = false;
                _repository.Update(mapped);
                logger.LogInformation($"The data of {typeof(B)} is deleted successfully.");
                await _repository.SaveAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            using (var logger = _loggerManager.CreateLogger())
            {
                var mapped = _mapper.Map<B>(entity);
                _repository.Update(mapped);
                logger.LogInformation($"The data of {typeof(B)} is updated successfully.");
                await _repository.SaveAsync();
            }
        }
    }
}
