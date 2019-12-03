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
    public partial class BajaProveedor : Form
    {

        private String BAJA_USUARIO_PROCEDURE = "MANA.BajaUsuario";

        private DataBaseManager _dbm;
        ListaProveedor _lista;
        private String _id;
        private String _userId;

        public BajaProveedor(DataBaseManager dbm, ListaProveedor lista, String id, String userId)
        {
            _dbm = dbm;
            _lista = lista;
            _id = id;
            _userId = userId;
            InitializeComponent();
            label2.Text = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary <string, Object> map = new Dictionary<string, Object>();
            map.Add("@UserId", _userId);
            if (1 == _dbm.executeProcedure(BAJA_USUARIO_PROCEDURE, map))
            {
                MessageBox.Show("Proveedor dado de baja correctamente.");
                _lista.llenarListado();
            }
            else
            {
                MessageBox.Show("Error al dar de baja al proveedor.");
            }

            Close();
        }
    }
}
