using Api.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SensoresController : ControllerBase
    {
        private readonly WeatherStationContext _db;

        public SensoresController(WeatherStationContext db)
        {
            _db = db;
        }

        [HttpGet("GetSensores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Sensore>> GetSensores()
        {
            return Ok(_db.Sensores.Include(b => b.Dispositivo).ToList());
        }

        [HttpPost("PostSensores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddSenso([FromBody] SensoreDto Data)
        {

            var dispositivo = _db.Dispositivos.Find(Data.DispositivoId);

            if (dispositivo == null)
            {
                return NotFound("El dispositivo especificado no existe.");
            }

            Sensore Dato = new()
            {
                Referencia = Data.Referencia,
                Descripcion = Data.Descripcion,
                DispositivoId = Data.DispositivoId
            };

            _db.Sensores.Add(Dato);
            _db.SaveChanges();

            return Ok(Data);
        }

    }
}
