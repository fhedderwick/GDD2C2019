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

namespace FrbaOfertas.AbmProveedor
{

    public partial class ListaProveedor : Form
    {

        private String GET_PROVEEDORES_QUERY = "SELECT P.PROV_ID ID, P.PROV_RAZON_SOCIAL RAZON_SOCIAL, P.PROV_CUIT CUIT, P.PROV_NOMBRE_CONTACTO NOMBRE_CONTACTO, P.PROV_MAIL MAIL, P.PROV_TELEFONO TELEFONO, P.PROV_DIRECCION DIRECCION, P.PROV_CODIGO_POSTAL CODIGO_POSTAL, P.PROV_CIUDAD CIUDAD, P.PROV_RUBRO_ID RUBRO_ID, P.PROV_USER_ID USER_ID, U.USUARIO_ESTADO ESTADO, R.RUBRO_DESCRIPCION RUBRO_DESCRIPCION FROM MANA.PROVEEDOR P INNER JOIN MANA.USUARIO U ON P.PROV_USER_ID = U.USER_ID INNER JOIN MANA.RUBRO R ON R.RUBRO_ID = P.PROV_RUBRO_ID";
        private String GET_ROLID_PROVIDER_QUERY = "SELECT R.ROL_ID FROM MANA.ROL R WHERE R.ROL_NOMBRE = 'Proveedor' AND ROL_ESTADO = 'Habilitado'";

        private DataBaseManager _dbm;
        private Par _rol;

        public ListaProveedor(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
            _rol = crearRolUsuario();
        }

        private Par crearRolUsuario(){
            Par par = new Par();
            SqlDataReader resultSet = _dbm.executeSelect(GET_ROLID_PROVIDER_QUERY);
            if (resultSet.HasRows)
            {
                resultSet.Read();
                par.Value = ((int)resultSet.GetValue(resultSet.GetOrdinal("ROL_ID"))).ToString();
                par.Text = "Proveedor";
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
                MessageBox.Show("No se pueden dar de alta proveedores: el rol está deshabilitado.");
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
                MessageBox.Show("Debe seleccionar un proveedor.");
            }
            else if (!"Habilitado".Equals(dataGridView1.SelectedRows[0].Cells[11].Value.ToString()))
            {
                String id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String userId = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                RehabilitarProveedor rehabilitarProveedor = new RehabilitarProveedor(_dbm, this, id, userId);
                rehabilitarProveedor.Show();
            } 
            else
            {
                String id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String userId = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                BajaProveedor bajaProveedor = new BajaProveedor(_dbm, this, id, userId);
                bajaProveedor.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            llenarListado();
        }

        public void llenarListado()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            StringBuilder query = new StringBuilder(GET_PROVEEDORES_QUERY);
            bool whereSet = false;
            if(textBox1.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" P.PROV_RAZON_SOCIAL LIKE @razonSocial ");
                map.Add("@razonSocial", "%" + textBox1.Text + "%");
            }
            if(textBox3.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" P.PROV_CUIT = @cuit ");
                map.Add("@cuit", textBox3.Text);
            }
            if (textBox4.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" P.PROV_MAIL LIKE @mail ");
                map.Add("@mail", "%" + textBox4.Text + "%");
            }
            SqlDataReader resultSet = _dbm.executeSelect(query.ToString(), map);
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;

            dataGridView1.ColumnCount = 12;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].Name = "USER ID";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].Name = "Razón Social";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].Name = "CUIT";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].Name = "Nombre contacto";
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
            dataGridView1.Columns[10].Name = "Rubro";
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[11].Name = "Estado";
            dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            while (resultSet.Read())
            {
                int id = _dbm.getIntFromResultSet(resultSet,"ID");
                int userId = _dbm.getIntFromResultSet(resultSet, "USER_ID");
                String razonSocial = _dbm.getStringFromResultSet(resultSet, "RAZON_SOCIAL");
                String cuit = _dbm.getStringFromResultSet(resultSet, "CUIT");
                String nombreContacto = _dbm.getStringFromResultSet(resultSet, "NOMBRE_CONTACTO");
                String mail = _dbm.getStringFromResultSet(resultSet,"MAIL");
                Decimal telefono = _dbm.getNumericFromResultSet(resultSet, "TELEFONO");
                String direccion = _dbm.getStringFromResultSet(resultSet,"DIRECCION");
                String codigoPostal = _dbm.getStringFromResultSet(resultSet,"CODIGO_POSTAL");
                String ciudad = _dbm.getStringFromResultSet(resultSet,"CIUDAD");
                int rubroId = _dbm.getIntFromResultSet(resultSet, "RUBRO_ID");
                String rubro = _dbm.getStringFromResultSet(resultSet, "RUBRO_DESCRIPCION");
                String estado = _dbm.getStringFromResultSet(resultSet,"ESTADO");

                string[] row = new string[] { id.ToString(), userId.ToString(), razonSocial, cuit, nombreContacto, mail, telefono.ToString(), direccion, codigoPostal, ciudad, rubro, estado };
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
                AltaYModifProveedor modificarProveedor = new AltaYModifProveedor(_dbm, id);
                modificarProveedor.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un proveedor.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        
    }
}
