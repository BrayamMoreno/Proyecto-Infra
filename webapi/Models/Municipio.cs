using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Municipio
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public int? DepartamentoId { get; set; }

    public virtual Departamento? Departamento { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
