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
    public class TipodocumentoesController : Controller
    {
        private readonly DrogueriaContext _context;

        public TipodocumentoesController(DrogueriaContext context)
        {
            _context = context;
        }

        // GET: Tipodocumentoes
        public async Task<IActionResult> Index()
        {
            var drogueriaContext = _context.Tipodocumentos.Include(t => t.IdBodegaNavigation).Include(t => t.IdSucursalNavigation);
            return View(await drogueriaContext.ToListAsync());
        }

        // GET: Tipodocumentoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipodocumento = await _context.Tipodocumentos
                .Include(t => t.IdBodegaNavigation)
                .Include(t => t.IdSucursalNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDoc == id);
            if (tipodocumento == null)
            {
                return NotFound();
            }

            return View(tipodocumento);
        }

        // GET: Tipodocumentoes/Create
        public IActionResult Create()
        {
            ViewData["IdBodega"] = new SelectList(_context.Bodegas, "IdBodega", "IdBodega");
            ViewData["IdSucursal"] = new SelectList(_context.Farmacia, "IdSucursal", "IdSucursal");
            return View();
        }

        // POST: Tipodocumentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoDoc,Descripcion,Tipotran,IdSucursal,IdBodega")] Tipodocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipodocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBodega"] = new SelectList(_context.Bodegas, "IdBodega", "IdBodega", tipodocumento.IdBodega);
            ViewData["IdSucursal"] = new SelectList(_context.Farmacia, "IdSucursal", "IdSucursal", tipodocumento.IdSucursal);
            return View(tipodocumento);
        }

        // GET: Tipodocumentoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipodocumento = await _context.Tipodocumentos.FindAsync(id);
            if (tipodocumento == null)
            {
                return NotFound();
            }
            ViewData["IdBodega"] = new SelectList(_context.Bodegas, "IdBodega", "IdBodega", tipodocumento.IdBodega);
            ViewData["IdSucursal"] = new SelectList(_context.Farmacia, "IdSucursal", "IdSucursal", tipodocumento.IdSucursal);
            return View(tipodocumento);
        }

        // POST: Tipodocumentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoDoc,Descripcion,Tipotran,IdSucursal,IdBodega")] Tipodocumento tipodocumento)
        {
            if (id != tipodocumento.CodigoDoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipodocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipodocumentoExists(tipodocumento.CodigoDoc))
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
            ViewData["IdBodega"] = new SelectList(_context.Bodegas, "IdBodega", "IdBodega", tipodocumento.IdBodega);
            ViewData["IdSucursal"] = new SelectList(_context.Farmacia, "IdSucursal", "IdSucursal", tipodocumento.IdSucursal);
            return View(tipodocumento);
        }

        // GET: Tipodocumentoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipodocumento = await _context.Tipodocumentos
                .Include(t => t.IdBodegaNavigation)
                .Include(t => t.IdSucursalNavigation)
                .FirstOrDefaultAsync(m => m.CodigoDoc == id);
            if (tipodocumento == null)
            {
                return NotFound();
            }

            return View(tipodocumento);
        }

        // POST: Tipodocumentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tipodocumento = await _context.Tipodocumentos.FindAsync(id);
            if (tipodocumento != null)
            {
                _context.Tipodocumentos.Remove(tipodocumento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipodocumentoExists(string id)
        {
            return _context.Tipodocumentos.Any(e => e.CodigoDoc == id);
        }
    }
}
