using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class RehabilitarCliente : Form
    {

        private String REHABILITAR_USUARIO_PROCEDURE = "MANA.AltaUsuario";

        private DataBaseManager _dbm;
        ListaCliente _lista;
        private String _id;
        private String _userId;

        public RehabilitarCliente(DataBaseManager dbm, ListaCliente lista, String id, String userId)
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
            if (0 != _dbm.executeProcedure(REHABILITAR_USUARIO_PROCEDURE, map))
            {
                MessageBox.Show("Cliente rehabilitado correctamente.");
                _lista.llenarListado();
            }
            else
            {
                MessageBox.Show("Error al rehabilitar al cliente.");
            }

            Close();
        }
    }
}
