using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Iconnexz.Models;
using Iconnexz.Authentication;

namespace Iconnexz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionsModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionsModel>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionsModel>> GetTransactionsModel(int id)
        {
            var transactionsModel = await _context.Transactions.FindAsync(id);

            if (transactionsModel == null)
            {
                return NotFound();
            }

            return transactionsModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionsModel(int id, TransactionsModel transactionsModel)
        {
            if (id != transactionsModel.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transactionsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionsModelExists(id))
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


        [HttpPost]
        public async Task<ActionResult<TransactionsModel>> PostTransactionsModel(TransactionsModel transactionsModel)
        {
            _context.Transactions.Add(transactionsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionsModel", new { id = transactionsModel.TransactionId }, transactionsModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<TransactionsModel>> DeleteTransactionsModel(int id)
        {
            var transactionsModel = await _context.Transactions.FindAsync(id);
            if (transactionsModel == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transactionsModel);
            await _context.SaveChangesAsync();

            return transactionsModel;
        }

        private bool TransactionsModelExists(int id)
        {
            return _context.Transactions.Any(e => e.TransactionId == id);
        }
    }
}
