using Buscador.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buscador.Models.Mapping
{
    public class AgendamentoMapping : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(keyExpression: t => t.Id);

            builder.Property(t => t.TrabalhadorId)
                .IsRequired();

            builder.Property(t => t.DataDoAgendamento)
                .IsRequired();

            builder.Property(t => t.DiaAgendado)
                .IsRequired();

            builder.Property(t => t.ClienteId)
                .IsRequired();

            builder.ToTable("Agendamentos");

        }
    }
}
