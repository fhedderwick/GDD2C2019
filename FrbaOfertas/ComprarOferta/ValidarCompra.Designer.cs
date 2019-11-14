namespace FrbaOfertas.ComprarOferta
{
    partial class ValidarCompra
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
            this.t1 = new System.Windows.Forms.TextBox();
            this.t2 = new System.Windows.Forms.TextBox();
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(109, 30);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(147, 23);
            this.l1.TabIndex = 0;
            this.l1.Text = "Ingrese los datos solicitados";
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(12, 154);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(100, 23);
            this.l2.TabIndex = 1;
            this.l2.Text = "Cantidad a Adquirir";
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(12, 110);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(100, 23);
            this.l3.TabIndex = 2;
            this.l3.Text = "Codigo de Cliente";
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(156, 151);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(100, 20);
            this.t1.TabIndex = 1;
            // 
            // t2
            // 
            this.t2.Location = new System.Drawing.Point(156, 107);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(100, 20);
            this.t2.TabIndex = 2;
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(212, 214);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(75, 40);
            this.b1.TabIndex = 2;
            this.b1.Text = "Siguiente";
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(53, 214);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(75, 40);
            this.b2.TabIndex = 3;
            this.b2.Text = "Volver al Menu";
            this.b2.Click += new System.EventHandler(this.b2_Click);
            // 
            // ValidarSaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 291);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.b2);
            this.Name = "ValidarSaldo";
            this.Text = "ValidarSaldo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.TextBox t2;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
    }
}