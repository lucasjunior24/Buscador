using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buscador.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(keyExpression: c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Foto)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.HasOne(navigationExpression: c => c.EnderecoCliente)
                .WithOne(navigationExpression: e => e.Cliente);


            builder.ToTable("Clientes");

        }
    }
}
