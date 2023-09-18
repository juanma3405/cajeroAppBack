﻿// <auto-generated />
using System;
using CajeroAppBack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CajeroAppBack.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230915155009_IngresoPinErroneo_AgregoData")]
    partial class IngresoPinErroneo_AgregoData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CajeroAppBack.Entidades.Operacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("CantidadRetirada")
                        .HasColumnType("float");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTarjeta")
                        .HasColumnType("int");

                    b.Property<int?>("TarjetaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TarjetaId");

                    b.ToTable("Operaciones");
                });

            modelBuilder.Entity("CajeroAppBack.Entidades.Tarjeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<bool>("Bloqueada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IngresoPinErroneo")
                        .HasColumnType("int");

                    b.Property<string>("NumeroTarjeta")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tarjetas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Balance = 0.0,
                            Bloqueada = false,
                            FechaVencimiento = new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IngresoPinErroneo = 0,
                            NumeroTarjeta = "1001100110011001",
                            Pin = 1212
                        },
                        new
                        {
                            Id = 2,
                            Balance = 0.0,
                            Bloqueada = false,
                            FechaVencimiento = new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IngresoPinErroneo = 0,
                            NumeroTarjeta = "1002100210021002",
                            Pin = 1515
                        },
                        new
                        {
                            Id = 3,
                            Balance = 15000.0,
                            Bloqueada = false,
                            FechaVencimiento = new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IngresoPinErroneo = 0,
                            NumeroTarjeta = "1003100310031003",
                            Pin = 1616
                        },
                        new
                        {
                            Id = 4,
                            Balance = 5000.0,
                            Bloqueada = false,
                            FechaVencimiento = new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IngresoPinErroneo = 0,
                            NumeroTarjeta = "1004100410041004",
                            Pin = 1717
                        });
                });

            modelBuilder.Entity("CajeroAppBack.Entidades.Operacion", b =>
                {
                    b.HasOne("CajeroAppBack.Entidades.Tarjeta", "Tarjeta")
                        .WithMany("Operaciones")
                        .HasForeignKey("TarjetaId");

                    b.Navigation("Tarjeta");
                });

            modelBuilder.Entity("CajeroAppBack.Entidades.Tarjeta", b =>
                {
                    b.Navigation("Operaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
