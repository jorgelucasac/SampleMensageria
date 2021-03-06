// <auto-generated />
using System;
using Estudos.Viagem.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Estudos.Viagem.Infrastructure.SqlServer.Migrations
{
    [DbContext(typeof(ViagemDataContext))]
    [Migration("20220301133009_AddMensagemValidacaoViagem2")]
    partial class AddMensagemValidacaoViagem2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Estudos.Viagem.Application.Entities.Carro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoDiaria")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("Estudos.Viagem.Application.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Estudos.Viagem.Application.Entities.Hospedagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HotelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeHotel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoDiaria")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Hospedagens");
                });

            modelBuilder.Entity("Estudos.Viagem.Application.Entities.PacoteViagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataUltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("HospedagemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MensagensValidacoes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Viagens");
                });

            modelBuilder.Entity("Estudos.Viagem.Application.Entities.PacoteViagem", b =>
                {
                    b.HasOne("Estudos.Viagem.Application.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Estudos.Viagem.Application.ValueObjects.Passagem", "Passagem", b1 =>
                        {
                            b1.Property<Guid>("PacoteViagemId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("DataIda")
                                .HasColumnType("DATE")
                                .HasColumnName("DataIda");

                            b1.Property<DateTime>("DataVolta")
                                .HasColumnType("DATE")
                                .HasColumnName("DataVolta");

                            b1.Property<string>("Destino")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Destino");

                            b1.Property<string>("Origem")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Origem");

                            b1.Property<int>("QuantidadeViajantes")
                                .HasColumnType("int")
                                .HasColumnName("QuantidadeViajantes");

                            b1.HasKey("PacoteViagemId");

                            b1.ToTable("Viagens");

                            b1.WithOwner()
                                .HasForeignKey("PacoteViagemId");
                        });

                    b.Navigation("Cliente");

                    b.Navigation("Passagem")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
