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
    public partial class AltaYModifProveedor : Form
    {

        private String NEW_PROVIDER_PROCEDURE = "MANA.CrearUsuarioProveedor";
        private String UPDATE_PROVIDER_PROCEDURE = "MANA.ModificarProveedor";

        private String GET_PROVIDER_DATA_QUERY = "SELECT P.PROV_ID ID, P.PROV_RAZON_SOCIAL RAZON_SOCIAL, P.PROV_CUIT CUIT, P.PROV_NOMBRE_CONTACTO NOMBRE_CONTACTO, P.PROV_MAIL MAIL, P.PROV_TELEFONO TELEFONO, P.PROV_DIRECCION DIRECCION, P.PROV_CODIGO_POSTAL CODIGO_POSTAL, P.PROV_CIUDAD CIUDAD, P.PROV_RUBRO_ID RUBRO_ID, P.PROV_USER_ID USER_ID, U.USUARIO_ESTADO ESTADO FROM MANA.PROVEEDOR P INNER JOIN MANA.USUARIO U ON U.USER_ID = P.PROV_USER_ID WHERE P.PROV_ID = @providerId";
        private String USER_EXISTS_QUERY = "SELECT * FROM MANA.PROVEEDOR P WHERE P.PROV_RAZON_SOCIAL = @razonSocial OR P.PROV_CUIT = @cuit";

        const String GET_RUBROS_QUERY = "SELECT RUBRO_ID ID, RUBRO_DESCRIPCION DESCRIPCION FROM MANA.RUBRO";

        private DataBaseManager _dbm;
        private int _id;
        private String _user;
        private String _pass;
        private String _rolId;

        public AltaYModifProveedor(DataBaseManager dbm, String id)
        {
            _dbm = dbm;
            _id = int.Parse(id);
            InitializeComponent();
            this.Text = "Modificación del proveedor (ID " + _id + ")";
            cargarRubros();
            cargarDatos();
        }

        public AltaYModifProveedor(DataBaseManager dbm, String user, String pass, String rolId )
        {
            _dbm = dbm;
            _user = user;
            _pass = pass;
            _rolId = rolId;
            _id = -1;
            InitializeComponent();
            this.Text = "Alta de proveedor";
            cargarRubros();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cargarDatos()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@providerId", _id.ToString());
            SqlDataReader resultSet = _dbm.executeSelect(GET_PROVIDER_DATA_QUERY, map);
            while (resultSet.Read())
            {
                razonsocialTextBox.Text = _dbm.getStringFromResultSet(resultSet, "RAZON_SOCIAL");
                mailTextBox.Text = _dbm.getStringFromResultSet(resultSet, "MAIL");
                telefonoTextBox.Text = _dbm.getNumericFromResultSet(resultSet, "TELEFONO").ToString();
                direccionTextBox.Text = _dbm.getStringFromResultSet(resultSet, "DIRECCION");
                codigoPostalTextBox.Text = _dbm.getStringFromResultSet(resultSet, "CODIGO_POSTAL");
                ciudadTextBox.Text = _dbm.getStringFromResultSet(resultSet, "CIUDAD");
                cuitTextBox.Text = _dbm.getStringFromResultSet(resultSet, "CUIT").ToString();
                comboBox1.SelectedValue = _dbm.getIntFromResultSet(resultSet, "RUBRO_ID").ToString();
                nombrecontactoTextBox.Text = _dbm.getStringFromResultSet(resultSet, "NOMBRE_CONTACTO").ToString();
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
                    map.Add("@RazonSocial", razonsocialTextBox.Text);
                    map.Add("@CUIT", cuitTextBox.Text);
                    map.Add("@NombreContacto", nombrecontactoTextBox.Text);
                    map.Add("@Mail", mailTextBox.Text);
                    map.Add("@Telefono", Convert.ToInt64(telefonoTextBox.Text));
                    map.Add("@Direccion", direccionTextBox.Text);
                    map.Add("@CodigoPostal", codigoPostalTextBox.Text);
                    map.Add("@Ciudad", ciudadTextBox.Text);
                    map.Add("@Rubro", comboBox1.Text); //VA EL TEXTO DEL RUBRO
                    if (3 == _dbm.executeProcedure(NEW_PROVIDER_PROCEDURE, map))
                    {
                        MessageBox.Show("Se ha agregado correctamente el proveedor.");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Fallo al agregar proveedor.");
                    }
                }
                else
                {
                    map.Add("@ID", _id);
                    map.Add("@RazonSocial", razonsocialTextBox.Text);
                    map.Add("@NombreContacto", nombrecontactoTextBox.Text);
                    map.Add("@CUIT", Convert.ToInt64(cuitTextBox.Text));
                    map.Add("@Mail", mailTextBox.Text);
                    map.Add("@Telefono", Convert.ToInt64(telefonoTextBox.Text));
                    map.Add("@Direccion", direccionTextBox.Text);
                    map.Add("@CodigoPostal", codigoPostalTextBox.Text);
                    map.Add("@Ciudad", ciudadTextBox.Text);
                    map.Add("@Rubro", comboBox1.Text); //ESTA OK, VA EL TEXTO DEL RUBRO
                    if (1 == _dbm.executeProcedure(UPDATE_PROVIDER_PROCEDURE, map))
                    {
                        MessageBox.Show("El proveedor fue modificado correctamente.");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar al proveedor.");
                    }
                }
            }
        }

        private bool validarDatos()
        {
            String razonSocial = razonsocialTextBox.Text;
            String mail = mailTextBox.Text;
            String telefono = telefonoTextBox.Text;
            String direccion = direccionTextBox.Text;
            String codigoPostal = codigoPostalTextBox.Text;
            String ciudad = ciudadTextBox.Text;
            String cuit = cuitTextBox.Text;
            String rubro = comboBox1.Text;
            String nombreContacto = nombrecontactoTextBox.Text;

            if (razonSocial.Length == 0)
            {
                MessageBox.Show("Debe completar la Razón Social.");
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
            if (cuit.Length == 0)
            {
                MessageBox.Show("Debe completar el CUIT.");
                return false;
            }
            if (rubro.Length == 0)
            {
                MessageBox.Show("Debe completar el Rubro.");
                return false;
            }
            if (nombreContacto.Length == 0)
            {
                MessageBox.Show("Debe completar el Nombre de Contacto.");
                return false;
            }
            
            if (datosCopiados(razonSocial,cuit))
            {
                MessageBox.Show("Ya existe un usuario con los mismos datos personales.");
                return false;
            }
            
            return true;
        }

        private bool datosCopiados(String razonSocial, String cuit)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@razonSocial", razonSocial);
            map.Add("@cuit", cuit);
            SqlDataReader resultSet;
            if (_id == -1)
            {
                resultSet = _dbm.executeSelect(USER_EXISTS_QUERY, map);
            }
            else
            {
                map.Add("@providerId", _id.ToString());
                resultSet = _dbm.executeSelect(USER_EXISTS_QUERY + " AND PROV_ID <> @provId", map);
            }
            return resultSet.HasRows;
        }

        private void cargarRubros()
        {
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.ValueMember = "Value";
            SqlDataReader resultSet = _dbm.executeSelect(GET_RUBROS_QUERY);
            //this.comboBox1.DisplayMember = "Text";
            //this.comboBox1.ValueMember = "Value";
            List<Par> list = new List<Par>();

            while (resultSet.Read())
            {
                list.Add(new Par() { Text = resultSet["DESCRIPCION"].ToString(), Value = resultSet["ID"].ToString() });
            }
            comboBox1.DataSource = list;
        }
    }
}
