using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingApp.Models
{
    public class MiejscaParkingowe
    {
        public int id_miejsca { get; set; }
        public int id_parkingu { get; set; }
        public string stan { get; set; } = "";
        public ICollection<Rezerwacje> Rezerwacja { get; set; } = new List<Rezerwacje>();

        public Parkingi Parking { get; set; } = new();
    }
}