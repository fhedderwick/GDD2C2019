using FrbaOfertas.Login;
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

        private String GET_CLIENTES_QUERY = "SELECT C.CLI_ID ID, C.CLI_NOMBRE NOMBRE, C.CLI_APELLIDO APELLIDO, C.CLI_DNI DNI, C.CLI_MAIL MAIL, C.CLI_TELEFONO TELEFONO, C.CLI_DIRECCION DIRECCION, C.CLI_CODIGO_POSTAL CODIGO_POSTAL, C.CLI_CIUDAD CIUDAD, C.CLI_FECHA_NACIMIENTO FECHA, C.CLI_SALDO SALDO, C.CLI_USER_ID USER_ID, U.USUARIO_ESTADO ESTADO FROM MANA.CLIENTE C INNER JOIN MANA.USUARIO U ON C.CLI_USER_ID = U.USER_ID";
        private String GET_ROLID_CLIENT_QUERY = "SELECT R.ROL_ID FROM MANA.ROL R WHERE R.ROL_NOMBRE = 'Cliente' AND ROL_ESTADO = 'Habilitado'";

        private DataBaseManager _dbm;
        private Par _rol;

        public ListaCliente(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
            _rol = crearRolUsuario();
        }

        private Par crearRolUsuario(){
            Par par = new Par();
            SqlDataReader resultSet = _dbm.executeSelect(GET_ROLID_CLIENT_QUERY);
            if (resultSet.HasRows)
            {
                resultSet.Read();
                par.Value = ((int)resultSet.GetValue(resultSet.GetOrdinal("ROL_ID"))).ToString();
                par.Text = "Cliente";
                return par;
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_rol == null)
            {
                MessageBox.Show("No se pueden dar de alta clientes: el rol está deshabilitado.");
            }
            else
            {
                NewUser altaUsuario = new NewUser(_dbm, "", _rol);
                altaUsuario.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
            }
            else if (!"Habilitado".Equals(dataGridView1.SelectedRows[0].Cells[12].Value.ToString()))
            {
                String id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String userId = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                RehabilitarCliente rehabilitarCliente = new RehabilitarCliente(_dbm, this, id, userId);
                rehabilitarCliente.Show();
            } 
            else
            {
                String id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String userId = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                BajaCliente bajaCliente = new BajaCliente(_dbm,this, id, userId);
                bajaCliente.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            llenarListado();
        }

        public void llenarListado()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            StringBuilder query = new StringBuilder(GET_CLIENTES_QUERY);
            bool whereSet = false;
            if(textBox1.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" C.CLI_NOMBRE LIKE @nombre ");
                map.Add("@nombre", "%" + textBox1.Text + "%");
            }
            if(textBox2.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" C.CLI_APELLIDO LIKE @apellido ");
                map.Add("@apellido", "%" + textBox2.Text + "%");
            }
            if(textBox3.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" C.CLI_DNI = @dni ");
                map.Add("@dni", textBox3.Text);
            }
            if (textBox4.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" C.CLI_MAIL LIKE @mail ");
                map.Add("@mail", "%" + textBox4.Text + "%");
            }
            SqlDataReader resultSet = _dbm.executeSelect(query.ToString(), map);
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;

            dataGridView1.ColumnCount = 13;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].Name = "USER ID";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].Name = "Nombre";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].Name = "Apellido";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].Name = "DNI";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].Name = "Mail";
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[6].Name = "Telefono";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[7].Name = "Direccion";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[8].Name = "Codigo Postal";
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[9].Name = "Ciudad";
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[10].Name = "Fecha Nacimiento";
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[11].Name = "Saldo";
            dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[12].Name = "Estado";
            dataGridView1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            while (resultSet.Read())
            {
                int id = _dbm.getIntFromResultSet(resultSet,"ID");
                int userId = _dbm.getIntFromResultSet(resultSet, "USER_ID");
                String nombre = _dbm.getStringFromResultSet(resultSet,"NOMBRE");
                String apellido = _dbm.getStringFromResultSet(resultSet,"APELLIDO");
                Decimal dni = _dbm.getNumericFromResultSet(resultSet, "DNI");
                String mail = _dbm.getStringFromResultSet(resultSet,"MAIL");
                Decimal telefono = _dbm.getNumericFromResultSet(resultSet, "TELEFONO");
                String direccion = _dbm.getStringFromResultSet(resultSet,"DIRECCION");
                String codigoPostal = _dbm.getStringFromResultSet(resultSet,"CODIGO_POSTAL");
                String ciudad = _dbm.getStringFromResultSet(resultSet,"CIUDAD");
                DateTime fechaNacimiento = (DateTime) _dbm.getFromResultSet(resultSet, "FECHA");
                Decimal saldo = _dbm.getNumericFromResultSet(resultSet,"SALDO");
                String estado = _dbm.getStringFromResultSet(resultSet,"ESTADO");

                string[] row = new string[] { id.ToString(), userId.ToString(), nombre, apellido, dni.ToString(), mail, telefono.ToString(), direccion, codigoPostal, ciudad, fechaNacimiento.ToShortDateString(), saldo.ToString(), estado };
                dataGridView1.Rows.Add(row);
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].ReadOnly = true;
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                AltaYModifCliente modificarCliente = new AltaYModifCliente(_dbm, id);
                modificarCliente.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        
    }
}
