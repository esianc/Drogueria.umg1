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
    public class EnfermedadsController : Controller
    {
        private readonly DrogueriaContext _context;

        public EnfermedadsController(DrogueriaContext context)
        {
            _context = context;
        }

        // GET: Enfermedads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enfermedads.ToListAsync());
        }

        // GET: Enfermedads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermedad = await _context.Enfermedads
                .FirstOrDefaultAsync(m => m.IdEnfermedad == id);
            if (enfermedad == null)
            {
                return NotFound();
            }

            return View(enfermedad);
        }

        // GET: Enfermedads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enfermedads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEnfermedad,Descripcion")] Enfermedad enfermedad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermedad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfermedad);
        }

        // GET: Enfermedads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermedad = await _context.Enfermedads.FindAsync(id);
            if (enfermedad == null)
            {
                return NotFound();
            }
            return View(enfermedad);
        }

        // POST: Enfermedads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdEnfermedad,Descripcion")] Enfermedad enfermedad)
        {
            if (id != enfermedad.IdEnfermedad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermedad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermedadExists(enfermedad.IdEnfermedad))
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
            return View(enfermedad);
        }

        // GET: Enfermedads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enfermedad = await _context.Enfermedads
                .FirstOrDefaultAsync(m => m.IdEnfermedad == id);
            if (enfermedad == null)
            {
                return NotFound();
            }

            return View(enfermedad);
        }

        // POST: Enfermedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var enfermedad = await _context.Enfermedads.FindAsync(id);
            if (enfermedad != null)
            {
                _context.Enfermedads.Remove(enfermedad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermedadExists(string id)
        {
            return _context.Enfermedads.Any(e => e.IdEnfermedad == id);
        }
    }
}
