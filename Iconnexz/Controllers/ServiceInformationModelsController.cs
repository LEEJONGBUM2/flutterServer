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
    public class ServiceInformationModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceInformationModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceInformationModel>>> GetServiceInformation()
        {
            return await _context.ServiceInformation.ToListAsync();
        }


        [HttpGet("{id}/id")]
        public async Task<ActionResult<ServiceInformationModel>> GetServiceInformationModel(int id)
        {
            var serviceInformationModel = await _context.ServiceInformation.FindAsync(id);

            if (serviceInformationModel == null)
            {
                return NotFound();
            }

            return serviceInformationModel;
        }

        [HttpGet("{vendor}/name")]
        public async Task<ActionResult<IEnumerable<ServiceInformationModel>>> GetServiceModelvendor(string vendor)
        {
            return await _context.ServiceInformation.Where(x => x.Vendor == vendor).ToListAsync();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceInformationModel(int id, ServiceInformationModel serviceInformationModel)
        {
            if (id != serviceInformationModel.ServiceId)
            {
                return BadRequest();
            }

            _context.Entry(serviceInformationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceInformationModelExists(id))
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
        public async Task<ActionResult<ServiceInformationModel>> PostServiceInformationModel(ServiceInformationModel serviceInformationModel)
        {
            _context.ServiceInformation.Add(serviceInformationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceInformationModel", new { id = serviceInformationModel.ServiceId }, serviceInformationModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceInformationModel>> DeleteServiceInformationModel(int id)
        {
            var serviceInformationModel = await _context.ServiceInformation.FindAsync(id);
            if (serviceInformationModel == null)
            {
                return NotFound();
            }

            _context.ServiceInformation.Remove(serviceInformationModel);
            await _context.SaveChangesAsync();

            return serviceInformationModel;
        }

        private bool ServiceInformationModelExists(int id)
        {
            return _context.ServiceInformation.Any(e => e.ServiceId == id);
        }
    }
}
