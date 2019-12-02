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
        const String GET_ROLES_QUERY = "SELECT ROL_ID ID, ROL_NOMBRE NOMBRE FROM MANA.ROL WHERE ROL_NOMBRE = @RolCliente or ROL_NOMBRE = @RolProv";
        
        DataBaseManager _dbm;
        String _username;

        public NewUser(DataBaseManager dbm, String username) : this(dbm, username, null) { }

        public NewUser(DataBaseManager dbm, String username, Par rol)
        {
            _dbm = dbm;
            _username = username;
            InitializeComponent();
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.ValueMember = "Value";
            textBox2.Text = _username;
            if (rol != null)
            {
                List<Par> list = new List<Par>();
                list.Add(new Par() { Text = rol.Text, Value = rol.Value });
                comboBox1.DataSource = list;
                comboBox1.Enabled = false;
            }
            else 
            {
                this.loadRol();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String user = textBox2.Text;
            String pass = maskedTextBox1.Text;
            String passRep = maskedTextBox2.Text;
            String rolNombre = comboBox1.Text;

            String rolId = comboBox1.SelectedValue.ToString();
            
            if (!checkUser(user) || !checkPass(pass, passRep))
            {
                return;
            }
            if (rolNombre.Length == 0)
            {
                MessageBox.Show("Elija un rol");
            }
            else if ("Cliente".Equals(rolNombre))
            {
                AltaYModifCliente altaCliente = new AltaYModifCliente(_dbm, user, pass, rolId);
                altaCliente.Show();
                Close();
            }
            else if ("Proveedor".Equals(rolNombre))
            {
                AltaYModifProveedor altaProveedor = new AltaYModifProveedor(_dbm, user, pass, rolId);
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

        private void loadRol()
        {
            string rolCliente = "Cliente";
            string rolProv = "Proveedor";
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@RolCliente", rolCliente);
            map.Add("@RolProv", rolProv);
            SqlDataReader resultSet = _dbm.executeSelect(GET_ROLES_QUERY, map);
            //this.comboBox1.DisplayMember = "Text";
            //this.comboBox1.ValueMember = "Value";
            List<Par> list = new List<Par>();

            while (resultSet.Read())
            {
                list.Add(new Par() { Text = resultSet["NOMBRE"].ToString(), Value = resultSet["ID"].ToString() });
            }
            comboBox1.DataSource = list;
        }

    }

}
