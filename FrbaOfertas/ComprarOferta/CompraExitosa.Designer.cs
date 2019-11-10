namespace FrbaOfertas.ComprarOferta
{
    partial class CompraExitosa
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
            this.btnVolverMenu = new System.Windows.Forms.Button();
            this.btnComprarNuevaOferta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.Location = new System.Drawing.Point(29, 144);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(75, 54);
            this.btnVolverMenu.TabIndex = 1;
            this.btnVolverMenu.Text = "Volver al Menu";
            this.btnVolverMenu.Click += new System.EventHandler(this.btnVolverMenu_Click);
            // 
            // btnComprarNuevaOferta
            // 
            this.btnComprarNuevaOferta.Location = new System.Drawing.Point(163, 144);
            this.btnComprarNuevaOferta.Name = "btnComprarNuevaOferta";
            this.btnComprarNuevaOferta.Size = new System.Drawing.Size(75, 54);
            this.btnComprarNuevaOferta.TabIndex = 2;
            this.btnComprarNuevaOferta.Text = "Comprar Otra Oferta";
            this.btnComprarNuevaOferta.Click += new System.EventHandler(this.btnComprarNuevaOferta_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 56);
            this.label1.TabIndex = 3;
            this.label1.Text = "Compra Exitosa!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.UseMnemonic = false;
            // 
            // CompraExitosa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVolverMenu);
            this.Controls.Add(this.btnComprarNuevaOferta);
            this.Name = "CompraExitosa";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVolverMenu;
        private System.Windows.Forms.Button btnComprarNuevaOferta;
        private System.Windows.Forms.Label label1;
    }
}