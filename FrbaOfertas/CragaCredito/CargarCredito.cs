using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CragaCredito
{
    public partial class CargarCredito : Form
    {
        public CargarCredito()
        {
            InitializeComponent();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.camposObligatorios() == true && this.ingresoCampos() == true)
                {
                    Hide();
                    CargaExitosa i = new CargaExitosa();
                    i.Show();
                    this.Close();
                }
                else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private bool camposObligatorios()
        {
            if (this.pagoConEfectivo()) { return true; }
            if (this.pagoConDebito()) { return this.ingresoNumeroTarjeta(); }
            if (this.pagoConCredito()) { return this.ingresoNumeroTarjeta(); }
            if (this.noSeleccionoMedio()) { return false; }
            else { return false; }
        }

        private bool ingresoCampos()
        { return t1.Text.Length != 0 && t4.Text.Length != 0; }

        private void t3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.pagoConEfectivo()) { t2.ReadOnly = true; }
            if (this.pagoConCredito()) { t2.ReadOnly = false; }
            if (this.pagoConDebito()) { t2.ReadOnly = false; }
        }

        private bool noSeleccionoMedio() { return t3.SelectedText.Length != 0; }
        private bool pagoConEfectivo() { return t3.SelectedItem.Equals("Efectivo"); }
        private bool pagoConCredito() { return t3.SelectedItem.Equals("Credito"); }
        private bool pagoConDebito() { return t3.SelectedItem.Equals("Debito"); }
        private bool pagoConTarjeta() { return this.pagoConCredito() || this.pagoConDebito(); }
        private bool ingresoNumeroTarjeta() { return t2.Text.Length != 0; }
        
    }
}
