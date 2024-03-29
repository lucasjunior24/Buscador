﻿using Buscador.Models.Entitiies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buscador.Mapping
{
    public class SolicitacaoMapping : IEntityTypeConfiguration<Solicitacao>
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.HasKey(keyExpression: s => s.Id);

            builder.Property(s => s.NomeDoCliente)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(s => s.NomeDoTrabalhador)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.ToTable("Solicitacoes");

        }
    }
}
