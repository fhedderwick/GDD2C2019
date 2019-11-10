namespace FrbaOfertas.CragaCredito
{
    partial class CargarCredito
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.l4 = new System.Windows.Forms.Label();
            this.l5 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.TextBox();
            this.t2 = new System.Windows.Forms.TextBox();
            this.t3 = new System.Windows.Forms.ComboBox();
            this.t4 = new System.Windows.Forms.TextBox();
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(12, 61);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(100, 23);
            this.l1.TabIndex = 0;
            this.l1.Text = "Codigo de Cliente";
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(12, 198);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(100, 23);
            this.l2.TabIndex = 1;
            this.l2.Text = "Monto";
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(12, 106);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(100, 23);
            this.l3.TabIndex = 2;
            this.l3.Text = "Tipo de Pago";
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(12, 152);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(100, 23);
            this.l4.TabIndex = 3;
            this.l4.Text = "Numero de Tarjeta";
            // 
            // l5
            // 
            this.l5.Location = new System.Drawing.Point(141, 9);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(153, 23);
            this.l5.TabIndex = 4;
            this.l5.Text = "Ingrese los datos solicidatos";
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(144, 58);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(100, 20);
            this.t1.TabIndex = 5;

            // 
            // t2
            // 
            this.t2.Location = new System.Drawing.Point(144, 149);
            this.t2.Name = "t2";
            this.t2.ReadOnly = true;
            this.t2.Size = new System.Drawing.Size(100, 20);
            this.t2.TabIndex = 6;
            // 
            // t3
            // 
            this.t3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.t3.FormattingEnabled = true;
            this.t3.Items.AddRange(new object[] {
            "Efectivo",
            "Debito",
            "Credito"});
            this.t3.Location = new System.Drawing.Point(144, 108);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(100, 21);
            this.t3.TabIndex = 7;
            this.t3.SelectedIndexChanged += new System.EventHandler(this.t3_SelectedIndexChanged);
            // 
            // t4
            // 
            this.t4.Location = new System.Drawing.Point(144, 198);
            this.t4.Name = "t4";
            this.t4.Size = new System.Drawing.Size(100, 20);
            this.t4.TabIndex = 8;

            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(291, 246);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(75, 44);
            this.b1.TabIndex = 9;
            this.b1.Text = "Cargar Credito";
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(51, 246);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(75, 44);
            this.b2.TabIndex = 10;
            this.b2.Text = "Volver al Menu";
            this.b2.Click += new System.EventHandler(this.b2_Click);
            // 
            // CargarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 302);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.l4);
            this.Controls.Add(this.l5);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t3);
            this.Controls.Add(this.t4);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.b2);
            this.Name = "CargarCredito";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label l4;
        private System.Windows.Forms.Label l5;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.TextBox t2;
        private System.Windows.Forms.ComboBox t3;
        private System.Windows.Forms.TextBox t4;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
    }
}