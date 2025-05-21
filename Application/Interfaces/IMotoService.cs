using System.Collections.Generic;
using System.Threading.Tasks;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IMotoService
    {
        Task<IEnumerable<Moto>> GetAllAsync(string? marcaFilter = null, int? anoFilter = null);
        Task<Moto?> GetByIdAsync(int id);
        Task AddAsync(Moto moto);
        Task UpdateAsync(Moto moto);
        Task DeleteAsync(int id);
    }
}
