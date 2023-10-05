using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? PersonaId { get; set; }

    public int? RolId { get; set; }

    public virtual Persona? Persona { get; set; }

    public virtual Role? Rol { get; set; }
}
