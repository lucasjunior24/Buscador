﻿// <auto-generated />
using System;
using Buscador.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Buscador.Migrations
{
    [DbContext(typeof(BuscadorContext))]
    partial class BuscadorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Buscador.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Buscador.Models.EnderecoCliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("EnderecoDosClientes");
                });

            modelBuilder.Entity("Buscador.Models.EnderecoTrabalhador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("TrabalhadorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TrabalhadorId")
                        .IsUnique();

                    b.ToTable("EnderecoDosTrabalhadores");
                });

            modelBuilder.Entity("Buscador.Models.Solicitacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataDaSolicitacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeDoCliente")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeDoTrabalhador")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("ProfissaoDoTrabalhador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusDaSolicitacao")
                        .HasColumnType("int");

                    b.Property<Guid>("TrabalhadorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TrabalhadorId");

                    b.ToTable("Solicitacoes");
                });

            modelBuilder.Entity("Buscador.Models.TipoDeServico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AreaProfissional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeDoServico")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("TrabalhadorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TrabalhadorId")
                        .IsUnique();

                    b.ToTable("TiposDeServicos");
                });

            modelBuilder.Entity("Buscador.Models.Trabalhador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CursoOuFormaçao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("varchar(140)");

                    b.Property<bool>("Solicitado")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempoExperiencia")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TipoDeTrabalhador")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Trabalhadores");
                });

            modelBuilder.Entity("Buscador.Models.EnderecoCliente", b =>
                {
                    b.HasOne("Buscador.Models.Cliente", "Cliente")
                        .WithOne("EnderecoCliente")
                        .HasForeignKey("Buscador.Models.EnderecoCliente", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Buscador.Models.EnderecoTrabalhador", b =>
                {
                    b.HasOne("Buscador.Models.Trabalhador", "Trabalhador")
                        .WithOne("EnderecoTrabalhador")
                        .HasForeignKey("Buscador.Models.EnderecoTrabalhador", "TrabalhadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trabalhador");
                });

            modelBuilder.Entity("Buscador.Models.Solicitacao", b =>
                {
                    b.HasOne("Buscador.Models.Cliente", "Cliente")
                        .WithMany("Solicitacao")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Buscador.Models.Trabalhador", "Trabalhador")
                        .WithMany("Solicitacao")
                        .HasForeignKey("TrabalhadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Trabalhador");
                });

            modelBuilder.Entity("Buscador.Models.TipoDeServico", b =>
                {
                    b.HasOne("Buscador.Models.Trabalhador", "Trabalhador")
                        .WithOne("TipoDeServico")
                        .HasForeignKey("Buscador.Models.TipoDeServico", "TrabalhadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trabalhador");
                });

            modelBuilder.Entity("Buscador.Models.Cliente", b =>
                {
                    b.Navigation("EnderecoCliente");

                    b.Navigation("Solicitacao");
                });

            modelBuilder.Entity("Buscador.Models.Trabalhador", b =>
                {
                    b.Navigation("EnderecoTrabalhador");

                    b.Navigation("Solicitacao");

                    b.Navigation("TipoDeServico");
                });
#pragma warning restore 612, 618
        }
    }
}
