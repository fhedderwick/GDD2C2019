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
    public partial class SeguridadAdministrativo : Form
    {
        private DataBaseManager _dbm;
        private String _userId;

        public SeguridadAdministrativo(DataBaseManager dbm, String userId)
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

        private void b2_Click(object sender, EventArgs e)  //Cambiar Password
        {
            Hide();
            ModificacionPassword i = new ModificacionPassword(_dbm);
            i.Show();
            
        }

        private void b1_Click(object sender, EventArgs e)  //Baja Usuario
        {
            Hide();
            BajaUser i = new BajaUser(_dbm);
            i.Show();
        }
    }
}
