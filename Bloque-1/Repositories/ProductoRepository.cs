using System;
using System.Collections.Generic;
using System.Text;

using Bloque_1.Models;
using Bloque_1.Interfaces;

namespace Bloque_1.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        // Lista privada ; se guarda en memoria
        private readonly List<Producto> _productos;

        // Constructor
        public ProductoRepository()
        {
            _productos = new List<Producto>
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

        }

        // Agregar un producto
        public void Agregar(Producto producto)
        {
            _productos.Add(producto);
        }

        // Listar productos
        public List<Producto> ObtenerTodos()
        {
            return _productos.ToList();
        }

        // Obtener un producto por ID ; FirstOrDefault devuelve el 1er elem. en cumplir la cond.
        public Producto? ObtenerPorId(int id)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }

        // Filtrar por Categoria
        public List<Producto> BuscarPorCategoria(string categoria)
        {
            return _productos.Where(p => p.Categoria == categoria).ToList();
        }
    }
}
