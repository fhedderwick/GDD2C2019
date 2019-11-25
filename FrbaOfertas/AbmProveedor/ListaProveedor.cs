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
        private DataBaseManager _dbm;
        private String GET_PROVEEDORES_QUERY = "select PROV_RAZON_SOCIAL RAZON_SOCIAL, PROV_MAIL MAIL,PROV_TELEFONO TELEFONO,PROV_DIRECCION DIRECCION,PROV_CODIGO_POSTAL CODIGO_POSTAL,PROV_CIUDAD CIUDAD,PROV_CUIT CUIT, PROV_RUBRO_ID RUBRO,PROV_NOMBRE_CONTACTO NOMBRE, PROV_ESTADO ESTADO FROM MANA.PROVEEDOR P";
        string[] columnasTabla = new string[] { "Razón Social", "Email", "Teléfono", "Dirección", "Código Postal", "Ciudad", "Cuit", "Rubro", "Nombre", "Estado" };


        public ListaProveedor(DataBaseManager dbm)
        {
            InitializeComponent();
            _dbm = dbm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AltaProveedor altaProv = new AltaProveedor(_dbm);
            //altaProv.Show();
            NewUser altaUsuarioProveedor = new NewUser(_dbm, "Proveedor");
            altaUsuarioProveedor.Show();
        }

        private void ListaProveedor_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debe seleccionar un proveedor.");
            }
            else if (!"Habilitado".Equals(dataGridView1.SelectedRows[0].Cells[9].Value.ToString()))
            {
                MessageBox.Show("El cliente elegido ya está deshabilitado.");
            }
            else
            {
                String rSocial = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                W bajaProveedor = new W(_dbm, this, rSocial);
                bajaProveedor.Show();
            }







        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            searchProveedores();
        }


        public void searchProveedores()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            StringBuilder query = new StringBuilder(GET_PROVEEDORES_QUERY);
            bool whereSet = false;

            if (razonSocialTextBox.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" PROV_RAZON_SOCIAL LIKE @RSOCIAL ");
                map.Add("@RSOCIAL", "%" + razonSocialTextBox.Text + "%");
            }

            if (cuitTextBox.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" PROV_CUIT LIKE @CUIT ");
                map.Add("@CUIT", "%" + cuitTextBox.Text + "%");
            }

            if (emailTextBox.TextLength != 0)
            {
                query.Append(whereSet ? " AND " : " WHERE ");
                whereSet = true;
                query.Append(" PROV_MAIL LIKE @MAIL ");
                map.Add("@MAIL", "%" + emailTextBox.Text + "%");
            }

            SqlDataReader resultSet = _dbm.executeSelect(query.ToString(), map);
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ColumnCount = 10;

            for (int f = 0; f < 10; f++)
            {
             dataGridView1.Columns[f].Name = columnasTabla[f];
             dataGridView1.Columns[f].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            while (resultSet.Read())
            {         
                String rSocial = _dbm.getStringFromResultSet(resultSet, "RAZON_SOCIAL");
                String mail = _dbm.getStringFromResultSet(resultSet, "MAIL");
                String telefono = _dbm.getStringFromResultSet(resultSet, "TELEFONO");
                String direccion = _dbm.getStringFromResultSet(resultSet, "DIRECCION");
                String cPostal = _dbm.getStringFromResultSet(resultSet, "CODIGO_POSTAL");
                String ciudad = _dbm.getStringFromResultSet(resultSet, "CIUDAD");
                String cuit = _dbm.getStringFromResultSet(resultSet, "CUIT");
                int rubro = _dbm.getIntFromResultSet(resultSet, "RUBRO");
                String nombre = _dbm.getStringFromResultSet(resultSet, "NOMBRE");
                String estado = _dbm.getStringFromResultSet(resultSet, "ESTADO");
                string[] row = new string[] { rSocial, mail, telefono, direccion, cPostal, ciudad, cuit, rubro.ToString(), nombre, estado};
                dataGridView1.Rows.Add(row);
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].ReadOnly = true;
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            razonSocialTextBox.Text = "";
            cuitTextBox.Text = "";
            emailTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                String rSocial = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                String cuit = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                ModificarProveedor modificarProveedor = new ModificarProveedor(_dbm, rSocial,cuit);
                modificarProveedor.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente.");
            }
        }

    }
}
