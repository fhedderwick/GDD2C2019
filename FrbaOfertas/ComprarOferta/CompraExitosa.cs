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
    public partial class CompraExitosa : Form
    {
        private DataBaseManager _dbm;
        private string _userId;

        public CompraExitosa(DataBaseManager dbm, String userId)
        {
            _dbm = dbm;
            _userId = userId;
            InitializeComponent();
        }

        private void btnComprarNuevaOferta_Click(object sender, EventArgs e)
        {
            Hide();
            OfertasPublicadas i = new OfertasPublicadas(_dbm, _userId);
            i.Show();
            this.Close();
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        
    }
}
