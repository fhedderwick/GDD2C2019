using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class ListadoEstad : Form
    {
        private DataBaseManager _dbm;
        private string query1;
        private string query2;
        int mesInicio;
        int mesFinal;

        public ListadoEstad(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void btn_obtenerListado_Click(object sender, EventArgs e)
        {      
            try {
                if (this.camposObligatoriosCompletos() == true)
                {                    
                    string anio = t1.Text;
                                                    //Listado 1
                    if (c1.SelectedItem.ToString() == "Proveedores con mayor porcentaje de descuento ofrecido en sus ofertas")
                    {                        
                        d1.Rows.Clear();
                        d1.AllowUserToAddRows = true;
                        d1.ColumnCount = 4;
                        d1.Columns[0].Name = "Codigo de Proveedor";
                        d1.Columns[1].Name = "Razon Social de Proveedor";
                        d1.Columns[2].Name = "Cantidad de Ofertas Publicadas";
                        d1.Columns[3].Name = "Porcentaje de descuento";
                        d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        if (c2.SelectedItem.ToString() == "1) Enero-Febrero-Marzo-Abril-Mayo-Junio")
                        { mesInicio = 1; mesFinal = 6; }
                         else if (c2.SelectedItem.ToString() == "2) Julio-Agosto-Septiembre-Octubre-Noviembre-Diciembre")
                        { mesInicio = 7; mesFinal = 12; }

                            Dictionary<string, string> map1 = new Dictionary<string, string>();
                            map1.Add("@MesInicio", mesInicio.ToString());
                            map1.Add("@MesFinal", mesFinal.ToString());
                            map1.Add("@Anio", anio);
                         /*   SqlDataReader resultSet = _dbm.executeSelect(query1, map1);
                            while (resultSet.Read())
                            {
                                int id = (int)resultSet.GetValue(resultSet.GetOrdinal("PROV_ID"));
                                string razonSocial = (String)resultSet.GetValue(resultSet.GetOrdinal("PROV_RAZON_SOCIAL"));
                                int cantidad = (int)resultSet.GetValue(resultSet.GetOrdinal("CANT_OFERTAS_PROV"));
                                decimal importe = (decimal)resultSet.GetValue(resultSet.GetOrdinal("MONTO_DESC_PROV"));

                                string[] row = new string[] { id.ToString(), razonSocial, cantidad.ToString(), importe.ToString() };
                                d1.Rows.Add(row);
                                for (int i = 0; i < d1.Rows.Count; i++)
                                { d1.Rows[i].ReadOnly = true;}
                            }
                            d1.AllowUserToAddRows = false;*/
                    }                              
                                                   //Listado 2
                    else if (c1.SelectedItem.ToString() == "Proveedores con mayor facturacion")
                    {
                        d1.Rows.Clear();
                        d1.AllowUserToAddRows = true;
                        d1.ColumnCount = 4;
                        d1.Columns[0].Name = "Codigo de Proveedor";
                        d1.Columns[1].Name = "Razon Social de Proveedor";
                        d1.Columns[2].Name = "Cantidad de Facturas realizadas";
                        d1.Columns[3].Name = "Monto Total Facturado";
                        d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        if (c2.SelectedItem.ToString() == "1) Enero-Febrero-Marzo-Abril-Mayo-Junio")
                        { mesInicio = 1; mesFinal = 6; }
                        else if (c2.SelectedItem.ToString() == "2) Julio-Agosto-Septiembre-Octubre-Noviembre-Diciembre")
                        { mesInicio = 7;mesFinal = 12; }

                        Dictionary<string, string> map2 = new Dictionary<string, string>();
                        map2.Add("@MesInicio", mesInicio.ToString());
                        map2.Add("@MesFinal", mesFinal.ToString());
                        map2.Add("@Anio", anio);
                    /*    SqlDataReader resultSet = _dbm.executeSelect(query2, map2);
                        while (resultSet.Read())
                        {
                            int id = (int)resultSet.GetValue(resultSet.GetOrdinal("PROV_ID"));
                            string razonSocial = (String)resultSet.GetValue(resultSet.GetOrdinal("PROV_RAZON_SOCIAL"));
                            int cantidad = (int)resultSet.GetValue(resultSet.GetOrdinal("CANT_FACT_PROV"));
                            decimal monto = (decimal)resultSet.GetValue(resultSet.GetOrdinal("MONTO_FACT_PROV"));

                            string[] row = new string[] { id.ToString(), razonSocial, cantidad.ToString(), monto.ToString() };
                            d1.Rows.Add(row);
                            for (int i = 0; i < d1.Rows.Count; i++)
                            { d1.Rows[i].ReadOnly = true; }
                        }
                        d1.AllowUserToAddRows = false; */
                    }                  
                }        
             else { MessageBox.Show("Faltan ingresar algunos de los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }            
            catch (Exception ex) { MessageBox.Show("Debe seleccionar el listado y/o semestre que desea obtener", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }        
      }
        private void b1_Click(object sender, EventArgs e)  //Cancelar
        {
            Hide();
            this.Close();
        }
        private bool camposObligatoriosCompletos() { return t1.Text.Length != 0;}
    }
}