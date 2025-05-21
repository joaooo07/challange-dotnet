using System.Collections.Generic;
using System.Threading.Tasks;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllAsync(string? nomeFilter = null);
        Task<Cliente?> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
