
using Bloque_2.DTOs;
using Bloque_2.Interfaces;
using Bloque_2.Models;

namespace Bloque_2.Services
{
    // conecta al Controller con el Repository y contiene la lógica de negocio
    // transforma los objetos Producto en ProductoDto para que la API no devuelva directamente las entidades
    public class ProductoService : IProductoService
    {
        // Inyeccion de dependencia ; el servicio no crea el repositorio, lo recibe mediante el constructor
        private readonly IProductoRepository _repository;
        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        // Obtiene todos los productos y los transforma en ProductoDto
        public List<ProductoDto> ObtenerTodos()
        {
            return _repository.ObtenerTodos()
                .Select(p => new ProductoDto
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    Categoria = p.Categoria,
                    Activo = p.Activo
                }).ToList();
        }

        // Busca un producto por ID y devuelve su DTO
        // Si no existe, devuelve null
        public ProductoDto? ObtenerPorId(int id)
        {
            Producto? producto = _repository.ObtenerPorId(id); // Le pide al repositorio que busque el producto

            if (producto == null)
            {
                return null;
            }

            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Categoria = producto.Categoria,
                Activo = producto.Activo
            };
        }

        // Crea un producto a partir de los datos recibidos en el DTO
        public ProductoDto Crear(CreateProductoDto dto)
        {
            List<Producto> productos = _repository.ObtenerTodos();

            // Si hay productos, toma el ID mayor y suma uno
            // Si no hay ninguno, comienza desde el ID 1
            int nuevoId = productos.Count > 0 ? productos.Max(p => p.Id) + 1 : 1;

            // Construye la entidad que se guardara en el repositorio
            Producto producto = new Producto
            {
                Id = nuevoId,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Categoria = dto.Categoria,
                Activo = true
            };

            _repository.Agregar(producto);

            // Devuelve el producto creado, convertido a DTO
            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Categoria = producto.Categoria,
                Activo = producto.Activo
            };
        }

        public bool Actualizar(int id, CreateProductoDto dto)
        {
            // Busca el producto que se quiere modificar
            Producto? producto = _repository.ObtenerPorId(id);

            if (producto == null)
            {
                return false;
            }

            // Modifica los campos con los datos recibidos
            producto.Nombre = dto.Nombre;
            producto.Precio = dto.Precio;
            producto.Categoria = dto.Categoria;

            _repository.Actualizar(producto);

            return true;
        }

        // Solicita al repositorio que elimine el producto por ID
        // Devuelve true / false
        public bool Eliminar(int id)
        {
            return _repository.Eliminar(id);
        }
    }
}
