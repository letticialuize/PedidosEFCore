using Microsoft.EntityFrameworkCore;

namespace PedidosEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=DESKTOP-H3A4EE5;Initial Catalog=CursoEFCore; Integrated Security=true");
        }
    }
}