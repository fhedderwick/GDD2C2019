namespace FrbaOfertas.Facturar
{
    partial class GenerarFactura
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.d1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.d1)).BeginInit();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(258, 9);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(100, 23);
            this.l1.TabIndex = 0;
            this.l1.Text = "Factura";
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(12, 56);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(100, 23);
            this.l2.TabIndex = 1;
            this.l2.Text = "Codigo de Factura";
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(12, 96);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(100, 23);
            this.l3.TabIndex = 2;
            this.l3.Text = "Fecha de Factura";
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(12, 134);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(100, 23);
            this.l4.TabIndex = 3;
            this.l4.Text = "Importe Total";
            // 
            // l5
            // 
            this.l5.Location = new System.Drawing.Point(235, 172);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(100, 23);
            this.l5.TabIndex = 4;
            this.l5.Text = "Ofertas Facturadas";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(152, 53);
            this.tb1.Name = "tb1";
            this.tb1.ReadOnly = true;
            this.tb1.Size = new System.Drawing.Size(100, 20);
            this.tb1.TabIndex = 5;             
            this.tb1.TextChanged += new System.EventHandler(this.tb1_TextChanged);
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(152, 93);
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.Size = new System.Drawing.Size(100, 20);
            this.tb2.TabIndex = 6;
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(152, 134);
            this.tb3.Name = "tb3";
            this.tb3.ReadOnly = true;
            this.tb3.Size = new System.Drawing.Size(100, 20);
            this.tb3.TabIndex = 7;
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(152, 446);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(75, 47);
            this.b1.TabIndex = 8;
            this.b1.Text = "Generar Nueva Factura";
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(364, 446);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(75, 47);
            this.b2.TabIndex = 9;
            this.b2.Text = "Volver al Menu";
            this.b2.Click += new System.EventHandler(this.b2_Click);
            // 
            // d1
            // 
            this.d1.Location = new System.Drawing.Point(12, 208);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(588, 205);
            this.d1.TabIndex = 8;
            // 
            // GenerarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 505);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.l4);
            this.Controls.Add(this.l5);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.d1);
            this.Name = "GenerarFactura";
            this.Text = "GenerarFactura";
            ((System.ComponentModel.ISupportInitialize)(this.d1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label l4;
        private System.Windows.Forms.Label l5;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.DataGridView d1;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;        
    }
}