using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace FrbaOfertas.CrearOferta
{
    public partial class AltaOferta : Form
    {
        private DataBaseManager _dbm;
        private string queryProv = "SELECT COUNT(PROV_ID) FROM MANA.PROVEEDOR WHERE PROV_ID = @ProvId";

        public AltaOferta(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            Hide();
            PantallaInicio i = new PantallaInicio(_dbm);
            i.Show();
            this.Close();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
            if (this.camposObligatoriosCompletos() == true)
            {
                if (this.validacionesRequeridas() == true && this.validarFechas() == true)
                {
                     Dictionary<string, object> m = new Dictionary<string, object>();
                     m.Add("@ProvId", tbProveedorId.Text);
                  if(_dbm.executeSelectInt(queryProv, m) != 0)           //Valido que exista el proveedor
                 {
                    Dictionary<string, object> map = new Dictionary<string, object>();
                    map.Add("@Descripcion", tbDescripcion.Text);
                    map.Add("@FechaPublicacion", Convert.ToDateTime(dtFechaPublicacion.Text));
                    map.Add("@FechaVencimiento", Convert.ToDateTime(dtFechaVencimiento.Text));
                    map.Add("@PrecioOferta", tbPrecioOferta.Text);
                    map.Add("@PrecioLista", tbPrecioLista.Text);
                    map.Add("@ProveedorId", tbProveedorId.Text);
                    map.Add("@CantidadDisponible", tbCantidadDisponible.Text);
                    map.Add("@MaximoUnidadesPorCliente", tbMaximoUnidadCliente.Text);
                    _dbm.executeProcedure("Mana.CrearOferta", map);

                    Hide();
                    Generacion_Exitosa i = new Generacion_Exitosa(_dbm);
                    i.Show();
                    this.Close();
                 }
                  else { MessageBox.Show("El proveedor ingresado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Los datos ingresados no son validos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private bool validarFechas()
        { 
            DateTime f1 = Convert.ToDateTime(dtFechaPublicacion.Text);
            DateTime f2 = Convert.ToDateTime(dtFechaVencimiento.Text);
            DateTime fechaActual = DateTime.Today;
            int v1 = fechaActual.CompareTo(f1);
            int v2 = fechaActual.CompareTo(f2);
            int v3 = f1.CompareTo(f2);
            if (v1 == 1 || v2 == 1 || v3 == 1 )  { return false;}
            else { return true; }
        }

        private bool validacionesRequeridas()
        {
            return Convert.ToInt32(tbCantidadDisponible.Text) >= Convert.ToInt32(tbMaximoUnidadCliente.Text);
        }

        private bool camposObligatoriosCompletos()
        {
            return tbDescripcion.Text.Length != 0 && tbPrecioOferta.Text.Length != 0 && tbPrecioLista.Text.Length != 0 &&
                   tbCantidadDisponible.Text.Length != 0 && tbMaximoUnidadCliente.Text.Length != 0 && tbProveedorId.Text.Length != 0;
        }
    }
}
