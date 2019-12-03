namespace FrbaOfertas.ListadoEstadistico
{
    partial class ListadoEstad
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
            this.lbl_listado = new System.Windows.Forms.Label();
            this.c1 = new System.Windows.Forms.ComboBox();
            this.c2 = new System.Windows.Forms.ComboBox();
            this.lbl_semestre = new System.Windows.Forms.Label();
            this.lbl_año = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.TextBox();
            this.b2 = new System.Windows.Forms.Button();
            this.d1 = new System.Windows.Forms.DataGridView();
            this.b1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.d1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_listado
            // 
            this.lbl_listado.AutoSize = true;
            this.lbl_listado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbl_listado.Location = new System.Drawing.Point(26, 23);
            this.lbl_listado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_listado.Name = "lbl_listado";
            this.lbl_listado.Size = new System.Drawing.Size(143, 18);
            this.lbl_listado.TabIndex = 3;
            this.lbl_listado.Text = "Seleccione el listado";
            // 
            // c1
            // 
            this.c1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c1.FormattingEnabled = true;
            this.c1.Items.AddRange(new object[] {
            "Proveedores con mayor porcentaje de descuento ofrecido en sus ofertas",
            "Proveedores con mayor facturacion"});
            this.c1.Location = new System.Drawing.Point(190, 23);
            this.c1.Margin = new System.Windows.Forms.Padding(2);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(295, 21);
            this.c1.TabIndex = 4;
            // 
            // c2
            // 
            this.c2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.c2.FormattingEnabled = true;
            this.c2.Items.AddRange(new object[] {
            "1) Enero-Febrero-Marzo-Abril-Mayo-Junio",
            "2) Julio-Agosto-Septiembre-Octubre-Noviembre-Diciembre"});
            this.c2.Location = new System.Drawing.Point(190, 58);
            this.c2.Margin = new System.Windows.Forms.Padding(2);
            this.c2.Name = "c2";
            this.c2.Size = new System.Drawing.Size(295, 21);
            this.c2.TabIndex = 6;
            // 
            // lbl_semestre
            // 
            this.lbl_semestre.AutoSize = true;
            this.lbl_semestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbl_semestre.Location = new System.Drawing.Point(26, 61);
            this.lbl_semestre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_semestre.Name = "lbl_semestre";
            this.lbl_semestre.Size = new System.Drawing.Size(76, 18);
            this.lbl_semestre.TabIndex = 5;
            this.lbl_semestre.Text = "Semestre:";
            // 
            // lbl_año
            // 
            this.lbl_año.AutoSize = true;
            this.lbl_año.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbl_año.Location = new System.Drawing.Point(26, 99);
            this.lbl_año.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_año.Name = "lbl_año";
            this.lbl_año.Size = new System.Drawing.Size(38, 18);
            this.lbl_año.TabIndex = 7;
            this.lbl_año.Text = "Año:";
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(190, 97);
            this.t1.Margin = new System.Windows.Forms.Padding(2);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(73, 20);
            this.t1.TabIndex = 8;
            // 
            // b2
            // 
            this.b2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b2.Location = new System.Drawing.Point(340, 152);
            this.b2.Margin = new System.Windows.Forms.Padding(2);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(170, 32);
            this.b2.TabIndex = 9;
            this.b2.Text = "Obtener Listado";
            this.b2.UseVisualStyleBackColor = true;
            this.b2.Click += new System.EventHandler(this.btn_obtenerListado_Click);
            // 
            // d1
            // 
            this.d1.AllowUserToAddRows = false;
            this.d1.AllowUserToDeleteRows = false;
            this.d1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d1.Location = new System.Drawing.Point(29, 222);
            this.d1.Margin = new System.Windows.Forms.Padding(2);
            this.d1.Name = "d1";
            this.d1.ReadOnly = true;
            this.d1.RowTemplate.Height = 24;
            this.d1.Size = new System.Drawing.Size(567, 155);
            this.d1.TabIndex = 10;
            // 
            // b1
            // 
            this.b1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b1.Location = new System.Drawing.Point(93, 152);
            this.b1.Margin = new System.Windows.Forms.Padding(2);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(170, 32);
            this.b1.TabIndex = 11;
            this.b1.Text = "Volver Atras";
            this.b1.UseVisualStyleBackColor = true;
            this.b1.Click += new System.EventHandler(this.b1_Click);
            // 
            // ListadoEstad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(626, 413);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.d1);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.lbl_año);
            this.Controls.Add(this.c2);
            this.Controls.Add(this.lbl_semestre);
            this.Controls.Add(this.c1);
            this.Controls.Add(this.lbl_listado);
            this.MaximizeBox = false;
            this.Name = "ListadoEstad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Estadístico";
            ((System.ComponentModel.ISupportInitialize)(this.d1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_listado;
        private System.Windows.Forms.ComboBox c1;
        private System.Windows.Forms.ComboBox c2;
        private System.Windows.Forms.Label lbl_semestre;
        private System.Windows.Forms.Label lbl_año;
        private System.Windows.Forms.TextBox t1;
        private System.Windows.Forms.Button b2;
        private System.Windows.Forms.DataGridView d1;               
        private System.Windows.Forms.Button b1;
       
    }
}