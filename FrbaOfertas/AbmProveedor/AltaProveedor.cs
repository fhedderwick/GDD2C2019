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
        const String EXISTS_PROV_QUERY = "SELECT * FROM MANA.PROVEEDOR P WHERE P.PROV_CUIT = @PROV_CUIT AND P.PROV_RAZON_SOCIAL = @PROV_RSOCIAL";
        const String ADD_PROV_QUERY = "INSERT INTO MANA.PROVEEDOR (PROV_RAZON_SOCIAL,PROV_MAIL,PROV_TELEFONO,PROV_DIRECCION,PROV_CIUDAD,PROV_CUIT,PROV_RUBRO_ID,PROV_ESTADO) VALUES (@PROV_RSOCIAL,@PROV_MAIL,@PROV_TEL,@PROV_DIRECCION,@PROV_CIUDAD,@PROV_CUIT,'Habilitado)";
       
        public AltaProveedor(DataBaseManager dbm)
        {
            InitializeComponent();
            _dbm = dbm;
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
                MessageBox.Show("EL PROVEEDOR NO EXISTE");



            }

        }



        private Boolean checkExistProveedor(String rSocial, String cuit){
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@PROV_RSOCIAL", rSocial);
            map.Add("@PROV_CUIT", cuit);
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

    }
}
