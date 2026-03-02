using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_SIGRE_PYME.Models;

public class LogSeguridad
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LogId { get; set; }

    public string? UsuarioId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Evento { get; set; } = string.Empty;

    public DateTime FechaEvento { get; set; } = DateTime.Now;

    [MaxLength(250)]
    public string? Detalle { get; set; }

    [MaxLength(45)]
    public string? IP { get; set; }
}