﻿using System;
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
        private String _user;
        private String _pass;

        public AltaCliente(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        public AltaCliente(DataBaseManager dbm,String user, String pass)
        {
            _dbm = dbm;
            _user = user;
            _pass = pass;
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
                if (1 == _dbm.executeUpdate(INSERT_QUERY, map))
                {
                    MessageBox.Show("El cliente fue dado de alta correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al dar de alta al cliente.");
                }
            }
            Close();
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
                MessageBox.Show("Datos copiados");
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
            return false;
        }
    }
}
