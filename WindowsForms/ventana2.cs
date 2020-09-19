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
        }

        private void btnIvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargar()
        {
            DArticulo arti = new DArticulo();
            dgvlista.DataSource = arti.listar();
            dgvlista.Columns[3].Visible = false;
        }
        private void btnlistar_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VentanaAgregar ven2 = new VentanaAgregar();
            ven2.ShowDialog();
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
                Articulo arti = (Articulo)dgvlista.CurrentRow.DataBoundItem;
                pbImagen.Load(arti.imagen);
            }
            catch
            {

            }
        }
    }
}
