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
            string retval = dbm.initialize();
            if (retval.Length == 0)
            {
                System.Console.Out.WriteLine("Connected OK!");
                Login.Login loginPanel = new Login.Login(dbm);
                Application.Run(loginPanel);
            }
            else
            {
                Application.Run(new ErrorConexion(retval));
            }
        }
    }
}
