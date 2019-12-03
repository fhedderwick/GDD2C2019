using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FrbaOfertas.Login
{
    public partial class Password : Form
    {
        const String CONT_UPDATE_QUERY = "UPDATE MANA.USUARIO SET USER_INTENTOS_FALLIDOS = @CONT WHERE USER_ID = @UserId";

        Login _loginForm;
        String _password;
        int _userId;
        DataBaseManager _dbm;
        int _count;        
        public Password(Login loginForm, DataBaseManager dbm, int userId, String password, int count)
        {
            _dbm = dbm;
            _userId = userId;
            _loginForm = loginForm;                       
            _password = password;
            _count = count;            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passwordIngresado = maskedTextBox1.Text;
            Dictionary<string, object> mapp = new Dictionary<string, object>();
            mapp.Add("@Password", passwordIngresado);           
            _dbm.executeProcedure("Mana.ValidarPassword", mapp);
            passwordIngresado = _dbm.executeSelectString("SELECT USER_PASSWORD FROM MANA.TT");
            if (_count >= 3)
            {
                MessageBox.Show("El usuario esta bloqueado por poner mal 3 veces la clave.");
            }
            else if (_password.Equals((passwordIngresado)))
            {              
                _count = 0;
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("@CONT", _count);
                map.Add("@UserId", _userId);
                _dbm.executeUpdate(CONT_UPDATE_QUERY, map);             
                _loginForm.Hide();
                PantallaPrincipalUsuario pantallaPrincipalUsuario = new PantallaPrincipalUsuario(_dbm,_userId.ToString());
                pantallaPrincipalUsuario.Show();
                this.Hide();
            }
            else
            {
                _count++;

                if (_count == 3)
                {
                    Dictionary<string, object> m = new Dictionary<string, object>();
                    m.Add("@UserId", _userId);
                    _dbm.executeProcedure("Mana.BajaUsuario", m);
                    MessageBox.Show("Contraseña invalida. El usuario esta bloqueado por poner mal 3 veces la clave.");
                }
                else
                {
                    Dictionary<string, object> map = new Dictionary<string, object>();
                    map.Add("@CONT", _count);
                    map.Add("@UserId", _userId);
                    _dbm.executeUpdate(CONT_UPDATE_QUERY, map);
                    MessageBox.Show("Contraseña invalida.");
                }
                
            }
            _dbm.executeProcedure("Mana.BorrarTT");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }       
    }
}
