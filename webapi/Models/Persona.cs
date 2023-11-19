using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nit { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public int? MunicipioId { get; set; }

}
