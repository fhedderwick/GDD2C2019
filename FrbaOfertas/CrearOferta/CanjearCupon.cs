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
        private string queryEstadoCupon = "SELECT CUPON_ESTADO FROM MANA.CUPON WHERE CUPON_ID = @CuponId";

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
            
            if (this.camposObligatoriosCompletos() == true)
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
                map.Add("@C_Dest_Fecha_Nac", Convert.ToDateTime(t10.Text));
                map.Add("@C_Dest_Ciudad", t11.Text);
                _dbm.executeProcedure("Mana.CanjearCupon", map);
                
                Dictionary<string, object> map2 = new Dictionary<string, object>();
                map2.Add("@CuponId", t1.Text);
                string estadoCupon = _dbm.executeSelectString(queryEstadoCupon, map2);

                if (estadoCupon == "Deshabilitado")  //Si el cupon fue canjeado entonces tiene que estar deshabilitado. Las validaciones pedidas en el enunciado estan en el Procedure de SQL
                {                   
                    MessageBox.Show("El cupon fue canjeado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    Generacion_Exitosa i = new Generacion_Exitosa(_dbm);
                    i.Show();
                    this.Close();
                }
                else { MessageBox.Show("El cupon no pudo darse de baja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }  
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
