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
    public partial class MenuOferta : Form
    {
        private DataBaseManager _dbm;
        private string _userId;

        public MenuOferta(DataBaseManager dbm, String userId)
        {
            _dbm = dbm;
            _userId = userId;
            InitializeComponent();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Hide();
            AltaOferta i = new AltaOferta(_dbm, _userId);
            i.Show();
            this.Close();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            Hide();
            CanjearCupon i = new CanjearCupon(_dbm, _userId);
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
