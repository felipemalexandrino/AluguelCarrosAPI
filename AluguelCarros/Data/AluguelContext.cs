using AluguelCarros.Model;
using Microsoft.EntityFrameworkCore;

namespace AluguelCarros.Data
{
    public class AluguelContext : DbContext
    {
        public AluguelContext(DbContextOptions<AluguelContext> opts):base(opts)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
