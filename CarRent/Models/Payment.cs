using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public string? Type { get; set; }

        

        public int ReservationID { get; set; }
        public Reservation? Reservation { get; set; }
    }
}
