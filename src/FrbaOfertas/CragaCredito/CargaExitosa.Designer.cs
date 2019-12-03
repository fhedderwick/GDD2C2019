namespace FrbaOfertas.CragaCredito
{
    partial class CargaExitosa
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
            this.b1 = new System.Windows.Forms.Button();
            this.b2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l1.Location = new System.Drawing.Point(101, 36);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(124, 23);
            this.l1.TabIndex = 0;
            this.l1.Text = "Carga Exitosa!";
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.b1.Location = new System.Drawing.Point(40, 113);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(75, 52);
            this.b1.TabIndex = 1;
            this.b1.Text = "Volver al Menu";
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(186, 113);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(75, 52);
            this.b2.TabIndex = 2;
            this.b2.Text = "Nueva Carga";
            this.b2.Click += new System.EventHandler(this.b2_Click);
            // 
            // CargaExitosa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 207);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.b2);
            this.Name = "CargaExitosa";
            this.Text = "Carga_Exitosa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
    }
}