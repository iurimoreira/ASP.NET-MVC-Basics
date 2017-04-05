using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Domain
{
    public class Emprestimo
    {
        public int id { get; set; }

        public DateTime dataEmprestimo { get; set; }

        public DateTime dataDevolucao { get; set; }

        public int idLivro { get; set; }
    }
}