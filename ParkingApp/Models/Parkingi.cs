    
namespace ParkingApp.Models
   
{
    public class Parkingi
    {
        
        public int id_parkingu { get; set; }
        public string adres { get; set; } = "";
        public int liczba_miejsc { get; set; }
        public int liczba_pięter { get; set; }

        public ICollection<MiejscaParkingowe> MiejsceParkingowe { get; set; } = new List<MiejscaParkingowe>();
   
    }
}