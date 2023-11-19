using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Lectura
{
    public int Id { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public int? SensorId { get; set; }

    public decimal? Temperatura { get; set; }

    public decimal? Humedad { get; set; }
}
