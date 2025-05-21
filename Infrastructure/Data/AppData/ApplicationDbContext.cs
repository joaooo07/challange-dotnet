using CP2.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP2.API.Infrastructure.Data.AppData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
            : base(opts) { }

        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Moto> Motos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(eb =>
            {
                eb.ToTable("CLIENTES");
                eb.Property(c => c.Id).HasColumnName("ID");
                eb.Property(c => c.Nome).HasColumnName("NOME");
                eb.Property(c => c.Email).HasColumnName("EMAIL");
                eb.Property(c => c.Idade).HasColumnName("IDADE");
            });

            modelBuilder.Entity<Moto>(eb =>
            {
                eb.ToTable("MOTOS");
                eb.Property(m => m.Id).HasColumnName("ID");
                eb.Property(m => m.Marca).HasColumnName("MARCA");
                eb.Property(m => m.Modelo).HasColumnName("MODELO");
                eb.Property(m => m.Ano).HasColumnName("ANO");
                eb.Property(m => m.Placa).HasColumnName("PLACA");
            });
        }
    }
}
