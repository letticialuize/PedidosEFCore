using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosEFCore.Domain;

namespace PedidosEFCore.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasColumnType("varchar(80)").IsRequired();
            builder.Property(c => c.Telefone).HasColumnType("char(11)");
            builder.Property(c => c.CEP).HasColumnType("char(8)").IsRequired();
            builder.Property(c => c.Estado).HasColumnType("char(2)").IsRequired();
            builder.Property(c => c.Cidade).HasMaxLength(60).IsRequired();

            builder.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
        }
    }
}