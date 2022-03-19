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
    public class BusinessInfoModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusinessInfoModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessInfoModel>>> GetBusinessInfo()
        {
            return await _context.BusinessInfo.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessInfoModel>> GetBusinessInfoModel(int id)
        {
            var businessInfoModel = await _context.BusinessInfo.FindAsync(id);

            if (businessInfoModel == null)
            {
                return NotFound();
            }

            return businessInfoModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessInfoModel(int id, BusinessInfoModel businessInfoModel)
        {
            if (id != businessInfoModel.BusinessInfoId)
            {
                return BadRequest();
            }

            _context.Entry(businessInfoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessInfoModelExists(id))
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
        public async Task<ActionResult<BusinessInfoModel>> PostBusinessInfoModel(BusinessInfoModel businessInfoModel)
        {
            _context.BusinessInfo.Add(businessInfoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessInfoModel", new { id = businessInfoModel.BusinessInfoId }, businessInfoModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessInfoModel>> DeleteBusinessInfoModel(int id)
        {
            var businessInfoModel = await _context.BusinessInfo.FindAsync(id);
            if (businessInfoModel == null)
            {
                return NotFound();
            }

            _context.BusinessInfo.Remove(businessInfoModel);
            await _context.SaveChangesAsync();

            return businessInfoModel;
        }

        private bool BusinessInfoModelExists(int id)
        {
            return _context.BusinessInfo.Any(e => e.BusinessInfoId == id);
        }
    }
}
