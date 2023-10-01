using System.ComponentModel.DataAnnotations;

namespace csharp_api.Models
{
    public class Articulos
    {
        [Key]
        [StringLength(10)]
        public string Articulo { get; set; }
        [Required]
        [StringLength(30)]
        public string Descripcion { get; set; }
    }
}
