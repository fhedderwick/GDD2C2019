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

namespace FrbaOfertas.AbmCliente
{

    public partial class ListaCliente : Form
    {

        private String GET_CLIENTES_QUERY = "SELECT C.CLI_ID ID, C.CLI_NOMBRE NOMBRE, C.CLI_APELLIDO APELLIDO, C.CLI_DNI DNI, C.CLI_MAIL MAIL, C.CLI_TELEFONO TELEFONO, C.CLI_DIRECCION DIRECCION, C.CLI_CIUDAD CIUDAD, C.CLI_FECHA_NACIMIENTO FECHA, C.CLI_SALDO SALDO, C.CLI_ESTADO ESTADO FROM MANA.CLIENTE C";
        private String WHERE_EXACT_QUERY = " WHERE C.CLI_NOMBRE = @nombre OR C.CLI_APELLIDO = @apellido OR C.CLI_MAIL = @mail OR C.CLI_DIRECCION = @direccion OR C.CLI_CIUDAD = @ciudad";
        //private String WHERE_EXACT_QUERY = " WHERE C.CLI_NOMBRE = @nombre OR C.CLI_APELLIDO = @apellido OR C.CLI_DNI = @dni OR C.CLI_MAIL = @mail OR C.CLI_TELEFONO = @telefono OR C.CLI_DIRECCION = @direccion OR C.CLI_CIUDAD = @ciudad";
        private String WHERE_NON_EXACT_QUERY = " WHERE C.CLI_NOMBRE LIKE @nombre OR C.CLI_APELLIDO LIKE @apellido OR C.CLI_MAIL LIKE @mail OR C.CLI_DIRECCION LIKE @direccion OR C.CLI_CIUDAD LIKE @ciudad";
        //private String WHERE_NON_EXACT_QUERY = " WHERE C.CLI_NOMBRE LIKE @nombre OR C.CLI_APELLIDO LIKE @apellido OR C.CLI_DNI LIKE @dni OR C.CLI_MAIL LIKE @mail OR C.CLI_TELEFONO LIKE @telefono OR C.CLI_DIRECCION LIKE @direccion OR C.CLI_CIUDAD LIKE @ciudad";

        private DataBaseManager _dbm;

        public ListaCliente(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaCliente altaCliente = new AltaCliente(_dbm);
            altaCliente.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool /*borrar esta linea*/ algunoSeleccionado = true;
            if (algunoSeleccionado)
            {
                BajaCliente bajaCliente = new BajaCliente(_dbm);
                bajaCliente.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            llenarListado();
        }

        private void llenarListado()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            StringBuilder query = new StringBuilder();
            query.Append(GET_CLIENTES_QUERY);
            if(textBox1.TextLength != 0){
                String texto = textBox1.Text;
                if (!checkBox1.Checked)
                {
                    texto = "%" + texto + "%";
                    query.Append(WHERE_NON_EXACT_QUERY);
                } else {
                    query.Append(WHERE_EXACT_QUERY);
                }
                map.Add("@nombre", texto);
                map.Add("@apellido", texto);
                //map.Add("@dni", texto);
                map.Add("@mail", texto);
                //map.Add("@telefono", texto);
                map.Add("@direccion", texto);
                map.Add("@ciudad", texto);
            }
            SqlDataReader resultSet = _dbm.executeSelect(query.ToString(), map);
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;

            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].Name = "Nombre";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].Name = "Apellido";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].Name = "DNI";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].Name = "Mail";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].Name = "Telefono";
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[6].Name = "Direccion";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[7].Name = "Ciudad";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[8].Name = "Fecha Nacimiento";
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[9].Name = "Saldo";
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[10].Name = "Estado";
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            while (resultSet.Read())
            {
                int id = (int)resultSet.GetValue(resultSet.GetOrdinal("ID"));
                String nombre = (String)resultSet.GetValue(resultSet.GetOrdinal("NOMBRE"));
                String apellido = (String)resultSet.GetValue(resultSet.GetOrdinal("APELLIDO"));
                Decimal dni = (Decimal) resultSet.GetValue(resultSet.GetOrdinal("DNI"));
                String mail = (String)resultSet.GetValue(resultSet.GetOrdinal("MAIL"));
                Decimal telefono = (Decimal)resultSet.GetValue(resultSet.GetOrdinal("TELEFONO"));
                String direccion = (String)resultSet.GetValue(resultSet.GetOrdinal("DIRECCION"));
                String ciudad = (String)resultSet.GetValue(resultSet.GetOrdinal("CIUDAD"));
                DateTime fechaNacimiento = (DateTime)resultSet.GetValue(resultSet.GetOrdinal("FECHA"));
                Decimal saldo = (Decimal)resultSet.GetValue(resultSet.GetOrdinal("SALDO"));
                String estado = (String)resultSet.GetValue(resultSet.GetOrdinal("ESTADO"));

                string[] row = new string[] { id.ToString(), nombre, apellido, dni.ToString(), mail, telefono.ToString(), direccion, ciudad, fechaNacimiento.ToString(), saldo.ToString(), estado };
                dataGridView1.Rows.Add(row);
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].ReadOnly = true;
            }
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool /*borrar esta linea*/ algunoSeleccionado = true;
            if (algunoSeleccionado)
            {
                ModificarCliente modificarCliente = new ModificarCliente(_dbm);
                modificarCliente.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente.");
            }
        }

        
    }
}
