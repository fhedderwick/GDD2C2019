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

namespace FrbaOfertas.Facturar
{
    public partial class GenerarFactura : Form
    {
        private DataBaseManager _dbm;
        private string queryFactura = "SELECT TOP 1 * FROM MANA.FACTURA ORDER BY FACT_ID DESC";
        private string queryItemFactura = "SELECT * FROM MANA.ITEM_FACTURA WHERE I_FACT_NUMERO = @FacturaNro";
        private string queryNroFactura = "SELECT MAX(FACT_NUMERO) FROM MANA.FACTURA";

        public GenerarFactura(DataBaseManager dbm)
        {
            _dbm = dbm;
            InitializeComponent();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Hide();
            IngresoDatos i = new IngresoDatos(_dbm);
            i.Show();
            this.Close();

        }

        private void b2_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }              

        private void button1_Click(object sender, EventArgs e)
        {
            //Factura
            d2.Rows.Clear();
            d2.AllowUserToAddRows = true;
            d2.ColumnCount = 5;
            d2.Columns[0].Name = "Codigo de Factura";
            d2.Columns[1].Name = "Numero de Factura";
            d2.Columns[2].Name = "Fecha de Factura";
            d2.Columns[3].Name = "Codigo de Proveedor";
            d2.Columns[4].Name = "Importe";
            d2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;            

            SqlDataReader resultSet = _dbm.executeSelect(queryFactura);
            while (resultSet.Read())
            {
                int id = (int)resultSet.GetValue(resultSet.GetOrdinal("FACT_ID"));
                decimal numero = (decimal)resultSet.GetValue(resultSet.GetOrdinal("FACT_NUMERO"));               
                DateTime fecha = (DateTime)resultSet.GetValue(resultSet.GetOrdinal("FACT_FECHA"));
                decimal importe = (decimal)resultSet.GetValue(resultSet.GetOrdinal("FACT_IMPORTE_TOTAL"));
                int provId = (int)resultSet.GetValue(resultSet.GetOrdinal("FACT_PROV_ID"));

                string[] row = new string[] { id.ToString(), numero.ToString(), fecha.ToString(), provId.ToString(), importe.ToString() };
                d2.Rows.Add(row);

                for (int i = 0; i < d2.Rows.Count; i++)
                {
                    d2.Rows[i].ReadOnly = true;
                }
                
            }
            d2.AllowUserToAddRows = false;

            //OfertasFacturadas

            d1.Rows.Clear();
            d1.AllowUserToAddRows = true;
            d1.ColumnCount = 4;
            d1.Columns[0].Name = "Codigo de Item Factura";
            d1.Columns[1].Name = "Numero de Factura";
            d1.Columns[2].Name = "Codigo de Oferta Facturada";
            d1.Columns[3].Name = "Importe de Oferta Facturada";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            decimal numeroFactura = _dbm.executeSelectDecimal(queryNroFactura);
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@FacturaNro", numeroFactura.ToString());
            SqlDataReader resultSet2 = _dbm.executeSelect(queryItemFactura, map);

            while (resultSet2.Read())
            {
                int id = (int)resultSet2.GetValue(resultSet2.GetOrdinal("I_FACT_ID"));
                decimal numeroFact = (decimal)resultSet2.GetValue(resultSet2.GetOrdinal("I_FACT_NUMERO"));
                int nroOferta = (int)resultSet2.GetValue(resultSet2.GetOrdinal("I_FACT_OF_VEN_ID"));
                decimal importeOferta = (decimal)resultSet2.GetValue(resultSet2.GetOrdinal("I_FACT_IMPORTE"));

                string[] row = new string[] { id.ToString(), numeroFact.ToString(), nroOferta.ToString(), importeOferta.ToString() };
                d1.Rows.Add(row);

                for (int i = 0; i < d1.Rows.Count; i++)
                {
                    d1.Rows[i].ReadOnly = true;
                }

            }
            d1.AllowUserToAddRows = false;
        }

    }
}
