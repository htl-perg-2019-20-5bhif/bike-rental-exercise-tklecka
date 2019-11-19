using System;
using System.ComponentModel.DataAnnotations;

namespace bike_rental_exercise_tklecka.Model
{
    public class Customer
    {
        public enum GenderEnum { Male, Female, Unknown };

        public int ID { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }
        [Required]
        [MaxLength(75)]
        public string Street { get; set; }
        [MaxLength(10)]
        public string HouseNumber { get; set; }
        [Required]
        [MaxLength(10)]
        public int ZIP { get; set; }
        [Required]
        [MaxLength(75)]
        public string Town { get; set; }

    }
}
