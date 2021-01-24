using Heikal.Lubricant.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Core.Interfaces
{
    public interface IClientService: IGenericService<ClientDto>
    {
        Task<IEnumerable<ClientViewDto>> GetClients();
    }
}
