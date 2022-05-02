using Microsoft.EntityFrameworkCore;

namespace CarRent.Models
    {
        public class RentingContext : DbContext
        {
            public RentingContext(DbContextOptions<RentingContext> options)
                : base(options)
            { }

            public DbSet<Cars>? Car { get; set; }
            public DbSet<Ride>? Rides { get; set; }
            public DbSet<Payment>? Payments { get; set; }
            public DbSet<Reservation>? Reservation { get; set; }
            public DbSet<Reviews>? Review { get; set; }
    }
 }
