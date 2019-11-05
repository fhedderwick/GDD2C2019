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
    public partial class ModificarProveedor : Form
    {
        private DataBaseManager _dbm;
        private String _razonSocial;

        public ModificarProveedor(DataBaseManager dbm,String razonSocial)
        {
            InitializeComponent();
            _razonSocial = razonSocial;
            _dbm = dbm;
        }

        private void ModificarProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
