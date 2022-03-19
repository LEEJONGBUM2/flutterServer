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
    public class ContactQModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactQModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactQModel>>> GetContactQ()
        {
            return await _context.ContactQ.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ContactQModel>> GetContactQ(int id)
        {
            var contactQModel = await _context.ContactQ.FindAsync(id);

            if (contactQModel == null)
            {
                return NotFound();
            }

            return contactQModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactQModel(int id, ContactQModel contactQModel)
        {
            if (id != contactQModel.ContactQId)
            {
                return BadRequest();
            }

            _context.Entry(contactQModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactQModelExists(id))
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
        public async Task<ActionResult<ContactQModel>> PostContactQModel(ContactQModel ContactQModel)
        {
            _context.ContactQ.Add(ContactQModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactQModel", new { id = ContactQModel.ContactQId }, ContactQModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactQModel>> DeleteContactQModel(int id)
        {
            var contactQModel = await _context.ContactQ.FindAsync(id);
            if (contactQModel == null)
            {
                return NotFound();
            }

            _context.ContactQ.Remove(contactQModel);
            await _context.SaveChangesAsync();

            return contactQModel;
        }

        private bool ContactQModelExists(int id)
        {
            return _context.ContactQ.Any(e => e.ContactQId == id);
        }
    }
}
