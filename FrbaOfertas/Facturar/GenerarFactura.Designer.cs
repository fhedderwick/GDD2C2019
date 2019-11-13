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
            this.l5 = new System.Windows.Forms.Label();
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.d1 = new System.Windows.Forms.DataGridView();
            this.d2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.d1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2)).BeginInit();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(127, 9);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(100, 23);
            this.l1.TabIndex = 0;
            this.l1.Text = "Factura";
            // 
            // l5
            // 
            this.l5.Location = new System.Drawing.Point(127, 173);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(100, 23);
            this.l5.TabIndex = 4;
            this.l5.Text = "Ofertas Facturadas";
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(455, 283);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(75, 47);
            this.b1.TabIndex = 8;
            this.b1.Text = "Generar Nueva Factura";
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(455, 366);
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
            this.d1.Size = new System.Drawing.Size(366, 205);
            this.d1.TabIndex = 8;
            
            // 
            // d2
            // 
            this.d2.Location = new System.Drawing.Point(12, 57);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(366, 87);
            this.d2.TabIndex = 10;
            
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(455, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 47);
            this.button1.TabIndex = 11;
            this.button1.Text = "Mostrar Tablas";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenerarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 472);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.l5);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.d2);
            this.Name = "GenerarFactura";
            this.Text = "GenerarFactura";
            ((System.ComponentModel.ISupportInitialize)(this.d1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l5;
        private System.Windows.Forms.DataGridView d1;
        private System.Windows.Forms.DataGridView d2;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button button1;        
    }
}