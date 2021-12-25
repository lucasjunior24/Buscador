using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buscador.Mapping
{
    public class SolicitacaoMapping : IEntityTypeConfiguration<Solicitacao>
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.HasKey(keyExpression: s => s.Id);

            builder.Property(s => s.NomeSolicitante)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(s => s.DocumentoSolicitante)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.ToTable("Solicitacoes");

        }
    }
}
