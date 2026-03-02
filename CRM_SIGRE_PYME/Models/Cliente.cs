using System.ComponentModel.DataAnnotations;

namespace CRM_SIGRE_PYME.Models;

public class Cliente
{
    public int ClienteId { get; set; }

    [Required]
    [MaxLength(120)]
    public string Nombre { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Identificacion { get; set; }

    [MaxLength(30)]
    public string? Telefono { get; set; }

    [MaxLength(120)]
    public string? Email { get; set; }

    [MaxLength(200)]
    public string? Direccion { get; set; }

    public bool Estado { get; set; } = true;
}