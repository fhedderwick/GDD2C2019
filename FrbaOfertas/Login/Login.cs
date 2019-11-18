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
                String estado = _dbm.getStringFromResultSet(resultSet, "USUARIO_ESTADO");
                if ("Habilitado".Equals(estado))
                {
                    Password passwordDialog = new Password(this, _dbm, _dbm.getIntFromResultSet(resultSet, "USER_ID"), _dbm.getStringFromResultSet(resultSet, "USER_PASSWORD"), _dbm.getIntFromResultSet(resultSet, "USER_INTENTOS_FALLIDOS"));
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
