using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Login
{
    public partial class Seguridad : Form
    {
        private DataBaseManager _dbm;
        private String _userId;
        private string queryUserRol = "SELECT ROL_NOMBRE FROM MANA.ROL WHERE ROL_ID = (SELECT UR_ROL_ID FROM MANA.USUARIO_ROL WHERE UR_USR_ID = @UserId)";
        private string rol;
        public Seguridad(DataBaseManager dbm, String userId)
        {
            _dbm = dbm;
            _userId = userId;                        
            InitializeComponent();
            this.load();
        }

        private void load()
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("@UserId", _userId);
            rol = _dbm.executeSelectString(queryUserRol, map);
            if (rol == "AdministradorGral") { b1.Visible = true; }
        }

        private void b3_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private void b2_Click(object sender, EventArgs e)  //Cambiar Password
        {            
            ModificacionPassword i = new ModificacionPassword(_dbm, _userId, rol);
            i.Show();
            
        }

        private void b1_Click(object sender, EventArgs e)  //Baja Usuario
        {            
            BajaUser i = new BajaUser(_dbm);
            i.Show();
        }
    }
}
