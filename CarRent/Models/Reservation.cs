using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        public string? Location { get; set; }
        public DateTime Pick_Up_Date { get; set; } 
        public DateTime Return_Date { get; set; }

        
        public ICollection<Ride>? Rides { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
