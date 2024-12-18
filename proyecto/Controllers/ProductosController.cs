using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static List<string> Productos = new List<string> { "Laptop", "Teclado", "Mouse" };

        [HttpGet]
        public IActionResult Get() => Ok(Productos);

        [HttpGet("{id}")]
        public IActionResult Get(int id) => id >= 0 && id < Productos.Count ? Ok(Productos[id]) : NotFound("Producto no encontrado");

        [HttpPost]
        public IActionResult Post([FromBody] string producto)
        {
            Productos.Add(producto);
            return Created($"api/productos/{Productos.Count - 1}", producto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string producto)
        {
            if (id >= 0 && id < Productos.Count)
            {
                Productos[id] = producto;
                return NoContent();
            }
            return NotFound("Producto no encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id >= 0 && id < Productos.Count)
            {
                Productos.RemoveAt(id);
                return NoContent();
            }
            return NotFound("Producto no encontrado");
        }
    }
}
