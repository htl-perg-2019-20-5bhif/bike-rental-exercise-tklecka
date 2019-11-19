using System;
using System.ComponentModel.DataAnnotations;

namespace bike_rental_exercise_tklecka.Model
{
    public class Rental
    {
        public int ID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int BikeID { get; set; }
        public Bike Bike { get; set; }
        [Required]
        public DateTime RentalBegin { get; set; }
        public DateTime RentalEnd { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0.00, double.MaxValue)]
        public double TotalCost { get; set; }
        [Required]
        public bool PaidFlag { get; set; }
    }
}
