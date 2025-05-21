using System.Collections.Generic;
using System.Threading.Tasks;
using CP2.API.Application.Interfaces;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        public ClienteService(IClienteRepository repo) => _repo = repo;

        public async Task<IEnumerable<Cliente>> GetAllAsync(string? nomeFilter = null) =>
            await _repo.GetAllAsync(nomeFilter);

        public async Task<Cliente?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task AddAsync(Cliente cliente) =>
            await _repo.AddAsync(cliente);

        public async Task UpdateAsync(Cliente cliente) =>
            await _repo.UpdateAsync(cliente);

        public async Task DeleteAsync(int id) =>
            await _repo.DeleteAsync(id);
    }
}
