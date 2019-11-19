using bike_rental_exercise_tklecka.Model;
using Microsoft.EntityFrameworkCore;

namespace bike_rental_exercise_tklecka.Data
{
    public class BikeDataContext : DbContext
    {
        public BikeDataContext(DbContextOptions<BikeDataContext> options) : base(options) { }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}
