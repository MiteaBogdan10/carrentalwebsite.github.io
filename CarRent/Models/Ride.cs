using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Ride
    {
        [Key]
        public int RideID { get; set; }

        public int CarsID { get; set; }
        public Cars? Car { get; set; }

        public int ReservationID { get; set; }
        public Reservation? Reservation { get; set; }

    }
}
