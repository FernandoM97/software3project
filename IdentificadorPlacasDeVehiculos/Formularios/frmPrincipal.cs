using IdentificadorPlacasDeVehiculos.Clases;
using IdentificadorPlacasDeVehiculos.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdentificadorPlacasDeVehiculos.Formularios
{
    public partial class frmPrincipal : Form
    {
        private clsUsuario usuarioLogueado;

        internal clsUsuario UsuarioLogueado
        {
            get
            {
                return usuarioLogueado;
            }

            set
            {
                usuarioLogueado = value;
            }
        }

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void detencionPlacasVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIdentificadorPlacas placas = new frmIdentificadorPlacas();
            placas.MdiParent = this;
            placas.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmIdentificadorPlacas placas = new frmIdentificadorPlacas();
            placas.Close();
            this.Close();
            Application.Exit();
        }
        
        private void datosPropietariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctaDatosPropietarios propietarios  = new ctaDatosPropietarios();
            propietarios.UsuarioLogueado = this.usuarioLogueado;
            propietarios.MdiParent = this;
            propietarios.Show();
        }

        private void entradasYSalidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctaBuscarEntradasSalidas entradas = new ctaBuscarEntradasSalidas();
            entradas.MdiParent = this;
            entradas.Show();
        }

        private void soloEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ctaBuscarEntradas entradas = new ctaBuscarEntradas();
            entradas.MdiParent = this;
            entradas.Show();
        }
    }
}
