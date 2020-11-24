using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Cliente>(c =>
            {
                c.ToTable("Clientes");
                c.HasKey(c => c.Id);
                c.Property(c => c.Nome).HasColumnType("varchar(80)").IsRequired();
                c.Property(c => c.Telefone).HasColumnType("char(11)");
                c.Property(c => c.CEP).HasColumnType("char(8)").IsRequired();
                c.Property(c => c.Estado).HasColumnType("char(2)").IsRequired();
                c.Property(c => c.Cidade).HasMaxLength(60).IsRequired();

                c.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
            });

            modelBuilder.Entity<Produto>(p => 
            {
                p.ToTable("Produtos");
                p.HasKey(p => p.Id);
                p.Property(p => p.CodigoBarras).HasColumnType("varchar(14)").IsRequired();
                p.Property(p => p.Descricao).HasColumnType("varchar(60)");
                p.Property(p => p.Valor).IsRequired();
                p.Property(p => p.TipoProduto).HasConversion<string>();
            });
        }
    }
}