using Api.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DispositivosController : ControllerBase
    {
        private readonly WeatherStationContext _db;

        public DispositivosController(WeatherStationContext db)
        {
            _db = db;
        }

        [HttpGet("GetDispositivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Dispositivo>> GetDispositivos()
        {
                return Ok(_db.Dispositivos.ToList());
        }

        [HttpGet("GetDispositivo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Dispositivo> GetDispositivo(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }

            Dispositivo Data = _db.Dispositivos.FirstOrDefault(x => x.Id == Id);

            if (Data == null)
            {
                return NotFound();
            }

            return Ok(Data);
        }

        [HttpPost("PostDispositivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddDispositivo([FromBody] DispositivoDto Data)
        {

            Dispositivo Dato = new()
            {
                Descripcion = Data.Descripcion,
                Latitud = Data.Latitud,
                Longitud = Data.Longitud,
            };

            _db.Dispositivos.Add(Dato);
          _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("DeleteDispositivo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Dispositivo> DeleteDispositivo(int Id) {

            Dispositivo Data = _db.Dispositivos.FirstOrDefault(x => x.Id == Id);

            if (Data == null)
            {
                return NotFound();
            }

            bool tieneSensoresRelacionados = _db.Sensores.Any(s => s.DispositivoId == Id);

            if (tieneSensoresRelacionados)
            {
                return BadRequest("No se puede eliminar el dispositivo porque tiene sensores relacionados.");
            }

            _db.Dispositivos.Remove(Data);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("PutDispositivo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Dispositivo> PatchDispositivo(int Id, [FromBody] DispositivoDto Dato)
            {
            Dispositivo Data = _db.Dispositivos.FirstOrDefault(x => x.Id == Id);

            if(Data == null)
            {
                return NotFound();
            }

            if (Id <= 0)
            {
                return BadRequest();
            }

            Data.Longitud = Dato.Longitud;
            Data.Latitud = Dato.Latitud;
            Data.Descripcion = Dato.Descripcion;
            _db.SaveChanges();
            return Ok(Data);
        }

    
    }
}
