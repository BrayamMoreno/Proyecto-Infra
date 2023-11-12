using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Sensore
{
    public int Id { get; set; }

    public string? Referencia { get; set; }

    public string? Descripcion { get; set; }

    public int? DispositivoId { get; set; }
}
