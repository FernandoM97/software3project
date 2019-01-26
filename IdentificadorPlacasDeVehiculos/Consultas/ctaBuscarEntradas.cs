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
    public partial class ctaBuscarEntradas : Form
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
        public ctaBuscarEntradas()
        {
            InitializeComponent();
        }

        private void ctaBuscarEntradas_Load(object sender, EventArgs e)
        {
            llenarGrids.SQL = "SELECT dbo.DatosPropietarioVehiculo.cedulaCiudadania, dbo.DatosPropietarioVehiculo.nombreApellidos, dbo.DatosPropietarioVehiculo.email, dbo.PuestoVehiculo.codigoPlaca, dbo.PuestoVehiculo.fechaEntrada, dbo.PuestoVehiculo.puestoVehiculo FROM dbo.PuestoVehiculo INNER JOIN dbo.DatosPropietarioVehiculo ON dbo.PuestoVehiculo.codigoPlaca = dbo.DatosPropietarioVehiculo.codigoPlaca order by 4";
            llenarGrids.LlenarGridWindows(dgvEntradas);
        }

        private void txtCriterio_TextChanged(object sender, EventArgs e)
        {
            if (rbnCodigoPlaca.Checked)
            {
                llenarGrids.SQL = "SELECT dbo.DatosPropietarioVehiculo.cedulaCiudadania, dbo.DatosPropietarioVehiculo.nombreApellidos, dbo.DatosPropietarioVehiculo.email, dbo.PuestoVehiculo.codigoPlaca, dbo.PuestoVehiculo.fechaEntrada, dbo.PuestoVehiculo.puestoVehiculo FROM dbo.PuestoVehiculo INNER JOIN dbo.DatosPropietarioVehiculo ON dbo.PuestoVehiculo.codigoPlaca = dbo.DatosPropietarioVehiculo.codigoPlaca where dbo.PuestoVehiculo.codigoPlaca like '" + txtCriterio.Text + "%' order by 4";
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
                llenarGrids.SQL = "SELECT dbo.DatosPropietarioVehiculo.cedulaCiudadania, dbo.DatosPropietarioVehiculo.nombreApellidos, dbo.DatosPropietarioVehiculo.email, dbo.PuestoVehiculo.codigoPlaca, dbo.PuestoVehiculo.fechaEntrada, dbo.PuestoVehiculo.puestoVehiculo FROM dbo.PuestoVehiculo INNER JOIN dbo.DatosPropietarioVehiculo ON dbo.PuestoVehiculo.codigoPlaca = dbo.DatosPropietarioVehiculo.codigoPlaca where dbo.PuestoVehiculo.puestoVehiculo >= " + puestoEntrada + " order by 4";
            }

            llenarGrids.LlenarGridWindows(dgvEntradas);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
