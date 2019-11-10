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
    public partial class GenerarCupon : Form
    {
        public GenerarCupon()
        {
            InitializeComponent();
        }
      
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Hide();
            CompraExitosa i = new CompraExitosa();
            i.Show();
            this.Close();
        }
    }
}
