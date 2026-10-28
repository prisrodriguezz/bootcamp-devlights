using Bloque_2.Models;

namespace Bloque_2.Interfaces
{
    // Trabaja directamente con la entidad Producto ; no conoce los DTOs
    public interface IProductoRepository
    {
        // Devuelve todos los productos
        List<Producto> ObtenerTodos();

        // Busca un producto por su identificador
        Producto? ObtenerPorId(int id);

        // Agrega un nuevo producto
        void Agregar(Producto producto);

        // Modifica un producto existente
        void Actualizar(Producto producto);

        // Elimina un producto y devuelve true/false
        bool Eliminar(int id);
    }
}