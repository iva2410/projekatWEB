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
    [Migration("20220319123055_V50")]
    partial class V50
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Edukacija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RadnikID")
                        .HasColumnType("int");

                    b.Property<int>("SlobodnaMesta")
                        .HasColumnType("int");

                    b.Property<int?>("salonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RadnikID");

                    b.HasIndex("salonID");

                    b.ToTable("Edukacije");
                });

            modelBuilder.Entity("Models.EdukacijaTermin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EdukacijaID")
                        .HasColumnType("int");

                    b.Property<int?>("TerminID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Vreme")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("EdukacijaID");

                    b.HasIndex("TerminID");

                    b.ToTable("EdukacijaTermini");
                });

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

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

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

            modelBuilder.Entity("Models.SalonTretman", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int?>("SalonID")
                        .HasColumnType("int");

                    b.Property<int?>("TretmanID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SalonID");

                    b.HasIndex("TretmanID");

                    b.ToTable("SaloniTretmani");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Termini");
                });

            modelBuilder.Entity("Models.Tretman", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VremeTrajanja")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Tretmani");
                });

            modelBuilder.Entity("Models.Edukacija", b =>
                {
                    b.HasOne("Models.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikID");

                    b.HasOne("Models.Salon", "salon")
                        .WithMany("Edukacije")
                        .HasForeignKey("salonID");

                    b.Navigation("Radnik");

                    b.Navigation("salon");
                });

            modelBuilder.Entity("Models.EdukacijaTermin", b =>
                {
                    b.HasOne("Models.Edukacija", "Edukacija")
                        .WithMany("termini")
                        .HasForeignKey("EdukacijaID");

                    b.HasOne("Models.Termin", "Termin")
                        .WithMany("Edukacija")
                        .HasForeignKey("TerminID");

                    b.Navigation("Edukacija");

                    b.Navigation("Termin");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.HasOne("Models.Salon", "Salon")
                        .WithMany("Radnici")
                        .HasForeignKey("SalonID");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("Models.SalonTretman", b =>
                {
                    b.HasOne("Models.Salon", "Salon")
                        .WithMany("Tretmani")
                        .HasForeignKey("SalonID");

                    b.HasOne("Models.Tretman", "Tretman")
                        .WithMany("Salon")
                        .HasForeignKey("TretmanID");

                    b.Navigation("Salon");

                    b.Navigation("Tretman");
                });

            modelBuilder.Entity("Models.Edukacija", b =>
                {
                    b.Navigation("termini");
                });

            modelBuilder.Entity("Models.Salon", b =>
                {
                    b.Navigation("Edukacije");

                    b.Navigation("Radnici");

                    b.Navigation("Tretmani");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.Navigation("Edukacija");
                });

            modelBuilder.Entity("Models.Tretman", b =>
                {
                    b.Navigation("Salon");
                });
#pragma warning restore 612, 618
        }
    }
}
