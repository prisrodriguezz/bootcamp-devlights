using System.Globalization;

namespace Bloque_2.DTOs
{
    // representa los datos que se devuelve al cliente
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }  = string.Empty;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Activo { get; set; }
    }
}
