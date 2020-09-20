using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Datos;

namespace WindowsForms
{
    public partial class ventana2 : Form
    {
        string _nombre;
        public ventana2(string nom)
        {
            InitializeComponent();
            _nombre = nom;
        }

        private void venatna2_Load(object sender, EventArgs e)
        {
            Saludo.Text += _nombre;
            cargar();
        }

        private void btnIvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargar()
        {
            DArticulo arti = new DArticulo();
            dgvlista.DataSource = arti.listar();  // carga el datagridview  con la lista de articulos
            dgvlista.Columns[4].Visible = false;    // ocultamos la columna 4 que contiene la url de imagenes
        }
        private void btnlistar_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VentanaAgregar ven2 = new VentanaAgregar();
            ven2.ShowDialog();
            cargar();                    // despues de de hacer click de agregar se llama a cargar 
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Articulo articulo;
            articulo = (Articulo)dgvlista.CurrentRow.DataBoundItem;

            VentanaAgregar modificar = new VentanaAgregar(articulo);
            modificar.ShowDialog();
            cargar();
        }

        private void dgvlista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo arti = (Articulo)dgvlista.CurrentRow.DataBoundItem; // tre el articulo de la fila seleccionada
                pbImagen.Load(arti.imagen);
            }
            catch
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DArticulo Darti = new DArticulo();
            Darti.eliminar(((Articulo)dgvlista.CurrentRow.DataBoundItem).id); // llamamos funcion elimimar y pasamos el id del articulo de la fila seleccionada
            cargar(); 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)dgvlista.DataSource;  // copia la lista de el datagridview a otra lista

            List<Articulo> listafiltro = lista.FindAll(x=>x.nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));

            dgvlista.DataSource = listafiltro;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
