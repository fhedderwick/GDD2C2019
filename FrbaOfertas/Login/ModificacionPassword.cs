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
    public partial class ModificacionPassword : Form
    {
        private DataBaseManager _dbm;
        private string _userId;
        private string _rol;
        private string queryUser = "SELECT USER_USERNAME FROM MANA.USUARIO WHERE USER_USERNAME = @Username";
        private string queryPassword = "SELECT USER_PASSWORD FROM MANA.USUARIO WHERE USER_USERNAME = @Username";

        public ModificacionPassword(DataBaseManager dbm, String userId, String rol)
        {
            _dbm = dbm;
            _userId = userId;
            _rol = rol;
            InitializeComponent();
            this.load();
        }

        private void load()
        { //Si el usuario es un Cliente o un Proveedor su username se va a cargar automaticamente.
            if (_rol != "AdministradorGral" || _rol != "Administrativo") 
            {
                string query = "SELECT USER_USERNAME FROM MANA.USUARIO WHERE USER_ID = @UserId";
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("@UserId", _userId);
                t1.Text = _dbm.executeSelectString(query, map); 
                t1.ReadOnly = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        { //Cancelar
            Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        { //Cambiar Password
            if (this.camposObligatoriosCompletos() == true) //Valido ingreso de todos los datos
            {
                string username = t1.Text;
                string password = t2.Text;
                string nuevaPassword = t3.Text;
                 Dictionary<string, object> map = new Dictionary<string, object>();
                        map.Add("@Username", username);
                 Dictionary<string, object> mapp = new Dictionary<string, object>();
                        mapp.Add("@Password", password);
                        _dbm.executeProcedure("Mana.ValidarPassword", mapp);
                        password = _dbm.executeSelectString("SELECT USER_PASSWORD FROM MANA.TT");
                                                           //Valido que el usuario Exista y que la contraseña actual ingresada sea correcta
                if(_dbm.executeSelectString(queryUser, map) == username && _dbm.executeSelectString(queryPassword, map) == password) 
                {
                    Dictionary<string, object> m = new Dictionary<string, object>();
                        m.Add("@Username", username);
                        m.Add("@Password", nuevaPassword);
                      _dbm.executeProcedure("MANA.CambiarPassword", m);
                  
                     MessageBox.Show("La operacion se ha realizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     Hide();
                     this.Close();
                }
                else{MessageBox.Show("El usuario o la contraseña ingresada no son validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
              _dbm.executeProcedure("Mana.BorrarTT");
            }
            else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private bool camposObligatoriosCompletos()
        {
            return t1.Text.Length != 0 && t2.Text.Length != 0 && t3.Text.Length != 0;
        }
    }
}
