namespace ParkingApp.Models
{
    public class MiejscaParkingowe
    {
        public MiejscaParkingowe() {
            stan = "";
            Rezerwacja = new List<Rezerwacje>();
            Parking = new Parkingi();
        
        }
        public int id_miejsca { get; set; }
        public int id_parkingu { get; set; }
        public string stan { get; set; }
        public ICollection<Rezerwacje> Rezerwacja  { get; set; }
        public Parkingi Parking { get; set; }

    }
}
