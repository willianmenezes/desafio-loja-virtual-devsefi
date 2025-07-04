﻿// <auto-generated />
using System;
using DevEficiente.LojaVirtual.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DevEficiente.LojaVirtual.Data.Migrations
{
    [DbContext(typeof(LojaVirtualContext))]
    [Migration("20250531014020_AddPedido")]
    partial class AddPedido
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Autor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Cadastro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(400)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Autores", (string)null);
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Compra", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("Cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Cidade");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Complemento");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("Documento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Endereco");

                    b.Property<Guid?>("IdEstado")
                        .HasColumnType("uuid")
                        .HasColumnName("IdEstado");

                    b.Property<Guid>("IdPais")
                        .HasColumnType("uuid")
                        .HasColumnName("IdPais");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("SobreNome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdPais");

                    b.ToTable("Compras", (string)null);
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Estado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdPais")
                        .HasColumnType("uuid")
                        .HasColumnName("IdPais");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("Estados", (string)null);
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.ItemPedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdLivro")
                        .HasColumnType("uuid")
                        .HasColumnName("IdLivro");

                    b.Property<Guid>("IdPedido")
                        .HasColumnType("uuid")
                        .HasColumnName("IdPedido");

                    b.Property<int>("Quantidade")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("Quantidade");

                    b.Property<decimal>("Valor")
                        .IsUnicode(false)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("IdPedido");

                    b.ToTable("ItensPedido", (string)null);
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Livro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataPublicacao")
                        .IsUnicode(false)
                        .HasColumnType("date")
                        .HasColumnName("DataPublicacao");

                    b.Property<Guid>("IdAutor")
                        .HasColumnType("uuid")
                        .HasColumnName("IdAutor");

                    b.Property<Guid>("IdCategoria")
                        .HasColumnType("uuid")
                        .HasColumnName("IdCategoria");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text")
                        .HasColumnName("Isbn");

                    b.Property<int>("NumeroPaginas")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("NumeroPaginas");

                    b.Property<decimal>("Preco")
                        .IsUnicode(false)
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("Preco");

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Resumo");

                    b.Property<string>("Sumario")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("text")
                        .HasColumnName("Sumario");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("IdAutor");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Livros", (string)null);
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Pais", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Paises", (string)null);
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdCompra")
                        .HasColumnType("uuid")
                        .HasColumnName("IdCompra");

                    b.Property<int>("StatusPedido")
                        .HasColumnType("integer")
                        .HasColumnName("StatusPedido");

                    b.HasKey("Id");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Compra", b =>
                {
                    b.HasOne("DevEficiente.LojaVirtual.Entities.Models.Estado", "Estado")
                        .WithMany("Compras")
                        .HasForeignKey("IdEstado")
                        .HasConstraintName("FK_Compra_Estado_IdEstado");

                    b.HasOne("DevEficiente.LojaVirtual.Entities.Models.Pais", "Pais")
                        .WithMany("Compras")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Compra_Pais_IdPais");

                    b.Navigation("Estado");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Estado", b =>
                {
                    b.HasOne("DevEficiente.LojaVirtual.Entities.Models.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Estado_Pais_IdPais");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.ItemPedido", b =>
                {
                    b.HasOne("DevEficiente.LojaVirtual.Entities.Models.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pedido_ItemPedido_IdPedido");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Livro", b =>
                {
                    b.HasOne("DevEficiente.LojaVirtual.Entities.Models.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Livro_Autor_IdAutor");

                    b.HasOne("DevEficiente.LojaVirtual.Entities.Models.Categoria", "Categoria")
                        .WithMany("Livros")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Livro_Categoria_IdCategoria");

                    b.Navigation("Autor");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Autor", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Categoria", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Estado", b =>
                {
                    b.Navigation("Compras");
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Pais", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Estados");
                });

            modelBuilder.Entity("DevEficiente.LojaVirtual.Entities.Models.Pedido", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
