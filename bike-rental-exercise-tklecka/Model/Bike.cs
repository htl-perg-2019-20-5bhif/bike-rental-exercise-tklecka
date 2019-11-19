using System;
using System.ComponentModel.DataAnnotations;

namespace bike_rental_exercise_tklecka.Model
{
    public class Bike
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Brand { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PurchaseDate { get; set; }
        [MaxLength(1000)]
        public string Notes { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateService { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0.00, double.MaxValue)]
        public double PriceHour { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(1.00, double.MaxValue)]
        public double PriceAddHour { get; set; }

        public enum BikeCategoryEnum
        {
            Standard,
            Mountain,
            Trecking,
            Racing
        };
        [Required]
        public BikeCategoryEnum BikeCategory { get; set; }
    }
}
