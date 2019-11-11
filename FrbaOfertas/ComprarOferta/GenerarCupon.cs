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
        private DataBaseManager _dbm;

        public GenerarCupon(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }
      
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Hide();
            CompraExitosa i = new CompraExitosa(_dbm);
            i.Show();
            this.Close();
        }
    }
}
