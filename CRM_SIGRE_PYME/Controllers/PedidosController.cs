using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CRM_SIGRE_PYME.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM_SIGRE_PYME.Controllers
{
    [Authorize(Roles = "Admin,Vendedor")] 
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pedidos = await _context.Pedidos
                .Include(p => p.Cliente)
                .ToListAsync();

            return View(pedidos);
        }
    }
}