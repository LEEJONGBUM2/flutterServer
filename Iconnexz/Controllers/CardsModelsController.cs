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
    public class CardsModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CardsModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardsModel>>> GetCards()
        {
            return await _context.Cards.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CardsModel>> GetCardsModel(int id)
        {
            var cardsModel = await _context.Cards.FindAsync(id);

            if (cardsModel == null)
            {
                return NotFound();
            }

            return cardsModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardsModel(int id, CardsModel cardsModel)
        {
            if (id != cardsModel.CardId)
            {
                return BadRequest();
            }

            _context.Entry(cardsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardsModelExists(id))
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
        public async Task<ActionResult<CardsModel>> PostCardsModel(CardsModel cardsModel)
        {
            _context.Cards.Add(cardsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardsModel", new { id = cardsModel.CardId }, cardsModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CardsModel>> DeleteCardsModel(int id)
        {
            var cardsModel = await _context.Cards.FindAsync(id);
            if (cardsModel == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(cardsModel);
            await _context.SaveChangesAsync();

            return cardsModel;
        }

        private bool CardsModelExists(int id)
        {
            return _context.Cards.Any(e => e.CardId == id);
        }
    }
}
