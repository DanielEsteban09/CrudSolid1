using CapaDatos;
using CapaNegocio.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoCapasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatoController : ControllerBase
    {

        IDato _dato;

        public DatoController(IDato dato)
        {
            _dato = dato;
        }

        // GET: api/<DatoController>
        [HttpGet]
        public IEnumerable<Dato> Get()
        {
            return _dato.GetDatos();
        }

        // GET api/<DatoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dato = _dato.GetDatoByID(id);

            if (dato != null)
            {
                return Ok(dato);
            }
            else
            {
                return NotFound();
            }
        }


        // POST api/<DatoController>
        [HttpPost]
        public IActionResult Post([FromBody] Dato dato)
        {
            if (dato != null)
            {
                _dato.CreateDato(dato);
                return Ok("Registro añadido satisfactoriamente");
            }
            else
            {
                return BadRequest("Datos de entrada invalidos");
            }
        }

        // PUT api/<DatoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Dato dato)
        {
            if (dato != null)
                {
                    _dato.UpdateDato(id, dato);
                    return Ok("Registro actualizado satisfactoriamente");
                }
            else
                {
                    return BadRequest("Datos de entrada invalidos");
                }
        }

        // DELETE api/<DatoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _dato.DeleteDato(id);
                return Ok("Registro eliminado satisfactoriamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
