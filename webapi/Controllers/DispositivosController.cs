using Api.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("PostDispositivos")]
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

        [HttpGet("GetDispositivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Dispositivo>> GetDispositivos()
        {
            return Ok(_db.Dispositivos.ToList());
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Dispositivo> DeleteDispositivo(int Id) {

            Dispositivo Data = _db.Dispositivos.FirstOrDefault(x => x.Id == Id);

            if (Data == null)
            {
                return NotFound();
            }

            _db.Dispositivos.Remove(Data);
            _db.SaveChanges();
            return NoContent();
        }
    
    }
}
