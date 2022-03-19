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
    public class VendorSidebarModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VendorSidebarModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorSidebarModel>>> GetVendorSidebar()
        {
            return await _context.VendorSidebar.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<VendorSidebarModel>> GetVendorSidebarModel(int id)
        {
            var vendorSidebarModel = await _context.VendorSidebar.FindAsync(id);

            if (vendorSidebarModel == null)
            {
                return NotFound();
            }

            return vendorSidebarModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorSidebarModel(int id, VendorSidebarModel vendorSidebarModel)
        {
            if (id != vendorSidebarModel.SidebarId)
            {
                return BadRequest();
            }

            _context.Entry(vendorSidebarModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorSidebarModelExists(id))
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
        public async Task<ActionResult<VendorSidebarModel>> PostVendorSidebarModel(VendorSidebarModel vendorSidebarModel)
        {
            _context.VendorSidebar.Add(vendorSidebarModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendorSidebarModel", new { id = vendorSidebarModel.SidebarId }, vendorSidebarModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<VendorSidebarModel>> DeleteVendorSidebarModel(int id)
        {
            var vendorSidebarModel = await _context.VendorSidebar.FindAsync(id);
            if (vendorSidebarModel == null)
            {
                return NotFound();
            }

            _context.VendorSidebar.Remove(vendorSidebarModel);
            await _context.SaveChangesAsync();

            return vendorSidebarModel;
        }

        private bool VendorSidebarModelExists(int id)
        {
            return _context.VendorSidebar.Any(e => e.SidebarId == id);
        }
    }
}
