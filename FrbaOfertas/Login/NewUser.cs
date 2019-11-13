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
using FrbaOfertas.AbmCliente;
using FrbaOfertas.AbmProveedor;

namespace FrbaOfertas.Login
{
    public partial class NewUser : Form
    {
        const String USER_EXISTS_QUERY = "SELECT * FROM MANA.USUARIO WHERE USER_USERNAME = @username";
        const String GET_ROLES_QUERY = "SELECT ROL_ID, ROL_NOMBRE FROM MANA.ROL R WHERE R.ROL_ESTADO = 'Habilitado'";

        DataBaseManager _dbm;
        String _username;

        public NewUser(DataBaseManager dbm, String username) : this(dbm, username, "") { }
        public NewUser(DataBaseManager dbm, String username, String rol)
        {
            _dbm = dbm;
            _username = username;
            InitializeComponent();
            textBox2.Text = _username;
            if (rol.Length == 0)
            {
                SqlDataReader resultSet = _dbm.executeSelect(GET_ROLES_QUERY);
                while (resultSet.Read())
                {
                    int id = (int)resultSet.GetValue(resultSet.GetOrdinal("ROL_ID"));
                    String name = (String)resultSet.GetValue(resultSet.GetOrdinal("ROL_NOMBRE"));
                    comboBox1.Items.Add(name);
                }
            }
            else
            {
                textBox2.Enabled = true;
                comboBox1.Items.Add(rol);
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String user = textBox2.Text;
            String pass = maskedTextBox1.Text;
            String passRep = maskedTextBox2.Text;
            String eleccion = comboBox1.Text;
            if (!checkUser(user) || !checkPass(pass, passRep))
            {
                return;
            }
            if (eleccion.Length == 0)
            {
                MessageBox.Show("Elija un rol");
            }
            else if ("Cliente".Equals(eleccion))
            {
                AltaYModifCliente altaCliente = new AltaYModifCliente(_dbm, user, pass);
                altaCliente.Show();
                Close();
            }
            else if ("Proveedor".Equals(eleccion))
            {
                AltaProveedor altaProveedor = new AltaProveedor(_dbm);
                altaProveedor.Show();
                Close();
            }
        }

        private bool checkUser(String user)
        {
            if (user.Length == 0)
            {
                MessageBox.Show("Complete el nombre de usuario.");
                return false;
            }
            if (existeEnBaseDeDatos(user))
            {
                MessageBox.Show("El nombre de usuario elegido ya existe. Elija otro.");
                return false;
            }
            return true;
        }

        private bool existeEnBaseDeDatos(String user)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@username", user);
            return _dbm.executeSelect(USER_EXISTS_QUERY, map).HasRows;
        }

        private bool checkPass(String pass, String pass2)
        {
            if (pass.Length == 0 || pass2.Length == 0)
            {
                MessageBox.Show("Complete el password.");
                return false;
            }
            if (!pass.Equals(pass2))
            {
                MessageBox.Show("Los password no coinciden.");
                return false;
            }
            if (!cumpleCaracteristicas(pass))
            {
                MessageBox.Show("El password debe tener numeros letras y todo eso.");
                return false;
            }
            return true;
        }

        private bool cumpleCaracteristicas(String pass)
        {
            return true; //chequear el largo y si tiene mayus/minus, numeros y todo eso
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
