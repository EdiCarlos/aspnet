using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinoMVC.Modelo;
using TreinoMVC.Repositorio;

namespace TreinoMVC.DAL
{
    public class LivroDAL
    {
        private void Inserir(Livro livro)
        {
            try
            {
                var comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "INSERT INTO Livro(titulo, autorId) " +
                                  "VALUES (@Titulo, @AutorId)"
                };

                comando.Parameters.AddWithValue("@Titulo", livro.Titulo);
                comando.Parameters.AddWithValue("@AutorId", livro.Autor.AutorId);

                Conexao.Crud(comando);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir dados. " + ex.Message);
            }
        }

        private void Alterar(Livro livro)
        {
            try
            {
                var comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "UPDATE Livro SET titulo=@Titulo, autorId=@AutorID " +
                                  "WHERE IdLivro = @LivroId"
                };

                comando.Parameters.AddWithValue("@Titulo", livro.Titulo);
                comando.Parameters.AddWithValue("@AutorId", livro.Autor.AutorId);
                comando.Parameters.AddWithValue("@LivroId", livro.LivroId);

                Conexao.Crud(comando);
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao alterar dados. " + ex.Message);
            }
        }

        public void Salvar(Livro livro)
        {
            if (livro.LivroId > 0)
            {
                Alterar(livro);
            }
            else
            {
                Inserir(livro);
            }
        }


        public void Excluir(int id)
        {
            try
            {
                var comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "DELETE FROM Livro WHERE IdLivro = @LivroId"
                };
                comando.Parameters.AddWithValue("@LivroId", id);
                Conexao.Crud(comando);

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir dados. " + ex.Message);
            }
        }

        public IList<Livro> ListarTodos()
        {
            try
            {
                var comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "SELECT IdLivro, titulo, autorId " +
                                  "FROM Livro "
                };

                SqlDataReader dr = Conexao.Buscar(comando);

                IList<Livro> livros = new List<Livro>();
                var autor = new AutorDAL();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        var livro = new Livro();
                        livro.LivroId = (int)dr["IdLivro"];
                        livro.Titulo = (string)dr["titulo"];
                        livro.Autor = autor.BuscarPorId((int)dr["autorId"]);


                        livros.Add(livro);
                    }
                }
                else
                {
                    livros = null;
                }
                return livros;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar dados. " + ex.Message);
            }
        }



        public Livro BuscarPorId(int id)
        {
            try
            {
                var comando = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = "SELECT IdLivro, titulo, autorId " +
                                  "FROM Livro " +
                                  "WHERE IdLivro = @Id"
                };
                ;

                comando.Parameters.AddWithValue("@Id", id);

                SqlDataReader dr = Conexao.Buscar(comando);

                var livro = new Livro();
                var autor = new AutorDAL();
                if (dr.HasRows)
                {
                    dr.Read();
                    livro.LivroId = (int)dr["IdLivro"];
                    livro.Titulo = (string)dr["titulo"];
                    livro.Autor = autor.BuscarPorId((int)dr["autorId"]);
                }
                else
                {
                    livro = null;
                }
                return livro;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar dados. " + ex.Message);
            }
        }
    }
}
