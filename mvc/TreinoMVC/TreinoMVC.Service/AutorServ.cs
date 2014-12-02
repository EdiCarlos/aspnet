using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TreinoMVC.DAL;
using TreinoMVC.Modelo;

namespace TreinoMVC.Service
{
   public class AutorServ
   {
       private readonly AutorDAL autorDal;

       public AutorServ()
       {
           autorDal = new AutorDAL();
       }

       public void Salvar(Autor autor)
       {
           autorDal.Salvar(autor);
       }

       public void Excluir(int id)
       {
           autorDal.Excluir(id);
       }

       public Autor BuscarPorId(int id)
       {
        return  autorDal.BuscarPorId(id);
       }

       public IList<Autor> ListarTodos()
       {
         return autorDal.ListarTodos();
       }
    }
}
