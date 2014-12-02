using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TreinoMVC.Repositorio
{
   public class Conexao
    {
       public static SqlConnection Conectar()
       {
           var conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["CNS1"].ConnectionString);
         conexao.Open();
           return conexao;
       }

       public static void Crud(SqlCommand cm)
       {
           var con = Conectar();
           cm.Connection = con;
           cm.ExecuteNonQuery();
           con.Close();
       }

       public static SqlDataReader Buscar(SqlCommand cm)
       {
           var con = Conectar();
           cm.Connection = con;
           var dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
           return dr;
       }
      
    }
}
