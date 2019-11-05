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
        const String EXISTS_PROV_QUERY = "SELECT * FROM MANA.PROVEEDOR P WHERE P.PROV_CUIT = @CUIT AND P.PROV_RAZON_SOCIAL = @RSOCIAL";
        const String ADD_PROV_QUERY = "INSERT INTO MANA.PROVEEDOR (PROV_RAZON_SOCIAL,PROV_MAIL,PROV_TELEFONO,PROV_DIRECCION,PROV_CODIGO_POSTAL,PROV_CIUDAD,PROV_CUIT,PROV_RUBRO_ID,PROV_NOMBRE_CONTACTO,PROV_ESTADO) VALUES (@RSOCIAL,@MAIL,@TELEFONO,@DIRECCION,@CPOSTAL,@CIUDAD,@CUIT,@RUBRO,@NOMBRE,'Habilitado')";
        const String GET_RUBROS_QUERY = "SELECT RUBRO_DESCRIPCION FROM MANA.RUBRO";

        public AltaProveedor(DataBaseManager dbm)
        {
            InitializeComponent();
            _dbm = dbm;
            cargarRubros();
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
                //String rub = rubroTextBox.Text;
               MessageBox.Show("EL PROVEEDOR NO EXISTE");
               // System.Console.Out.WriteLine("EL RUBRO ES: ");

                //System.Console.Out.WriteLine(rub);

                //Console.Write(rub);

                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("@RSOCIAL", razonSocial);
                map.Add("@MAIL", mailTextBox.Text);
                map.Add("@TELEFONO", telefonoTextBox.Text);
                map.Add("@DIRECCION", direccionTextBox.Text);
                map.Add("@CPOSTAL", codigoPostalTextBox.Text);
                map.Add("@CIUDAD", ciudadTextBox.Text);
                map.Add("@CUIT", cuit);
                map.Add("@RUBRO", 3); //le pongo 3 por defecto q es electronica.
                map.Add("@NOMBRE",nombreContactoBox1.Text);
                _dbm.executeUpdate(ADD_PROV_QUERY, map);

            }

        }



        private Boolean checkExistProveedor(String rSocial, String cuit){
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@RSOCIAL", rSocial);
            map.Add("@CUIT", cuit);
            SqlDataReader resultSet = _dbm.executeSelect(EXISTS_PROV_QUERY, map);
            return resultSet.HasRows;  
        }


        private bool addProveedor(String nombre)
        {
            //Dictionary<string, object> map = new Dictionary<string, object>();
           // map.Add("@ROL_NOMBRE", nombre);
            //return 1 == _dbm.executeUpdate(ADD_ROL_QUERY, map);
            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cargarRubros()
        {
            SqlDataReader resultSet = _dbm.executeSelect(GET_RUBROS_QUERY);

            while (resultSet.Read())
            {

                // String name = (String)resultSet.GetValue(resultSet.GetOrdinal("RUBRO_DESCRIPCION"));
                //comboBox1.Items.Add(name);  

            }

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            
            comboSource.Add("6", "Sunday");
            comboSource.Add("7", "Monday");

            comboBox1.DataSource = new BindingSource(comboSource, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            string key = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Key;
            string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;

        }
    }
}
