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
using LibLlenarCombos;
using IdentificadorPlacasDeVehiculos.Clases;

namespace IdentificadorPlacasDeVehiculos.Consultas
{
    public partial class ctaDatosPropietarios : Form
    {
        LlenarCombos llenarCombos = new LlenarCombos("Parametros.xml");
        LlenarGrids llenarGrids = new LlenarGrids("Parametros.xml");

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
        public ctaDatosPropietarios()
        {
            InitializeComponent();
        }

        private void ctaDatosPropietarios_Load(object sender, EventArgs e)
        {
            llenarGrids.SQL = "select * from DatosPropietarioVehiculo";
            llenarGrids.LlenarGridWindows(dgvDatosPropietarios);

            llenarCombos.SQL = "select idGenero,genero from Genero";
            llenarCombos.CampoID = "idGenero";
            llenarCombos.CampoTexto = "genero";
            llenarCombos.LlenarComboWindows(cbbGenero);
            cbbGenero.SelectedIndex = -1;

            //Perfil del Usuario
            if (UsuarioLogueado.IDPerfil != 1)
            {
                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtCedulaCiudadania.Text == "")
            {
                MessageBox.Show("Debe ingresar una cedula ", "Mensaje");
                txtCedulaCiudadania.Focus();
                return;
            }
            int cedulaCiudadania;
            try
            {
                cedulaCiudadania = Convert.ToInt32(txtCedulaCiudadania.Text);
            }
            catch (Exception)
            {
                cedulaCiudadania = 0;
            }
            if (cedulaCiudadania==0)
            {
                MessageBox.Show("Debe ingresar un valor correcto", "Mensaje");
                txtCedulaCiudadania.Focus();
                return;
            }

            clsDatosPropietarios propietarios = clsDatos.consultarDatosPropietarios(cedulaCiudadania);

            if (propietarios == null)
            {
                MessageBox.Show(clsDatos.Mensaje, "Mensaje");
                btnLimpiar_Click(sender, e);
                txtCedulaCiudadania.Focus();
                return;
            }
            txtCedulaCiudadania.Text= propietarios.cedulaCiudadania.ToString();
            txtNombresApellidos.Text = propietarios.nombreApellidos;
            cbbGenero.SelectedValue = propietarios.idGenero.ToString();
            txtCiudad.Text = propietarios.ciudad;
            txtDireccion.Text = propietarios.direccion;
            txtEmail.Text = propietarios.email;
            txtNroCelular.Text = propietarios.nroCelular;
            txtCodigoPlaca.Text = propietarios.codigoPlaca;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCedulaCiudadania.Text = "";
            txtCiudad.Text = "";
            txtCodigoPlaca.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtNombresApellidos.Text = "";
            txtNroCelular.Text = "";
            cbbGenero.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCedulaCiudadania.Text == "")
            {
                MessageBox.Show("Debe ingresar una cedula ", "Mensaje");
                txtCedulaCiudadania.Focus();
                return;
            }
            int cedulaCiudadania;
            try
            {
                cedulaCiudadania = Convert.ToInt32(txtCedulaCiudadania.Text);
            }
            catch (Exception)
            {
                cedulaCiudadania = 0;
            }
            if (cedulaCiudadania == 0)
            {
                MessageBox.Show("Debe ingresar una cedula", "Mensaje");
                txtCedulaCiudadania.Focus();
                return;
            }
           
            if (txtNombresApellidos.Text == "")
            {
                MessageBox.Show("Debe ingresar nombres y apellidos ", "Mensaje");
                txtNombresApellidos.Focus();
                return;
            }
          
            if (cbbGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar un genero ", "Mensaje");
                cbbGenero.Focus();
                return;
            }
           
            if (txtCiudad.Text == "")
            {
                MessageBox.Show("Debe ingresar una ciudad", "Mensaje");
                txtCiudad.Focus();
                return;
            }
            
            if (txtDireccion.Text == "")
            {
                MessageBox.Show("Debe ingresar una direccion ", "Mensaje");
                txtDireccion.Focus();
                return;
            }
            
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Debe ingresar un email ", "Mensaje");
                txtEmail.Focus();
                return;
            }
            
            if (txtNroCelular.Text == "")
            {
                MessageBox.Show("Debe ingresar un numero de celular", "Mensaje");
                txtNroCelular.Focus();
                return;
            }
           
            if (txtCodigoPlaca.Text == "")
            {
                MessageBox.Show("Debe ingresar un codigo placa ", "Mensaje");
                txtCodigoPlaca.Focus();
                return;
            }
           
            clsDatosPropietarios propietarios = clsDatos.consultarDatosPropietarios(cedulaCiudadania);

            bool existe = !(propietarios == null);

            if(propietarios == null)
            {
                propietarios = new clsDatosPropietarios();
            }
            propietarios.cedulaCiudadania = cedulaCiudadania;
            propietarios.nombreApellidos = txtNombresApellidos.Text;
            propietarios.idGenero = Convert.ToInt32(cbbGenero.SelectedValue);
            propietarios.ciudad = txtCiudad.Text;
            propietarios.direccion = txtDireccion.Text;
            propietarios.email = txtEmail.Text;
            propietarios.nroCelular = txtNroCelular.Text;
            propietarios.codigoPlaca = txtCodigoPlaca.Text;

            if (existe)
            {
                clsDatos.ActualizarDatosPropietarios(propietarios);
            }
            else
            {
                clsDatos.NuevoDatosPropietarios(propietarios);
            }
            MessageBox.Show(clsDatos.Mensaje);
            llenarGrids.LlenarGridWindows(dgvDatosPropietarios);
            txtCedulaCiudadania.Focus();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCedulaCiudadania.Text == "")
            {
                MessageBox.Show("Debe ingresar una cedula ciudadania", "Mensaje");
                txtCedulaCiudadania.Focus();
                return;
            }
            int cedulaCiudadania;
            try
            {
                cedulaCiudadania = Convert.ToInt32(txtCedulaCiudadania.Text);
            }
            catch (Exception)
            {
                cedulaCiudadania = 0;   
            }
            if (cedulaCiudadania == 0)
            {
                MessageBox.Show("Debe ingresar un valor numerico", "Mesaje");
                txtCedulaCiudadania.Focus();
                return;
            }
            clsDatosPropietarios propietarios = clsDatos.consultarDatosPropietarios(cedulaCiudadania);
            if (propietarios == null)
            {
                MessageBox.Show("registro no existe", "Mesaje");
                txtCedulaCiudadania.Focus();
                return;
            }
            DialogResult dr = MessageBox.Show("Está seguro de eliminar el registro", "Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                txtCedulaCiudadania.Focus();
                return;
            }
            clsDatos.eliminarDatosPropietarios(cedulaCiudadania);
            MessageBox.Show(clsDatos.Mensaje);
            llenarGrids.LlenarGridWindows(dgvDatosPropietarios);
            btnLimpiar_Click(sender, e);
            txtCedulaCiudadania.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarDatosPropietarios buscar = new frmBuscarDatosPropietarios();
            buscar.ShowDialog();
            if (buscar.CedulaCiudadania == 0)
            {
                return;
            }
            txtCedulaCiudadania.Text = buscar.CedulaCiudadania.ToString();
            btnConsultar_Click(sender, e);
        }
    }
}
