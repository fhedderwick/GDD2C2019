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
    public partial class AltaProveedor : Form
    {
        private DataBaseManager _dbm;
        private String _user;
        private String _pass;
        const String EXISTS_PROV_QUERY = "SELECT * FROM MANA.PROVEEDOR P WHERE P.PROV_CUIT = @CUIT AND P.PROV_RAZON_SOCIAL = @RSOCIAL";
        const String ADD_PROV_QUERY = "INSERT INTO MANA.PROVEEDOR (PROV_RAZON_SOCIAL,PROV_MAIL,PROV_TELEFONO,PROV_DIRECCION,PROV_CODIGO_POSTAL,PROV_CIUDAD,PROV_CUIT,PROV_RUBRO_ID,PROV_NOMBRE_CONTACTO,PROV_ESTADO) VALUES (@RSOCIAL,@MAIL,@TELEFONO,@DIRECCION,@CPOSTAL,@CIUDAD,@CUIT,@RUBRO,@NOMBRE,'Habilitado')";
        const String GET_RUBROS_QUERY = "SELECT RUBRO_ID ID, RUBRO_DESCRIPCION DESCRIPCION FROM MANA.RUBRO";
        const String ADD_USUARIO = "INSERT INTO MANA.USUARIO (USER_USERNAME,USER_PASSWORD,USUARIO_ESTADO) VALUES (@USUARIO,@PASSWORD,'Habilitado')";



        public AltaProveedor(DataBaseManager dbm, String user, String pass)
        {
            InitializeComponent();
            _dbm = dbm;
            loadRubro();
            _user = user;
            _pass = pass;
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {

        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            String razonSocial = razonSocialTextBox.Text;
            String cuit = cuitTextBox.Text.ToString();

            if (checkExistProveedor(razonSocial, cuit))
            {
                MessageBox.Show("EL PROVEEDOR YA EXISTE");
            }
            else
            {
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("@RSOCIAL", razonSocial);
                map.Add("@MAIL", mailTextBox.Text);
                map.Add("@TELEFONO", telefonoTextBox.Text);
                map.Add("@DIRECCION", direccionTextBox.Text);
                map.Add("@CPOSTAL", codigoPostalTextBox.Text);
                map.Add("@CIUDAD", ciudadTextBox.Text);
                map.Add("@CUIT", cuit);
                map.Add("@RUBRO", rubroComboBox.SelectedValue);
                map.Add("@NOMBRE",nombreContactoBox1.Text);
                _dbm.executeUpdate(ADD_PROV_QUERY, map);
                MessageBox.Show("EL PROVEEDOR SE DIO DE ALTA");

                Dictionary<string, object> mapUsuario = new Dictionary<string, object>();
                mapUsuario.Add("@USUARIO", _user);
                mapUsuario.Add("@PASSWORD", _pass);
                _dbm.executeUpdate(ADD_USUARIO, mapUsuario);
                MessageBox.Show("EL USUARIO SE DIO DE ALTA");

                Close();
            }

        }

        private Boolean checkExistProveedor(String rSocial, String cuit){
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@RSOCIAL", rSocial);
            map.Add("@CUIT", cuit);
            SqlDataReader resultSet = _dbm.executeSelect(EXISTS_PROV_QUERY, map);
            return resultSet.HasRows;  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void loadRubro()
        {
            SqlDataReader resultSet = _dbm.executeSelect(GET_RUBROS_QUERY);
            this.rubroComboBox.DisplayMember = "Text";
            this.rubroComboBox.ValueMember = "Value";
            List<Rubro> list = new List<Rubro>();
            while (resultSet.Read())
            {
                list.Add(new Rubro() { Text = resultSet["DESCRIPCION"].ToString(), Value = resultSet["ID"].ToString() });
            }
            rubroComboBox.DataSource = list;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class Rubro
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
