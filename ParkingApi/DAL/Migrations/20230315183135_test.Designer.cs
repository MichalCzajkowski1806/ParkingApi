﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230315183135_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entity.Miasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Wojewodztwo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Miasto");
                });

            modelBuilder.Entity("DAL.Entity.Miejsce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Inwalidzkie")
                        .HasColumnType("bit");

                    b.Property<int?>("MiejsceInwalidzkieId")
                        .HasColumnType("int");

                    b.Property<int>("ParkingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MiejsceInwalidzkieId");

                    b.HasIndex("ParkingId");

                    b.ToTable("Miejsce");
                });

            modelBuilder.Entity("DAL.Entity.MiejsceInwalidzkie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdMiejsca")
                        .HasColumnType("int");

                    b.Property<int>("Miejsce")
                        .HasColumnType("int");

                    b.Property<decimal>("RozmiarMiejsca")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Miejsce")
                        .IsUnique();

                    b.ToTable("MiejsceInwalidzkie");
                });

            modelBuilder.Entity("DAL.Entity.Opiekun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Opiekun");
                });

            modelBuilder.Entity("DAL.Entity.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IdMiasta")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdMiasta");

                    b.ToTable("Parking");
                });

            modelBuilder.Entity("DAL.Entity.Rezerwacja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Do")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMiejsca")
                        .HasColumnType("int");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Od")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdMiejsca");

                    b.ToTable("Rezerwacja");
                });

            modelBuilder.Entity("OpiekunParking", b =>
                {
                    b.Property<int>("OpiekunowieId")
                        .HasColumnType("int");

                    b.Property<int>("ParkingiId")
                        .HasColumnType("int");

                    b.HasKey("OpiekunowieId", "ParkingiId");

                    b.HasIndex("ParkingiId");

                    b.ToTable("OpiekunParking");
                });

            modelBuilder.Entity("DAL.Entity.Miejsce", b =>
                {
                    b.HasOne("DAL.Entity.MiejsceInwalidzkie", "MiejsceInwalidzkie")
                        .WithMany()
                        .HasForeignKey("MiejsceInwalidzkieId");

                    b.HasOne("DAL.Entity.Parking", "parking")
                        .WithMany("Miejsca")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MiejsceInwalidzkie");

                    b.Navigation("parking");
                });

            modelBuilder.Entity("DAL.Entity.MiejsceInwalidzkie", b =>
                {
                    b.HasOne("DAL.Entity.Miejsce", "miejsce")
                        .WithOne()
                        .HasForeignKey("DAL.Entity.MiejsceInwalidzkie", "Miejsce")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("miejsce");
                });

            modelBuilder.Entity("DAL.Entity.Parking", b =>
                {
                    b.HasOne("DAL.Entity.Miasto", "Miasto")
                        .WithMany("Parkingi")
                        .HasForeignKey("IdMiasta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Miasto");
                });

            modelBuilder.Entity("DAL.Entity.Rezerwacja", b =>
                {
                    b.HasOne("DAL.Entity.Miejsce", "miejsce")
                        .WithMany("Rezerwacje")
                        .HasForeignKey("IdMiejsca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("miejsce");
                });

            modelBuilder.Entity("OpiekunParking", b =>
                {
                    b.HasOne("DAL.Entity.Opiekun", null)
                        .WithMany()
                        .HasForeignKey("OpiekunowieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entity.Parking", null)
                        .WithMany()
                        .HasForeignKey("ParkingiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entity.Miasto", b =>
                {
                    b.Navigation("Parkingi");
                });

            modelBuilder.Entity("DAL.Entity.Miejsce", b =>
                {
                    b.Navigation("Rezerwacje");
                });

            modelBuilder.Entity("DAL.Entity.Parking", b =>
                {
                    b.Navigation("Miejsca");
                });
#pragma warning restore 612, 618
        }
    }
}
