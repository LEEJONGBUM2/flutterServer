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
    public class BankInformationModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BankInformationModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankInformationModel>>> GetBankInformation()
        {
            return await _context.BankInformation.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BankInformationModel>> GetBankInformationModel(int id)
        {
            var bankInformationModel = await _context.BankInformation.FindAsync(id);

            if (bankInformationModel == null)
            {
                return NotFound();
            }

            return bankInformationModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankInformationModel(int id, BankInformationModel bankInformationModel)
        {
            if (id != bankInformationModel.BankInformationId)
            {
                return BadRequest();
            }

            _context.Entry(bankInformationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankInformationModelExists(id))
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
        public async Task<ActionResult<BankInformationModel>> PostBankInformationModel(BankInformationModel bankInformationModel)
        {
            _context.BankInformation.Add(bankInformationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBankInformationModel", new { id = bankInformationModel.BankInformationId }, bankInformationModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<BankInformationModel>> DeleteBankInformationModel(int id)
        {
            var bankInformationModel = await _context.BankInformation.FindAsync(id);
            if (bankInformationModel == null)
            {
                return NotFound();
            }

            _context.BankInformation.Remove(bankInformationModel);
            await _context.SaveChangesAsync();

            return bankInformationModel;
        }

        private bool BankInformationModelExists(int id)
        {
            return _context.BankInformation.Any(e => e.BankInformationId == id);
        }
    }
}
