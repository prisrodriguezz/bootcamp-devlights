
using Bloque_2.Interfaces;
using Bloque_2.Models;

namespace Bloque_2.Repositories
{
    // capa de acceso a datos ; administra la entidad Producto
    public class ProductoRepositoryInMemory : IProductoRepository
    {
        // Lista compartida por todas las instancias del repositorio
        private static readonly List<Producto> _productos = new List<Producto>
        {
            new Producto
            {
                Id = 1,
                Nombre = "Teclado",
                Precio = 25000,
                Categoria = "Informatica",
                Activo = true
            },
            new Producto
            {
                Id = 2,
                Nombre = "Mouse",
                Precio = 12000,
                Categoria = "Informatica",
                Activo = true
            },
            new Producto
            {
                Id = 3,
                Nombre = "Cuaderno",
                Precio = 5000,
                Categoria = "Libreria",
                Activo = true
            },
            new Producto
            {
                Id = 4,
                Nombre = "Cartuchera",
                Precio = 10000,
                Categoria = "Libreria",
                Activo = false
            }
        };

        public List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        public void Agregar(Producto producto)
        {
            _productos.Add(producto);
        }

        public void Actualizar(Producto producto)
        {
            int indice = _productos.FindIndex(p => p.Id == producto.Id);

            if (indice != -1)
            {
                _productos[indice] = producto;
            }
        }

        public bool Eliminar(int id)
        {
            Producto? producto = ObtenerPorId(id);

            if (producto == null)
            {
                return false;
            }

            _productos.Remove(producto);
            return true;
        }
    }
}
