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
            comando.CommandText = "select A.Codigo, A.Nombre,A.Descripcion,A.ImagenUrl,M.Descripcion ,C.Descripcion from ARTICULOS A ,MARCAS M, CATEGORIAS C where A.idmarca=M.id AND	A.IdCategoria=C.id";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Articulo aux = new Articulo();
                aux.codigo = lector.GetString(0);
                aux.nombre = lector.GetString(1);
                aux.descripcion = lector.GetString(2);
                aux.imagen = (string)lector["ImagenUrl"];
                aux.marca = new Marca();
                aux.marca.nombre = lector.GetString(4);
                aux.categoria = new Categoria();
                aux.categoria.nombre = lector.GetString(5);

                lista.Add(aux);
            }
            conexion.Close();
            return lista;


        }
        public void agregar(Articulo nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            conexion.ConnectionString = "data source=DESKTOP-8E98HER\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi ";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)values('" + nuevo.codigo + "', '" + nuevo.nombre + "', '" + nuevo.descripcion + "',@idMarca,@idcat, '" + nuevo.imagen + "', 1)";
            comando.Parameters.AddWithValue("@idMarca", nuevo.marca.id);
            comando.Parameters.AddWithValue("@idcat", nuevo.categoria.id);
            comando.Connection = conexion;

            conexion.Open();
            comando.ExecuteNonQuery();
        }
    }
}
