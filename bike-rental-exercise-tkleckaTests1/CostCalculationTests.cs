using bike_rental_exercise_tklecka.Model;
using System;
using Xunit;

namespace bike_rental_exercise_tklecka.Tests
{
    public class CostCalculationTests
    {
        [Fact()]
        public void CalculateTotalCosts_MultiHours()
        {
            Bike b = new Bike { ID = 1, BikeCategory = Bike.BikeCategoryEnum.Mountain, Brand = "KTM", DateService = DateTime.Now, PurchaseDate = DateTime.Now, PriceAddHour = 5, PriceHour = 3 };
            Customer c = new Customer { ID = 1, Birthday = DateTime.Now, FirstName = "Max", LastName = "Mustermann", Gender = Customer.GenderEnum.Male, HouseNumber = "10", Street = "Musterstraße", Town = "Musterstadt", ZIP = 1234 };
            Rental r = new Rental { ID = 1, BikeID = 1, Bike = b, CustomerID = 1, Customer = c, PaidFlag = false, RentalBegin = DateTime.Parse("14/02/2018 08:15:00"), RentalEnd = DateTime.Parse("14/02/2018 10:30:00") };

            CostCalculation cc = new CostCalculation();
            double act = cc.CalculateTotalCosts(r);

            Assert.Equal(13, act);
        }

        [Fact()]
        public void CalculateTotalCosts_FirstHour()
        {
            Bike b = new Bike { ID = 1, BikeCategory = Bike.BikeCategoryEnum.Mountain, Brand = "KTM", DateService = DateTime.Now, PurchaseDate = DateTime.Now, PriceAddHour = 5, PriceHour = 3 };
            Customer c = new Customer { ID = 1, Birthday = DateTime.Now, FirstName = "Max", LastName = "Mustermann", Gender = Customer.GenderEnum.Male, HouseNumber = "10", Street = "Musterstraße", Town = "Musterstadt", ZIP = 1234 };
            Rental r = new Rental { ID = 1, BikeID = 1, Bike = b, CustomerID = 1, Customer = c, PaidFlag = false, RentalBegin = DateTime.Parse("14/02/2018 08:15:00"), RentalEnd = DateTime.Parse("14/02/2018 08:45:00") };

            CostCalculation cc = new CostCalculation();
            double act = cc.CalculateTotalCosts(r);

            Assert.Equal(3, act);
        }

        [Fact()]
        public void CalculateTotalCosts_Free()
        {
            Bike b = new Bike { ID = 1, BikeCategory = Bike.BikeCategoryEnum.Mountain, Brand = "KTM", DateService = DateTime.Now, PurchaseDate = DateTime.Now, PriceAddHour = 5, PriceHour = 3 };
            Customer c = new Customer { ID = 1, Birthday = DateTime.Now, FirstName = "Max", LastName = "Mustermann", Gender = Customer.GenderEnum.Male, HouseNumber = "10", Street = "Musterstraße", Town = "Musterstadt", ZIP = 1234 };
            Rental r = new Rental { ID = 1, BikeID = 1, Bike = b, CustomerID = 1, Customer = c, PaidFlag = false, RentalBegin = DateTime.Parse("14/02/2018 08:15:00"), RentalEnd = DateTime.Parse("14/02/2018 08:20:00") };

            CostCalculation cc = new CostCalculation();
            double act = cc.CalculateTotalCosts(r);

            Assert.Equal(0, act);
        }
    }
}