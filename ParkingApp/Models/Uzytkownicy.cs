namespace ParkingApp.Models
{
    public class Uzytkownicy
    {
        /*
        public Uzytkownicy()
        {

            imie = "";
            nazwisko = "";
            email = "";
            haslo = "";
            nr_telefonu = "";
            adres = "";

            Postoj = new List<Postoje>();
            Pojazd = new List<Pojazdy>();
            Rezerwacja = new List<Rezerwacje>();
        }*/

        public int id_uzytkownika { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public string nr_telefonu { get; set; }
        public string adres { get; set; }
        public bool czy_gosc { get; set; }

        public ICollection<Postoje> Postoj { get; set; }
        public ICollection<Pojazdy> Pojazd { get; set; }
        public ICollection<Rezerwacje> Rezerwacja { get; set; }


    }
}