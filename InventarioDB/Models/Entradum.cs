using System;
using System.Collections.Generic;

namespace InventarioDB.Models;

public partial class Entradum
{
    public int EntradaId { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Cantidad { get; set; }

    public int? ProductoId { get; set; }

    public string? Observacion { get; set; }

    public virtual Producto? Producto { get; set; }
}
