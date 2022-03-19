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
    public class UserNavbarModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserNavbarModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserNavbarModel>>> GetUserNavbar()
        {
            return await _context.UserNavbar.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserNavbarModel>> GetUserNavbarModel(int id)
        {
            var userNavbarModel = await _context.UserNavbar.FindAsync(id);

            if (userNavbarModel == null)
            {
                return NotFound();
            }

            return userNavbarModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserNavbarModel(int id, UserNavbarModel userNavbarModel)
        {
            if (id != userNavbarModel.NavbarId)
            {
                return BadRequest();
            }

            _context.Entry(userNavbarModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserNavbarModelExists(id))
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
        public async Task<ActionResult<UserNavbarModel>> PostUserNavbarModel(UserNavbarModel userNavbarModel)
        {
            _context.UserNavbar.Add(userNavbarModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserNavbarModel", new { id = userNavbarModel.NavbarId }, userNavbarModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<UserNavbarModel>> DeleteUserNavbarModel(int id)
        {
            var userNavbarModel = await _context.UserNavbar.FindAsync(id);
            if (userNavbarModel == null)
            {
                return NotFound();
            }

            _context.UserNavbar.Remove(userNavbarModel);
            await _context.SaveChangesAsync();

            return userNavbarModel;
        }

        private bool UserNavbarModelExists(int id)
        {
            return _context.UserNavbar.Any(e => e.NavbarId == id);
        }
    }
}
