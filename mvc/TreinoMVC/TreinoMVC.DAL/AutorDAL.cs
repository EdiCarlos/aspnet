using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TreinoMVC.Modelo;
using TreinoMVC.Repositorio;

namespace TreinoMVC.DAL
{
   public class AutorDAL
    {
       private void Inserir(Autor autor)
       {
           try
           {
               var comando = new SqlCommand
               {
                   CommandType = CommandType.Text,
                   CommandText = "INSERT INTO autor(nome) " +
                                 "VALUES (@Nome)"
               };

               comando.Parameters.AddWithValue("@Nome", autor.Nome);

               Conexao.Crud(comando);
           }
           catch (Exception ex)
           {

               throw new Exception("Erro ao inserir dados. " + ex.Message);
           }
       }

       private void Alterar(Autor autor)
       {
           try
           {
               var comando = new SqlCommand
               {
                   CommandType = CommandType.Text,
                   CommandText = "UPDATE autor SET nome=@Nome " +
                                 "WHERE autorId = @AutorId"
               };

               comando.Parameters.AddWithValue("@Nome", autor.Nome);
               comando.Parameters.AddWithValue("@AutorId", autor.AutorId);

               Conexao.Crud(comando);
           }
           catch (Exception ex)
           {

               throw new Exception("Erro ao alterar dados. " + ex.Message);
           }
       }

       public void Salvar(Autor autor)
       {
           if (autor.AutorId > 0)
           {
               Alterar(autor);
           }
           else
           {
               Inserir(autor);
           }
       }


       public void Excluir(int id)
       {
           try
           {
               var comando = new SqlCommand
               {
                   CommandType = CommandType.Text,
                   CommandText = "DELETE FROM autor WHERE autorId = @AutorID"
               };
               comando.Parameters.AddWithValue("@AutorId", id);
               Conexao.Crud(comando);

           }
           catch (Exception ex)
           {

               throw new Exception("Erro ao excluir dados. " + ex.Message);
           }
       }

       public IList<Autor> ListarTodos()
       {
           try
           {
               var comando = new SqlCommand
               {
                   CommandType = CommandType.Text,
                   CommandText = "SELECT autorId, nome " +
                                 "FROM autor "
               };

               SqlDataReader dr = Conexao.Buscar(comando);

               IList<Autor> autores = new List<Autor>();

               if (dr.HasRows)
               {
                   while (dr.Read())
                   {
                       var autor = new Autor();
                       autor.AutorId = (int)dr["autorId"];
                       autor.Nome = (string)dr["nome"];
                      

                       autores.Add(autor);
                   }
               }
               else
               {
                   autores = null;
               }
               return autores;
           }
           catch (Exception ex)
           {
               throw new Exception("Erro ao buscar dados. " + ex.Message);
           } 
       }



       public Autor BuscarPorId(int id)
       {
           try
           {
               var comando = new SqlCommand();
               comando.CommandType = CommandType.Text;
               comando.CommandText = "SELECT autorId, nome " +
                                     "FROM autor " +
                                     "WHERE autorId = @Id";

               comando.Parameters.AddWithValue("@Id", id);

               SqlDataReader dr = Conexao.Buscar(comando);

               var autor = new Autor();

               if (dr.HasRows)
               {
                   dr.Read();
                   autor.AutorId = (int)dr["autorId"];
                   autor.Nome = (string)dr["nome"];
               }
               else
               {
                   autor = null;
               }
               return autor;
           }
           catch (Exception ex)
           {
               throw new Exception("Erro ao buscar dados. " + ex.Message);
           }
       }
    }
}
