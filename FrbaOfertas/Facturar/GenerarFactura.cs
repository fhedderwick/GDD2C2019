using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Facturar
{
    public partial class GenerarFactura : Form
    {
        public GenerarFactura()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Hide();
            IngresoDatos i = new IngresoDatos();
            i.Show();
            this.Close();

        }

        private void b2_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }
    }
}
