﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesWebMvc.Data;

namespace SalesWebMvc.Migrations
{
    [DbContext(typeof(SalesWebMvcContext))]
    [Migration("20200423021242_Correction_01_22-04-2020")]
    partial class Correction_01_22042020
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalesWebMvc.Models.Departamento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Venda", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("VendedorVendaid")
                        .HasColumnType("int");

                    b.Property<DateTime>("data")
                        .HasColumnType("datetime2");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("VendedorVendaid");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Vendedor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartamentoVendedorid")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("salariobase")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("DepartamentoVendedorid");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Venda", b =>
                {
                    b.HasOne("SalesWebMvc.Models.Vendedor", "VendedorVenda")
                        .WithMany("VendasVendedor")
                        .HasForeignKey("VendedorVendaid");
                });

            modelBuilder.Entity("SalesWebMvc.Models.Vendedor", b =>
                {
                    b.HasOne("SalesWebMvc.Models.Departamento", "DepartamentoVendedor")
                        .WithMany("ColecaoVendedores")
                        .HasForeignKey("DepartamentoVendedorid");
                });
#pragma warning restore 612, 618
        }
    }
}