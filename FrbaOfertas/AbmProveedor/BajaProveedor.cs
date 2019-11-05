using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class W : Form
    {
        private DataBaseManager _dbm;
        private ListaProveedor _lista;
        private String _razonSocial;

        private String DELETE_PROVEEDOR_QUERY = "UPDATE MANA.PROVEEDOR SET PROV_ESTADO = 'Deshabilitado' WHERE PROV_RAZON_SOCIAL = @RSOCIAL";


        
        public W(DataBaseManager dbm,ListaProveedor lista,String razonSocial)
        {
            InitializeComponent();
            _dbm = dbm;
            _lista = lista;
            _razonSocial = razonSocial;
            label2.Text = razonSocial;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BajaProveedor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, Object> map = new Dictionary<string, Object>();
            map.Add("@RSOCIAL", _razonSocial);
            if (1 == _dbm.executeUpdate(DELETE_PROVEEDOR_QUERY, map))
            {
                MessageBox.Show("Proveedor dado de baja correctamente.");
                _lista.searchProveedores();
            }
            else
            {
                MessageBox.Show("Error al dar de baja el proveedor.");
            }

            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
