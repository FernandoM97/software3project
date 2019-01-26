using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibLlenarGrids;

namespace IdentificadorPlacasDeVehiculos.Consultas
{
    public partial class frmBuscarDatosPropietarios : Form
    {
        private LlenarGrids llenarGrids = new LlenarGrids("Parametros.xml");
        private int cedulaCiudadania;

        public int CedulaCiudadania
        {
            get
            {
                return cedulaCiudadania;
            }
        }

        public frmBuscarDatosPropietarios()
        {
            InitializeComponent();
        }

        private void frmBuscarDatosPropietarios_Load(object sender, EventArgs e)
        {
            llenarGrids.SQL = "select cedulaCiudadania, codigoPlaca from DatosPropietarioVehiculo order by 2";
            llenarGrids.LlenarGridWindows(dgvBusqueda);
        }

        private void txtCriterio_TextChanged(object sender, EventArgs e)
        {
            if (rbnCodigoPlaca.Checked)
            {
                llenarGrids.SQL = "select cedulaCiudadania, codigoPlaca from DatosPropietarioVehiculo where codigoPlaca like '" + txtCriterio.Text + "%' order by 2";
            }else
            {
                int cedulaCiudadania = 0;
                try
                {
                    cedulaCiudadania = Convert.ToInt32(txtCriterio.Text);
                }
                catch (Exception)
                {
                    cedulaCiudadania = 0;
                }
                llenarGrids.SQL = "select cedulaCiudadania, codigoPlaca from DatosPropietarioVehiculo where cedulaCiudadania >= " + cedulaCiudadania + " order by 1";
            }
           
            llenarGrids.LlenarGridWindows(dgvBusqueda);
        }

        private void rbnCedula_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void rbnCodigoPlaca_CheckedChanged(object sender, EventArgs e)
        {
            txtCriterio.Text = "";
            txtCriterio.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cedulaCiudadania=0;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int pos= Convert.ToInt32(dgvBusqueda.CurrentRow.Index);
            cedulaCiudadania = (int)dgvBusqueda.Rows[pos].Cells[0].Value;
            this.Close();
        }
    }
}
