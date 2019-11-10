namespace FrbaOfertas.CrearOferta
{
    partial class Generacion_Exitosa
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerarNuevaOferta = new System.Windows.Forms.Button();
            this.btnVolverAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "La Oferta ha sido Generada Exitosamente!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.UseMnemonic = false;
            // 
            // btnGenerarNuevaOferta
            // 
            this.btnGenerarNuevaOferta.Location = new System.Drawing.Point(179, 146);
            this.btnGenerarNuevaOferta.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarNuevaOferta.Name = "btnGenerarNuevaOferta";
            this.btnGenerarNuevaOferta.Size = new System.Drawing.Size(112, 54);
            this.btnGenerarNuevaOferta.TabIndex = 1;
            this.btnGenerarNuevaOferta.Text = "Generar Nueva Oferta";
            this.btnGenerarNuevaOferta.Click += new System.EventHandler(this.btnGenerarNuevaOferta_Click);
            // 
            // btnVolverAtras
            // 
            this.btnVolverAtras.Location = new System.Drawing.Point(23, 146);
            this.btnVolverAtras.Margin = new System.Windows.Forms.Padding(4);
            this.btnVolverAtras.Name = "btnVolverAtras";
            this.btnVolverAtras.Size = new System.Drawing.Size(112, 54);
            this.btnVolverAtras.TabIndex = 2;
            this.btnVolverAtras.Text = "Volver al Menu Principal";
            this.btnVolverAtras.Click += new System.EventHandler(this.btnVolverAtras_Click);
            // 
            // Generacion_Exitosa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 238);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarNuevaOferta);
            this.Controls.Add(this.btnVolverAtras);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Generacion_Exitosa";
            this.Text = "Generacion_Exitosa";
            this.ResumeLayout(false);

        }

        #endregion
    
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVolverAtras;
        private System.Windows.Forms.Button btnGenerarNuevaOferta;
    }
}