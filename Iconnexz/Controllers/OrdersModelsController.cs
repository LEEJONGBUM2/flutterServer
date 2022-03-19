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
    public class OrdersModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersModelsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersModel>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }


        [HttpGet("{vendor}/name")]
        public async Task<ActionResult<IEnumerable<OrdersModel>>> GetOrdersModelvendor(string vendor)
        {
            return await _context.Orders.Where(x => x.Vendor == vendor).ToListAsync();
        }

        [HttpGet("{id}/id")]
        public async Task<ActionResult<OrdersModel>> GetOrdersModel(int id)
        {
            var ordersModel = await _context.Orders.FindAsync(id);

            if (ordersModel == null)
            {
                return NotFound();
            }

            return ordersModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersModel(int id, OrdersModel ordersModel)
        {
            if (id != ordersModel.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(ordersModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersModelExists(id))
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
        public async Task<ActionResult<OrdersModel>> PostOrdersModel(OrdersModel ordersModel)
        {
            _context.Orders.Add(ordersModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersModel", new { id = ordersModel.OrderId }, ordersModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersModel>> DeleteOrdersModel(int id)
        {
            var ordersModel = await _context.Orders.FindAsync(id);
            if (ordersModel == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(ordersModel);
            await _context.SaveChangesAsync();

            return ordersModel;
        }

        private bool OrdersModelExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
