using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Dto
{
    public class LecturaDto
    {
        public int? SensorId { get; set; }

        public decimal? Temperatura { get; set; }

        public decimal? Humedad { get; set; }
    }
}
