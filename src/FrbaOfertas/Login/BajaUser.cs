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
    public partial class BajaUser : Form
    {
        private DataBaseManager _dbm;
        private string queryUser = "SELECT USER_USERNAME FROM MANA.USUARIO WHERE USER_USERNAME = @Username";
        private string queryPassword = "SELECT USER_PASSWORD FROM MANA.USUARIO WHERE USER_USERNAME = @Username";
        private string queryUserId = "SELECT USER_ID FROM MANA.USUARIO WHERE USER_USERNAME = @Username";
        private string queryEstado = "SELECT USUARIO_ESTADO FROM MANA.USUARIO WHERE USER_USERNAME = @Username";

        public BajaUser(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  //Cancelar
            Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {  //Dar de Baja
            if (this.camposObligatoriosCompletos() == true) //Valido ingreso de datos
            { 
                string username = t1.Text;
                string password = t2.Text;                
                 Dictionary<string, object> map = new Dictionary<string, object>();
                        map.Add("@Username", username);
                 Dictionary<string, object> map2 = new Dictionary<string, object>();
                        map2.Add("@Password", password);
                        _dbm.executeProcedure("Mana.ValidarPassword", map2);
                        password = _dbm.executeSelectString("SELECT USER_PASSWORD FROM MANA.TT");
                                                           //Valido que el usuario Exista y que la contraseña actual ingresada sea correcta
                        if (_dbm.executeSelectString(queryUser, map) == username && _dbm.executeSelectString(queryPassword, map) == password)
                        {
                            Dictionary<string, object> map3 = new Dictionary<string, object>();
                             map3.Add("@Username", username);
                             string estado = _dbm.executeSelectString(queryEstado, map3);
                             if (estado != "Deshabilitado") //Valido que el usuario no se encuentre deshabilitado
                             {
                                 Dictionary<string, object> map4 = new Dictionary<string, object>();
                                 map4.Add("@Username", username);
                                 int userId = _dbm.executeSelectInt(queryUserId, map4);
                                 Dictionary<string, object> map5 = new Dictionary<string, object>();
                                 map5.Add("@UserId", userId.ToString());
                                 _dbm.executeProcedure("MANA.BajaUsuario", map5);

                                 MessageBox.Show("La operacion se ha realizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 Hide();
                                 this.Close();
                             }
                             else { MessageBox.Show("El usuario ya se encuentra Deshabilitado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }                            
                        }
                        else { MessageBox.Show("El usuario o la contraseña ingresada no son validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                              _dbm.executeProcedure("Mana.BorrarTT");
            }
            else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private bool camposObligatoriosCompletos()
        {
            return t1.Text.Length != 0 && t2.Text.Length != 0;
        }
    }
}
