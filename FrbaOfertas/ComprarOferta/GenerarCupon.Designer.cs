namespace FrbaOfertas.ComprarOferta
{
    partial class GenerarCupon
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
            this.d1 = new System.Windows.Forms.DataGridView();
            this.b2 = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.d1)).BeginInit();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l1.Location = new System.Drawing.Point(217, 19);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(120, 27);
            this.l1.TabIndex = 10;
            this.l1.Text = "Cupon Compra";
            // 
            // d1
            // 
            this.d1.Location = new System.Drawing.Point(12, 116);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(560, 150);
            this.d1.TabIndex = 11;
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(67, 348);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(92, 65);
            this.b2.TabIndex = 12;
            this.b2.Text = "Mostrar Cupon";
            this.b2.Click += new System.EventHandler(this.b2_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(369, 348);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(104, 65);
            this.btnSiguiente.TabIndex = 20;
            this.btnSiguiente.Text = "Finalizar Compra";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // GenerarCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 451);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.btnSiguiente);
            this.Name = "GenerarCupon";
            this.Text = "GenerarCupon";
            ((System.ComponentModel.ISupportInitialize)(this.d1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.DataGridView d1;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button b2;
    }
}