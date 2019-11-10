namespace FrbaOfertas.Facturar
{
    partial class IngresoDatos
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
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb3 = new System.Windows.Forms.TextBox();
            this.VolverAtras = new System.Windows.Forms.Button();
            this.Facturar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(135, 28);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(139, 23);
            this.l1.TabIndex = 0;
            this.l1.Text = "Ingrese los datos pedidos:";
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(26, 155);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(100, 23);
            this.l2.TabIndex = 1;
            this.l2.Text = "Fecha Inicio";
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(26, 208);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(100, 23);
            this.l3.TabIndex = 2;
            this.l3.Text = "Fecha Final";
            // 
            // l4
            // 
            this.l4.Location = new System.Drawing.Point(26, 97);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(117, 23);
            this.l4.TabIndex = 3;
            this.l4.Text = "Codigo de Proveedor";
            // 
            // tb1
            // 
            this.tb1.Location = new System.Drawing.Point(184, 94);
            this.tb1.Name = "tb1";
            this.tb1.Size = new System.Drawing.Size(100, 20);
            this.tb1.TabIndex = 4;
            // 
            // tb2
            // 
            this.tb2.Location = new System.Drawing.Point(184, 152);
            this.tb2.Name = "tb2";
            this.tb2.Size = new System.Drawing.Size(100, 20);
            this.tb2.TabIndex = 5;
            // 
            // tb3
            // 
            this.tb3.Location = new System.Drawing.Point(184, 205);
            this.tb3.Name = "tb3";
            this.tb3.Size = new System.Drawing.Size(100, 20);
            this.tb3.TabIndex = 6;
            // 
            // VolverAtras
            // 
            this.VolverAtras.Location = new System.Drawing.Point(41, 256);
            this.VolverAtras.Name = "VolverAtras";
            this.VolverAtras.Size = new System.Drawing.Size(75, 41);
            this.VolverAtras.TabIndex = 7;
            this.VolverAtras.Text = "Volver al Menu";
            this.VolverAtras.Click += new System.EventHandler(this.VolverAtras_Click);
            // 
            // Facturar
            // 
            this.Facturar.Location = new System.Drawing.Point(308, 256);
            this.Facturar.Name = "Facturar";
            this.Facturar.Size = new System.Drawing.Size(75, 41);
            this.Facturar.TabIndex = 8;
            this.Facturar.Text = "Facturar";
            this.Facturar.Click += new System.EventHandler(this.Facturar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 309);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.l4);
            this.Controls.Add(this.tb1);
            this.Controls.Add(this.tb2);
            this.Controls.Add(this.tb3);
            this.Controls.Add(this.VolverAtras);
            this.Controls.Add(this.Facturar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label l4;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb3;
        private System.Windows.Forms.Button VolverAtras;
        private System.Windows.Forms.Button Facturar;
    }
}