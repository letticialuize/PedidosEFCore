using Microsoft.EntityFrameworkCore;
using PedidosEFCore.Data.Configurations;
using PedidosEFCore.Domain;

namespace PedidosEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-H3A4EE5;Initial Catalog=CursoEFCore; Integrated Security=true");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}