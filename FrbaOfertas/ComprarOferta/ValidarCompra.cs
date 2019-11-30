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

namespace FrbaOfertas.ComprarOferta
{
    public partial class ValidarCompra : Form
    {
        private DataBaseManager _dbm;
        private string _userId;
        private string rol;
        private string codigoOferta;
        private string precioOferta;
        private string precioLista;
        private string codigoCliente;
        private string cantidadAdquirida;
        private string queryUserRol = "SELECT ROL_NOMBRE FROM MANA.ROL WHERE ROL_ID = (SELECT UR_ROL_ID FROM MANA.USUARIO_ROL WHERE UR_USR_ID = @UserId)";   
        private string querySaldoCliente = "SELECT CLI_SALDO FROM MANA.CLIENTE WHERE CLI_ID = @ClienteId";       
        private string queryMaxUnidad = "SELECT OF_MAXIMO_UNIDAD_CLIENTE FROM MANA.OFERTA WHERE OF_NUMERO = @OfertaNro";

        public ValidarCompra(DataBaseManager dbm, string userId, string codigoDeOferta, string precioDeOferta, string precioDeLista)
        {
            _dbm = dbm;
            _userId = userId;
            codigoOferta = codigoDeOferta;
            precioOferta = precioDeOferta;
            precioLista = precioDeLista;
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
                t2.Text = _dbm.executeSelectInt(query, map).ToString();
                t2.ReadOnly = true;
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            codigoCliente = t2.Text;
            cantidadAdquirida = t1.Text;            
            decimal saldoCliente;

            if (this.camposObligatoriosCompletos() == true)  //Valido que se hayan ingresado datos
            {
                try   //Valido que el cliente exista.
                {  
                    Dictionary<string, object> map1 = new Dictionary<string, object>();
                    map1.Add("@ClienteId", codigoCliente);
                    saldoCliente = _dbm.executeSelectDecimal(querySaldoCliente, map1);

                    if (saldoCliente >= (Convert.ToDecimal(precioOferta) * Convert.ToDecimal(cantidadAdquirida))) //Valido Saldo del Cliente. Tambien esta en SQL
                    {
                       Dictionary<string, object> m = new Dictionary<string, object>();                       
                       m.Add("@OfertaNro", codigoOferta);
                       int maximoUnidad = _dbm.executeSelectInt(queryMaxUnidad, m);

                        if (maximoUnidad >= Convert.ToInt32(t1.Text)) //Valido MaxUnidadCliente; tambien esta en Sql
                        {
                            Dictionary<string, object> map = new Dictionary<string, object>();
                            map.Add("@FechaCompra", DateTime.Today);
                            map.Add("@OfertaNumero", codigoOferta);
                            map.Add("@PrecioOferta", precioOferta);
                            map.Add("@PrecioLista", precioLista);
                            map.Add("@CantidadAdquirida", t1.Text);
                            map.Add("@ClienteId", t2.Text);
                            map.Add("@FechaValidez", (DateTime.Now).AddMonths(1));
                            _dbm.executeProcedure("Mana.ComprarOferta", map);

                            MessageBox.Show("La operacion se ha realizado Exitosamente!");
                            GenerarCupon i = new GenerarCupon(_dbm, _userId);
                            i.Show();
                            this.Close();
                        }
                        else { MessageBox.Show("No se pudo realizar la operacion. La cantidad a adquirir supera el limite disponible de compra por cliente."); }
                    }
                    else { MessageBox.Show("No posee suficiente credito para realizar la operacion."); }
                }
                catch (Exception ex) { MessageBox.Show("El cliente ingresado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            else { MessageBox.Show("Faltan ingresar algunos datos."); }
        }

        private bool camposObligatoriosCompletos() { return t1.Text.Length != 0 && t2.Text.Length != 0; }
    }
}