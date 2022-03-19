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
    public class WalletModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WalletModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<WalletModel>>> GetWallet()
        {
            return await _context.Wallet.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<WalletModel>> GetWalletModel(int id)
        {
            var walletModel = await _context.Wallet.FindAsync(id);

            if (walletModel == null)
            {
                return NotFound();
            }

            return walletModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutWalletModel(int id, WalletModel walletModel)
        {
            if (id != walletModel.WalletId)
            {
                return BadRequest();
            }

            _context.Entry(walletModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WalletModelExists(id))
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
        public async Task<ActionResult<WalletModel>> PostWalletModel(WalletModel walletModel)
        {
            _context.Wallet.Add(walletModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWalletModel", new { id = walletModel.WalletId }, walletModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<WalletModel>> DeleteWalletModel(int id)
        {
            var walletModel = await _context.Wallet.FindAsync(id);
            if (walletModel == null)
            {
                return NotFound();
            }

            _context.Wallet.Remove(walletModel);
            await _context.SaveChangesAsync();

            return walletModel;
        }

        private bool WalletModelExists(int id)
        {
            return _context.Wallet.Any(e => e.WalletId == id);
        }
    }
}
