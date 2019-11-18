using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Login;
using FrbaOfertas.AbmRol;
using FrbaOfertas.AbmProveedor;
using FrbaOfertas.AbmCliente;
using FrbaOfertas.ComprarOferta;
using FrbaOfertas.CrearOferta;
using FrbaOfertas.Facturar;
using FrbaOfertas.CragaCredito;

namespace FrbaOfertas
{
    public partial class PantallaPrincipalUsuario : Form
    {

        const String GET_FUNC_QUERY = "SELECT F.FR_FUNCIONALIDAD_ID, FU.FUN_NOMBRE NOMBRE FROM MANA.USUARIO_ROL R INNER JOIN MANA.FUNCIONALIDAD_ROL F ON R.UR_ROL_ID = F.FR_ROL_ID INNER JOIN MANA.FUNCIONALIDAD FU ON F.FR_FUNCIONALIDAD_ID = FU.FUNC_ID WHERE R.UR_USR_ID = @USER_ID";

        private DataBaseManager _dbm;
        private String _userId;
        public PantallaPrincipalUsuario(DataBaseManager dbm,String userId){
            _dbm = dbm;
            _userId = userId;
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@USER_ID", userId);
            SqlDataReader resultSet = _dbm.executeSelect(GET_FUNC_QUERY, map);
            InitializeComponent();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            while (resultSet.Read())
            {
                String nombreFuncionalidad = (String)resultSet.GetValue(resultSet.GetOrdinal("NOMBRE"));
                switch (nombreFuncionalidad)
                {
                    case "Seguridad": button9.Show(); break;
                    case "Abm Rol": button1.Show(); break;
                    case "Abm Cliente": button3.Show(); break;
                    case "Abm Proveedor": button4.Show(); break;
                    case "Carga Credito": button2.Show(); break;
                    case "Ofertas": button5.Show(); break;
                    case "Comprar Oferta": button6.Show(); break;
                    case "Facturacion": button7.Show(); break;
                    case "Listado Estadistico": button8.Show(); break;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaRol listaRol = new ListaRol(_dbm);
            listaRol.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ListaProveedor listaProv = new ListaProveedor(_dbm);
            listaProv.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaCliente listaCliente = new ListaCliente(_dbm);
            listaCliente.Show();
        }       
      
        private void button5_Click_1(object sender, EventArgs e)
        {
            PantallaInicio i = new PantallaInicio(_dbm);
            i.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            OfertasPublicadas i = new OfertasPublicadas(_dbm);
            i.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            IngresoDatos i = new IngresoDatos(_dbm);
            i.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarCredito i = new CargarCredito(_dbm);
            i.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Seguridad i = new Seguridad(_dbm, _userId);
            i.Show();
        }
    }
}