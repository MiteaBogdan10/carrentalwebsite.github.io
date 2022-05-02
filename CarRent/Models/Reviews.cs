using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewsID { get; set; }

        public int Nota { get; set; }
        public string? Comentariu { get; set; }

        public int CarsID { get; set; }
        public Cars? Car { get; set; }
    }
}
