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
        private string _userid;

        public Generacion_Exitosa(DataBaseManager dbm, string userId)
        {
            _dbm = dbm;
            _userid = userId;
            InitializeComponent();
        }
        
        private void btnVolverAtras_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }       
       
    }
}
