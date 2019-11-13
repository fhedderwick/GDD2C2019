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

        public CanjearCupon(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Hide();
            PantallaInicio i = new PantallaInicio(_dbm);
            i.Show();
            this.Close();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            int cuponId;
            if (this.camposObligatoriosCompletos() == true)
            {
                cuponId = Convert.ToInt32(t1.Text);
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
                map.Add("@C_Dest_Fecha_Nac", Convert.ToDateTime(t10.Text));
                map.Add("@C_Dest_Ciudad", t11.Text);
                _dbm.executeProcedure("Mana.CanjearCupon", map);
                //Si el cupon fue canjeado entonces tiene que estar deshabilitado. Las validaciones pedidas en el enunciado estan en el Procedure de SQL
                /*
                if (_dbm.executeSelect("SELECT CUPON_ESTADO FROM CUPON WHERE CUPON_ID = cuponId") == "Deshabilitado")
                {
                    Hide();
                    MessageBox.Show("El cupon fue canjeado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else { MessageBox.Show("El cupon no pudo darse de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }  */
            }
            else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private bool camposObligatoriosCompletos()
        {
            return t1.Text.Length != 0 && t2.Text.Length != 0 && t3.Text.Length != 0 && t4.Text.Length != 0 && t5.Text.Length != 0 &&
                   t6.Text.Length != 0 && t7.Text.Length != 0 && t8.Text.Length != 0 && t9.Text.Length != 0 && t10.Text.Length != 0 && t11.Text.Length != 0;
        }
    }
}
