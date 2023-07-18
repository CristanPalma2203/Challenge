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
    public class DepartmentsCompaniesController : Controller
    {
        private readonly PruebaContext _context;

        public DepartmentsCompaniesController(PruebaContext context)
        {
            _context = context;
        }

        // GET: DepartmentsCompanies
        public async Task<IActionResult> Index()
        {
            var pruebaContext = _context.DepartmentsCompanies.Include(d => d.Company).Include(d => d.Department);

            var x = View(await pruebaContext.ToListAsync());
            return x;
        }

        // GET: DepartmentsCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartmentsCompanies == null)
            {
                return NotFound();
            }

            var departmentsCompany = await _context.DepartmentsCompanies
                .Include(d => d.Company)
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentsCompany == null)
            {
                return NotFound();
            }

            return View(departmentsCompany);
        }

        // GET: DepartmentsCompanies/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: DepartmentsCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,DepartmentId,NumberEmployees")] DepartmentsCompany departmentsCompany)
        {

            _context.Add(departmentsCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: DepartmentsCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartmentsCompanies == null)
            {
                return NotFound();
            }

            var departmentsCompany = await _context.DepartmentsCompanies.FindAsync(id);
            if (departmentsCompany == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", departmentsCompany.CompanyId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", departmentsCompany.DepartmentId);
            return View(departmentsCompany);
        }

        // POST: DepartmentsCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,DepartmentId,NumberEmployees")] DepartmentsCompany departmentsCompany)
        {
            if (id != departmentsCompany.Id)
            {
                return NotFound();
            }

           
            try
            {
                _context.Update(departmentsCompany);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentsCompanyExists(departmentsCompany.Id))
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

        // GET: DepartmentsCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartmentsCompanies == null)
            {
                return NotFound();
            }

            var departmentsCompany = await _context.DepartmentsCompanies
                .Include(d => d.Company)
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentsCompany == null)
            {
                return NotFound();
            }

            return View(departmentsCompany);
        }

        // POST: DepartmentsCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartmentsCompanies == null)
            {
                return Problem("Entity set 'PruebaContext.DepartmentsCompanies'  is null.");
            }
            var departmentsCompany = await _context.DepartmentsCompanies.FindAsync(id);
            if (departmentsCompany != null)
            {
                _context.DepartmentsCompanies.Remove(departmentsCompany);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentsCompanyExists(int id)
        {
          return (_context.DepartmentsCompanies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
