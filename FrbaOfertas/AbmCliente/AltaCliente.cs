using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class AltaCliente : Form
    {
        private DataBaseManager _dbm;

        public AltaCliente(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                MessageBox.Show("hacer el insert");
            }
            
        }

        private bool validarDatos()
        {
            return true;
        }
    }
}
