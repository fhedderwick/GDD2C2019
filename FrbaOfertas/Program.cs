using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataBaseManager dbm = new DataBaseManager();
            if (dbm.initialize())
            {
                System.Console.Out.WriteLine("Connected OK!");
                //MainPanel mainPanel = new MainPanel(dbm);
                //Application.Run(mainPanel);
            }
            else
            {
                Application.Run(new ErrorConexion());
            }
        }
    }
}
