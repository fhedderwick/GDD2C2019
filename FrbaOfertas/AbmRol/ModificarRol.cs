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
    public partial class ModificarRol : Form
    {

        const String ENABLE_ROL_QUERY = "UPDATE MANA.ROL SET ROL_ESTADO = 'Habilitado' WHERE ROL_ID = @ROL_ID";
        const String GET_ALL_FUNC_QUERY = "SELECT FUNC_ID, FUN_NOMBRE, ISNULL(FR_ROL_ID,-1) HAB FROM MANA.FUNCIONALIDAD F LEFT JOIN MANA.FUNCIONALIDAD_ROL FR ON F.FUNC_ID = FR.FR_FUNCIONALIDAD_ID AND FR.FR_ROL_ID = @ROL_ID";
        const String DELETE_ROL_FUNC_QUERY = "DELETE FROM MANA.FUNCIONALIDAD_ROL WHERE FR_ROL_ID = @ROL_ID";
        const String INSERT_ROL_FUNC_QUERY = "INSERT INTO MANA.FUNCIONALIDAD_ROL (FR_ROL_ID,FR_FUNCIONALIDAD_ID) VALUES (@ROL_ID,@FUNC_ID)";

        private ListaRol _listaRol;
        private DataBaseManager _dbm;
        private String _rolname;
        private int _rolId;

        public ModificarRol(ListaRol listaRol, DataBaseManager dbm, String rolname, int rolId, bool habilitado)
        {
            _listaRol = listaRol;
            _dbm = dbm;
            _rolname = rolname;
            _rolId = rolId;
            InitializeComponent();
            label1.Text = "Modificando el rol \"" + rolname + "\".";
            button1.Enabled = !habilitado;
            cargarListaFuncionalidades();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("@ROL_ID", _rolId);
            if (1 == _dbm.executeUpdate(ENABLE_ROL_QUERY, map))
            {
                MessageBox.Show("El rol \"" + _rolname + "\" se rehabilitó correctamente. Las relaciones previas con los usuarios no se pueden recuperar y deberá hacerlo manualmente.");
                button1.Enabled = false;
                _listaRol.actualizarValores();
            }
            else
            {
                MessageBox.Show("Error al rehabilitar al rol \"" + _rolname + "\".");
            }
        }

        private void cargarListaFuncionalidades()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].Name = "Nombre";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Set?";
            dataGridView1.Columns.Add(chk);
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;

            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@ROL_ID", _rolId.ToString());
            SqlDataReader resultSet = _dbm.executeSelect(GET_ALL_FUNC_QUERY, map);
            while (resultSet.Read())
            {
                int id = (int)resultSet.GetValue(resultSet.GetOrdinal("FUNC_ID"));
                String name = (String)resultSet.GetValue(resultSet.GetOrdinal("FUN_NOMBRE"));
                bool habilitado = -1 != (int)resultSet.GetValue(resultSet.GetOrdinal("HAB"));

                string[] row = new string[] { id.ToString(), name , habilitado.ToString() };
                dataGridView1.Rows.Add(row);

            }

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map.Add("@ROL_ID", _rolId.ToString());
            //int ret = _dbm.executeUpdate(DELETE_ROL_FUNC_QUERY, map);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                String a = dataGridView1.Rows[i].Cells[2].Value.ToString();
                MessageBox.Show(a);
               /* map.Add("@FUNC_ID", funcid.ToString());
                if (0 == _dbm.executeUpdate(INSERT_ROL_FUNC_QUERY, map))
                {
                    //rollback!
                }*/
            }
            
        }
    }
}
