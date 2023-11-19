using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Dispositivo
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string? Latitud { get; set; }

    public string? Longitud { get; set; }
}
