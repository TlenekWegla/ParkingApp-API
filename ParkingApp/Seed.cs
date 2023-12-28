
using ParkingApp.Kontekst_Danych;
using ParkingApp.Models;

namespace ParkingApp
{
    public class Seed
    {
        private readonly KontekstDanych _dbContext;

        public Seed(KontekstDanych dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void SeedDataContext()
        {
            if (!_dbContext.Uzytkownicy.Any() || _dbContext.Parking.Any())
            {
                var users = new List<Uzytkownicy>
                {
                    new Uzytkownicy
                    {
                        imie = "Daniel",
                        nazwisko = "Kowalski",
                        email = "jan.kowalski@example.com",
                        haslo = "haslo123",
                        nr_telefonu = "123456789",
                        adres = "ul. Kwiatowa 1, 00-001 Warszawa",
                        czy_gosc = false,
                        Postoj = new List<Postoje>
                        {
                            new Postoje
                            {
                                id_miejsca_parkingowego = 1,
                                data_rozpoczecia = DateTime.Now.AddHours(-2),
                                data_zakonczenia = DateTime.Now.AddHours(-1)
                            }
                        },
                        Pojazd = new List<Pojazdy>
                        {
                            new Pojazdy
                            {
                                numer_rejestracyjny = "ABC123",
                                marka = "Toyota",
                                model = "Corolla",
                                waga = 1500
                            },
                             new Pojazdy
                            {
                                numer_rejestracyjny = "TE23ST",
                                marka = "KIA",
                                model = "Stonic",
                                waga = 1800
                            }
                        },
                        Rezerwacja = new List<Rezerwacje>
                        {
                            new Rezerwacje
                            {
                                id_pojazdu = 1,
                                id_miejsca = 1,
                                data_rozpoczęcia = DateTime.Now.AddDays(1),
                                data_zakończenia = DateTime.Now.AddDays(2),
                                status = "Aktywna"
                            }
                        }
                    }
                };

                _dbContext.Uzytkownicy.AddRange(users);
                _dbContext.SaveChanges();

                var parking = new List<Parkingi>
                {
                    new Parkingi
                    {
                        adres = "ul. Parkowa 3, 00-003 Warszawa",
                        liczba_miejsc = 100,
                        liczba_pięter = 2,
                        MiejsceParkingowe = new List<MiejscaParkingowe>
                        {
                            new MiejscaParkingowe
                            {
                                stan = "Wolne"
                            },
                            new MiejscaParkingowe
                            {
                                stan = "Zajęte"
                            }
                        }
                    }
                };

                _dbContext.Parking.AddRange(parking);
                _dbContext.SaveChanges();
            }
        }
    }
}