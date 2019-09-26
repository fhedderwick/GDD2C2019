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

        const String USER_QUERY = "SELECT USER_USERNAME, USER_PASSWORD, USER_INTENTOS_FALLIDOS FROM MANA.USUARIO U "
                  //+ " LEFT JOIN MANA.USUARIO_ROL UR ON UR.USUARIO_ID = U.USERNAME AND UR.FUNCIONALIDAD = 'administrador' "
                  + " WHERE U.USER_USERNAME = @USER_NOMBRE";

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
                if (false) //si es administrador
                {
                    Password passwordDialog = new Password(this, _dbm, (String)resultSet.GetValue(resultSet.GetOrdinal("PASSWORD")), (int)resultSet.GetValue(resultSet.GetOrdinal("INTENTOS_FALLIDOS")));
                    passwordDialog.ShowDialog();
                }
                else
                {
                    PantallaPrincipalUsuario pantallaPrincipalUsuario = new PantallaPrincipalUsuario(_dbm);
                    pantallaPrincipalUsuario.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("El usuario especificado no existe.");
            }
        }
    }
}
