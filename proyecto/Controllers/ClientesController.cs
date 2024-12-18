using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private static List<string> Clientes = new List<string> { "Juan Perez", "Maria Lopez" };

        [HttpGet]
        public IActionResult Get() => Ok(Clientes);

        [HttpPost]
        public IActionResult Post([FromBody] string cliente)
        {
            Clientes.Add(cliente);
            return Created($"api/clientes/{Clientes.Count - 1}", cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id >= 0 && id < Clientes.Count)
            {
                Clientes.RemoveAt(id);
                return NoContent();
            }
            return NotFound("Cliente no encontrado");
        }
    }
}
