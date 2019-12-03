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

        private String query1 = "SELECT TOP 5 O.OF_PROVEEDOR_ID PROV_ID, P.PROV_RAZON_SOCIAL, P.PROV_CUIT, COUNT(*) CANTIDAD_OFERTAS, ROUND(AVG((100*(O.OF_PRECIO_LISTA-O.OF_PRECIO_OFERTA)/O.OF_PRECIO_LISTA)),2) MONTO_DESC_PROV " +
          " FROM MANA.OFERTA O INNER JOIN MANA.PROVEEDOR P ON O.OF_PROVEEDOR_ID = P.PROV_ID " +
          " WHERE MONTH(O.OF_FECHA_PUBLICACION) >= @mesInicial AND MONTH(O.OF_FECHA_PUBLICACION) <= @mesFinal " +
          " AND YEAR(O.OF_FECHA_PUBLICACION) = @anio " +
          " GROUP BY O.OF_PROVEEDOR_ID, P.PROV_RAZON_SOCIAL, P.PROV_CUIT " +
          " ORDER BY MONTO_DESC_PROV DESC";

        private DataBaseManager _dbm;
        private String query2 = "SELECT C.CLI_ID ID, C.CLI_NOMBRE NOMBRE, C.CLI_APELLIDO APELLIDO, C.CLI_DNI DNI, C.CLI_MAIL MAIL, C.CLI_TELEFONO TELEFONO, C.CLI_DIRECCION DIRECCION, C.CLI_CODIGO_POSTAL CODIGO_POSTAL, C.CLI_CIUDAD CIUDAD, C.CLI_FECHA_NACIMIENTO FECHA, C.CLI_SALDO SALDO, U.USUARIO_ESTADO ESTADO FROM MANA.CLIENTE C INNER JOIN MANA.USUARIO U ON U.USER_ID = C.CLI_USER_ID WHERE C.CLI_ID = @clientId";
        int mesInicio;
        int mesFinal;

        public ListadoEstad(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
            loadCombos();
        }

        private void btn_obtenerListado_Click(object sender, EventArgs e)
        {
            if (t1.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el año.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                String firstComboValue = c1.SelectedValue.ToString();
                String secondComboValue = c2.SelectedValue.ToString();
                if ("1".Equals(secondComboValue))
                { mesInicio = 1; mesFinal = 6; }
                else if ("2".Equals(secondComboValue))
                { mesInicio = 7; mesFinal = 12; }
                Dictionary<string, string> map = new Dictionary<string, string>();
                map.Add("@mesInicial", mesInicio.ToString());
                map.Add("@mesFinal", mesFinal.ToString());
                map.Add("@anio", t1.Text);

                //Listado 1
                if ("1".Equals(firstComboValue))
                {
                    d1.Rows.Clear();
                    d1.ColumnCount = 5;
                    d1.Columns[0].Name = "Codigo de Proveedor";
                    d1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    d1.Columns[1].Name = "Razon Social";
                    d1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    d1.Columns[2].Name = "CUIT";
                    d1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    d1.Columns[3].Name = "Cantidad de Ofertas Publicadas";
                    d1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    d1.Columns[4].Name = "Porcentaje de descuento";
                    d1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    SqlDataReader resultSet = _dbm.executeSelect(query1, map);
                    while (resultSet.Read())
                    {
                        int id = (int)resultSet.GetValue(resultSet.GetOrdinal("PROV_ID"));
                        string razonSocial = (String)resultSet.GetValue(resultSet.GetOrdinal("PROV_RAZON_SOCIAL"));
                        string cuit = (String)resultSet.GetValue(resultSet.GetOrdinal("PROV_CUIT"));
                        int cantidad = (int)resultSet.GetValue(resultSet.GetOrdinal("CANTIDAD_OFERTAS"));
                        decimal importe = (decimal)resultSet.GetValue(resultSet.GetOrdinal("MONTO_DESC_PROV"));
                        string importeFinal = formatPercentage(importe);

                        string[] row = new string[] { id.ToString(), razonSocial, cuit, cantidad.ToString(), importeFinal };
                        d1.Rows.Add(row);
                        for (int i = 0; i < d1.Rows.Count; i++)
                        { d1.Rows[i].ReadOnly = true; }
                    }
                    d1.AllowUserToAddRows = false;
                }
                //Listado 2
                else if ("2".Equals(firstComboValue))
                {
                    d1.Rows.Clear();
                    d1.AllowUserToAddRows = true;
                    d1.ColumnCount = 4;
                    d1.Columns[0].Name = "Codigo de Proveedor";
                    d1.Columns[1].Name = "Razon Social de Proveedor";
                    d1.Columns[2].Name = "Cantidad de Facturas realizadas";
                    d1.Columns[3].Name = "Monto Total Facturado";
                    d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    SqlDataReader resultSet = _dbm.executeSelect(query2, map);
                    while (resultSet.Read())
                    {
                        int id = (int)resultSet.GetValue(resultSet.GetOrdinal("PROV_ID"));
                        string razonSocial = (String)resultSet.GetValue(resultSet.GetOrdinal("PROV_RAZON_SOCIAL"));
                        int cantidad = (int)resultSet.GetValue(resultSet.GetOrdinal("CANTIDAD_OFERTAS"));
                        decimal monto = (decimal)resultSet.GetValue(resultSet.GetOrdinal("MONTO_FACT_PROV"));

                        string[] row = new string[] { id.ToString(), razonSocial, cantidad.ToString(), monto.ToString() };
                        d1.Rows.Add(row);
                        for (int i = 0; i < d1.Rows.Count; i++)
                        { d1.Rows[i].ReadOnly = true; }
                    }
                    d1.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void b1_Click(object sender, EventArgs e)  //Cancelar
        {
            Close();
        }

        private void loadCombos()
        {
            c1.DisplayMember = "Text";
            c1.ValueMember = "Value";
            c2.DisplayMember = "Text";
            c2.ValueMember = "Value";

            List<Par> list = new List<Par>();
            string firstOne = "Proveedores con mayor porcentaje de descuento ofrecido en sus ofertas";
            string secondOne = "Proveedores con mayor facturacion";
            list.Add(new Par() { Text = firstOne, Value = "1" });
            list.Add(new Par() { Text = secondOne, Value = "2" });
            c1.DataSource = list;

            List<Par> list2 = new List<Par>();
            string firstTwo = "1) Enero-Febrero-Marzo-Abril-Mayo-Junio";
            string secondTwo = "2) Julio-Agosto-Septiembre-Octubre-Noviembre-Diciembre";
            list2.Add(new Par() { Text = firstTwo, Value = "1" });
            list2.Add(new Par() { Text = secondTwo, Value = "2" });
            c2.DataSource = list2;
        }

        private string formatPercentage(decimal num)
        {
            int index = num.ToString().IndexOf(',');
            return num.ToString().Substring(0, index + 3) +"%";
        }
    }
}