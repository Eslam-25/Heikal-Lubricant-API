using Heikal.Lubricant.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Core.Interfaces
{
    public interface ILineService: IGenericService<LineDto>
    {
        Task<LineDto> GetLine(int id);
        Task<IEnumerable<LineViewDto>> GetLines();
    }
}
