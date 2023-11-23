using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Models.Dto;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using System.Reflection.Metadata.Ecma335;

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

            var ultimasLecturas = _db.Lecturas.OrderByDescending(l => l.Id).Take(20).ToList();

            return Ok(ultimasLecturas);
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

        [HttpGet("lecturas-completas")]
        public IActionResult GetLecturasCompletas()
        {
            var result = _db.Lecturas.OrderByDescending(l => l.Id)
                .Join(_db.Sensores,
                    lectura => lectura.SensorId,
                    sensor => sensor.Id,
                    (lectura, sensor) => new { Lectura = lectura, Sensor = sensor })
                .Join(_db.Dispositivos,
                    combined => combined.Sensor.DispositivoId,
                    dispositivo => dispositivo.Id,
                    (combined, dispositivo) => new
                    {
                        Id = combined.Lectura.Id,
                        Humedad = combined.Lectura.Humedad,
                        Temperatura = combined.Lectura.Temperatura,
                        Fecha = combined.Lectura.Fecha,
                        Hora = combined.Lectura.Hora,
                        Referencia = combined.Sensor.Referencia,
                        DescripcionDispositivo = dispositivo.Descripcion,
                        Longitud = dispositivo.Longitud,
                        Latitud = dispositivo.Latitud
                    }).Take(30).ToList();

            return Ok(result);
        }
    }
}