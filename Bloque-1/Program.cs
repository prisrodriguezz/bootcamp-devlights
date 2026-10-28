using Bloque_1.Models;
using Bloque_1.Interfaces;
using Bloque_1.Repositories;

namespace Bloque_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProductoRepository repo = new ProductoRepository();

            Console.WriteLine("###### LISTA DE PRODUCTOS ######");
            List<Producto> productos = repo.ObtenerTodos();
            foreach (Producto producto in productos)
            {
                Console.WriteLine(
                    $"Id: {producto.Id} | " + 
                    $"Nombre: {producto.Nombre} | " + 
                    $"Precio: {producto.Precio} | " + 
                    $"Categoria: {producto.Categoria} | " + 
                    $"Activo: {producto.Activo}"
                );
            }

            Console.WriteLine("\n###### BUSQUEDA POR ID: 2 ######");
            Producto? productoBuscado = repo.ObtenerPorId(2);
            if (productoBuscado != null)
            {
                Console.WriteLine($"Producto encontrado: {productoBuscado.Nombre}");
            }
            else
            {
                Console.WriteLine("No se encontro el producto.");
            }

            Console.WriteLine("\n###### BUSQUEDA POR ID: 6 ######");
            productoBuscado = repo.ObtenerPorId(6);
            if (productoBuscado != null)
            {
                Console.WriteLine($"Producto encontrado: {productoBuscado.Nombre}");
            }
            else
            {
                Console.WriteLine("No se encontro el producto.");
            }


            Console.WriteLine("\n###### FILTRAR POR CATEGORIA: INFORMATICA ######");
            List<Producto> productosCategoria = repo.BuscarPorCategoria("Informatica");
            foreach(Producto producto in productosCategoria)
            {
                Console.WriteLine(
                    $"{producto.Nombre} - ${producto.Precio}");
            }

            Console.WriteLine("\n###### AGREGAR PRODUCTO ######");
            Producto nuevoProd = new Producto
            {
                Id = 5,
                Nombre = "Monitor",
                Precio = 18000,
                Categoria = "Informatica",
                Activo = true
            };

            repo.Agregar(nuevoProd);
            Console.WriteLine("Producto agregado correctamente!");

            Console.WriteLine("\nLISTA ACTUALIZADA:");
            foreach (Producto producto in repo.ObtenerTodos())
            {
                Console.WriteLine(
                    $"{producto.Id} - {producto.Nombre} - ${producto.Precio} - {producto.Categoria}");
            }
        }
    }
}
