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
    public class VendorRegModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorRegModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorRegModel>>> GetVendorReg()
        {
            return await _context.VendorReg.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<VendorRegModel>> GetVendorRegModel(int id)
        {
            var vendorRegModel = await _context.VendorReg.FindAsync(id);

            if (vendorRegModel == null)
            {
                return NotFound();
            }

            return vendorRegModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorRegModel(int id, VendorRegModel vendorRegModel)
        {
            if (id != vendorRegModel.VendorRegId)
            {
                return BadRequest();
            }

            _context.Entry(vendorRegModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorRegModelExists(id))
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
        public async Task<ActionResult<VendorRegModel>> PostVendorRegModel(VendorRegModel vendorRegModel)
        {
            _context.VendorReg.Add(vendorRegModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendorRegModel", new { id = vendorRegModel.VendorRegId }, vendorRegModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<VendorRegModel>> DeleteVendorRegModel(int id)
        {
            var vendorRegModel = await _context.VendorReg.FindAsync(id);
            if (vendorRegModel == null)
            {
                return NotFound();
            }

            _context.VendorReg.Remove(vendorRegModel);
            await _context.SaveChangesAsync();

            return vendorRegModel;
        }

        private bool VendorRegModelExists(int id)
        {
            return _context.VendorReg.Any(e => e.VendorRegId == id);
        }
    }
}
