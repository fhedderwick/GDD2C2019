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

namespace FrbaOfertas.CragaCredito
{
    public partial class CargarCredito : Form
    {
        private DataBaseManager _dbm;
        private string clienteId;
        private string querySaldo = "SELECT CLI_SALDO FROM MANA.CLIENTE WHERE CLI_ID = @ClienteId";

        public CargarCredito(DataBaseManager dbm)
        {
            _dbm = dbm;            
            InitializeComponent();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            try
            {
                 if (this.validarModoPago() == true && this.ingresoCampos() == true)
                {
                    clienteId = t1.Text;                    
                    Dictionary<string, object> map = new Dictionary<string, object>();                    
                    map.Add("@FechaCarga", DateTime.Today);                      //Fecha del archivo de Configuracion (?
                    map.Add("ClienteId", t1.Text);
                    map.Add("@TipoPago", t3.SelectedItem.ToString());
                    map.Add("@Monto", t4.Text);
                    map.Add("@NumeroTarjeta", t2.Text);
                    _dbm.executeProcedure("Mana.CargarCredito", map);

                    this.obtenerNuevoSaldo(clienteId);                     
                    Hide();
                    CargaExitosa i = new CargaExitosa(_dbm);
                    i.Show();
                    this.Close();
                     
                }
                else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
                //Valido que el cliente exista. Igualmente esta validado en el procedure de SQL
            catch (Exception ex) { MessageBox.Show("Verifique que los datos ingresados sean correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private bool validarModoPago()
        {
            if (this.pagoConEfectivo()) { return true; }
            if (this.pagoConDebito()) { return this.ingresoNumeroTarjeta(); }
            if (this.pagoConCredito()) { return this.ingresoNumeroTarjeta(); }            
            else { return false; }
        }

        private bool ingresoCampos()
        { return t1.Text.Length != 0 && t4.Text.Length != 0; }

        private void t3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pagoConEfectivo()) { t2.ReadOnly = true; }
            if (this.pagoConCredito()) { t2.ReadOnly = false; }
            if (this.pagoConDebito()) { t2.ReadOnly = false; }
        }
        
        private bool pagoConEfectivo() { return t3.SelectedItem.Equals("Efectivo"); }
        private bool pagoConCredito() { return t3.SelectedItem.Equals("Crédito"); }
        private bool pagoConDebito() { return t3.SelectedItem.Equals("Debito"); }
        private bool pagoConTarjeta() { return this.pagoConCredito() || this.pagoConDebito(); }
        private bool ingresoNumeroTarjeta() { return t2.Text.Length != 0; }

        private void obtenerNuevoSaldo(string clienteId)
        {            
            Dictionary<string, object> map1 = new Dictionary<string, object>();
            map1.Add("@ClienteId", clienteId);
            decimal saldo = _dbm.executeSelectDecimal(querySaldo, map1);
          MessageBox.Show("Su carga fue exitosa. Su nuevo saldo es:" + " " + saldo, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
