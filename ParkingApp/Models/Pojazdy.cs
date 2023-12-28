using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingApp.Models
{
    public class Pojazdy
    {
        public int id_pojazdu { get; set; }
        public string numer_rejestracyjny { get; set; } = "";
        public string marka { get; set; } = "";
        public string model { get; set; } = "";
        public int waga { get; set; }
        public int id_użytkownika { get; set; }

        [NotMapped] public Uzytkownicy Uzytkownik { get; set; } = new();
    }
}