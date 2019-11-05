using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class DateChooser : Form
    {
        private TextBox _fechaTextBox;

        public DateChooser(TextBox fechaTextBox)
        {
            _fechaTextBox = fechaTextBox;
            InitializeComponent();
            monthCalendar1.MaxSelectionCount = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _fechaTextBox.Text = monthCalendar1.SelectionStart.ToShortDateString();
            Close();
        }
    }
}
