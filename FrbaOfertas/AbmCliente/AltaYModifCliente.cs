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
    public partial class AltaYModifCliente : Form
    {
        private String GET_CLIENT_DATA_QUERY = "SELECT C.CLI_ID ID, C.CLI_NOMBRE NOMBRE, C.CLI_APELLIDO APELLIDO, C.CLI_DNI DNI, C.CLI_MAIL MAIL, C.CLI_TELEFONO TELEFONO, C.CLI_DIRECCION DIRECCION, C.CLI_CODIGO_POSTAL CODIGO_POSTAL, C.CLI_CIUDAD CIUDAD, C.CLI_FECHA_NACIMIENTO FECHA, C.CLI_SALDO SALDO, C.CLI_ESTADO ESTADO FROM MANA.CLIENTE C WHERE C.CLI_ID = @clientId";
        private String INSERT_QUERY = "INSERT INTO MANA.CLIENTE (CLI_NOMBRE,CLI_APELLIDO,CLI_DNI,CLI_MAIL,CLI_TELEFONO,CLI_DIRECCION,CLI_CODIGO_POSTAL,CLI_CIUDAD,CLI_FECHA_NACIMIENTO) VALUES (@nombre,@apellido,@dni,@mail,@telefono,@direccion,@codigoPostal,@ciudad,@fechaNacimiento)";
        private String UPDATE_QUERY = "UPDATE MANA.CLIENTE SET CLI_NOMBRE = @nombre,CLI_APELLIDO=@apellido,CLI_DNI=@dni,CLI_MAIL=@mail,CLI_TELEFONO=@telefono,CLI_DIRECCION=@direccion,CLI_CODIGO_POSTAL=@codigoPostal,CLI_CIUDAD=@ciudad,CLI_FECHA_NACIMIENTO=@fechaNacimiento WHERE CLI_ID=@clientId";
        private String USER_EXISTS_QUERY = "SELECT COUNT(*) FROM MANA.CLIENTE C WHERE C.CLI_NOMBRE = @nombre AND C.CLI_APELLIDO = @apellido AND C.CLI_DNI = @dni AND C.CLI_MAIL = @mail";

        private DataBaseManager _dbm;
        private int _id;
        private String _user;
        private String _pass;

        public AltaYModifCliente(DataBaseManager dbm)
        {
            _dbm = dbm;
            _id = -1;
            InitializeComponent();
            this.Text = "Alta de cliente";
        }

        public AltaYModifCliente(DataBaseManager dbm, String id)
        {
            _dbm = dbm;
            _id = int.Parse(id);
            InitializeComponent();
            this.Text = "Modificación del cliente (ID " + _id + ")";
            cargarDatos();
        }

        public AltaYModifCliente(DataBaseManager dbm, String user, String pass)
        {
            _dbm = dbm;
            _user = user;
            _pass = pass;
            _id = -1;
            InitializeComponent();
            this.Text = "Alta de cliente";
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cargarDatos()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@clientId", _id.ToString());
            SqlDataReader resultSet = _dbm.executeSelect(GET_CLIENT_DATA_QUERY, map);
            while (resultSet.Read())
            {
                nombreTextBox.Text = _dbm.getStringFromResultSet(resultSet, "NOMBRE");
                apellidoTextBox.Text = _dbm.getStringFromResultSet(resultSet, "APELLIDO");
                dniTextBox.Text = _dbm.getStringFromResultSet(resultSet, "DNI");
                mailTextBox.Text = _dbm.getStringFromResultSet(resultSet, "MAIL");
                telefonoTextBox.Text = _dbm.getStringFromResultSet(resultSet, "TELEFONO");
                direccionTextBox.Text = _dbm.getStringFromResultSet(resultSet, "DIRECCION");
                codigoPostalTextBox.Text = _dbm.getStringFromResultSet(resultSet, "CODIGO_POSTAL");
                ciudadTextBox.Text = _dbm.getStringFromResultSet(resultSet, "CIUDAD");
                fechaTextBox.Text = _dbm.getStringFromResultSet(resultSet, "FECHA");
            }
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
                if (_id == -1)
                {
                    if (1 == _dbm.executeUpdate(INSERT_QUERY, map))
                    {
                        MessageBox.Show("El cliente fue dado de alta correctamente.");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al dar de alta al cliente.");
                    }
                }
                else
                {
                    map.Add("@clientId", _id.ToString());
                    if (1 == _dbm.executeUpdate(UPDATE_QUERY, map))
                    {
                        MessageBox.Show("El cliente fue modificado correctamente.");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar al cliente.");
                    }
                }
            }
        }

        private bool validarDatos()
        {
            String nombre = nombreTextBox.Text;
            String apellido = apellidoTextBox.Text;
            String dni = dniTextBox.Text;
            String mail = mailTextBox.Text;
            String telefono = telefonoTextBox.Text;
            String direccion = direccionTextBox.Text;
            String codigoPostal = codigoPostalTextBox.Text;
            String ciudad = ciudadTextBox.Text;
            String fechaNacimiento = fechaTextBox.Text;

            if (nombre.Length == 0)
            {
                MessageBox.Show("Debe completar el Nombre.");
                return false;
            }
            if (apellido.Length == 0)
            {
                MessageBox.Show("Debe completar el Apellido.");
                return false;
            }
            if (dni.Length == 0)
            {
                MessageBox.Show("Debe completar el DNI.");
                return false;
            }
            if (mail.Length == 0)
            {
                MessageBox.Show("Debe completar el mail.");
                return false;
            }
            if (telefono.Length == 0)
            {
                MessageBox.Show("Debe completar el telefono.");
                return false;
            }
            if (direccion.Length == 0)
            {
                MessageBox.Show("Debe completar la direccion.");
                return false;
            }
            if (codigoPostal.Length == 0)
            {
                MessageBox.Show("Debe completar el codigo postal.");
                return false;
            }
            if (ciudad.Length == 0)
            {
                MessageBox.Show("Debe completar la ciudad.");
                return false;
            }
            if (fechaNacimiento.Length == 0)
            {
                MessageBox.Show("Debe seleccionar la fecha de nacimiento.");
                return false;
            }
            
            if (datosCopiados(nombre,apellido,dni,mail))
            {
                MessageBox.Show("Ya existe un usuario con los mismos datos personales.");
                return false;
            }
            
            return true;
        }

        private void abrirCalendario(object sender, MouseEventArgs e)
        {
            DateChooser dateChooser = new DateChooser(fechaTextBox);
            dateChooser.Show();
        }

        private bool datosCopiados(String nombre, String apellido, String dni, String mail)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@nombre", nombre);
            map.Add("@apellido", apellido);
            map.Add("@dni", dni);
            map.Add("@mail", mail);
            SqlDataReader resultSet;
            if (_id == -1)
            {
                resultSet = _dbm.executeSelect(USER_EXISTS_QUERY, map);
            }
            else
            {
                map.Add("@clientId", _id.ToString());
                resultSet = _dbm.executeSelect(USER_EXISTS_QUERY + " WHERE CLI_ID <> @clientId", map);
            }
            return resultSet.HasRows;
        }
    }
}
