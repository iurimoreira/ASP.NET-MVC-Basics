using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria.Domain
{
    public class Livro
    {
        public int id { get; set; }

        public string autor { get; set; }

        public string editora { get; set; }

        public string titulo { get; set; }

        public int ano { get; set; }
    }
}