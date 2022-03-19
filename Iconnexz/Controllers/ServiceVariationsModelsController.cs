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
    public class ServiceVariationsModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceVariationsModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceVariationsModel>>> GetServiceVariations()
        {
            return await _context.ServiceVariations.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceVariationsModel>> GetServiceVariationsModel(int id)
        {
            var serviceVariationsModel = await _context.ServiceVariations.FindAsync(id);

            if (serviceVariationsModel == null)
            {
                return NotFound();
            }

            return serviceVariationsModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceVariationsModel(int id, ServiceVariationsModel serviceVariationsModel)
        {
            if (id != serviceVariationsModel.VariationsId)
            {
                return BadRequest();
            }

            _context.Entry(serviceVariationsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceVariationsModelExists(id))
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
        public async Task<ActionResult<ServiceVariationsModel>> PostServiceVariationsModel(ServiceVariationsModel serviceVariationsModel)
        {
            _context.ServiceVariations.Add(serviceVariationsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVariationsModel", new { id = serviceVariationsModel.VariationsId }, serviceVariationsModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceVariationsModel>> DeleteServiceVariationsModel(int id)
        {
            var serviceVariationsModel = await _context.ServiceVariations.FindAsync(id);
            if (serviceVariationsModel == null)
            {
                return NotFound();
            }

            _context.ServiceVariations.Remove(serviceVariationsModel);
            await _context.SaveChangesAsync();

            return serviceVariationsModel;
        }

        private bool ServiceVariationsModelExists(int id)
        {
            return _context.ServiceVariations.Any(e => e.VariationsId == id);
        }
    }
}
