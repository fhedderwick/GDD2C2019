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
        private string queryCantFact = "SELECT COUNT(FACT_ID) FROM MANA.FACTURA";
        private string queryProv = "SELECT COUNT(PROV_ID) FROM MANA.PROVEEDOR WHERE PROV_ID = @ProvId";
        public IngresoDatos(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void Facturar_Click(object sender, EventArgs e)
        {
            if (this.camposObligatoriosCompletos() == true)
            {
               Dictionary<string, object> m = new Dictionary<string, object>();
               m.Add("@ProvId", tb1.Text);
               if(_dbm.executeSelectInt(queryProv, m) != 0)           //Valido que exista el proveedor
               {
                int cantidadFacturas = _dbm.executeSelectInt(queryCantFact);             //Cuento las facturas que tengo antes de generar la nueva
                Dictionary<string, object> map = new Dictionary<string, object>();
                map.Add("@ProveedorId", tb1.Text);
                map.Add("@FechaInicio", Convert.ToDateTime(dtFechaInicio.Text));
                map.Add("@FechaFinal", Convert.ToDateTime(dtFechaFinal.Text));
                _dbm.executeProcedure("Mana.FacturarOfertasAProveedor", map);

                int nuevaCantidadFacturas = _dbm.executeSelectInt(queryCantFact);       //Si se genero una nueva factura entonces tiene que haber 1 mas que antes
                 if (nuevaCantidadFacturas == cantidadFacturas + 1)
                 {
                    Hide();
                    GenerarFactura i = new GenerarFactura(_dbm);                        //Muestro la factura generada
                    i.Show();
                    this.Close();
                 }                                                                                    
                 else { MessageBox.Show("No se pudo realizar la operacion. No existen Ofertas a Facturar en esas fechas para el proveedor ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
               }
                else { MessageBox.Show("El proveedor ingresado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
