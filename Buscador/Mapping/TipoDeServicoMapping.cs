using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buscador.Mappings
{
    public class TipoDeServicoMapping : IEntityTypeConfiguration<TipoDeServico>
    {
        public void Configure(EntityTypeBuilder<TipoDeServico> builder)
        {
            builder.HasKey(keyExpression: t => t.Id);

            builder.Property(t => t.NomeDoServico)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("TiposDeServicos");

        }
    }
}
