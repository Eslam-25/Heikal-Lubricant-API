using AutoMapper;
using Heikal.Lubricant.Core.Dtos;
using Heikal.Lubricant.Core.Entities;
using Heikal.Lubricant.Core.Interfaces;
using Heikal.Lubricant.Core.Interfaces.Repositories;

namespace Heikal.Lubricant.Core.Services
{
    public class RoleService: GenericService<RoleDto, Role>, IRoleService
    {
        public RoleService(IMapper mapper, IRepository<Role> repository, ILoggerManager loggerManager)
            : base(mapper, repository, loggerManager)
        {
        }
    }
}
