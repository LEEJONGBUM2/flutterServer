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
    public class SuggestModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuggestModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuggestModel>>> GetSuggest()
        {
            return await _context.Suggest.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuggestModel>> GetSuggest(int id)
        {
            var suggestModel = await _context.Suggest.FindAsync(id);

            if (suggestModel == null)
            {
                return NotFound();
            }

            return suggestModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuggestModel(int id, SuggestModel suggestModel)
        {
            if (id != suggestModel.SuggestId)
            {
                return BadRequest();
            }

            _context.Entry(suggestModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuggestModelExists(id))
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
        public async Task<ActionResult<SuggestModel>> PostSuggestModel(SuggestModel SuggestModel)
        {
            _context.Suggest.Add(SuggestModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuggestModel", new { id = SuggestModel.SuggestId }, SuggestModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SuggestModel>> DeleteSuggestModel(int id)
        {
            var suggestModel = await _context.Suggest.FindAsync(id);
            if (suggestModel == null)
            {
                return NotFound();
            }

            _context.Suggest.Remove(suggestModel);
            await _context.SaveChangesAsync();

            return suggestModel;
        }

        private bool SuggestModelExists(int id)
        {
            return _context.Suggest.Any(e => e.SuggestId == id);
        }
    }
}
