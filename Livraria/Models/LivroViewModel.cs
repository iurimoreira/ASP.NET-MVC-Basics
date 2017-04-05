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
        [Required(ErrorMessage = "Informe o autor")]
        public string autor { get; set; }
        [Required(ErrorMessage = "Informe a editoraa")]
        public string editora { get; set; }
        [Required(ErrorMessage = "Informe o título")]
        public string titulo { get; set; }
        [Required(ErrorMessage = "Informe o ano")]
        public int ano { get; set; }
    }
}