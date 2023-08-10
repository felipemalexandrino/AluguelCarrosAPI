using AluguelCarros.Model;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarros.Data
{
    public class AluguelContext : DbContext
    {
        public AluguelContext(DbContextOptions<AluguelContext> opts):base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cliente CPF UNIQUE
            modelBuilder.Entity<Cliente>().HasIndex(c=> c.CPF).IsUnique();

            //Carro RENAVAM PLACA UNIQUE
            modelBuilder.Entity<Carro>().HasIndex(c => c.Placa).IsUnique();
            modelBuilder.Entity<Carro>().HasIndex(c => c.Revanam).IsUnique();

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Carro> Carros { get; set; }
    }
}
