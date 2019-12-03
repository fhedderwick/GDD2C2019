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

namespace FrbaOfertas.ComprarOferta
{    
    public partial class GenerarCupon : Form
    {
        private DataBaseManager _dbm;
        private string _userId;
        private string queryCupon = "SELECT TOP 1 * FROM MANA.CUPON ORDER BY CUPON_ID DESC";

        public GenerarCupon(DataBaseManager dbm, String userId)
        {
            _dbm = dbm;
            _userId = userId;
            InitializeComponent();
        }
      
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Hide();
            CompraExitosa i = new CompraExitosa(_dbm, _userId);
            i.Show();
            this.Close();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            //Cupon
            d1.Rows.Clear();
            d1.AllowUserToAddRows = true;
            d1.ColumnCount = 10;
            d1.Columns[0].Name = "Codigo de Cupon";
            d1.Columns[1].Name = "Fecha de Compra";
            d1.Columns[2].Name = "Codigo de Oferta";
            d1.Columns[3].Name = "Precio de Oferta";
            d1.Columns[4].Name = "Precio de Lista";
            d1.Columns[5].Name = "Cantidad Adquirida";
            d1.Columns[6].Name = "Importe";
            d1.Columns[7].Name = "Codigo de Cliente";
            d1.Columns[8].Name = "Estado";
            d1.Columns[9].Name = "Fecha de Validez";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SqlDataReader resultSet = _dbm.executeSelect(queryCupon);
            while (resultSet.Read())
            {
                int id = (int)resultSet.GetValue(resultSet.GetOrdinal("CUPON_ID"));               
                DateTime fecha = (DateTime)resultSet.GetValue(resultSet.GetOrdinal("CUPON_FECHA_COMPRA"));
                string nroOferta = (String)resultSet.GetValue(resultSet.GetOrdinal("CUPON_NUMERO_OFERTA")); 
                decimal precioO = (decimal)resultSet.GetValue(resultSet.GetOrdinal("CUPON_PRECIO_OFERTA"));
                decimal precioL = (decimal)resultSet.GetValue(resultSet.GetOrdinal("CUPON_PRECIO_LISTA"));
                int cantidad = (int)resultSet.GetValue(resultSet.GetOrdinal("CUPON_CANTIDAD_ADQUIRIDA"));
                decimal importe = (decimal)resultSet.GetValue(resultSet.GetOrdinal("CUPON_IMPORTE"));
                int clienteId = (int)resultSet.GetValue(resultSet.GetOrdinal("CUPON_CLI_ID"));
                string estado = (String)resultSet.GetValue(resultSet.GetOrdinal("CUPON_ESTADO"));
                DateTime fechaV = (DateTime)resultSet.GetValue(resultSet.GetOrdinal("CUPON_FECHA_VALIDEZ"));              
                
                string[] row = new string[] { id.ToString(), fecha.ToString(), nroOferta, precioO.ToString(), precioL.ToString(), cantidad.ToString(), importe.ToString(), clienteId.ToString(), estado, fechaV.ToString() };
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
