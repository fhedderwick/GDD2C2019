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
        private string id;       

        public CargaExitosa(DataBaseManager dbm, string clienteId)
        {
            _dbm = dbm;
            id = clienteId;
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
            CargarCredito i = new CargarCredito(_dbm);
            i.Show();
            this.Close();
        }
         
        private void t1_TextChanged(object sender, EventArgs e)
        {                       
           
        }
        /*
        private string saldo()
        {
            string query = "SELECT C.CLI_SALDO FROM CLIENTE C WHERE CLI_ID = @ClienteId";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@ClienteId", id);
            SqlDataReader importe;
            importe = _dbm.executeSelect(query, map);
            while (importe.Read())
            {
               
            }
            return "Hola";
        }
       */
    }
}
