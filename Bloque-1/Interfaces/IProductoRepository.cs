using System;
using System.Collections.Generic;
using System.Text;

using Bloque_1.Models;

namespace Bloque_1.Interfaces
{
    public interface IProductoRepository
    {
        // Recibe un producto para agregar a la lista
        void Agregar(Producto producto);
        // Devuelve todos los productos de la lista
        List<Producto> ObtenerTodos();
        // Busca un producto por su identificador
        Producto? ObtenerPorId(int id);
        // Devuelve productos filtrando por categoria
        List<Producto> BuscarPorCategoria(string Categoria);
    }
}
