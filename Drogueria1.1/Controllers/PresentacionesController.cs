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
    public class PresentacionesController : Controller
    {
        private readonly DrogueriaContext _context;

        public PresentacionesController(DrogueriaContext context)
        {
            _context = context;
        }

        // GET: Presentaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presentacions.ToListAsync());
        }

        // GET: Presentaciones/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentacions
                .FirstOrDefaultAsync(m => m.IdPresentacion == id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        }

        // GET: Presentaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presentaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPresentacion,Descripcion")] Presentacion presentacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presentacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presentacion);
        }

        // GET: Presentaciones/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentacions.FindAsync(id);
            if (presentacion == null)
            {
                return NotFound();
            }
            return View(presentacion);
        }

        // POST: Presentaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPresentacion,Descripcion")] Presentacion presentacion)
        {
            if (id != presentacion.IdPresentacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presentacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentacionExists(presentacion.IdPresentacion))
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
            return View(presentacion);
        }

        // GET: Presentaciones/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentacions
                .FirstOrDefaultAsync(m => m.IdPresentacion == id);
            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);
        }

        // POST: Presentaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var presentacion = await _context.Presentacions.FindAsync(id);
            if (presentacion != null)
            {
                _context.Presentacions.Remove(presentacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresentacionExists(string id)
        {
            return _context.Presentacions.Any(e => e.IdPresentacion == id);
        }
    }
}
