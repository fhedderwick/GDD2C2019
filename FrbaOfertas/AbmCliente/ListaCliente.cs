﻿using System;
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

        private String GET_CLIENTES_QUERY = "SELECT C.CLI_ID ID, C.CLI_NOMBRE NOMBRE, C.CLI_APELLIDO APELLIDO, C.CLI_DNI DNI, C.CLI_MAIL MAIL, C.CLI_TELEFONO TELEFONO, C.CLI_DIRECCION DIRECCION, C.CLI_CODIGO_POSTAL CODIGO_POSTAL, C.CLI_CIUDAD CIUDAD, C.CLI_FECHA_NACIMIENTO FECHA, C.CLI_SALDO SALDO, C.CLI_ESTADO ESTADO FROM MANA.CLIENTE C";
        private String FILTRO_NOMBRE_QUERY = " WHERE C.CLI_NOMBRE = @nombre OR C.CLI_APELLIDO = @apellido OR C.CLI_DNI = @dni OR C.CLI_MAIL = @mail OR C.CLI_TELEFONO = @telefono OR C.CLI_DIRECCION = @direccion OR C.CLI_CODIGO_POSTAL = @codigoPostal OR C.CLI_CIUDAD = @ciudad";
        private String FILTRO_APELLIDO_QUERY = " WHERE C.CLI_NOMBRE LIKE @nombre OR C.CLI_APELLIDO LIKE @apellido OR C.CLI_DNI LIKE @dni OR C.CLI_MAIL LIKE @mail OR C.CLI_TELEFONO LIKE @telefono OR C.CLI_DIRECCION LIKE @direccion OR C.CLI_CODIGO_POSTAL LIKE @codigoPostal OR C.CLI_CIUDAD LIKE @ciudad";
        private String FILTRO_DNI_QUERY = " WHERE C.CLI_NOMBRE LIKE @nombre OR C.CLI_APELLIDO LIKE @apellido OR C.CLI_DNI LIKE @dni OR C.CLI_MAIL LIKE @mail OR C.CLI_TELEFONO LIKE @telefono OR C.CLI_DIRECCION LIKE @direccion OR C.CLI_CODIGO_POSTAL LIKE @codigoPostal OR C.CLI_CIUDAD LIKE @ciudad";
        private String FILTRO_EMAIL_QUERY = " WHERE C.CLI_NOMBRE LIKE @nombre OR C.CLI_APELLIDO LIKE @apellido OR C.CLI_DNI LIKE @dni OR C.CLI_MAIL LIKE @mail OR C.CLI_TELEFONO LIKE @telefono OR C.CLI_DIRECCION LIKE @direccion OR C.CLI_CODIGO_POSTAL LIKE @codigoPostal OR C.CLI_CIUDAD LIKE @ciudad";

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
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
            }
            else if (!"Habilitado".Equals(dataGridView1.SelectedRows[0].Cells[11].Value.ToString()))
            {
                MessageBox.Show("El cliente elegido ya está deshabilitado.");
            } 
            else
            {
                String id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                BajaCliente bajaCliente = new BajaCliente(_dbm,this, id);
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

            dataGridView1.ColumnCount = 12;
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
            dataGridView1.Columns[7].Name = "Codigo Postal";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[8].Name = "Ciudad";
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[9].Name = "Fecha Nacimiento";
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[10].Name = "Saldo";
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[11].Name = "Estado";
            dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            while (resultSet.Read())
            {
                int id = _dbm.getIntFromResultSet(resultSet,"ID");
                String nombre = _dbm.getStringFromResultSet(resultSet,"NOMBRE");
                String apellido = _dbm.getStringFromResultSet(resultSet,"APELLIDO");
                String dni = _dbm.getStringFromResultSet(resultSet,"DNI");
                String mail = _dbm.getStringFromResultSet(resultSet,"MAIL");
                String telefono = _dbm.getStringFromResultSet(resultSet,"TELEFONO");
                String direccion = _dbm.getStringFromResultSet(resultSet,"DIRECCION");
                String codigoPostal = _dbm.getStringFromResultSet(resultSet,"CODIGO_POSTAL");
                String ciudad = _dbm.getStringFromResultSet(resultSet,"CIUDAD");
                DateTime fechaNacimiento = (DateTime) _dbm.getFromResultSet(resultSet, "FECHA");
                Decimal saldo = _dbm.getNumericFromResultSet(resultSet,"SALDO");
                String estado = _dbm.getStringFromResultSet(resultSet,"ESTADO");

                string[] row = new string[] { id.ToString(), nombre, apellido, dni.ToString(), mail, telefono.ToString(), direccion, codigoPostal, ciudad, fechaNacimiento.ToShortDateString(), saldo.ToString(), estado };
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
                ModificarCliente modificarCliente = new ModificarCliente(_dbm,id);
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
