using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using CP2.API.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly ApplicationDbContext _ctx;
        public MotoRepository(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<List<Moto>> GetAllAsync(string? marcaFilter = null, int? anoFilter = null)
        {
            var query = _ctx.Motos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(marcaFilter))
                query = query.Where(m => m.Marca.Contains(marcaFilter));
            if (anoFilter.HasValue)
                query = query.Where(m => m.Ano == anoFilter.Value);
            return await query.ToListAsync();
        }

        public async Task<Moto?> GetByIdAsync(int id) =>
            await _ctx.Motos.FindAsync(id);

        public async Task AddAsync(Moto m)
        {
            _ctx.Motos.Add(m);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Moto m)
        {
            _ctx.Entry(m).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _ctx.Motos.FindAsync(id);
            if (entity != null)
            {
                _ctx.Motos.Remove(entity);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
