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
using System.Configuration;

namespace FrbaOfertas.CragaCredito
{
    public partial class CargarCredito : Form
    {
        private DataBaseManager _dbm;
        private string _userId;
        private string rol;
        private string clienteId;
        private string queryUserRol = "SELECT ROL_NOMBRE FROM MANA.ROL WHERE ROL_ID = (SELECT UR_ROL_ID FROM MANA.USUARIO_ROL WHERE UR_USR_ID = @UserId)";       
        private string querySaldo = "SELECT CLI_SALDO FROM MANA.CLIENTE WHERE CLI_ID = @ClienteId";
        private string queryCliente = "SELECT COUNT(CLI_ID) FROM MANA.CLIENTE WHERE CLI_ID = @ClienteId";        
        private string queryEstado = "SELECT USUARIO_ESTADO FROM MANA.USUARIO WHERE USER_ID = (SELECT CLI_USER_ID FROM MANA.CLIENTE WHERE CLI_ID = @ClienteId)";

        public CargarCredito(DataBaseManager dbm, String userId)
        {
            _dbm = dbm;
            _userId = userId;
            InitializeComponent();
            this.load();
        }

        private void load()
        { //Si el usuario es un Cliente su userId se va a cargar automaticamente.
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("@UserId", _userId);
            rol = _dbm.executeSelectString(queryUserRol, map);
            if (rol == "Cliente")
            {
                string query = "SELECT CLI_ID FROM MANA.CLIENTE WHERE CLI_USER_ID = @UserId";
                Dictionary<string, object> map2 = new Dictionary<string, object>();
                map2.Add("@UserId", _userId);
                t1.Text = _dbm.executeSelectInt(query, map).ToString();
                t1.ReadOnly = true;
            }
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
                    Dictionary<string, object> map3 = new Dictionary<string, object>();
                    map3.Add("@ClienteId", clienteId);
                    if (_dbm.executeSelectInt(queryCliente, map3) != 0)           //Valido que exista el Cliente
                    {                      
                        Dictionary<string, object> map2 = new Dictionary<string, object>();
                        map2.Add("@ClienteId", clienteId);
                        string estado = _dbm.executeSelectString(queryEstado, map2);

                        if (estado == "Habilitado")  //Valido que el cliente este Habilitado
                        {
                            DateTime fechaArchivo = Convert.ToDateTime(ConfigurationManager.AppSettings["fecha"]);
                            Dictionary<string, object> map = new Dictionary<string, object>();
                            map.Add("@FechaCarga", fechaArchivo);                      //Fecha del archivo de Configuracion
                            map.Add("@ClienteId", t1.Text);
                            map.Add("@TipoPago", t3.SelectedItem.ToString());
                            map.Add("@Monto", t4.Text);
                            map.Add("@NumeroTarjeta", t2.Text);
                            _dbm.executeProcedure("Mana.CargarCredito", map);

                            this.obtenerNuevoSaldo(clienteId);
                            Hide();
                            CargaExitosa i = new CargaExitosa(_dbm, _userId);
                            i.Show();
                            this.Close();
                        }
                        else { MessageBox.Show("El cliente no puede realizar esta operacion porque se encuentra Deshabilitado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                    }
                    else { MessageBox.Show("El cliente ingresado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                }
                else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }  //Si no seleccionas el modo de pago tira error null, lo atrapo con una excepcion
            catch (Exception ex) { MessageBox.Show("Debe seleccionar el modo de pago correspondiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

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
            if (this.pagoConEfectivo()) { t2.ReadOnly = true; t2.Clear(); }
            if (this.pagoConCredito()) { t2.ReadOnly = false; }
            if (this.pagoConDebito()) { t2.ReadOnly = false; }
        }
        
        private bool pagoConEfectivo() { return t3.SelectedItem.Equals("Efectivo"); }
        private bool pagoConCredito() { return t3.SelectedItem.Equals("Crédito"); }
        private bool pagoConDebito() { return t3.SelectedItem.Equals("Debito"); }        
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
