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
    public partial class PantallaInicio : Form
    {
        private DataBaseManager _dbm;

        public PantallaInicio(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Hide();
            AltaOferta i = new AltaOferta(_dbm);
            i.Show();
            this.Close();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            Hide();
            CanjearCupon i = new CanjearCupon(_dbm);
            i.Show();
            this.Close();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }
    }
}
