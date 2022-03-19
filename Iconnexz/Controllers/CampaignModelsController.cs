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
    public class CampaignModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CampaignModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampaignModel>>> GetCampaign()
        {
            return await _context.Campaign.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CampaignModel>> GetCampaignModel(int id)
        {
            var campaignModel = await _context.Campaign.FindAsync(id);

            if (campaignModel == null)
            {
                return NotFound();
            }

            return campaignModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaignModel(int id, CampaignModel campaignModel)
        {
            if (id != campaignModel.CampaignId)
            {
                return BadRequest();
            }

            _context.Entry(campaignModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignModelExists(id))
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
        public async Task<ActionResult<CampaignModel>> PostCampaignModel(CampaignModel campaignModel)
        {
            _context.Campaign.Add(campaignModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampaignModel", new { id = campaignModel.CampaignId }, campaignModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CampaignModel>> DeleteCampaignModel(int id)
        {
            var campaignModel = await _context.Campaign.FindAsync(id);
            if (campaignModel == null)
            {
                return NotFound();
            }

            _context.Campaign.Remove(campaignModel);
            await _context.SaveChangesAsync();

            return campaignModel;
        }

        private bool CampaignModelExists(int id)
        {
            return _context.Campaign.Any(e => e.CampaignId == id);
        }
    }
}
