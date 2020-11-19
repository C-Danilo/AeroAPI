﻿// <auto-generated />
using System;
using AeroportoAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AeroportoAPI.Migrations
{
    [DbContext(typeof(ReservaContext))]
    partial class ReservaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AeroportoAPI.Model.Local", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("AeroportoAPI.Model.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Documento")
                        .HasColumnType("longtext");

                    b.Property<int>("Poltrona")
                        .HasColumnType("int");

                    b.Property<int>("VooId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VooId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("AeroportoAPI.Model.Voo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LimitePassageiros")
                        .HasColumnType("int");

                    b.Property<int>("LocalDestinoId")
                        .HasColumnType("int");

                    b.Property<int>("LocalOrigemId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroParadas")
                        .HasColumnType("int");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<TimeSpan>("TempoIda")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("TempoVolta")
                        .HasColumnType("time(6)");

                    b.Property<DateTime>("dataIda")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dataVolta")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("LocalDestinoId");

                    b.HasIndex("LocalOrigemId");

                    b.ToTable("Voos");
                });

            modelBuilder.Entity("AeroportoAPI.Model.Reserva", b =>
                {
                    b.HasOne("AeroportoAPI.Model.Voo", "Voo")
                        .WithMany()
                        .HasForeignKey("VooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AeroportoAPI.Model.Voo", b =>
                {
                    b.HasOne("AeroportoAPI.Model.Local", "LocalDestino")
                        .WithMany()
                        .HasForeignKey("LocalDestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AeroportoAPI.Model.Local", "LocalOrigem")
                        .WithMany()
                        .HasForeignKey("LocalOrigemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
