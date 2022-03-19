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
    public class FaqModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FaqModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaqModel>>> GetFaq()
        {
            return await _context.Faq.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FaqModel>> GetFaq(int id)
        {
            var faqModel = await _context.Faq.FindAsync(id);

            if (faqModel == null)
            {
                return NotFound();
            }

            return faqModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaqModel(int id, FaqModel faqModel)
        {
            if (id != faqModel.FaqId)
            {
                return BadRequest();
            }

            _context.Entry(faqModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaqModelExists(id))
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
        public async Task<ActionResult<FaqModel>> PostFaqModel(FaqModel FaqModel)
        {
            _context.Faq.Add(FaqModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFaqModel", new { id = FaqModel.FaqId }, FaqModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<FaqModel>> DeleteFaqModel(int id)
        {
            var faqModel = await _context.Faq.FindAsync(id);
            if (faqModel == null)
            {
                return NotFound();
            }

            _context.Faq.Remove(faqModel);
            await _context.SaveChangesAsync();

            return faqModel;
        }

        private bool FaqModelExists(int id)
        {
            return _context.Faq.Any(e => e.FaqId == id);
        }
    }
}
