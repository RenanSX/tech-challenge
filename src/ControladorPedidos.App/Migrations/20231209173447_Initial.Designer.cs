﻿// <auto-generated />
using System;
using ControladorPedidos.App.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControladorPedidos.App.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231209173447_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ControladorPedidos.App.Entities.CategoriaProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaProduto", (string)null);
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.Pagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MetodoPagamento")
                        .HasColumnType("int");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("char(36)");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Pagamento", (string)null);
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("PagamentoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PagamentoId")
                        .IsUnique();

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("AtualizadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("PedidoProduto", b =>
                {
                    b.Property<Guid>("PedidosId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProdutosId")
                        .HasColumnType("char(36)");

                    b.HasKey("PedidosId", "ProdutosId");

                    b.HasIndex("ProdutosId");

                    b.ToTable("PedidoProduto");
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.Pedido", b =>
                {
                    b.HasOne("ControladorPedidos.App.Entities.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId");

                    b.HasOne("ControladorPedidos.App.Entities.Pagamento", "Pagamento")
                        .WithOne("Pedido")
                        .HasForeignKey("ControladorPedidos.App.Entities.Pedido", "PagamentoId");

                    b.Navigation("Cliente");

                    b.Navigation("Pagamento");
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.Produto", b =>
                {
                    b.HasOne("ControladorPedidos.App.Entities.CategoriaProduto", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("PedidoProduto", b =>
                {
                    b.HasOne("ControladorPedidos.App.Entities.Pedido", null)
                        .WithMany()
                        .HasForeignKey("PedidosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControladorPedidos.App.Entities.Produto", null)
                        .WithMany()
                        .HasForeignKey("ProdutosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.CategoriaProduto", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("ControladorPedidos.App.Entities.Pagamento", b =>
                {
                    b.Navigation("Pedido")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
