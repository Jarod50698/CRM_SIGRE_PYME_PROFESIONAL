using System.ComponentModel.DataAnnotations;

namespace CRM_SIGRE_PYME.Models;

public class Producto
{
    public int ProductoId { get; set; }

    [Required]
    [MaxLength(50)]
    public string SKU { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Nombre { get; set; } = string.Empty;

    [Range(0, 999999999)]
    public decimal PrecioCompra { get; set; }

    [Range(0, 999999999)]
    public decimal PrecioVenta { get; set; }

    public bool Estado { get; set; } = true;

    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}