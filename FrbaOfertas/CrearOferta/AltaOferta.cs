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
    public partial class AltaOferta : Form
    {
        public AltaOferta()
        {
            InitializeComponent();
        }

        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            Hide();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            if (this.camposObligatoriosCompletos() == true)
            {                                
                    Hide();
                  // Pantalla siguiente  
                  //  i.Show();
                    this.Close();                                
            }
            else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private bool camposObligatoriosCompletos()
        {
            return tbDescripcion.Text.Length != 0 && tbPrecioOferta.Text.Length != 0 && tbPrecioLista.Text.Length != 0 &&
                   tbCantidadDisponible.Text.Length != 0 && tbMaximoUnidadCliente.Text.Length != 0 && tbProveedorId.Text.Length != 0;
        }
    }
}
