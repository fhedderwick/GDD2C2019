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
    public partial class ListaProveedor : Form
    {
        private DataBaseManager _dbm;


        public ListaProveedor(DataBaseManager dbm)
        {
            InitializeComponent();
            _dbm = dbm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AltaProveedor altaProv = new AltaProveedor(_dbm);
            altaProv.Show();
        }

        private void ListaProveedor_Load(object sender, EventArgs e)
        {

        }
    }
}
