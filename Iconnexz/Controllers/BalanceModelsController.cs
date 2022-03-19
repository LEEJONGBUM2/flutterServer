using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Iconnexz.Models;
using Iconnexz.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Iconnexz.Controllers
{/*
    [Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BalanceModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BalanceModel>>> GetBalance()
        {
            return await _context.Balance.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BalanceModel>> GetBalanceModel(int id)
        {
            var balanceModel = await _context.Balance.FindAsync(id);

            if (balanceModel == null)
            {
                return NotFound();
            }

            return balanceModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBalanceModel(int id, BalanceModel balanceModel)
        {
            if (id != balanceModel.BalanceId)
            {
                return BadRequest();
            }

            _context.Entry(balanceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalanceModelExists(id))
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
        public async Task<ActionResult<BalanceModel>> PostBalanceModel(BalanceModel balanceModel)
        {
            _context.Balance.Add(balanceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBalanceModel", new { id = balanceModel.BalanceId }, balanceModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<BalanceModel>> DeleteBalanceModel(int id)
        {
            var balanceModel = await _context.Balance.FindAsync(id);
            if (balanceModel == null)
            {
                return NotFound();
            }

            _context.Balance.Remove(balanceModel);
            await _context.SaveChangesAsync();

            return balanceModel;
        }

        private bool BalanceModelExists(int id)
        {
            return _context.Balance.Any(e => e.BalanceId == id);
        }
    }
}
