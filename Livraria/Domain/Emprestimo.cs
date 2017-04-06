using System;

namespace Livraria.Domain
{
    public class Emprestimo
    {
        public int id { get; set; }

        public DateTime dataEmprestimo { get; set; }

        public DateTime dataDevolucao { get; set; }

        public int idLivro { get; set; }

        public string nomeDoLivro { get; set; }
    }
}