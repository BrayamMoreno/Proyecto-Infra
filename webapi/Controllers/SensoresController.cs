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

        [HttpGet("GetSensor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Sensore>> GetSensores(int Id)
        {
            Sensore Data = _db.Sensores.Include(b => b.Dispositivo).FirstOrDefault(b => b.Id == Id);

            if (Data == null)
            {
                return NotFound();
            }

            return Ok(Data);
        }

        [HttpPost("PostSensor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddSenso([FromBody] SensoreDto Data)
        {

            var dispositivo = _db.Sensores.Find(Data.DispositivoId);

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

        [HttpDelete("DeleteSensor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Sensore> DeleteSensor(int Id)
        {
            Sensore Data = _db.Sensores.FirstOrDefault(b => b.Id == Id);

            if (Data == null)
            {
                return NotFound();
            }

            _db.Remove(Data);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("PutSensor")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Sensore> PutSensor(int Id, [FromBody] SensoreDto Dato)
        {
            Sensore Data = _db.Sensores.FirstOrDefault(x => x.Id == Id);

            if (Data == null)
            {
                return NotFound();
            }

            if (Id <= 0)
            {
                return BadRequest();
            }

            Data.Referencia = Dato.Referencia;
            Data.Descripcion = Dato.Descripcion;
            Data.DispositivoId = Dato.DispositivoId;

            _db.SaveChanges();
            return Ok();
        }

    }
}
