using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class ModificarRol : Form
    {

        const String ENABLE_ROL_QUERY = "UPDATE MANA.ROL SET ROL_ESTADO = 'Habilitado' WHERE ROL_ID = @ROL_ID";

        private ListaRol _listaRol;
        private DataBaseManager _dbm;
        private String _rolname;
        private int _rolId;

        public ModificarRol(ListaRol listaRol, DataBaseManager dbm, String rolname, int rolId, bool habilitado)
        {
            _listaRol = listaRol;
            _dbm = dbm;
            _rolname = rolname;
            _rolId = rolId;
            InitializeComponent();
            label1.Text = "Modificando el rol \"" + rolname + "\".";
            button1.Enabled = !habilitado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("@ROL_ID", _rolId);
            if (1 == _dbm.executeUpdate(ENABLE_ROL_QUERY, map))
            {
                MessageBox.Show("El rol \"" + _rolname + "\" se rehabilitó correctamente. Las relaciones previas con los usuarios no se pueden recuperar y deberá hacerlo manualmente.");
                button1.Enabled = false;
                _listaRol.actualizarValores();
            }
            else
            {
                MessageBox.Show("Error al rehabilitar al rol \"" + _rolname + "\".");
            }
        }
    }
}
