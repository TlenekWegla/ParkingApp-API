namespace ParkingApp.Models
{
    public class Pojazdy

    {

        public Pojazdy()
        {
            // Inicjalizacja właściwości w konstruktorze
            numer_rejestracyjny = "";
            marka = "";
            model = "";
            Uzytkownik = new Uzytkownicy();
        }
        public int id_pojazdu { get; set; }
        public string numer_rejestracyjny { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public int waga { get; set; }
        public int id_użytkownika { get; set; }

        public Uzytkownicy Uzytkownik { get; set; }

    }
}
