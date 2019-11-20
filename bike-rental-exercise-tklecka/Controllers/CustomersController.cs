﻿using bike_rental_exercise_tklecka.Data;
using bike_rental_exercise_tklecka.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bike_rental_exercise_tklecka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly BikeDataContext _context;

        public CustomersController(BikeDataContext context)
        {
            _context = context;
        }

        //api/Customers/lastname?lastname=mu
        [HttpGet]
        [Route("lastname", Name = "GetCustomersLastname")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersLastname([FromQuery] string lastname)
        {
            return await _context.Customers.Where(c => c.LastName.ToLower().Contains(lastname.ToLower())).ToListAsync();
        }

        //api/Customers/rentals/1
        [HttpGet]
        [Route("rentals/{id}", Name = "GetCustomerRentals")]
        public async Task<ActionResult<IEnumerable<Rental>>> GetCustomerRentals(int id)
        {
            return await _context.Rentals.Where(r => r.CustomerID == id).Include(r => r.Bike).ToListAsync();
        }

        // GET: api/Customers/getbyid/5
        /*[HttpGet("getbyid/{id}")]
        [Route("getbyid/{id}", Name = "GetCustomer")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        */
        // PUT: api/Customers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.ID)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.ID }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
