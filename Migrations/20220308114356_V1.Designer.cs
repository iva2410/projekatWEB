﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace webprojekat.Migrations
{
    [DbContext(typeof(SalonContext))]
    [Migration("20220308114356_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GodineRada")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Plata")
                        .HasColumnType("int");

                    b.Property<string>("Pol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SalonID");

                    b.ToTable("Radnici");
                });

            modelBuilder.Entity("Models.Salon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Saloni");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Vreme")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Termini");
                });

            modelBuilder.Entity("Models.TerminSalon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.Property<int?>("TerminID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SalonID");

                    b.HasIndex("TerminID");

                    b.ToTable("TerminSaloni");
                });

            modelBuilder.Entity("Models.Tretman", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SaloniID")
                        .HasColumnType("int");

                    b.Property<int>("VremeTrajanja")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SaloniID");

                    b.ToTable("Tretmani");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.HasOne("Models.Salon", "Salon")
                        .WithMany("Radnici")
                        .HasForeignKey("SalonID");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Models.TerminSalon", b =>
                {
                    b.HasOne("Models.Salon", "Salon")
                        .WithMany("Termini")
                        .HasForeignKey("SalonID");

                    b.HasOne("Models.Termin", "Termin")
                        .WithMany("Salon")
                        .HasForeignKey("TerminID");

                    b.Navigation("Salon");

                    b.Navigation("Termin");
                });

            modelBuilder.Entity("Models.Tretman", b =>
                {
                    b.HasOne("Models.Salon", "Saloni")
                        .WithMany("Tretmani")
                        .HasForeignKey("SaloniID");

                    b.Navigation("Saloni");
                });

            modelBuilder.Entity("Models.Salon", b =>
                {
                    b.Navigation("Radnici");

                    b.Navigation("Termini");

                    b.Navigation("Tretmani");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.Navigation("Salon");
                });
#pragma warning restore 612, 618
        }
    }
}