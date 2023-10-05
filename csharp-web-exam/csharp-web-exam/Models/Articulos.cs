using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace csharp_web.Models
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