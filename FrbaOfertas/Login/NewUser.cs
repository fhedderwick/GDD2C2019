using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Login
{
    public partial class NewUser : Form
    {

        const String GET_ROLES_QUERY = "SELECT ROL_ID, ROL_NOMBRE FROM MANA.ROL R WHERE R.ROL_ESTADO = 'Habilitado'";

        DataBaseManager _dbm;
        String _username;

        public NewUser(DataBaseManager dbm, String username)
        {
            _dbm = dbm;
            _username = username;
            InitializeComponent();
            textBox2.Text = _username;
            SqlDataReader resultSet = _dbm.executeSelect(GET_ROLES_QUERY);
            while (resultSet.Read())
            {
                int id = (int)resultSet.GetValue(resultSet.GetOrdinal("ROL_ID"));
                String name = (String)resultSet.GetValue(resultSet.GetOrdinal("ROL_NOMBRE"));
                comboBox1.Items.Add(name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Segun el rol elegido se muestra NuevoCliente o NewProveedor");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
