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
using System.Configuration;

namespace FrbaOfertas.ComprarOferta
{
    public partial class OfertasPublicadas : Form
    {
        private DataBaseManager _dbm;
        private string _userId;
        private string queryOfertasPublicadas = "SELECT * FROM MANA.OFERTA WHERE OF_ESTADO = @Estado AND CONVERT(DATE,OF_FECHA_PUBLICACION) <= CONVERT(DATE,@Fecha,103)"; //103 = dd/mm/yyyy

        public OfertasPublicadas(DataBaseManager dbm, String userId)
        {
            _dbm = dbm;
            _userId = userId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  //Ofertas Publicadas
            d1.Rows.Clear();
            d1.AllowUserToAddRows = true;
            d1.ColumnCount = 10;
            d1.Columns[0].Name = "Codigo de Oferta";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            d1.Columns[1].Name = "Descripcion";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            d1.Columns[2].Name = "Fecha de Publicacion";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            d1.Columns[3].Name = "Fecha de Vencimiento";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            d1.Columns[4].Name = "Precio de Oferta";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            d1.Columns[5].Name = "Precio de Lista";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            d1.Columns[6].Name = "Codigo de Proveedor";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            d1.Columns[7].Name = "Cantidad Disponible";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            d1.Columns[8].Name = "Maximo Unidades por Cliente";
            d1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            string estadoOferta = "Habilitado";              
            string fechaArchivo = ConfigurationManager.AppSettings["fecha"];  //Fecha Archivo Configuracion
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("@Estado", estadoOferta);
            map.Add("@Fecha", fechaArchivo);  //Llamo a las ofertas Habilitadas y que esten vigentes a la fecha
            SqlDataReader resultSet = _dbm.executeSelect(queryOfertasPublicadas, map);
            if (resultSet.HasRows)  //Valido que haya ofertas publicadas actualmente
            {
                while (resultSet.Read())
                {
                    string codigo = (String)resultSet.GetValue(resultSet.GetOrdinal("OF_NUMERO"));
                    string descripcion = (String)resultSet.GetValue(resultSet.GetOrdinal("OF_DESCRIPCION"));
                    DateTime fechaP = (DateTime)resultSet.GetValue(resultSet.GetOrdinal("OF_FECHA_PUBLICACION"));
                    DateTime fechaV = (DateTime)resultSet.GetValue(resultSet.GetOrdinal("OF_FECHA_VENCIMIENTO"));
                    decimal precioO = (decimal)resultSet.GetValue(resultSet.GetOrdinal("OF_PRECIO_OFERTA"));
                    decimal precioL = (decimal)resultSet.GetValue(resultSet.GetOrdinal("OF_PRECIO_LISTA"));
                    int codigoProv = (int)resultSet.GetValue(resultSet.GetOrdinal("OF_PROVEEDOR_ID"));
                    decimal cantidad = (decimal)resultSet.GetValue(resultSet.GetOrdinal("OF_CANTIDAD_DISPONIBLE"));
                    int maximo = (int)resultSet.GetValue(resultSet.GetOrdinal("OF_MAXIMO_UNIDAD_CLIENTE"));

                    string[] row = new string[] { codigo, descripcion, fechaP.ToString(), fechaV.ToString(), precioO.ToString(), precioL.ToString(), codigoProv.ToString(), cantidad.ToString(), maximo.ToString() };
                    d1.Rows.Add(row);

                    for (int i = 0; i < d1.Rows.Count; i++)
                    {
                        d1.Rows[i].ReadOnly = true;
                    }
                }
                d1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                d1.AllowUserToAddRows = false;
            }
            else { MessageBox.Show("No hay ofertas publicadas hasta la fecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {  //Comprar Oferta
            if (d1.SelectedRows.Count > 0)  //Valido que haya elegido 1 oferta
            {                
                string codigoOferta = d1.SelectedRows[0].Cells[0].Value.ToString();
                string precioOferta = d1.SelectedRows[0].Cells[4].Value.ToString();
                string precioLista = d1.SelectedRows[0].Cells[5].Value.ToString();
                Hide();
                ValidarCompra i = new ValidarCompra(_dbm, _userId, codigoOferta, precioOferta, precioLista);
                i.Show();
                this.Close();
            }
            else { MessageBox.Show("Debe seleccionar una Oferta"); }
        }
       
    }
}
