using System.ComponentModel.DataAnnotations;

namespace CRM_SIGRE_PYME.Models;

public class Pedido
{
    public int PedidoId { get; set; }

    // FK Cliente (obligatorio)
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    // FK Usuario (Identity usa string)
    [Required]
    public string UsuarioId { get; set; } = string.Empty;

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    [Required]
    [MaxLength(30)]
    public string Estado { get; set; } = "Pendiente";

    public decimal Total { get; set; }
}