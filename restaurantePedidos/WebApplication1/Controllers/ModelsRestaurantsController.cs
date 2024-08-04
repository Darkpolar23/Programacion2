using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apirestaurant.Context;
using Apirestaurant.Models;

namespace WebApplication1.Controllers
{
    public class ModelsRestaurantsController : Controller
    {
        private readonly AppDBcontext _context;

        public ModelsRestaurantsController(AppDBcontext context)
        {
            _context = context;
        }

        // GET: ModelsRestaurants
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModelsRestaurants.ToListAsync());
        }

        // GET: ModelsRestaurants/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelsRestaurant = await _context.ModelsRestaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelsRestaurant == null)
            {
                return NotFound();
            }

            return View(modelsRestaurant);
        }

        // GET: ModelsRestaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModelsRestaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Full_nombre,Numeropedido,Detallespedidos,Costopedido,Fechapedido")] ModelsRestaurant modelsRestaurant)
        {
            if (ModelState.IsValid)
            {
                modelsRestaurant.Id = Guid.NewGuid();
                _context.Add(modelsRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelsRestaurant);
        }

        // GET: ModelsRestaurants/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelsRestaurant = await _context.ModelsRestaurants.FindAsync(id);
            if (modelsRestaurant == null)
            {
                return NotFound();
            }
            return View(modelsRestaurant);
        }

        // POST: ModelsRestaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Full_nombre,Numeropedido,Detallespedidos,Costopedido,Fechapedido")] ModelsRestaurant modelsRestaurant)
        {
            if (id != modelsRestaurant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelsRestaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelsRestaurantExists(modelsRestaurant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(modelsRestaurant);
        }

        // GET: ModelsRestaurants/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelsRestaurant = await _context.ModelsRestaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (modelsRestaurant == null)
            {
                return NotFound();
            }

            return View(modelsRestaurant);
        }

        // POST: ModelsRestaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var modelsRestaurant = await _context.ModelsRestaurants.FindAsync(id);
            if (modelsRestaurant != null)
            {
                _context.ModelsRestaurants.Remove(modelsRestaurant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelsRestaurantExists(Guid id)
        {
            return _context.ModelsRestaurants.Any(e => e.Id == id);
        }
    }
}
