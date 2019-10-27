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

namespace FrbaOfertas
{
    public partial class PantallaPrincipalUsuario : Form
    {

        const String GET_FUNC_QUERY = "SELECT F.FR_FUNCIONALIDAD_ID, FU.FUN_NOMBRE NOMBRE FROM MANA.USUARIO_ROL R INNER JOIN MANA.FUNCIONALIDAD_ROL F ON R.UR_ROL_ID = F.FR_ROL_ID INNER JOIN MANA.FUNCIONALIDAD FU ON F.FR_FUNCIONALIDAD_ID = FU.FUNC_ID WHERE R.UR_USR_ID = @USER_ID";

        private DataBaseManager _dbm;

        public PantallaPrincipalUsuario(DataBaseManager dbm,String userId){
            _dbm = dbm;
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
            while (resultSet.Read())
            {
                String nombreFuncionalidad = (String)resultSet.GetValue(resultSet.GetOrdinal("NOMBRE"));
                switch (nombreFuncionalidad)
                {
                    case "Abm Rol": button1.Show(); break;
                    case "Abm Cliente": button3.Show(); break;
                    case "Abm Proveedor": button4.Show(); break;
                    case "Carga Credito": button2.Show(); break;
                    case "Crear Oferta": button5.Show(); break;
                    case "Comprar Oferta": button6.Show(); break;
                    case "Baja Oferta": break;
                    case "Facturacion": button7.Show(); break;
                    case "Estadistica": button8.Show(); break;
                }
            }

        }
    }
}
