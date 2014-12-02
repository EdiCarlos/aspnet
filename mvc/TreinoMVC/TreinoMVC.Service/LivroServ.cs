using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinoMVC.DAL;
using TreinoMVC.Modelo;

namespace TreinoMVC.Service
{
   public class LivroServ
   {
       private readonly LivroDAL livroDal;

       public LivroServ()
       {
           livroDal = new LivroDAL();
       }

       public void Salvar(Livro livro)
       {
           livroDal.Salvar(livro);
       }

       public void Excluir(int id)
       {
           livroDal.Excluir(id);
       }

       public Livro BuscarPorId(int id)
       {
          return livroDal.BuscarPorId(id);
       }

       public IList<Livro> ListarTodos()
       {
           return livroDal.ListarTodos();
       }
   }
}
