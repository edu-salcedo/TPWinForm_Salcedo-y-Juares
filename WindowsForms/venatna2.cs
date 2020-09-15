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

namespace WindowsForms
{
    public partial class venatna2 : Form
    {
        public venatna2()
        {
            InitializeComponent();
        }

        private void venatna2_Load(object sender, EventArgs e)
        {
            
        }

        private void btnIvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlistar_Click(object sender, EventArgs e)
        {
            lista lista = new lista();
            lista.ShowDialog();
        }
    }
}
