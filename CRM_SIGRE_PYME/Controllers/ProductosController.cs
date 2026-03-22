using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CRM_SIGRE_PYME.Data;
using CRM_SIGRE_PYME.Models;
using Microsoft.EntityFrameworkCore;
using CRM_SIGRE_PYME.Services;

namespace CRM_SIGRE_PYME.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly LogService _log;

        public ProductosController(ApplicationDbContext context, LogService log)
        {
            _context = context;
            _log = log;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos.ToListAsync();
            return View(productos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid)
                return View(producto);

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            await _log.Registrar(
                "Crear Producto",
                "Productos",
                "INFO",
                $"Producto {producto.Nombre} creado correctamente"
            );

            return RedirectToAction(nameof(Index));
        }
    }
}