using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class LivroViewModel
    {
        [Required(ErrorMessage = "Informe o Id")]
        public int id { get; set; }

        [StringLength(40, ErrorMessage = "O campo autor permite um número máximo de 40 caracteres.")]
        [Required(ErrorMessage = "Informe o autor")]
        public string autor { get; set; }

        [StringLength(25, ErrorMessage = "O campo editora permite um número máximo de 25 caracteres.")]
        [Required(ErrorMessage = "Informe a editora")]
        public string editora { get; set; }

        [StringLength(140, ErrorMessage = "O campo título permite um número máximo de 140 caracteres.")]
        [Required(ErrorMessage = "Informe o título")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "Informe o ano")]
        public int ano { get; set; }
    }
}