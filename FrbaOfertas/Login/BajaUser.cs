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
    public partial class BajaUser : Form
    {
        private DataBaseManager _dbm;

        public BajaUser(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  //Cancelar
            Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {  //Dar de Baja

        }
    }
}
