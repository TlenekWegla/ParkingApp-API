﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingApp.Kontekst_Danych;

#nullable disable

namespace ParkingApp.Migrations
{
    [DbContext(typeof(KontekstDanych))]
    partial class KontekstDanychModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkingApp.Models.MiejscaParkingowe", b =>
                {
                    b.Property<int>("id_miejsca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_miejsca"));

                    b.Property<int?>("Parkingiid_parkingu")
                        .HasColumnType("int");

                    b.Property<int>("id_parkingu")
                        .HasColumnType("int");

                    b.Property<string>("stan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_miejsca");

                    b.HasIndex("Parkingiid_parkingu");

                    b.ToTable("MiejsceParkingowe");
                });

            modelBuilder.Entity("ParkingApp.Models.Parkingi", b =>
                {
                    b.Property<int>("id_parkingu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_parkingu"));

                    b.Property<string>("adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("liczba_miejsc")
                        .HasColumnType("int");

                    b.Property<int>("liczba_pięter")
                        .HasColumnType("int");

                    b.HasKey("id_parkingu");

                    b.ToTable("Parking");
                });

            modelBuilder.Entity("ParkingApp.Models.Pojazdy", b =>
                {
                    b.Property<int>("id_pojazdu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_pojazdu"));

                    b.Property<int?>("Uzytkownicyid_uzytkownika")
                        .HasColumnType("int");

                    b.Property<int>("id_użytkownika")
                        .HasColumnType("int");

                    b.Property<string>("marka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numer_rejestracyjny")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("waga")
                        .HasColumnType("int");

                    b.HasKey("id_pojazdu");

                    b.HasIndex("Uzytkownicyid_uzytkownika");

                    b.ToTable("Pojazd");
                });

            modelBuilder.Entity("ParkingApp.Models.Postoje", b =>
                {
                    b.Property<int>("id_postoju")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_postoju"));

                    b.Property<int?>("Uzytkownicyid_uzytkownika")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_rozpoczecia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_zakonczenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_miejsca_parkingowego")
                        .HasColumnType("int");

                    b.Property<int>("id_uzytkownika")
                        .HasColumnType("int");

                    b.HasKey("id_postoju");

                    b.HasIndex("Uzytkownicyid_uzytkownika");

                    b.ToTable("Postoj");
                });

            modelBuilder.Entity("ParkingApp.Models.Rezerwacje", b =>
                {
                    b.Property<int>("id_rezerwacji")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_rezerwacji"));

                    b.Property<int?>("MiejscaParkingoweid_miejsca")
                        .HasColumnType("int");

                    b.Property<int?>("Uzytkownicyid_uzytkownika")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_rozpoczęcia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("data_zakończenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("id_miejsca")
                        .HasColumnType("int");

                    b.Property<int>("id_pojazdu")
                        .HasColumnType("int");

                    b.Property<int>("id_uzytkownika")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_rezerwacji");

                    b.HasIndex("MiejscaParkingoweid_miejsca");

                    b.HasIndex("Uzytkownicyid_uzytkownika");

                    b.ToTable("Rezerwacja");
                });

            modelBuilder.Entity("ParkingApp.Models.Uzytkownicy", b =>
                {
                    b.Property<int>("id_uzytkownika")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_uzytkownika"));

                    b.Property<string>("adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("czy_gosc")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("haslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nr_telefonu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_uzytkownika");

                    b.ToTable("Uzytkownicy");
                });

            modelBuilder.Entity("ParkingApp.Models.MiejscaParkingowe", b =>
                {
                    b.HasOne("ParkingApp.Models.Parkingi", null)
                        .WithMany("MiejsceParkingowe")
                        .HasForeignKey("Parkingiid_parkingu");
                });

            modelBuilder.Entity("ParkingApp.Models.Pojazdy", b =>
                {
                    b.HasOne("ParkingApp.Models.Uzytkownicy", null)
                        .WithMany("Pojazd")
                        .HasForeignKey("Uzytkownicyid_uzytkownika");
                });

            modelBuilder.Entity("ParkingApp.Models.Postoje", b =>
                {
                    b.HasOne("ParkingApp.Models.Uzytkownicy", null)
                        .WithMany("Postoj")
                        .HasForeignKey("Uzytkownicyid_uzytkownika");
                });

            modelBuilder.Entity("ParkingApp.Models.Rezerwacje", b =>
                {
                    b.HasOne("ParkingApp.Models.MiejscaParkingowe", null)
                        .WithMany("Rezerwacja")
                        .HasForeignKey("MiejscaParkingoweid_miejsca");

                    b.HasOne("ParkingApp.Models.Uzytkownicy", null)
                        .WithMany("Rezerwacja")
                        .HasForeignKey("Uzytkownicyid_uzytkownika");
                });

            modelBuilder.Entity("ParkingApp.Models.MiejscaParkingowe", b =>
                {
                    b.Navigation("Rezerwacja");
                });

            modelBuilder.Entity("ParkingApp.Models.Parkingi", b =>
                {
                    b.Navigation("MiejsceParkingowe");
                });

            modelBuilder.Entity("ParkingApp.Models.Uzytkownicy", b =>
                {
                    b.Navigation("Pojazd");

                    b.Navigation("Postoj");

                    b.Navigation("Rezerwacja");
                });
#pragma warning restore 612, 618
        }
    }
}
