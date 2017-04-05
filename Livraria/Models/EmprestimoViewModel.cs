using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class EmprestimoViewModel
    {
        [Required(ErrorMessage = "Informe o Id")]
        public int id { get; set; }


        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Informe a data do empréstimo")]
        public DateTime dataEmprestimo { get; set; }


        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Informe a data de devolução")]
        public DateTime dataDevolucao { get; set; }

        [Required(ErrorMessage = "Informe o identificador do livro")]
        public int idLivro { get; set; }
    }
}