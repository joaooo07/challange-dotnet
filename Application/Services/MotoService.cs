using System.Collections.Generic;
using System.Threading.Tasks;
using CP2.API.Application.Interfaces;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class MotoService : IMotoService
    {
        private readonly IMotoRepository _repo;
        public MotoService(IMotoRepository repo) => _repo = repo;

        public async Task<IEnumerable<Moto>> GetAllAsync(string? marcaFilter = null, int? anoFilter = null) =>
            await _repo.GetAllAsync(marcaFilter, anoFilter);

        public async Task<Moto?> GetByIdAsync(int id) =>
            await _repo.GetByIdAsync(id);

        public async Task AddAsync(Moto moto) =>
            await _repo.AddAsync(moto);

        public async Task UpdateAsync(Moto moto) =>
            await _repo.UpdateAsync(moto);

        public async Task DeleteAsync(int id) =>
            await _repo.DeleteAsync(id);
    }
}
