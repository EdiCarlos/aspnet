using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinoMVC.Modelo
{
    public class Livro
    {
        public int LivroId { get; set; }

        public string Titulo { get; set; }

        public Autor Autor { get; set; }


        public Livro()
        {
            Autor = new Autor();
        }
    }
}
