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
    public class BodegasController : Controller
    {
        private readonly DrogueriaContext _context;

        public BodegasController(DrogueriaContext context)
        {
            _context = context;
        }

        // GET: Bodegas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bodegas.ToListAsync());
        }

        // GET: Bodegas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodegas
                .FirstOrDefaultAsync(m => m.IdBodega == id);
            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        // GET: Bodegas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bodegas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBodega,NombreBod,DirBodega")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bodega);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bodega);
        }

        // GET: Bodegas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }
            return View(bodega);
        }

        // POST: Bodegas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdBodega,NombreBod,DirBodega")] Bodega bodega)
        {
            if (id != bodega.IdBodega)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bodega);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BodegaExists(bodega.IdBodega))
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
            return View(bodega);
        }

        // GET: Bodegas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bodega = await _context.Bodegas
                .FirstOrDefaultAsync(m => m.IdBodega == id);
            if (bodega == null)
            {
                return NotFound();
            }

            return View(bodega);
        }

        // POST: Bodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bodega = await _context.Bodegas.FindAsync(id);
            if (bodega != null)
            {
                _context.Bodegas.Remove(bodega);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BodegaExists(string id)
        {
            return _context.Bodegas.Any(e => e.IdBodega == id);
        }
    }
}
