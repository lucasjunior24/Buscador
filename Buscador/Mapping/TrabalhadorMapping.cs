using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buscador.Mappings
{
    public class TrabalhadorMapping : IEntityTypeConfiguration<Trabalhador>
    {
        public void Configure(EntityTypeBuilder<Trabalhador> builder)
        {
            builder.HasKey(keyExpression: t => t.Id);

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(t => t.UserId)
                .IsRequired();

            builder.Property(t => t.Documento)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(t => t.Foto)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(t => t.Email)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(t => t.Profissao)
                .IsRequired()
                .HasColumnType("varchar(140)");

            builder.Property(x => x.TipoDeTrabalhador)
              .IsRequired()
              .HasColumnType("varchar(50)")
              .HasConversion(
                  a => a.ToString(),
                  a => (TipoDeTrabalhador)System.Enum.Parse(typeof(TipoDeTrabalhador), a));


            // 1 : 1 => Trabalhador : Endereco
            builder.HasOne(navigationExpression: t => t.EnderecoTrabalhador)
                .WithOne(navigationExpression: e => e.Trabalhador);

            // 1 : 1 => Trabalhador : TipoDeServico
            builder.HasOne(navigationExpression: t => t.TipoDeServico)
                .WithOne(navigationExpression: e => e.Trabalhador);

            builder.ToTable("Trabalhadores");

        }
    }
}
