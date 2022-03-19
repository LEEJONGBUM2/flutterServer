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
    public class VendorAddressModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorAddressModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorAddressModel>>> GetVendorAddress()
        {
            return await _context.VendorAddress.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<VendorAddressModel>> GetVendorAddressModel(int id)
        {
            var vendorAddressModel = await _context.VendorAddress.FindAsync(id);

            if (vendorAddressModel == null)
            {
                return NotFound();
            }

            return vendorAddressModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorAddressModel(int id, VendorAddressModel vendorAddressModel)
        {
            if (id != vendorAddressModel.VendorAddressId)
            {
                return BadRequest();
            }

            _context.Entry(vendorAddressModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorAddressModelExists(id))
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
        public async Task<ActionResult<VendorAddressModel>> PostVendorAddressModel(VendorAddressModel vendorAddressModel)
        {
            _context.VendorAddress.Add(vendorAddressModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendorAddressModel", new { id = vendorAddressModel.VendorAddressId }, vendorAddressModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<VendorAddressModel>> DeleteVendorAddressModel(int id)
        {
            var vendorAddressModel = await _context.VendorAddress.FindAsync(id);
            if (vendorAddressModel == null)
            {
                return NotFound();
            }

            _context.VendorAddress.Remove(vendorAddressModel);
            await _context.SaveChangesAsync();

            return vendorAddressModel;
        }

        private bool VendorAddressModelExists(int id)
        {
            return _context.VendorAddress.Any(e => e.VendorAddressId == id);
        }
    }
}
