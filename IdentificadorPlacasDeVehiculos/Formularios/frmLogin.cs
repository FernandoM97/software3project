using IdentificadorPlacasDeVehiculos.Clases;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="")
            {
                MessageBox.Show("Debe ingresar un usuario", "Error");
                txtUsuario.Focus();
                return;
            }
            if (txtClave.Text == "")
            {
                MessageBox.Show("Debe ingresar una clave", "Error");
                txtClave.Focus();
                return;
            }

            clsUsuario usuario = clsDatos.consultarUsuario(txtUsuario.Text);

            if (clsDatos.ValidarUsuario(txtUsuario.Text, txtClave.Text))
            {
                frmPrincipal principal = new frmPrincipal();
                principal.UsuarioLogueado = usuario;
                principal.Show(this);
                this.Hide();
            }
            else
            {
                MessageBox.Show(clsDatos.Mensaje);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
