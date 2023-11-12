using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Municipio
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public int? DepartamentoId { get; set; }
}
