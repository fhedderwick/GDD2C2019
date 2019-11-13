using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Facturar
{
    public partial class IngresoDatos : Form
    {
        private DataBaseManager _dbm;

        public IngresoDatos(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void Facturar_Click(object sender, EventArgs e)
        {
            if (this.camposObligatoriosCompletos() == true)
            {
                int cantidadFacturas; //Cuento las facturas que tengo antes de generar la nueva

                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("@ProveedorId", tb1.Text);
                map.Add("@FechaInicio", Convert.ToDateTime(dtFechaInicio.Text));
                map.Add("@FechaFinal", Convert.ToDateTime(dtFechaFinal.Text));
                _dbm.executeProcedure("Mana.FacturarOfertasAProveedor", map);

                Hide();
                GenerarFactura i = new GenerarFactura(_dbm);
                i.Show();
                this.Close();
                //Si se genero una nueva factura entonces tiene que haber 1 mas que antes
              /*  if (_dbm.executeSelect("SELECT COUNT(FACT_ID) FROM FACTURA") == (cantidadFacturas + 1))
                {
                   
                }
                else { MessageBox.Show("No se pudo realizar la operacion. Verifique los datos ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }*/
            }
            else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void VolverAtras_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private bool camposObligatoriosCompletos()
        {
            return tb1.Text.Length != 0;
        }
    }
}
