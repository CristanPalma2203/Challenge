using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using System.Diagnostics;

namespace Prueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly PruebaContext _context;

        public HomeController(PruebaContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Search(int id)
        {
            var entity = _context.Companies.Include(c=> c.Binnacles).Include(c => c.DepartmentsCompany).FirstOrDefault(p => p.Id == id);

            if (entity != null)
            {
                // Si se encuentra la entidad, puedes enviarla a la vista
                return RedirectToAction("Details", "Companies", new { id = entity.Id });
            }
            else
            {
                // Si no se encuentra la entidad, puedes mostrar un mensaje de error o redirigir a otra página
                TempData["Error"] = "La entidad no se encontró.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Search2(int id)
        {
            var entity = _context.Departments.Include(c => c.DepartmentsCompany).ThenInclude(dc=>dc.Company).FirstOrDefault(p => p.Id == id);

            if (entity != null)
            {
                // Si se encuentra la entidad, puedes enviarla a la vista
                return RedirectToAction("Details", "Departments", new { id = entity.Id });
            }
            else
            {
                // Si no se encuentra la entidad, puedes mostrar un mensaje de error o redirigir a otra página
                TempData["Error"] = "La entidad no se encontró.";
                return RedirectToAction("Index");
            }
        }
    }
}