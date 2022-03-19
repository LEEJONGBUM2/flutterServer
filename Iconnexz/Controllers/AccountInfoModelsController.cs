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
    public class AccountInfoModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountInfoModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountInfoModel>>> GetAccountInfo()
        {
            return await _context.AccountInfo.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AccountInfoModel>> GetAccountInfoModel(int id)
        {
            var accountInfoModel = await _context.AccountInfo.FindAsync(id);

            if (accountInfoModel == null)
            {
                return NotFound();
            }

            return accountInfoModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountInfoModel(int id, AccountInfoModel accountInfoModel)
        {
            if (id != accountInfoModel.AccountInfoId)
            {
                return BadRequest();
            }

            _context.Entry(accountInfoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountInfoModelExists(id))
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
        public async Task<ActionResult<AccountInfoModel>> PostAccountInfoModel(AccountInfoModel accountInfoModel)
        {
            _context.AccountInfo.Add(accountInfoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountInfoModel", new { id = accountInfoModel.AccountInfoId }, accountInfoModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountInfoModel>> DeleteAccountInfoModel(int id)
        {
            var accountInfoModel = await _context.AccountInfo.FindAsync(id);
            if (accountInfoModel == null)
            {
                return NotFound();
            }

            _context.AccountInfo.Remove(accountInfoModel);
            await _context.SaveChangesAsync();

            return accountInfoModel;
        }

        private bool AccountInfoModelExists(int id)
        {
            return _context.AccountInfo.Any(e => e.AccountInfoId == id);
        }
    }
}
