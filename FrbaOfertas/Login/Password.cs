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
    public partial class Password : Form
    {
        const String CONT_UPDATE_QUERY = "UPDATE MANA.USUARIO SET INTENTOS_FALLIDOS = @CONT";

        Login _loginForm;
        String _password;
        DataBaseManager _dbm;
        int _count;
        public Password(Login loginForm, DataBaseManager dbm, String password, int count)
        {
            _dbm = dbm;
            _loginForm = loginForm;
            _password = password;
            InitializeComponent();
            _count = count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_count >= 3)
            {
                _count = 3;
                MessageBox.Show("El usuario esta bloqueado por poner mal 3 veces la clave.");
            }
            else if (_password.Equals(maskedTextBox1.Text))
            {
                _count = 0;
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("@CONT", _count);
                _dbm.executeUpdate(CONT_UPDATE_QUERY, map);
                _loginForm.Hide();
                PantallaPrincipalAdministrador pantallaPrincipalAdministrador = new PantallaPrincipalAdministrador(_dbm);
                pantallaPrincipalAdministrador.Show();
                this.Hide();
            }
            else
            {
                _count++;
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("@CONT", _count);
                _dbm.executeUpdate(CONT_UPDATE_QUERY, map);
                MessageBox.Show("Contraseña invalida.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
