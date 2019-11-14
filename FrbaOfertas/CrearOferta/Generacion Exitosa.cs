using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CrearOferta
{
    public partial class Generacion_Exitosa : Form
    {
        private DataBaseManager _dbm;

        public Generacion_Exitosa(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        
        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }       
       
    }
}
