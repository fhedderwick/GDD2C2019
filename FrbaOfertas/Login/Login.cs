using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Login
{
    public partial class Login : Form
    {

        const String USER_QUERY = "SELECT * FROM MANA.USUARIO U WHERE U.USER_USERNAME = @USER_NOMBRE";

        private DataBaseManager _dbm;

        public Login(DataBaseManager dbm)
        {
            this._dbm = dbm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String inputText = this.textBox1.Text;
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@USER_NOMBRE", inputText);
            SqlDataReader resultSet = _dbm.executeSelect(USER_QUERY, map);
            if (resultSet.HasRows)
            {
                resultSet.Read();
                if ("Habilitado".Equals((String)resultSet.GetValue(resultSet.GetOrdinal("USUARIO_ESTADO"))))
                {
                    Password passwordDialog = new Password(this, _dbm, (int)resultSet.GetValue(resultSet.GetOrdinal("USER_ID")), (String)resultSet.GetValue(resultSet.GetOrdinal("USER_PASSWORD")), (int)resultSet.GetValue(resultSet.GetOrdinal("USER_INTENTOS_FALLIDOS")));
                    passwordDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("El usuario especificado se encuentra deshabilitado.");
                }
            }
            else
            {
                UsuarioInexistente usuarioInexistenteDialog = new UsuarioInexistente(this, _dbm, inputText);
                usuarioInexistenteDialog.ShowDialog();
            }
        }
    }
}
