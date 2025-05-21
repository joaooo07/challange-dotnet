using System.Collections.Generic;
using System.Threading.Tasks;
using CP2.API.Domain.Entities;

namespace CP2.API.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAllAsync(string? nomeFilter = null);
        Task<Cliente?> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
