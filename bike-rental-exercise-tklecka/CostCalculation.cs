using bike_rental_exercise_tklecka.Model;
using System;

namespace bike_rental_exercise_tklecka
{
    public class CostCalculation
    {
        public double CalculateTotalCosts(Rental rental)
        {
            var duration = rental.RentalEnd - rental.RentalBegin;
            double totalCost = 0;
            if (duration.TotalMinutes <= 15)
            {
                return totalCost;
            }
            totalCost += rental.Bike.PriceHour;
            var additionalHours = duration.TotalHours - 1;
            if (additionalHours > 0)
            {
                totalCost += (int)(Math.Ceiling(additionalHours)) * rental.Bike.PriceAddHour;
            }
            return totalCost;
        }
    }
}
