namespace FrbaOfertas.Login
{
    partial class Seguridad
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
            this.b3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l1.Location = new System.Drawing.Point(92, 27);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(100, 23);
            this.l1.TabIndex = 0;
            this.l1.Text = "Seguridad";
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(95, 111);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(75, 42);
            this.b1.TabIndex = 1;
            this.b1.Text = "Baja de Usuario";
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(95, 63);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(75, 42);
            this.b2.TabIndex = 2;
            this.b2.Text = "Cambiar Password";
            // 
            // b3
            // 
            this.b3.Location = new System.Drawing.Point(12, 111);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(75, 40);
            this.b3.TabIndex = 3;
            this.b3.Text = "Volver Atras";
            this.b3.Click += new System.EventHandler(this.b3_Click);
            // 
            // Seguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b3);
            this.Name = "Seguridad";
            this.Text = "Seguridad";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Button b1;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.Button b3;
    }
}