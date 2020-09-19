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

            conexion.ConnectionString = "data source=T480S-JMJ\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi ";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select A.Codigo, A.Nombre, A.Descripcion, M.Descripcion, C.Descripcion from ARTICULOS as A, MARCAS AS M, CATEGORIAS AS C WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Articulo aux = new Articulo();
                aux.codigo = lector.GetString(0);
                aux.nombre = lector.GetString(1);
                aux.descripcion = lector.GetString(2);

                aux.marca = new Marca();
                aux.marca.nombre = lector.GetString(3);

                aux.categoria = new Categoria();
                aux.categoria.nombre = lector.GetString(4);

                lista.Add(aux);
            }
            lector.Close();
            conexion.Close();
            return lista;
        } 
        
        public void alta(Articulo nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            conexion.ConnectionString = "data source=T480S-JMJ\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi ";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenURL,Precio) VALUES ('" + nuevo.codigo + "','" + nuevo.nombre + "','" + nuevo.descripcion + "',@IdMarca,@IdCategoria,'" + nuevo.imagenURL + "','" + nuevo.precio + "')";
            comando.Parameters.AddWithValue("@IdMarca", nuevo.marca.id);
            comando.Parameters.AddWithValue("@IdCategoria", nuevo.categoria.id);
            comando.Connection = conexion;

            conexion.Open();
            comando.ExecuteNonQuery();
        }
    }
}
