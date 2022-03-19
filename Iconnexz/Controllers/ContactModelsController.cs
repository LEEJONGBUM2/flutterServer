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
    public class ContactModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactModel>>> GetContact()
        {
            return await _context.Contact.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ContactModel>> GetContact(int id)
        {
            var contactModel = await _context.Contact.FindAsync(id);

            if (contactModel == null)
            {
                return NotFound();
            }

            return contactModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactModel(int id, ContactModel contactModel)
        {
            if (id != contactModel.ContactId)
            {
                return BadRequest();
            }

            _context.Entry(contactModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactModelExists(id))
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
        public async Task<ActionResult<ContactModel>> PostContactModel(ContactModel ContactModel)
        {
            _context.Contact.Add(ContactModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactModel", new { id = ContactModel.ContactId }, ContactModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactModel>> DeleteContactModel(int id)
        {
            var contactModel = await _context.Contact.FindAsync(id);
            if (contactModel == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(contactModel);
            await _context.SaveChangesAsync();

            return contactModel;
        }

        private bool ContactModelExists(int id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }
    }
}
