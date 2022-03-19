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
    public class UserIndividualModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserIndividualModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserIndividualModel>>> GetUserIndividual()
        {
            return await _context.UserIndividual.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserIndividualModel>> GetUserIndividualModel(int id)
        {
            var userIndividualModel = await _context.UserIndividual.FindAsync(id);

            if (userIndividualModel == null)
            {
                return NotFound();
            }

            return userIndividualModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserIndividualModel(int id, UserIndividualModel userIndividualModel)
        {
            if (id != userIndividualModel.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userIndividualModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserIndividualModelExists(id))
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
        public async Task<ActionResult<UserIndividualModel>> PostUserIndividualModel(UserIndividualModel userIndividualModel)
        {
            _context.UserIndividual.Add(userIndividualModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserIndividualModel", new { id = userIndividualModel.UserId }, userIndividualModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<UserIndividualModel>> DeleteUserIndividualModel(int id)
        {
            var userIndividualModel = await _context.UserIndividual.FindAsync(id);
            if (userIndividualModel == null)
            {
                return NotFound();
            }

            _context.UserIndividual.Remove(userIndividualModel);
            await _context.SaveChangesAsync();

            return userIndividualModel;
        }

        private bool UserIndividualModelExists(int id)
        {
            return _context.UserIndividual.Any(e => e.UserId == id);
        }
    }
}
