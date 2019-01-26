using IdentificadorPlacasDeVehiculos.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdentificadorPlacasDeVehiculos
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLogin());
            }
            catch (Exception ex)
            {
              //MessageBox.Show("Error Clase Main" + ex);
                return;
            }
        }
    }
}
