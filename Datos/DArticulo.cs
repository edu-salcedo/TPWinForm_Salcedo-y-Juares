using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Datos
{
    public class DArticulo
    {
        public List<Articulo> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulo> lista = new List<Articulo>();
       
            conexion.ConnectionString = "data source=DESKTOP-8E98HER\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi ";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select Codigo,Nombre,Descripcion from ARTICULOS";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while(lector.Read())
            {
                Articulo aux = new Articulo();
                aux.codigo = lector.GetString(0);
                aux.nombre = lector.GetString(1);
                aux.descripcion = lector.GetString(2);
              
                lista.Add(aux);
            }
            conexion.Close();
            return lista;


        }
    }
}
