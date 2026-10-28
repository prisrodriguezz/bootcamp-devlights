using System.ComponentModel.DataAnnotations;

namespace Bloque_2.DTOs
{
    // representa los datos que se reciben en una solicitud POST o PUT
    public class CreateProductoDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)] // entre 3 y 100 caracteres
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(0.01, 999999999)] // precio mayor que cero
        public decimal Precio { get; set; }

        [Required]
        public string Categoria { get; set; } = string.Empty;
    }
}
