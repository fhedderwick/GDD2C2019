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
        private DataBaseManager _dbm;

        public GenerarFactura(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Hide();
            IngresoDatos i = new IngresoDatos(_dbm);
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
