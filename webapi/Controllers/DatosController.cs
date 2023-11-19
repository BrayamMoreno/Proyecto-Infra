using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Models.Dto;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {
        private readonly WeatherStationContext _db;

        public DatosController(WeatherStationContext db)
        {
            _db = db;
        }

        [HttpGet("GetLecturas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Lectura>> GetLecturas()
        {
            return Ok(_db.Lecturas.ToList());
        }

        [HttpPost("PostLecturas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddLectura([FromBody] LecturaDto Data)
        {

            var dispositivo = _db.Sensores.Find(Data.SensorId);

            if (dispositivo == null)
            {
                return NotFound("El Sensor especificado no existe.");
            }

            Lectura Dato = new()
            {   
                SensorId = Data.SensorId,
                Temperatura = Data.Temperatura,
                Humedad = Data.Humedad
            };

            _db.Lecturas.Add(Dato);  
            _db.SaveChanges();

            return Ok(Data);
        }
    }
}