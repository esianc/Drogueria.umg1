using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Drogueria1._1_.Models;

namespace Drogueria1._1_.Controllers
{
    public class IngredientesController : Controller
    {
        private readonly DrogueriaContext _context;

        public IngredientesController(DrogueriaContext context)
        {
            _context = context;
        }

        // GET: Ingredientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingredientes.ToListAsync());
        }

        // GET: Ingredientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes
                .FirstOrDefaultAsync(m => m.IdIngredientea == id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }

        // GET: Ingredientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIngredientea,Nombre")] Ingrediente ingrediente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingrediente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingrediente);
        }

        // GET: Ingredientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }
            return View(ingrediente);
        }

        // POST: Ingredientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdIngredientea,Nombre")] Ingrediente ingrediente)
        {
            if (id != ingrediente.IdIngredientea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingrediente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredienteExists(ingrediente.IdIngredientea))
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
            return View(ingrediente);
        }

        // GET: Ingredientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = await _context.Ingredientes
                .FirstOrDefaultAsync(m => m.IdIngredientea == id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente);
        }

        // POST: Ingredientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente != null)
            {
                _context.Ingredientes.Remove(ingrediente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredienteExists(string id)
        {
            return _context.Ingredientes.Any(e => e.IdIngredientea == id);
        }
    }
}
