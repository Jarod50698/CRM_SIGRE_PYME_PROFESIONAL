using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CRM_SIGRE_PYME.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM_SIGRE_PYME.Controllers
{
    [Authorize(Roles = "Admin,Vendedor")] // ✅ Admin y Vendedor pueden ver clientes
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }
    }
}