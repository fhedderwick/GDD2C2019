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
    public partial class AltaYModifCliente : Form
    {

        private String NEW_CLIENT_PROCEDURE = "MANA.CrearUsuarioCliente";
        private String UPDATE_CLIENT_PROCEDURE = "MANA.ModificarCliente";

        private String GET_CLIENT_DATA_QUERY = "SELECT C.CLI_ID ID, C.CLI_NOMBRE NOMBRE, C.CLI_APELLIDO APELLIDO, C.CLI_DNI DNI, C.CLI_MAIL MAIL, C.CLI_TELEFONO TELEFONO, C.CLI_DIRECCION DIRECCION, C.CLI_CODIGO_POSTAL CODIGO_POSTAL, C.CLI_CIUDAD CIUDAD, C.CLI_FECHA_NACIMIENTO FECHA, C.CLI_SALDO SALDO, U.USUARIO_ESTADO ESTADO FROM MANA.CLIENTE C INNER JOIN MANA.USUARIO U ON U.USER_ID = C.CLI_USER_ID WHERE C.CLI_ID = @clientId";
        private String USER_EXISTS_QUERY = "SELECT * FROM MANA.CLIENTE C WHERE C.CLI_NOMBRE = @nombre AND C.CLI_APELLIDO = @apellido AND C.CLI_DNI = @dni AND C.CLI_MAIL = @mail";
      
        private DataBaseManager _dbm;
        private int _id;
        private String _user;
        private String _pass;
        private String _rolId;

        public AltaYModifCliente(DataBaseManager dbm, String id)
        {
            _dbm = dbm;
            _id = int.Parse(id);
            InitializeComponent();
            this.Text = "Modificación del cliente (ID " + _id + ")";
            cargarDatos();
        }

        public AltaYModifCliente(DataBaseManager dbm, String user, String pass, String rolId )
        {
            _dbm = dbm;
            _user = user;
            _pass = pass;
            _rolId = rolId;
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
                dniTextBox.Text = _dbm.getNumericFromResultSet(resultSet, "DNI").ToString();
                mailTextBox.Text = _dbm.getStringFromResultSet(resultSet, "MAIL");
                telefonoTextBox.Text = _dbm.getNumericFromResultSet(resultSet, "TELEFONO").ToString();
                direccionTextBox.Text = _dbm.getStringFromResultSet(resultSet, "DIRECCION");
                codigoPostalTextBox.Text = _dbm.getStringFromResultSet(resultSet, "CODIGO_POSTAL");
                ciudadTextBox.Text = _dbm.getStringFromResultSet(resultSet, "CIUDAD");
                fechaTextBox.Text = formatDateTime(_dbm.getDatetimeFromResultSet(resultSet, "FECHA"));
            }
        }

        private string formatDateTime(DateTime datetime)
        {
            return datetime.ToShortDateString();
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                if (_id == -1)
                {
                    map.Add("@rolId", _rolId);
                    map.Add("@username", _user);
                    map.Add("@password", _pass);
                    map.Add("@nombre", nombreTextBox.Text);
                    map.Add("@apellido", apellidoTextBox.Text);
                    map.Add("@dni", dniTextBox.Text);
                    map.Add("@mail", mailTextBox.Text);
                    map.Add("@telefono", telefonoTextBox.Text);
                    map.Add("@direccion", direccionTextBox.Text);
                    map.Add("@codigoPostal", codigoPostalTextBox.Text);
                    map.Add("@ciudad", ciudadTextBox.Text);
                    map.Add("@fechaNac", Convert.ToDateTime(fechaTextBox.Text));
                    if (3 == _dbm.executeProcedure(NEW_CLIENT_PROCEDURE, map))
                    {
                        MessageBox.Show("Se ha agregado correctamente el cliente.");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Fallo al agregar cliente.");
                    }
                }
                else
                {
                    map.Add("@ID", _id);
                    map.Add("@Nombre", nombreTextBox.Text);
                    map.Add("@Apellido", apellidoTextBox.Text);
                    map.Add("@Dni", Convert.ToInt64(dniTextBox.Text));
                    map.Add("@Mail", mailTextBox.Text);
                    map.Add("@Telefono", Convert.ToInt64(telefonoTextBox.Text));
                    map.Add("@Direccion", direccionTextBox.Text);
                    map.Add("@CodigoPostal", codigoPostalTextBox.Text);
                    map.Add("@Ciudad", ciudadTextBox.Text);
                    map.Add("@FechaNac", Convert.ToDateTime(fechaTextBox.Text));
                    if (1 == _dbm.executeProcedure(UPDATE_CLIENT_PROCEDURE, map))
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
                resultSet = _dbm.executeSelect(USER_EXISTS_QUERY + " AND CLI_ID <> @clientId", map);
            }
            return resultSet.HasRows;
        }
    }
}
