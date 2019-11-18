using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Login
{
    public partial class Seguridad : Form
    {
        private DataBaseManager _dbm;
        private String _userId;
        public Seguridad(DataBaseManager dbm, String userId)
        {
            _dbm = dbm;
            _userId = userId;
            InitializeComponent();
        }

        private void b3_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }
    }
}
