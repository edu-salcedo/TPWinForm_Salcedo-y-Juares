using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Datos;
using Dominio;
namespace WindowsForms
{
    public partial class VentanaAgregar : Form
    {
        private Articulo articulo = null;
        public VentanaAgregar()
        {
            InitializeComponent();
        }
        public VentanaAgregar(Articulo arti)
        {
            InitializeComponent();
            articulo = arti;
        }

        private void VentanaAgregar_Load(object sender, EventArgs e)
        {
            DMarca marca = new DMarca();
            cbMarca.DataSource = marca.listar();    // llena el comno box con la lista de marcas
            cbMarca.ValueMember = "id";
            cbMarca.DisplayMember = "nombre";
            cbMarca.SelectedIndex = -1;
            DCategoria cat = new DCategoria();
            cbCategoria.DataSource = cat.listar();    // llena el comno box con la lista de categorias
            cbCategoria.ValueMember = "id";
            cbCategoria.DisplayMember = "nombre";
            cbCategoria.SelectedIndex = -1;

            if (articulo != null)
            {
                texNombre.Text = articulo.nombre;
                texCodigo.Text = articulo.codigo;
                textDescripcion.Text = articulo.descripcion;
                tbImagen.Text = articulo.imagen;
                texPrecio.Text =Convert.ToString(articulo.precio); 

                cbMarca.SelectedValue = articulo.marca.nombre;
                cbCategoria.SelectedValue = articulo.categoria.nombre;
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo arti = new Articulo();
            DArticulo darti = new DArticulo();
            arti.codigo = texCodigo.Text;                // se asigna el codigo que ingreso en texbox
            arti.nombre = texNombre.Text;               //      "        nombre  "     "      "
            arti.imagen = tbImagen.Text;
            arti.descripcion = textDescripcion.Text;    //      "        descripcion   "     "      "
            arti.marca = (Marca)cbMarca.SelectedItem;
            arti.categoria = (Categoria)cbCategoria.SelectedItem;
            arti.precio= decimal.Parse(texPrecio.Text);

            if (arti.id == 0)
            {
                darti.agregar(arti);                   //  se llama funcion agregar y se manda parametro articulo con los valores ingresados
            }
            else
            {
                darti.editar(arti);                    //se llama funcion etitar
            }
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
