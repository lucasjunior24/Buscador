﻿using Buscador.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buscador.Mappings
{
    public class EnderecoTrabalhadorMapping : IEntityTypeConfiguration<EnderecoTrabalhador>
    {
        public void Configure(EntityTypeBuilder<EnderecoTrabalhador> builder)
        {
            builder.HasKey(keyExpression: p => p.Id);

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(p => p.Complemento)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("EnderecoDosTrabalhadores");

        }
    }
}
