namespace frbaOfertas.Listado_Estadistico
{
    partial class frm_listadoEstadistico
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
            this.components = new System.ComponentModel.Container();
            this.lbl_listado = new System.Windows.Forms.Label();
            this.cmb_listado = new System.Windows.Forms.ComboBox();
            this.cmb_semestre = new System.Windows.Forms.ComboBox();
            this.lbl_semestre = new System.Windows.Forms.Label();
            this.lbl_año = new System.Windows.Forms.Label();
            this.txt_año = new System.Windows.Forms.TextBox();
            this.btn_obtenerListado = new System.Windows.Forms.Button();
            this.dgv_listado = new System.Windows.Forms.DataGridView();
            // this.gD2C2019DataSet = new frbaOfertas.GD2C2019DataSet();
            this.gradoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.gradoTableAdapter = new frbaOfertas.GD2C2019DataSetTableAdapters.gradoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).BeginInit();
            // ((System.ComponentModel.ISupportInitialize)(this.gD2C2019DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_listado
            // 
            this.lbl_listado.AutoSize = true;
            this.lbl_listado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbl_listado.Location = new System.Drawing.Point(34, 28);
            this.lbl_listado.Name = "lbl_listado";
            this.lbl_listado.Size = new System.Drawing.Size(353, 24);
            this.lbl_listado.TabIndex = 3;
            this.lbl_listado.Text = "Seleccione el listado que desea obtener:";
            // 
            // cmb_listado
            // 
            this.cmb_listado.FormattingEnabled = true;
            this.cmb_listado.Items.AddRange(new object[] {
            "Empresas con mayor cantidad de localidades no vendidas",
            "Clientes con mayores puntos vencidos",
            "Clientes con mayor cantidad de compras"});
            this.cmb_listado.Location = new System.Drawing.Point(402, 31);
            this.cmb_listado.Name = "cmb_listado";
            this.cmb_listado.Size = new System.Drawing.Size(392, 24);
            this.cmb_listado.TabIndex = 4;
            // this.cmb_listado.SelectedIndexChanged += new System.EventHandler(this.cmb_listado_SelectedIndexChanged);
            // 
            // cmb_semestre
            // 
            this.cmb_semestre.FormattingEnabled = true;
            this.cmb_semestre.Items.AddRange(new object[] {
            "1) Enero-Febrero-Marzo-Abril-Mayo-Junio",
            "2) Julio-Agosto-Septiembre-Octubre-Noviembre-Diciembre"});
            this.cmb_semestre.Location = new System.Drawing.Point(402, 71);
            this.cmb_semestre.Name = "cmb_semestre";
            this.cmb_semestre.Size = new System.Drawing.Size(392, 24);
            this.cmb_semestre.TabIndex = 6;
            // 
            // lbl_semestre
            // 
            this.lbl_semestre.AutoSize = true;
            this.lbl_semestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbl_semestre.Location = new System.Drawing.Point(293, 71);
            this.lbl_semestre.Name = "lbl_semestre";
            this.lbl_semestre.Size = new System.Drawing.Size(94, 24);
            this.lbl_semestre.TabIndex = 5;
            this.lbl_semestre.Text = "semestre:";
            // 
            // lbl_año
            // 
            this.lbl_año.AutoSize = true;
            this.lbl_año.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbl_año.Location = new System.Drawing.Point(337, 110);
            this.lbl_año.Name = "lbl_año";
            this.lbl_año.Size = new System.Drawing.Size(50, 24);
            this.lbl_año.TabIndex = 7;
            this.lbl_año.Text = "Año:";
            // 
            // txt_año
            // 
            this.txt_año.Location = new System.Drawing.Point(402, 112);
            this.txt_año.Name = "txt_año";
            this.txt_año.Size = new System.Drawing.Size(392, 22);
            this.txt_año.TabIndex = 8;
            // 
            // btn_obtenerListado
            // 
            this.btn_obtenerListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_obtenerListado.Location = new System.Drawing.Point(297, 149);
            this.btn_obtenerListado.Name = "btn_obtenerListado";
            this.btn_obtenerListado.Size = new System.Drawing.Size(226, 39);
            this.btn_obtenerListado.TabIndex = 9;
            this.btn_obtenerListado.Text = "Obtener Listado";
            this.btn_obtenerListado.UseVisualStyleBackColor = true;
            this.btn_obtenerListado.Click += new System.EventHandler(this.btn_obtenerListado_Click);
            // 
            // dgv_listado
            // 
            this.dgv_listado.AllowUserToAddRows = false;
            this.dgv_listado.AllowUserToDeleteRows = false;
            this.dgv_listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listado.Location = new System.Drawing.Point(38, 208);
            this.dgv_listado.Name = "dgv_listado";
            this.dgv_listado.ReadOnly = true;
            this.dgv_listado.RowTemplate.Height = 24;
            this.dgv_listado.Size = new System.Drawing.Size(756, 260);
            this.dgv_listado.TabIndex = 10;
            //this.dgv_listado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_listado_CellContentClick);
            // 
            // gD2C2019DataSet
            // 
            //   this.gD2C2019DataSet.DataSetName = "GD2C2019DataSet";
            // this.gD2C2019DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gradoBindingSource
            // 
            this.gradoBindingSource.DataMember = "grado";
            // this.gradoBindingSource.DataSource = this.gD2C2019DataSet;
            // 
            // gradoTableAdapter
            // 
            //      this.gradoTableAdapter.ClearBeforeFill = true;
            // 
            // frm_listadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(835, 482);
            this.Controls.Add(this.dgv_listado);
            this.Controls.Add(this.btn_obtenerListado);
            this.Controls.Add(this.txt_año);
            this.Controls.Add(this.lbl_año);
            this.Controls.Add(this.cmb_semestre);
            this.Controls.Add(this.lbl_semestre);
            this.Controls.Add(this.cmb_listado);
            this.Controls.Add(this.lbl_listado);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frm_listadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Estadístico";
            //    this.Load += new System.EventHandler(this.frm_listadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listado)).EndInit();
            // ((System.ComponentModel.ISupportInitialize)(this.gD2C2019DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_listado;
        private System.Windows.Forms.ComboBox cmb_listado;
        private System.Windows.Forms.ComboBox cmb_semestre;
        private System.Windows.Forms.Label lbl_semestre;
        private System.Windows.Forms.Label lbl_año;
        private System.Windows.Forms.TextBox txt_año;
        private System.Windows.Forms.Button btn_obtenerListado;
        private System.Windows.Forms.DataGridView dgv_listado;
        
        private System.Windows.Forms.BindingSource gradoBindingSource;
       
    }
}