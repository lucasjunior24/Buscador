using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buscador.Mapping
{
    public class PerfilMapping : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.HasKey(keyExpression: p => p.Id);

            builder.Property(p => p.PerfilDeUsuario)
                .IsRequired()
                .HasColumnType("varchar(40)");


            builder.ToTable("Perfis");

        }
    }
}
