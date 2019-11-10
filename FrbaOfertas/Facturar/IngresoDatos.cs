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
    public partial class IngresoDatos : Form
    {
        public IngresoDatos()
        {
            InitializeComponent();
        }

        private void Facturar_Click(object sender, EventArgs e)
        {
            if (this.camposObligatoriosCompletos() == true)
            {
                Hide();
                GenerarFactura i = new GenerarFactura();
                i.Show();
                this.Close();
            }
            else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void VolverAtras_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private bool camposObligatoriosCompletos()
        {
            return tb1.Text.Length != 0 && tb2.Text.Length != 0 && tb3.Text.Length != 0;
        }
    }
}
