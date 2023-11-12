using Api.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data;
using webapi.Models;
using webapi.Models.Dto;

namespace webapi.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly WeatherStationContext _db;

        public UsuariosController(WeatherStationContext db)
        {
            _db = db;
        }


        [HttpGet("GetUsuarios")]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return Ok(_db.Usuarios.ToList());
        }

        [HttpGet("GetDepartamentos")]
        public ActionResult<IEnumerable<Departamento>> GetDepartamentos()
        {
            return Ok(_db.Departamentos.ToList());
        }

        [HttpGet("GetMunicipios")]
        public ActionResult<IEnumerable<Municipio>> GetMunicipios(int id)
        {
            var data = _db.Municipios.Where(x => x.DepartamentoId == id);

            return Ok(data);
        }

        [HttpPost("PostUsuario")]
        public IActionResult PostUsuario([FromBody] PersonaDto Data)
        {
            Persona Dato = new()
            {
                Nit = Data.Nit,
                Nombre = Data.Nombre,
                Apellido = Data.Apellido,
                Direccion = Data.Direccion,
                Telefono = Data.Telefono,
                Correo = Data.Correo,
                MunicipioId = Data.MunicipioId,

            };

            _db.Personas.Add(Dato);
            _db.SaveChanges();


            Persona Data1 = _db.Personas.FirstOrDefault(X => X.Nit == Data.Nit);

            var Id = Data1.Id;


            Usuario Dato1 = new()
            {
                Username = Data.Username,
                Password = Data.Password,
                PersonaId = Id,
                RolId = 1
            };

            _db.Usuarios.Add(Dato1);
            _db.SaveChanges();

            return Ok(Data);
        }


        [HttpGet("GetIdPersona")]
        public IActionResult GetIdPersona(string cedula)
        {
            return Ok();
        }
    }
}
