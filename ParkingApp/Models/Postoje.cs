namespace ParkingApp.Models
{
    public class Postoje
    {
        public Postoje() { 
        Uzytkownik = new Uzytkownicy();
        
        }

        public int id_postoju { get; set; }
        public int id_miejsca_parkingowego { get; set; }
        public DateTime data_zakończenia { get; set; }
        public DateTime data_rozpoczęcia { get; set; }
        public int id_użytkownika { get; set; }

        public Uzytkownicy Uzytkownik { get; set; }
    }
}
