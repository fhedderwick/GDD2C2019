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
    public partial class ListaRol : Form
    {

        const String GET_ROL_DATA_QUERY = "SELECT ROL_ID,ROL_ESTADO FROM MANA.ROL R WHERE R.ROL_NOMBRE = @ROL_NOMBRE";
        const String GET_ROLES_QUERY = "SELECT ROL_NOMBRE FROM MANA.ROL";
        const String GET_FUNC_ROL_QUERY = "SELECT FUNC_ID, FUN_NOMBRE FROM MANA.FUNCIONALIDAD_ROL FR INNER JOIN MANA.FUNCIONALIDAD F ON FR.FR_FUNCIONALIDAD_ID = F.FUNC_ID WHERE FR.FR_ROL_ID = @ROL_ID";

        private DataBaseManager _dbm;
        private int _idSeleccionado;
        private String _nombreSeleccionado;
        private bool _habilitado;

        public ListaRol(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
            cargarRoles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaRol altaRol = new AltaRol(_dbm);
            altaRol.Show();
        }

        private void cargarRoles()
        {
            SqlDataReader resultSet = _dbm.executeSelect(GET_ROLES_QUERY);
            while (resultSet.Read())
            {
                String name = (String)resultSet.GetValue(resultSet.GetOrdinal("ROL_NOMBRE"));
                comboBox1.Items.Add(name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_nombreSeleccionado == null)
            {
                MessageBox.Show("Seleccione un rol.");
            }
            else
            {
                ModificarRol modificarRol = new ModificarRol(this,_dbm, _nombreSeleccionado,_idSeleccionado, _habilitado);
                modificarRol.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_nombreSeleccionado == null)
            {
                MessageBox.Show("Seleccione un rol.");
            }
            else
            {
                BajaRol bajaRol = new BajaRol(this,_dbm, _nombreSeleccionado, _idSeleccionado);
                bajaRol.Show();
            }
        }
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            actualizarValores();
            recargarListaFuncionalidades();
        }


        internal void actualizarValores()
        {
            _nombreSeleccionado = comboBox1.SelectedItem.ToString();
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@ROL_NOMBRE", _nombreSeleccionado);
            SqlDataReader resultSet = _dbm.executeSelect(GET_ROL_DATA_QUERY, map);
            if (resultSet.HasRows)
            {
                resultSet.Read();
                _idSeleccionado = (int)resultSet.GetValue(resultSet.GetOrdinal("ROL_ID"));
                _habilitado = "Habilitado".Equals((String)resultSet.GetValue(resultSet.GetOrdinal("ROL_ESTADO")));
            }
            else
            {
                MessageBox.Show("Se ha producido un error.");
                _nombreSeleccionado = null;
                _idSeleccionado = -1;
                _habilitado = false;
            }
            button3.Enabled = _habilitado;
        }

        private void recargarListaFuncionalidades()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].Name = "Nombre";

            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@ROL_ID", _idSeleccionado.ToString());
            SqlDataReader resultSet = _dbm.executeSelect(GET_FUNC_ROL_QUERY,map);
            while (resultSet.Read())
            {
                int id = (int)resultSet.GetValue(resultSet.GetOrdinal("FUNC_ID"));
                String name = (String)resultSet.GetValue(resultSet.GetOrdinal("FUN_NOMBRE"));

                string[] row = new string[] {id.ToString(), name};
                dataGridView1.Rows.Add(row);

                dataGridView1.Rows[0].ReadOnly = true;
                dataGridView1.Rows[1].ReadOnly = true;
            }
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
