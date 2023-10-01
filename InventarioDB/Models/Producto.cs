using System;
using System.Collections.Generic;

namespace InventarioDB.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public int? Sku { get; set; }

    public decimal? Valor { get; set; }

    public int? Cantidad { get; set; }

    public string? Responsable { get; set; }

    public int? StockMinimo { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<Entradum> Entrada { get; set; } = new List<Entradum>();

    public virtual ICollection<Salidum> Salida { get; set; } = new List<Salidum>();
}
