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
    public class UserOrganizationModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserOrganizationModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOrganizationModel>>> GetUserOrganization()
        {
            return await _context.UserOrganization.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOrganizationModel>> GetUserOrganizationModel(int id)
        {
            var userOrganizationModel = await _context.UserOrganization.FindAsync(id);

            if (userOrganizationModel == null)
            {
                return NotFound();
            }

            return userOrganizationModel;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOrganizationModel(int id, UserOrganizationModel userOrganizationModel)
        {
            if (id != userOrganizationModel.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userOrganizationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOrganizationModelExists(id))
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
        public async Task<ActionResult<UserOrganizationModel>> PostUserOrganizationModel(UserOrganizationModel userOrganizationModel)
        {
            _context.UserOrganization.Add(userOrganizationModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserOrganizationModel", new { id = userOrganizationModel.UserId }, userOrganizationModel);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserOrganizationModel>> DeleteUserOrganizationModel(int id)
        {
            var userOrganizationModel = await _context.UserOrganization.FindAsync(id);
            if (userOrganizationModel == null)
            {
                return NotFound();
            }

            _context.UserOrganization.Remove(userOrganizationModel);
            await _context.SaveChangesAsync();

            return userOrganizationModel;
        }

        private bool UserOrganizationModelExists(int id)
        {
            return _context.UserOrganization.Any(e => e.UserId == id);
        }
    }
}
