using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ComprarOferta
{
    public partial class CompraExitosa : Form
    {
        public CompraExitosa()
        {
            InitializeComponent();
        }

        private void btnComprarNuevaOferta_Click(object sender, EventArgs e)
        {
            Hide();
            OfertasPublicadas i = new OfertasPublicadas();
            i.Show();
            this.Close();
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Hide();
        }

        
    }
}
