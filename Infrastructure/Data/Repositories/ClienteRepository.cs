using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using CP2.API.Infrastructure.Data.AppData;
using Microsoft.EntityFrameworkCore;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _ctx;
        public ClienteRepository(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<List<Cliente>> GetAllAsync(string? nomeFilter = null)
        {
            var query = _ctx.Clientes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(nomeFilter))
                query = query.Where(c => c.Nome.Contains(nomeFilter));
            return await query.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id) =>
            await _ctx.Clientes.FindAsync(id);

        public async Task AddAsync(Cliente c)
        {
            _ctx.Clientes.Add(c);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente c)
        {
            _ctx.Entry(c).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _ctx.Clientes.FindAsync(id);
            if (entity != null)
            {
                _ctx.Clientes.Remove(entity);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
