using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Controllers
{
    public class BinnaclesController : Controller
    {
        private readonly PruebaContext _context;

        public BinnaclesController(PruebaContext context)
        {
            _context = context;
        }

        // GET: Binnacles
        public async Task<IActionResult> Index()
        {
            var pruebaContext = _context.Binnacles.Include(b => b.Company);
            return View(await pruebaContext.ToListAsync());
        }

        // GET: Binnacles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Binnacles == null)
            {
                return NotFound();
            }

            var binnacle = await _context.Binnacles
                .Include(b => b.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binnacle == null)
            {
                return NotFound();
            }

            return View(binnacle);
        }

        // GET: Binnacles/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            return View();
        }

        // POST: Binnacles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Details,CompanyId,dateTime")] Binnacle binnacle)
        {

                _context.Add(binnacle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        
        }

        // GET: Binnacles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Binnacles == null)
            {
                return NotFound();
            }

            var binnacle = await _context.Binnacles.FindAsync(id);
            if (binnacle == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", binnacle.CompanyId);
            return View(binnacle);
        }

        // POST: Binnacles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Details,CompanyId,dateTime")] Binnacle binnacle)
        {
            if (id != binnacle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binnacle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinnacleExists(binnacle.Id))
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
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Id", binnacle.CompanyId);
            return View(binnacle);
        }

        // GET: Binnacles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Binnacles == null)
            {
                return NotFound();
            }

            var binnacle = await _context.Binnacles
                .Include(b => b.Company)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binnacle == null)
            {
                return NotFound();
            }

            return View(binnacle);
        }

        // POST: Binnacles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Binnacles == null)
            {
                return Problem("Entity set 'PruebaContext.Binnacles'  is null.");
            }
            var binnacle = await _context.Binnacles.FindAsync(id);
            if (binnacle != null)
            {
                _context.Binnacles.Remove(binnacle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinnacleExists(int id)
        {
          return (_context.Binnacles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
