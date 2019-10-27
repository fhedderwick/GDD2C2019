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
    public partial class UsuarioInexistente : Form
    {
        Login _loginForm;
        DataBaseManager _dbm;
        String _username;

        public UsuarioInexistente(Login loginForm,DataBaseManager dbm,String username)
        {
            _loginForm = loginForm;
            _dbm = dbm;
            _username = username;
            InitializeComponent();
            label3.Text = _username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser(_dbm,_username);
            newUser.Show();
        }
    }
}
