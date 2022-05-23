using Buscador.Models.Entitiies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buscador.Mapping
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(keyExpression: c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Icone)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(navigationExpression: c => c.Trabalhador)
                .WithOne(navigationExpression: e => e.Categoria);

            builder.ToTable("Categorias");

        }
    }
}
