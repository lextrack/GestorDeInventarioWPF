using System;
using System.Collections.Generic;

namespace InventarioDB.Models;

public partial class Salidum
{
    public int SalidaId { get; set; }

    public DateTime? Fecha { get; set; }

    public int? Cantidad { get; set; }

    public int? ProductoId { get; set; }

    public string? Observacion { get; set; }

    public virtual Producto? Producto { get; set; }
}
