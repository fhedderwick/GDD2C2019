using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ComprarOferta
{
    public partial class OfertasPublicadas : Form
    {
        private DataBaseManager _dbm;

        public OfertasPublicadas(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            GenerarCupon i = new GenerarCupon(_dbm);
            i.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
