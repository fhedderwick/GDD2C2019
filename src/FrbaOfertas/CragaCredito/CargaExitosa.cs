using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaOfertas.CragaCredito
{
    public partial class CargaExitosa : Form
    {
        private DataBaseManager _dbm;
        private string _userId;    

        public CargaExitosa(DataBaseManager dbm, String userId)
        {
            _dbm = dbm;
            _userId = userId;
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Hide();
            CargarCredito i = new CargarCredito(_dbm, _userId);
            i.Show();
            this.Close();
        }
         
        private void t1_TextChanged(object sender, EventArgs e)
        {                       
           
        }
        
    }
}
