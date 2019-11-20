using bike_rental_exercise_tklecka.Data;
using bike_rental_exercise_tklecka.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bike_rental_exercise_tklecka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly BikeDataContext _context;

        public RentalsController(BikeDataContext context)
        {
            _context = context;
        }

        // GET: api/Rentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            return await _context.Rentals.Include(r => r.Bike).Include(r => r.Customer).ToListAsync();
        }

        // GET: api/Rentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        [HttpGet]
        [Route("unpaid", Name = "UnpaidRental")]
        public async Task<ActionResult<IEnumerable<Rental>>> UnpaidRental()
        {
            var rental = await _context.Rentals.Where(r => !r.PaidFlag)
                .Where(r => r.TotalCost > 0)
                .Include(r => r.Customer)
                .ToListAsync();

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        [HttpGet]
        [Route("markpaid/{id}", Name = "MarkPaidRental")]
        public async Task<ActionResult<Rental>> MarkPaidRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);

            if (rental == null)
            {
                return NotFound();
            }
            else
            {
                rental.PaidFlag = true;
                _context.Update(rental);
                await _context.SaveChangesAsync();
            }

            return rental;
        }

        [HttpGet]
        [Route("endrental/{id}", Name = "EndRental")]
        public async Task<ActionResult<Rental>> EndRental(int id)
        {
            var rental = await _context.Rentals.Where(r => r.ID == id).Include(r => r.Bike).FirstAsync();

            if (rental == null)
            {
                return NotFound();
            }
            else if (rental.PaidFlag || !rental.RentalEnd.ToString().Equals("01/01/0001 00:00:00"))
            {
                return BadRequest();
            }
            else
            {
                CostCalculation cc = new CostCalculation();
                rental.RentalEnd = DateTime.Now;
                rental.TotalCost = cc.CalculateTotalCosts(rental);
                _context.Update(rental);
                await _context.SaveChangesAsync();
            }

            return rental;
        }

        // PUT: api/Rentals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRental(int id, Rental rental)
        {
            if (id != rental.ID)
            {
                return BadRequest();
            }

            _context.Entry(rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rentals/startrental
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Rental>> PostRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRental", new { id = rental.ID }, rental);
        }

        [HttpPost]
        [Route("startrental", Name = "StartRental")]
        public async Task<ActionResult<Rental>> StartRental(Rental rental)
        {
            if (!rental.PaidFlag && rental.RentalEnd.ToString().Equals("01/01/0001 00:00:00") && rental.TotalCost == 0)
            {
                _context.Rentals.Add(rental);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetRental", new { id = rental.ID }, rental);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Rentals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rental>> DeleteRental(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();

            return rental;
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.ID == id);
        }
    }
}
