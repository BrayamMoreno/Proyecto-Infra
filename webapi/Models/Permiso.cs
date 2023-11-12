using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Permiso
{
    public int Id { get; set; }

    public bool Leer { get; set; }

    public bool Crear { get; set; }

    public bool Eliminar { get; set; }

    public bool Editar { get; set; }
}
