using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ESBookshopContext _context;

        public PaymentsController(ESBookshopContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        [Route("DetailsPaiement/{id}")]
        public async Task<ActionResult<Payment>> GetPaymentDetails(int id)
        {
            Payment payment = null;

            string userIdCurrentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userIdOrder = (from pay in _context.Payments
                                  where pay.IdOrder == id
                                  select pay.UserId).FirstOrDefault();

            if (userIdOrder == userIdCurrentUser)
            {
                payment =
                (from i in _context.Payments
                 where i.IdOrder == id
                 select new Payment()
                 {
                     Id = i.Id,
                     User = (from user in _context.AspNetUsers
                             where user.Id == i.UserId
                             select user).FirstOrDefault(),
                     IdOrderNavigation = (from order in _context.Orders
                                          where order.Id == i.IdOrder
                                          select order).FirstOrDefault(),
                     PaidDate = i.PaidDate,
                     PriceTotal = i.PriceTotal,
                     Details = i.Details
                 }).FirstOrDefault();
            }

            return payment;
        }

        [Route("DetailsPaiementPdf/{id}")]
        public async Task<ActionResult<Payment>> GetPaymentDetailsPdf(int id)
        {
            Payment payment = null;

            string userIdCurrentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userIdOrder = (from pay in _context.Payments
                                  where pay.Id == id
                                  select pay.UserId).FirstOrDefault();

            if (userIdOrder == userIdCurrentUser)
            {
                payment =
                (from i in _context.Payments
                 where i.Id == id
                 select new Payment()
                 {
                     Id = i.Id,
                     User = (from user in _context.AspNetUsers
                             where user.Id == i.UserId
                             select user).FirstOrDefault(),
                     IdOrderNavigation = (from order in _context.Orders
                                          where order.Id == i.IdOrder
                                          select order).FirstOrDefault(),
                     PaidDate = i.PaidDate,
                     PriceTotal = i.PriceTotal,
                     Details = i.Details
                 }).FirstOrDefault();
            }

            return payment;
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return payment;
            //return CreatedAtAction("GetPayment", new { id = payment.Id }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Payment>> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
