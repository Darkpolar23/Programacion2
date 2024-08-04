using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apirestaurant.Context;
using Apirestaurant.Models;

namespace Apirestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly AppDBcontext _context;

        public PedidoController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelsRestaurant>>> GetModelsRestaurants()
        {
            return await _context.ModelsRestaurants.ToListAsync();
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelsRestaurant>> GetModelsRestaurant(Guid id)
        {
            var modelsRestaurant = await _context.ModelsRestaurants.FindAsync(id);

            if (modelsRestaurant == null)
            {
                return NotFound();
            }

            return modelsRestaurant;
        }

        // PUT: api/Pedido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelsRestaurant(Guid id, ModelsRestaurant modelsRestaurant)
        {
            if (id != modelsRestaurant.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelsRestaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelsRestaurantExists(id))
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

        // POST: api/Pedido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelsRestaurant>> PostModelsRestaurant(ModelsRestaurant modelsRestaurant)
        {
            _context.ModelsRestaurants.Add(modelsRestaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelsRestaurant", new { id = modelsRestaurant.Id }, modelsRestaurant);
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelsRestaurant(Guid id)
        {
            var modelsRestaurant = await _context.ModelsRestaurants.FindAsync(id);
            if (modelsRestaurant == null)
            {
                return NotFound();
            }

            _context.ModelsRestaurants.Remove(modelsRestaurant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelsRestaurantExists(Guid id)
        {
            return _context.ModelsRestaurants.Any(e => e.Id == id);
        }
    }
}
