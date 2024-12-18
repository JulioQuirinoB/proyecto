using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private static List<string> Ordenes = new List<string> { "Orden 1", "Orden 2" };

        [HttpGet]
        public IActionResult Get() => Ok(Ordenes);

        [HttpPost]
        public IActionResult Post([FromBody] string orden)
        {
            Ordenes.Add(orden);
            return Created($"api/ordenes/{Ordenes.Count - 1}", orden);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id >= 0 && id < Ordenes.Count)
            {
                Ordenes.RemoveAt(id);
                return NoContent();
            }
            return NotFound("Orden no encontrada");
        }
    }
}
