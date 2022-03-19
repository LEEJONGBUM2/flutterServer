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
    public class ServiceMappingModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServiceMappingModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceMappingModel>>> GetServiceMapping()
        {
            return await _context.ServiceMapping.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceMappingModel>> GetServiceMappingModel(int id)
        {
            var serviceMappingModel = await _context.ServiceMapping.FindAsync(id);

            if (serviceMappingModel == null)
            {
                return NotFound();
            }

            return serviceMappingModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceMappingModel(int id, ServiceMappingModel serviceMappingModel)
        {
            if (id != serviceMappingModel.MappingId)
            {
                return BadRequest();
            }

            _context.Entry(serviceMappingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceMappingModelExists(id))
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
        public async Task<ActionResult<ServiceMappingModel>> PostServiceMappingModel(ServiceMappingModel serviceMappingModel)
        {
            _context.ServiceMapping.Add(serviceMappingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMappingModel", new { id = serviceMappingModel.MappingId }, serviceMappingModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceMappingModel>> DeleteServiceMappingModel(int id)
        {
            var serviceMappingModel = await _context.ServiceMapping.FindAsync(id);
            if (serviceMappingModel == null)
            {
                return NotFound();
            }

            _context.ServiceMapping.Remove(serviceMappingModel);
            await _context.SaveChangesAsync();

            return serviceMappingModel;
        }

        private bool ServiceMappingModelExists(int id)
        {
            return _context.ServiceMapping.Any(e => e.MappingId == id);
        }
    }
}
