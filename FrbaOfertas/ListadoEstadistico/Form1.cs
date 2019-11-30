using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frbaOfertas.Listado_Estadistico
{
    public partial class frm_listadoEstadistico : Form
    {
        comandos cma = new comandos();

        public frm_listadoEstadistico()
        {
            InitializeComponent();
        }

        private void btn_obtenerListado_Click(object sender, EventArgs e)
        {
            if (cmb_listado.SelectedItem.ToString() == "Proveedores con mayor porcentaje de descuento ofrecido en sus ofertas .")
            {
                if (cmb_semestre.SelectedItem.ToString() == "1) Enero-Febrero-Marzo-Abril-Mayo-Junio")
                    cma.llenarDataGridView(dgv_listado, "SELECT TOP 5 proveedor_id, precio_lista as Monto, precio_oferta as Oferta, sum(oferta/monto*100) as Descuento FROM MANA.proveedor p join MANA.oferta o on p.proveedor_id = o.proveedor_id WHERE MONTH(fecha_publicacion) BETWEEN 1 AND 6 AND YEAR(fecha_publicacion)='" + txt_año.Text + "' GROUP BY p.id_proveedor ORDER BY 2 DESC");

                if (cmb_semestre.SelectedItem.ToString() == "2) Julio-Agosto-Septiembre-Octubre-Noviembre-Diciembre")
                    cma.llenarDataGridView(dgv_listado, "SELECT TOP 5 proveedor_id, precio_lista as Monto, precio_oferta as Oferta, sum(oferta/monto*100) as Descuento FROM MANA.proveedor p join MANA.oferta o on p.proveedor_id = o.proveedor_id WHERE MONTH(fecha_publicacion) BETWEEN 7 AND 12 AND YEAR(fecha_publicacion)='" + txt_año.Text + "' GROUP BY p.id_proveedor ORDER BY 2 DESC");

            }
            else
            {
                if (cmb_listado.SelectedItem.ToString() == "Proveedores con mayor facturación ")
                {
                    if (cmb_semestre.SelectedItem.ToString() == "1) Enero-Febrero-Marzo-Abril-Mayo-Junio")
                        cma.llenarDataGridView(dgv_listado, "SELECT TOP 5 proveedor_id, sum(importe_total) AS 'Importe total' FROM MANA.oferta_vendida ov join MANA item_factura i on ov.oferta_vendida_id = i.oferta_vendida_id join MANA.factura f on f.factura_id = i.factura_numero  WHERE MONTH(fechaFactura) BETWEEN 1 AND 6 AND YEAR(fechaFactura)= '" + txt_año.Text + "' GROUP BY idEmpresa ORDER BY 2 DESC");

                    if (cmb_semestre.SelectedItem.ToString() == "3) Julio-Agosto-Septiembre-Octubre-Noviembre-Diciembre")
                        cma.llenarDataGridView(dgv_listado, "SELECT TOP 5 proveedor_id, sum(importe_total) AS 'Importe total' FROM MANA.oferta_vendida ov join MANA item_factura i on ov.oferta_vendida_id = i.oferta_vendida_id join MANA.factura f on f.factura_id = i.factura_numero  WHERE MONTH(fechaFactura) BETWEEN 7 AND 12 AND YEAR(fechaFactura)= '" + txt_año.Text + "' GROUP BY idEmpresa ORDER BY 2 DESC");

                
                }
                }
            }
        }

        private void dgv_listado_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void frm_listadoEstadistico_Load(object sender, EventArgs e)
        {
            
    // cargar con bd con otros comandos
    //this.gradoTableAdapter.Fill(this.gD1C2019DataSet.grado);
            //cmb_listado.DropDownStyle = ComboBoxStyle.DropDownList;
           // cmb_semestre.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmb_listado_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}