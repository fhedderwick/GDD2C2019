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
        private String _id;

        const String EXISTS_PROV_QUERY = "SELECT PROV_ID ID, PROV_RAZON_SOCIAL RSOCIAL,PROV_MAIL MAIL,PROV_TELEFONO TELEFONO,PROV_DIRECCION DIRECCION,PROV_CODIGO_POSTAL CPOSTAL,PROV_CIUDAD CIUDAD,PROV_CUIT CUIT,PROV_RUBRO_ID RUBRO,PROV_NOMBRE_CONTACTO NOMBRE,PROV_ESTADO ESTADO FROM MANA.PROVEEDOR P WHERE P.PROV_CUIT = @CUIT AND P.PROV_RAZON_SOCIAL = @RSOCIAL";
        const String UPDATE_PROV_QUERY = "UPDATE MANA.PROVEEDOR SET PROV_RAZON_SOCIAL=@RSOCIAL, PROV_MAIL=@MAIL, PROV_TELEFONO=@TEL,PROV_DIRECCION=@DIRE,PROV_CODIGO_POSTAL=@CPOSTAL,PROV_CIUDAD=@CIUDAD,PROV_CUIT=@CUIT,PROV_RUBRO_ID=@RUBRO,PROV_NOMBRE_CONTACTO=@NOMBRE,PROV_ESTADO=@ESTADO where PROV_ID=@ID";
        const String RUBROS_QUERY = "SELECT RUBRO_ID ID, RUBRO_DESCRIPCION DESCRIPCION FROM MANA.RUBRO";

        public ModificarProveedor(DataBaseManager dbm,String razonSocial,String cuit)
        {
            InitializeComponent();
            _razonSocial = razonSocial;
            _dbm = dbm;
            _cuit = cuit;
            loadRubro();
            loadEstado();
            loadProveedor();
        }

        private void ModificarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();

            String nRSocial = razonSocialTextBox.Text;
            String nMail = mailTextBox.Text;
            String nTelefono = telefonoTextBox.Text;
            String nDire = direccionTextBox.Text;
            String nCPostal = codigoPostalTextBox.Text;
            String nCiudad = ciudadTextBox.Text;
            String nCuit = cuitTextBox.Text;
            String nRubro = rubroComboBox.SelectedValue.ToString();
            String nNombre = nombreContactoBox1.Text;
            String nEstado = estadoComboBox.Text;

            map.Add("@RSOCIAL", nRSocial);
            map.Add("@MAIL", nMail);
            map.Add("@TEL", nTelefono);
            map.Add("@DIRE", nDire);
            map.Add("@CPOSTAL", nCPostal);
            map.Add("@CIUDAD", nCiudad);
            map.Add("@CUIT", nCuit);
            map.Add("@RUBRO", nRubro);
            map.Add("@NOMBRE", nNombre);
            map.Add("@ESTADO", nEstado);
            map.Add("@ID", _id);    

            if ((nCuit == _cuit) && (nRSocial == _razonSocial))
            {
                MessageBox.Show("ACTUALIZAR CAMBIOS, no se modifico nada");

                    if (1 == _dbm.executeUpdate(UPDATE_PROV_QUERY, map))
                    {
                        MessageBox.Show("Se actualizo correctamente");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al querer actualizar");
                    }
            }
            else
            {
                MessageBox.Show("Ver si el nuevo cuit o razon social existen.");
                Dictionary<string, string> mapa = new Dictionary<string, string>();
                mapa.Add("@RSOCIAL", nRSocial);                
                mapa.Add("@CUIT", nCuit);
                SqlDataReader resultSet = _dbm.executeSelect(EXISTS_PROV_QUERY, mapa);

                if (resultSet.HasRows)
                {
                    MessageBox.Show("El proveedor modificado existe, no se puede modificar");

                }else{
                    MessageBox.Show("ACTUALIZAR CAMBIOS, se cambio el cuit o la rsocial");

                    if (1 == _dbm.executeUpdate(UPDATE_PROV_QUERY, map))
                    {
                        MessageBox.Show("Se actualizo correctamente");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al querer actualizar");
                    }

                }
            }

        }

        private void loadRubro()
        {
           SqlDataReader resultSet = _dbm.executeSelect(RUBROS_QUERY);
           this.rubroComboBox.DisplayMember = "Text";
           this.rubroComboBox.ValueMember = "Value";
           List<Rubro> list = new List<Rubro>();         

           while (resultSet.Read())
           {
               list.Add(new Rubro() { Text = resultSet["DESCRIPCION"].ToString(), Value = resultSet["ID"].ToString() });
           }
          rubroComboBox.DataSource = list;
        }

        private void loadEstado()
        {
            estadoComboBox.Items.Add("Habilitado");
            estadoComboBox.Items.Add("Deshabilitado");
        }

        private void loadProveedor()
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@CUIT", _cuit);
            map.Add("@RSOCIAL", _razonSocial);
            SqlDataReader resultSet = _dbm.executeSelect(EXISTS_PROV_QUERY, map);
            while (resultSet.Read())
            {
                razonSocialTextBox.Text = resultSet["RSOCIAL"].ToString();
                mailTextBox.Text = resultSet["MAIL"].ToString();
                telefonoTextBox.Text = resultSet["TELEFONO"].ToString();
                direccionTextBox.Text = resultSet["DIRECCION"].ToString();
                codigoPostalTextBox.Text = resultSet["CPOSTAL"].ToString();
                ciudadTextBox.Text = resultSet["CIUDAD"].ToString();
                cuitTextBox.Text = resultSet["CUIT"].ToString();
                rubroComboBox.Text = resultSet["RUBRO"].ToString();
                nombreContactoBox1.Text = resultSet["NOMBRE"].ToString();
                estadoComboBox.Text = resultSet["ESTADO"].ToString();

                _id = resultSet["ID"].ToString();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public class Rubro
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
    }

    
}
