using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Cars
    {
        [Key]
        public int CarsID { get; set; }

        public string? Name_Car { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        

        
        public ICollection<Ride>? Rides { get; set; }
        public ICollection<Reviews>? Review { get; set; }
        
    }
}
