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
    public class FarmaciasController : Controller
    {
        private readonly DrogueriaContext _context;

        public FarmaciasController(DrogueriaContext context)
        {
            _context = context;
        }

        // GET: Farmacias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farmacia.ToListAsync());
        }

        // GET: Farmacias/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacium = await _context.Farmacia
                .FirstOrDefaultAsync(m => m.IdSucursal == id);
            if (farmacium == null)
            {
                return NotFound();
            }

            return View(farmacium);
        }

        // GET: Farmacias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmacias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSucursal,NombreSucursal,DireccionSucursal")] Farmacium farmacium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmacium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmacium);
        }

        // GET: Farmacias/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacium = await _context.Farmacia.FindAsync(id);
            if (farmacium == null)
            {
                return NotFound();
            }
            return View(farmacium);
        }

        // POST: Farmacias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdSucursal,NombreSucursal,DireccionSucursal")] Farmacium farmacium)
        {
            if (id != farmacium.IdSucursal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmacium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmaciumExists(farmacium.IdSucursal))
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
            return View(farmacium);
        }

        // GET: Farmacias/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmacium = await _context.Farmacia
                .FirstOrDefaultAsync(m => m.IdSucursal == id);
            if (farmacium == null)
            {
                return NotFound();
            }

            return View(farmacium);
        }

        // POST: Farmacias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var farmacium = await _context.Farmacia.FindAsync(id);
            if (farmacium != null)
            {
                _context.Farmacia.Remove(farmacium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmaciumExists(string id)
        {
            return _context.Farmacia.Any(e => e.IdSucursal == id);
        }
    }
}
