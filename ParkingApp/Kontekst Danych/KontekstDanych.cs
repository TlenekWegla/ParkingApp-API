using Microsoft.EntityFrameworkCore;
using ParkingApp.Models;

namespace ParkingApp.Kontekst_Danych;

public class KontekstDanych : DbContext
{
    public KontekstDanych(DbContextOptions<KontekstDanych> options) : base(options)
    {
    }

    public DbSet<MiejscaParkingowe> MiejsceParkingowe { get; set; }
    public DbSet<Parkingi> Parking { get; set; }
    public DbSet<Pojazdy> Pojazd { get; set; }
    public DbSet<Postoje> Postoj { get; set; }
    public DbSet<Rezerwacje> Rezerwacja { get; set; }
    public DbSet<Uzytkownicy> Uzytkownicy { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Klucz główny dla MiejscaParkingowe
        modelBuilder.Entity<MiejscaParkingowe>()
            .HasKey(m => m.id_miejsca);

        // Klucz główny dla Parkingi
        modelBuilder.Entity<Parkingi>()
            .HasKey(p => p.id_parkingu);

        // Klucz główny dla Pojazdy
        modelBuilder.Entity<Pojazdy>()
            .HasKey(p => p.id_pojazdu);

        // Klucz główny dla Postoje
        modelBuilder.Entity<Postoje>()
            .HasKey(p => p.id_postoju);

        // Klucz główny dla Rezerwacje
        modelBuilder.Entity<Rezerwacje>()
            .HasKey(r => r.id_rezerwacji);

        // Klucz główny dla Uzytkownicy
        modelBuilder.Entity<Uzytkownicy>()
            .HasKey(u => u.id_uzytkownika);

    



        // Klucz obcy dla Postoje

        modelBuilder.Entity<Postoje>()
           .HasOne(m => m.Uzytkownik)
           .WithMany(p => p.Postoj)
           .HasForeignKey(m => m.id_uzytkownika)
           .OnDelete(DeleteBehavior.Restrict);

        // Klucz obcy dla Pojazd

        modelBuilder.Entity<Pojazdy>()
          .HasOne(m => m.Uzytkownik)
          .WithMany(p => p.Pojazd)
          .HasForeignKey(m => m.id_uzytkownika)
          .OnDelete(DeleteBehavior.Restrict);

        // Klucz obcy dla rezerwacje

        modelBuilder.Entity<Rezerwacje>()
            .HasOne(m => m.Uzytkownik)
            .WithMany(p => p.Rezerwacja)
            .HasForeignKey(m => m.id_uzytkownika)
            .OnDelete(DeleteBehavior.Restrict);

        // Klucz obcy dla MiejscaParkingowe


        modelBuilder.Entity<MiejscaParkingowe>()
            .HasOne(m => m.Parking)
            .WithMany(p => p.MiejsceParkingowe)
            .HasForeignKey(m => m.id_parkingu)
            .OnDelete(DeleteBehavior.Restrict);


        // Na koniec wywołujemy metodę bazową
        base.OnModelCreating(modelBuilder);
    }
}