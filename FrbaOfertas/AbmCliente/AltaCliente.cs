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
    public partial class AltaCliente : Form
    {

        private String INSERT_QUERY = "INSERT INTO MANA.CLIENTE (CLI_NOMBRE,CLI_APELLIDO,CLI_DNI,CLI_MAIL,CLI_TELEFONO,CLI_DIRECCION,CLI_CODIGO_POSTAL,CLI_CIUDAD,CLI_FECHA_NACIMIENTO) VALUES (@nombre,@apellido,@dni,@mail,@telefono,@direccion,@codigoPostal,@ciudad,@fechaNacimiento)";

        private DataBaseManager _dbm;

        public AltaCliente(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("@nombre", nombreTextBox.Text);
                map.Add("@apellido", apellidoTextBox.Text);
                map.Add("@dni", dniTextBox.Text);
                map.Add("@mail", mailTextBox.Text);
                map.Add("@telefono", telefonoTextBox.Text);
                map.Add("@direccion", direccionTextBox.Text);
                map.Add("@codigoPostal", codigoPostalTextBox.Text);
                map.Add("@ciudad", ciudadTextBox.Text);
                map.Add("@fechaNacimiento", fechaTextBox.Text);
                _dbm.executeUpdate(INSERT_QUERY, map);
            }
            
        }

        private bool validarDatos()
        {
            return true;
        }
    }
}
