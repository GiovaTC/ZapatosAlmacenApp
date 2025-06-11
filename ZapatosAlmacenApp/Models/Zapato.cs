using System.ComponentModel.DataAnnotations;

namespace ZapatosAlmacenApp.Models
{
    public class Zapato
    {
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Range(20, 50)]
        public int Talla { get; set; }

        public string Color { get; set; }

        [Range(0, int.MaxValue)]
        public int Cantidad { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }
    }
}
