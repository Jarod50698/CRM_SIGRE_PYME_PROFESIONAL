using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_SIGRE_PYME.Models;

public class MovimientoInventario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MovimientoId { get; set; }

    public int ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;

    [Required]
    public string UsuarioId { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Tipo { get; set; } = "Entrada";

    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    public DateTime FechaMovimiento { get; set; } = DateTime.Now;

    [MaxLength(200)]
    public string? Observacion { get; set; }
}