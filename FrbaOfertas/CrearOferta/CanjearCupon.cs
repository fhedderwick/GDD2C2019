using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CrearOferta
{
    public partial class CanjearCupon : Form
    {
        private DataBaseManager _dbm;
        private string _userId;
        private string rol;
        private string queryUserRol = "SELECT ROL_NOMBRE FROM MANA.ROL WHERE ROL_ID = (SELECT UR_ROL_ID FROM MANA.USUARIO_ROL WHERE UR_USR_ID = @UserId)"; 
        private string queryEstadoCupon = "SELECT CUPON_ESTADO FROM MANA.CUPON WHERE CUPON_ID = @CuponId";
        private string queryCupon = "SELECT COUNT(CUPON_ID) FROM MANA.CUPON WHERE CUPON_ID = @CuponId";

        public CanjearCupon(DataBaseManager dbm, string userId)
        {
            _dbm = dbm;
            _userId = userId;
            InitializeComponent();
            this.load();
        }

        private void load()
        { //Si el usuario es un Proveedor su userId se va a cargar automaticamente.
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("@UserId", _userId);
            rol = _dbm.executeSelectString(queryUserRol, map);
            if (rol == "Proveedor")
            {
                string query = "SELECT PROV_ID FROM MANA.PROVEEDOR WHERE PROV_USER_ID = @UserId";
                Dictionary<string, object> map2 = new Dictionary<string, object>();
                map2.Add("@UserId", _userId);
                t3.Text = _dbm.executeSelectInt(query, map).ToString();
                t3.ReadOnly = true;
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Hide();
            MenuOferta i = new MenuOferta(_dbm, _userId);
            i.Show();
            this.Close();
        }

        private void b2_Click(object sender, EventArgs e)
        {

            if (this.camposObligatoriosCompletos() == true)
            {
                Dictionary<string, object> m = new Dictionary<string, object>();
                m.Add("@CuponId", t1.Text);
                if (_dbm.executeSelectInt(queryCupon, m) != 0) //Valido que el cupon exista
                {
                    string estadoCupon = _dbm.executeSelectString(queryEstadoCupon, m);
                    if (estadoCupon == "Habilitado")  //Valido que el cupon no haya sido canjeado o vencido
                    {
                        Dictionary<string, object> map = new Dictionary<string, object>();
                        map.Add("@CuponId", t1.Text);
                        map.Add("@NumeroOferta", t2.Text);
                        map.Add("@ProveedorId", t3.Text);
                        map.Add("@FechaEntrega", DateTime.Today);
                        map.Add("@C_Dest_Nombre", t4.Text);
                        map.Add("@C_Dest_Apellido", t5.Text);
                        map.Add("@C_Dest_Dni", t6.Text);
                        map.Add("@C_Dest_Direccion", t7.Text);
                        map.Add("@C_Dest_Telefono", t8.Text);
                        map.Add("@C_Dest_Mail ", t9.Text);
                        map.Add("@C_Dest_Fecha_Nac", Convert.ToDateTime(dtFecha.Text));
                        map.Add("@C_Dest_Ciudad", t11.Text);
                        _dbm.executeProcedure("Mana.CanjearCupon", map);
                        //Si el cupon fue canjeado entonces ahora esta deshabilitado. Las validaciones pedidas en el enunciado estan en el Procedure de SQL      
                        estadoCupon = _dbm.executeSelectString(queryEstadoCupon, m);
                        if (estadoCupon == "Deshabilitado")
                        {
                            MessageBox.Show("El cupon fue canjeado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Hide();
                            Generacion_Exitosa i = new Generacion_Exitosa(_dbm, _userId);
                            i.Show();
                            this.Close();
                        }  //Si no fue canjeado -> Hay datos incorrectos: puede ser el codigo de proveedor o el de la oferta
                        else { MessageBox.Show("El cupon no pudo darse de baja. Verifique que los datos ingresados en el sector Datos de Cupon sean correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    else { MessageBox.Show("No se puede realizar la operacion. El cupon ya ha sido canjeado o ha expirado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("El Cupon ingresado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private bool camposObligatoriosCompletos()
        {
            return t1.Text.Length != 0 && t2.Text.Length != 0 && t3.Text.Length != 0 && t4.Text.Length != 0 && t5.Text.Length != 0 &&
                   t6.Text.Length != 0 && t7.Text.Length != 0 && t8.Text.Length != 0 && t9.Text.Length != 0 && t11.Text.Length != 0;
        }
    }
}
