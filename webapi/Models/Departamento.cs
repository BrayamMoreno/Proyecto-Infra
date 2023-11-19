using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
