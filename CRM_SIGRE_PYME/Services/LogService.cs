using CRM_SIGRE_PYME.Data;
using CRM_SIGRE_PYME.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CRM_SIGRE_PYME.Services
{
    public class LogService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _http;

        public LogService(ApplicationDbContext context,
                          IHttpContextAccessor http)
        {
            _context = context;
            _http = http;
        }

        public async Task Registrar(
            string accion,
            string modulo,
            string tipo,
            string descripcion)
        {
            var userId = _http.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var ip = _http.HttpContext?
                .Connection?
                .RemoteIpAddress?
                .ToString();

            var navegador = _http.HttpContext?
                .Request?
                .Headers["User-Agent"]
                .ToString();

            var url = _http.HttpContext?
                .Request?
                .Path;

            var log = new LogSeguridad
            {
                UsuarioId = userId,
                Accion = accion,
                Modulo = modulo,
                Tipo = tipo,
                Descripcion = descripcion,
                Ip = ip,
                Navegador = navegador,
                Url = url,
                Fecha = DateTime.Now
            };

            _context.LogsSeguridad.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}