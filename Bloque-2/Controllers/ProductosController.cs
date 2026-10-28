
using Microsoft.AspNetCore.Mvc;
using Bloque_2.DTOs;
using Bloque_2.Interfaces;

namespace Bloque_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // establece la ruta base
    public class ProductosController : ControllerBase
    {
        // recibe el servicio mediante inyección de dependencias
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        // GET: api/productos
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var productos = _service.ObtenerTodos();
            return Ok(productos); // 200: la operacion fue exitosa y devuelve datos
        }

        // GET: api/productos/{id}
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var producto = _service.ObtenerPorId(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        public IActionResult Crear([FromBody] CreateProductoDto dto)
        {
            var productoCreado = _service.Crear(dto);

            return CreatedAtAction( // 201: se creo el producto
                nameof(ObtenerPorId),
                new { id = productoCreado.Id },
                productoCreado
            );
        }

        // PUT: api/productos/{id}
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] CreateProductoDto dto)
        {
            bool actualizado = _service.Actualizar(id, dto);

            if (!actualizado)
                return NotFound(); // 404: no existe el producto solicitado

            return NoContent(); // 204: la operacion fue exitosa y no necesita devolver contenido
        }

        // DELETE: api/productos/{id}
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            bool eliminado = _service.Eliminar(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}
