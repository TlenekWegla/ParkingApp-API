using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingApp.Models
{
    public class Postoje
    {
        public int id_postoju { get; set; }
        public int id_miejsca { get; set; }
        public DateTime data_zakonczenia { get; set; }
        public DateTime data_rozpoczecia { get; set; }
        public int id_uzytkownika { get; set; }

        public Uzytkownicy Uzytkownik { get; set; } = new();
    }
}