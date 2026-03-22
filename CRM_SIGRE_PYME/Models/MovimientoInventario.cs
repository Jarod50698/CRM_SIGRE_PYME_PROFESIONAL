using System.ComponentModel.DataAnnotations;

namespace CRM_SIGRE_PYME.Models;

public class PedidoDetalle
{
    public int PedidoDetalleId { get; set; }

    public int PedidoId { get; set; }
    public Pedido Pedido { get; set; } = null!;

    public int ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }
}