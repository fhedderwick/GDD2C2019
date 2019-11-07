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
    public partial class ModificarProveedor : Form
    {
        private DataBaseManager _dbm;
        private String _razonSocial;
        private String _cuit;

        //const String EXISTS_PROV_QUERY = "SELECT * FROM MANA.PROVEEDOR P WHERE P.PROV_CUIT = @CUIT AND P.PROV_RAZON_SOCIAL = @RSOCIAL";
        const String EXISTS_PROV_QUERY = "SELECT PROV_RAZON_SOCIAL RSOCIAL,PROV_MAIL MAIL,PROV_TELEFONO TELEFONO,PROV_DIRECCION DIRECCION,PROV_CODIGO_POSTAL CPOSTAL,PROV_CIUDAD CIUDAD,PROV_CUIT CUIT,PROV_RUBRO_ID RUBRO,PROV_NOMBRE_CONTACTO NOMBRE,PROV_ESTADO ESTADO FROM MANA.PROVEEDOR P WHERE P.PROV_CUIT = @CUIT AND P.PROV_RAZON_SOCIAL = @RSOCIAL";

        public ModificarProveedor(DataBaseManager dbm,String razonSocial,String cuit)
        {
            InitializeComponent();
            _razonSocial = razonSocial;
            _dbm = dbm;
            _cuit = cuit;
            loadProveedor();
        }

        private void ModificarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void guardarButton_Click(object sender, EventArgs e)
        {

        }

        private void loadProveedor()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@CUIT", _cuit);
            map.Add("@RSOCIAL", _razonSocial);
            SqlDataReader resultSet = _dbm.executeSelect(EXISTS_PROV_QUERY, map);
            while (resultSet.Read())
            {
                // String name = (String)resultSet.GetValue(resultSet.GetOrdinal("RUBRO_DESCRIPCION"));
                //comboBox1.Items.Add(name);  
                razonSocialTextBox.Text = resultSet["RSOCIAL"].ToString();
                mailTextBox.Text = resultSet["MAIL"].ToString();
                telefonoTextBox.Text = resultSet["TELEFONO"].ToString();
                direccionTextBox.Text = resultSet["DIRECCION"].ToString();
                codigoPostalTextBox.Text = resultSet["CPOSTAL"].ToString();
                ciudadTextBox.Text = resultSet["CIUDAD"].ToString();
                cuitTextBox.Text = resultSet["CUIT"].ToString();
                rubroTextBox.Text = resultSet["RUBRO"].ToString();
                nombreContactoBox1.Text = resultSet["NOMBRE"].ToString();
            }


        }





    }
}
