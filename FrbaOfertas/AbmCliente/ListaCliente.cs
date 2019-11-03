using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class ListaCliente : Form
    {

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

    /*
     
    CLI_ID INT NOT NULL IDENTITY,
	CLI_NOMBRE NVARCHAR(255),
	CLI_APELLIDO NVARCHAR(255),
	CLI_DNI NUMERIC(18),
	CLI_MAIL NVARCHAR(255),
	CLI_TELEFONO NUMERIC(18),
	CLI_DIRECCION NVARCHAR(255),
	CLI_CIUDAD NVARCHAR(255),
	CLI_FECHA_NACIMIENTO DATETIME,
	CLI_SALDO NUMERIC(18) DEFAULT 200,
	CLI_ESTADO NVARCHAR(20),
     
     */
}
