using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CrearOferta
{
    public partial class Generacion_Exitosa : Form
    {
        public Generacion_Exitosa()
        {
            InitializeComponent();
        }

        
        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnGenerarNuevaOferta_Click(object sender, EventArgs e)
        {
            Hide();
            AltaOferta i = new AltaOferta();
            i.Show();
            this.Close();
        }

        
    }
}
