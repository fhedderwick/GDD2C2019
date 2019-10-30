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

namespace FrbaOfertas.AbmRol
{
    public partial class AltaRol : Form
    {

        const String EXISTS_ROL_QUERY = "SELECT R.ROL_ID FROM MANA.ROL R WHERE R.ROL_NOMBRE = @ROL_NOMBRE";
        const String ADD_ROL_QUERY = "INSERT INTO MANA.ROL (ROL_NOMBRE,ROL_ESTADO) VALUES (@ROL_NOMBRE,'Habilitado')";

        private DataBaseManager _dbm;

        public AltaRol(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String inputText = textBox1.Text;
            if (!checkExistence(inputText))
            {
                if (addRol(inputText))
                {
                    MessageBox.Show("El rol \"" + inputText + "\" fue creado con éxito.");
                }
                else
                {
                    MessageBox.Show("No se pudo crear el rol \"" + inputText + "\".");
                }
            }
            else
            {
                MessageBox.Show("El rol \"" + inputText + "\" ya existe. Elija otro nombre.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool checkExistence(String nombre)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@ROL_NOMBRE", nombre);
            SqlDataReader resultSet = _dbm.executeSelect(EXISTS_ROL_QUERY, map);
            return resultSet.HasRows;
        }

        private bool addRol(String nombre)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("@ROL_NOMBRE", nombre);
            return 1 == _dbm.executeUpdate(ADD_ROL_QUERY, map);
        }
    }
}
