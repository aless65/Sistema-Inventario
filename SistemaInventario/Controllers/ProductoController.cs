using AcademiaFS.Proyecto.Inventario._Features.Productos.Dtos;
using AcademiaFS.Proyecto.Inventario._Features.Sucursales.Dtos;
using AcademiaFS.Proyecto.Inventario.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario._Features.Lotes;

namespace AcademiaFS.Proyecto.Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorization]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var respuesta = _productoService.ListarProductos();

            return Ok(respuesta);
        }

        [HttpPost("Insertar")]
        public IActionResult Create(ProductoDto producto)
        {
            var respuesta = _productoService.InsertarProductos(producto);

            return Ok(respuesta);
        }

        [HttpPut("Editar")]
        public IActionResult Edit(ProductoDto producto)
        {
            var respuesta = _productoService.EditarProductos(producto);

            return Ok(respuesta);
        }

        [HttpPut("Eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var respuesta = _productoService.EliminarProductos(id);

            return Ok(respuesta);
        }
    }
}
