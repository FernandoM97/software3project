using LibLlenarGrids;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdentificadorPlacasDeVehiculos.Consultas
{
    public partial class ctaBuscarEntradasSalidas : Form
    {
        private LlenarGrids llenarGrids = new LlenarGrids("Parametros.xml");
        private string codigoPlaca;

        public string CodigoPlaca
        {
            get
            {
                return codigoPlaca;
            }
        }

        public ctaBuscarEntradasSalidas()
        {
            InitializeComponent();
        }

        private void ctaBuscarEntradasSalidas_Load(object sender, EventArgs e)
        {
            llenarGrids.SQL = "SELECT dbo.PuestoVehiculo2.codigoPlaca, dbo.PuestoVehiculo2.fechaEntrada, dbo.PuestoVehiculo2.puestoVehiculo, dbo.SalidaVehiculo2.fechaSalida FROM dbo.PuestoVehiculo2 INNER JOIN dbo.SalidaVehiculo2 ON dbo.PuestoVehiculo2.codigoPlaca = dbo.SalidaVehiculo2.codigoPlacaPuesto GROUP BY dbo.PuestoVehiculo2.codigoPlaca, dbo.PuestoVehiculo2.fechaEntrada, dbo.PuestoVehiculo2.puestoVehiculo, dbo.SalidaVehiculo2.fechaSalida order by 1";
            llenarGrids.LlenarGridWindows(dgvEntradasSalidas);
        }

        private void txtCriterio_TextChanged(object sender, EventArgs e)
        {
            if (rbnCodigoPlaca.Checked)
            {
                llenarGrids.SQL = "SELECT dbo.PuestoVehiculo2.codigoPlaca, dbo.PuestoVehiculo2.fechaEntrada, dbo.PuestoVehiculo2.puestoVehiculo, dbo.SalidaVehiculo2.fechaSalida FROM dbo.PuestoVehiculo2 INNER JOIN dbo.SalidaVehiculo2 ON dbo.PuestoVehiculo2.codigoPlaca = dbo.SalidaVehiculo2.codigoPlacaPuesto WHERE codigoPlaca like '" + txtCriterio.Text + "%' ORDER BY 1";
            }
            else
            {
                int puestoEntrada = 0;
               
                try
                {
                    puestoEntrada = Convert.ToInt32(txtCriterio.Text);
                }
                catch (Exception)
                {
                    puestoEntrada = 0;
                }
                llenarGrids.SQL = "SELECT dbo.PuestoVehiculo2.codigoPlaca, dbo.PuestoVehiculo2.fechaEntrada, dbo.PuestoVehiculo2.puestoVehiculo, dbo.SalidaVehiculo2.fechaSalida FROM dbo.PuestoVehiculo2 INNER JOIN dbo.SalidaVehiculo2 ON dbo.PuestoVehiculo2.codigoPlaca = dbo.SalidaVehiculo2.codigoPlacaPuesto where dbo.PuestoVehiculo2.puestoVehiculo >= " + puestoEntrada + " order by 1";
            }

            llenarGrids.LlenarGridWindows(dgvEntradasSalidas);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbnCodigoPlaca_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void rbnPuesto_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }
    }
}
