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
    public partial class BajaRol : Form
    {

        const String DISABLE_ROL_QUERY = "UPDATE MANA.ROL SET ROL_ESTADO = 'Deshabilitado' WHERE ROL_ID = @ROL_ID";
        const String DELETE_ROL_USER_RELATIONS_QUERY = "DELETE FROM MANA.USUARIO_ROL WHERE UR_ROL_ID = @ROL_ID";

        DataBaseManager _dbm;
        String _rolname;
        int _rolId;
        private ListaRol _listaRol;
        private string _nombreSeleccionado;
        private int _idSeleccionado;

        public BajaRol(ListaRol listaRol, DataBaseManager dbm, String rolname, int rolId)
        {
            _listaRol = listaRol;
            _dbm = dbm;
            _rolname = rolname;
            _rolId = rolId;
            InitializeComponent();
            label3.Text = _rolname + "?";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add("@ROL_ID", _rolId);
            int deletedRows = _dbm.executeUpdate(DELETE_ROL_USER_RELATIONS_QUERY, map);
            if (1 == _dbm.executeUpdate(DISABLE_ROL_QUERY, map))
            {
                String mensaje = "El rol \"" + _rolname + "\" se dio de baja correctamente. ";
                switch (deletedRows)
                {
                    case 0: mensaje += "No había usuarios con ese rol."; break;
                    case 1: mensaje += "Se dio de baja una relación de usuario."; break;
                    default: mensaje += "Se dieron de baja " + deletedRows + " relaciones de usuario."; break;
                }
                MessageBox.Show(mensaje);
                _listaRol.actualizarValores();
            }
            else
            {
                MessageBox.Show("Error al dar de baja al rol \"" + _rolname + "\".");
            }
            
        }
    }
}
