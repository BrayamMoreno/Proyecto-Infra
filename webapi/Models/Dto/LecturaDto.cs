using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.Dto
{
    public class LecturaDto
    {
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Valor { get; set; }

        public int? SensorId { get; set; }

    }
}
