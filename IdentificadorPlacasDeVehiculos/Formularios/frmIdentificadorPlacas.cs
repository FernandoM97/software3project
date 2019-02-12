using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using IdentificadorPlacasDeVehiculos.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using openalprnet;
using LibParametros;
using System.Net;
using LibLlenarGrids;

namespace IdentificadorPlacasDeVehiculos.Formularios
{
    public partial class frmIdentificadorPlacas : Form
    {
        //Conexion Base de datos SqlServer
        SqlConnection cn = new SqlConnection();

        SqlCommand cmd;
        SqlDataReader sqldr;
        DataSet ds;
        SqlDataAdapter da;
        DataRow dr;

        SqlDataAdapter daPlaca = new SqlDataAdapter();
        BindingSource bsPlaca = new BindingSource();
        DataSet dsPlaca = new DataSet();

        SqlDataAdapter daPuesto = new SqlDataAdapter();
        BindingSource bsPuesto = new BindingSource();
        DataSet dsPuesto = new DataSet();

        SqlDataAdapter daPuesto2 = new SqlDataAdapter();

        SqlDataAdapter daSalida = new SqlDataAdapter();
        BindingSource bsSalida = new BindingSource();
        DataSet dsSalida = new DataSet();

        SqlDataAdapter daSalida2 = new SqlDataAdapter();

        private FilterInfoCollection Dispositivos = null; // Todas las camaras
        private VideoCaptureDevice FuenteDeVideo; // La camara

        //variable del lector placas

        string confPath = Application.StartupPath + "\\openalpr.conf";
        string runtimePath = Application.StartupPath + "\\runtime_data\\";
        AlprNet alpr = null;
        AlprResultsNet results = null;

        // inicializador valores de filtro

        private int minr = 189;
        private int ming = 129;
        private int minb = 32;
        private int maxr = 255;
        private int maxg = 255;
        private int maxb = 226;

        public frmIdentificadorPlacas()
        {
            InitializeComponent();
        }

        //Variables de detenccion

        MotionDetector Dectector;
        float NivelDeDetenccion;

        private void IdentificadorPlacas_Load(object sender, EventArgs e)
        {
            //Conexion Base de datos SqlServer
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

            //Placas vehiculos
            daPlaca.SelectCommand = new SqlCommand("select * from PlacasVehiculo", cn);
            dsPlaca.Clear();
            daPlaca.Fill(dsPlaca);
            dgvPlacas.DataSource = dsPlaca.Tables[0];
            bsPlaca.DataSource = dsPlaca.Tables[0];
            txtCodigoPlaca1.DataBindings.Add(new Binding("Text", bsPlaca, "codigoPlaca"));

            //Puesto vehiculos
            daPuesto.SelectCommand = new SqlCommand("select * from PuestoVehiculo", cn);
            dsPuesto.Clear();
            daPuesto.Fill(dsPuesto);
            dgvPuestoVehiculo.DataSource = dsPuesto.Tables[0];
            bsPuesto.DataSource = dsPuesto.Tables[0];
            txtPuestoVehiculo1.DataBindings.Add(new Binding("Text", bsPuesto, "puestoVehiculo"));

            //Puesto vehiculos2
            daPuesto2.SelectCommand = new SqlCommand("select * from PuestoVehiculo", cn);

            //Salida vehiculos
            daSalida.SelectCommand = new SqlCommand("select * from SalidaVehiculo", cn);
            dsSalida.Clear();
            daSalida.Fill(dsSalida);
            dgvSalidaVehiculos.DataSource = dsSalida.Tables[0];
            bsSalida.DataSource = dsSalida.Tables[0];
            txtCodigoPlacaSalida.DataBindings.Add(new Binding("Text", bsSalida, "codigoPlacaPuesto"));


            //Salida vehiculos2
            daSalida2.SelectCommand = new SqlCommand("select * from SalidaVehiculo", cn);


            try
            {

                // conectar.cargarImagenes(cbListaImagenes);
                cargarImagenes(cbListaImagenes);
                //cbListaImagenes.SelectedIndex = 0;
            }
            catch (IOException ex)
            {

                MessageBox.Show("" + ex);
            }

            //Iniciar variables de detector de Movimiento
            Dectector = new MotionDetector(new TwoFramesDifferenceDetector(), new MotionBorderHighlighting());
            NivelDeDetenccion = 0;

            //Listar dispositivos de entrada de video
            Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //Cargar todos los dispositivos al combo

            foreach (FilterInfo x in Dispositivos)
            {
                cbbCamaras.Items.Add(x.Name.ToString());
                CheckForIllegalCrossThreadCalls = false; //Permite que se escriba en las etiquetas durante el Thread video_NewFrame
                this.Location = new System.Drawing.Point(this.Location.X, 0); //Situa el recuadro parte superior de la pantalla
            }
            cbbCamaras.SelectedIndex = 1;
            //lector placa
            PictureBoxORIGINAL.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxFILTRADO.SizeMode = PictureBoxSizeMode.StretchImage;

            alpr = new AlprNet("us", confPath, runtimePath);
            cn.Close();
        }

        private void VideoNewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (!ExisteCodigoPlaca(txtCodigoPlaca.Text))
            {
                try
                {
                    Bitmap imagenOriginal = new Bitmap(490, 419);
                    Bitmap imagenFiltrada = new Bitmap(490, 419);

                    imagenOriginal = (Bitmap)eventArgs.Frame.Clone(); // Imagen de la camara
                    imagenFiltrada = (Bitmap)eventArgs.Frame.Clone(); // Imagen filtrada

                    // Filtrado de color
                    ColorFiltering colorFiltro = new ColorFiltering();
                    colorFiltro.Red = new IntRange(minr, maxr); //Rojo
                    colorFiltro.Green = new IntRange(ming, maxg); //Verde
                    colorFiltro.Blue = new IntRange(minb, maxb); //Azul
                    colorFiltro.ApplyInPlace(imagenFiltrada);

                    //Pone filtrado en escala de grises para poder procesar Blobs
                    Grayscale gris = Grayscale.CommonAlgorithms.BT709;
                    Bitmap imageng = gris.Apply(imagenFiltrada);

                    //Clasifica Filtrado (Gris) en zonas (Blob)
                    BlobCounter blobs = new BlobCounter();
                    blobs.MinHeight = 10; //Solo tomara las que tenga un tamaño determinado
                    blobs.MinWidth = 10; // Solo tomara las que tenga un tamaño determinado
                    blobs.ObjectsOrder = ObjectsOrder.Size; // Tomara el tamaño mayor 
                    blobs.ProcessImage(imageng); // Ejecuta el clasificador

                    Rectangle[] arregloRetangulos = blobs.GetObjectsRectangles(); // Coleccion de Blobs pasados a rectangulos
                    if (arregloRetangulos.Length > 0)
                    {
                        Rectangle retangulo = arregloRetangulos[0]; // ...Toma el primero porque es el mas grande
                        Graphics dibulo = Graphics.FromImage(imagenOriginal); // .... Y sobre la imagen del PictureBox....
                        Pen trazo = new Pen(Color.Yellow, 5);
                        dibulo.DrawRectangle(trazo, retangulo); // Dibuja el rectangulo del Blog
                        dibulo.Dispose(); // Libera el dibujo anterior
                    }
                    results = alpr.Recognize(imagenFiltrada);
                    PictureBoxORIGINAL.Image = imagenOriginal; // Proyecta las imagenes real
                    PictureBoxFILTRADO.Image = imagenFiltrada; // Proyecta las imagenes filtradas

                    if (results.Plates.Count > 0)
                    {
                        txtCodigoPlaca.Text = results.Plates[0].BestPlate.Characters;
                        txtCodigoPlaca.ForeColor = Color.Yellow;
                        PictureBoxORIGINAL.Image = imagenOriginal; // Proyecta las imagenes real
                        PictureBoxFILTRADO.Image = imagenFiltrada;
                    }
                   // txtCodigoPlaca.Text = "";
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error " + ex);
                    return;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Inicia la captura de imagenes de la camara y el Thread viideo_NewFrame
            FuenteDeVideo = new VideoCaptureDevice(Dispositivos[cbbCamaras.SelectedIndex].MonikerString);
            FuenteDeVideo.NewFrame += new NewFrameEventHandler(VideoNewFrame);
            FuenteDeVideo.Start();
            cbbCamaras.Visible = true;
        }
        //Detiene la captura de la Fuente de video

        private void btnDetenerCaptura_Click(object sender, EventArgs e)
        {
            FuenteDeVideo.Stop();
        }

        private void btnIniciarDetenccion_Click(object sender, EventArgs e)
        {
            //Establecer el dispositivo seleccionado como fuente de video
            FuenteDeVideo = new VideoCaptureDevice(Dispositivos[cbbCamaras.SelectedIndex].MonikerString);
            //Inicial el control
            videoSourcePlayerDMovimiento.VideoSource = FuenteDeVideo;
            //Iniciar recepcion de imagen
            videoSourcePlayerDMovimiento.Start();
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            NivelDeDetenccion = Dectector.ProcessFrame(image);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                insertarCodigoPlaca(txtCodigoPlaca.Text);
                cn.Close();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void cbListaImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // FuenteDeVideo.Stop();
                //conectar.verImagen(PictureBoxORIGINAL, cbListaImagenes.SelectedItem.ToString());
                verImagen(PictureBoxORIGINAL, cbListaImagenes.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            bsPlaca.MoveFirst();
            dgvUpdatePlacas();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            bsPlaca.MovePrevious();
            dgvUpdatePlacas();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            bsPlaca.MoveNext();
            dgvUpdatePlacas();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            bsPlaca.MoveLast();
            dsPlaca.Clear();
            daPlaca.Fill(dsPlaca);
            dgvUpdatePlacas();
        }
        private void dgvUpdatePlacas()
        {
            dgvPlacas.ClearSelection();
            dgvPlacas.AllowUserToAddRows = false;
            // dgvPlacas.Rows[bsPlaca.Position].Selected = true;
        }
        private void dgvUpdateDatosPropietario()
        {
            dgvDatosPropietarios.ClearSelection();
            dgvDatosPropietarios.AllowUserToAddRows = false;
            //dgvDatosPropietarios.Rows[bsPlaca.Position].Selected = true;
        }
        public bool ExisteCodigoPlaca(string codigoPlaca)
        {
            int aux = 0;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select(1) from PlacasVehiculo where codigoPlaca = '" + codigoPlaca + "'", cn);
                aux = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error de conexion BD Existe codigoPlaca: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return aux == 1;
        }
        public bool ExistePuestoVehiculo(string puestoVehiculo)
        {
            int aux = 0;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select(1) from PuestoVehiculo where puestoVehiculo = '" + puestoVehiculo + "'", cn);
                aux = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();

                cmd.Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error de conexion BD Existe puesto vehiculo: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return aux == 1;
        }
        public bool ExistePPlaca(string codigoPlaca)
        {
            int aux = 0;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select(1) from PuestoVehiculo where codigoPlaca = '" + codigoPlaca + "'", cn);
                aux = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                cn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error de conexion BD Existe puesto placa: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return aux == 1;
            cn.Close();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!ExistePPlaca(txtCodigoPlaca1.Text))
            {
                EliminarCodigoPlaca(txtCodigoPlaca1.Text);
                dsPlaca.Clear();
                daPlaca.Fill(dsPlaca);
                dgvUpdatePlacas();
            }
            else
            {
                MessageBox.Show("Eliminar primero el puesto");
            }
            return;
        }
        public void EliminarCodigoPlaca(string codigoPlaca)
        {
            if (txtCodigoPlaca1.Text == "")
            {
                MessageBox.Show("Debe ingresar un codigo placa: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigoPlaca1.Focus();
                return;
            }
            if (!ExisteCodigoPlaca(txtCodigoPlaca1.Text))
            {
                MessageBox.Show("El codigo placa NO existe en la base de datos: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigoPlaca1.Focus();
                return;
            }
            DialogResult dr = MessageBox.Show("Está seguro de borrar el registro: ", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                txtCodigoPlaca1.Focus();
                return;
            }
            daPlaca.DeleteCommand = new SqlCommand("delete from PlacasVehiculo where codigoPlaca = @codigoPlaca", cn);
            daPlaca.DeleteCommand.Parameters.Add("@codigoPlaca", SqlDbType.VarChar).Value = codigoPlaca;

            cn.Open();
            daPlaca.DeleteCommand.ExecuteNonQuery();
            cn.Close();

            dsPlaca.Clear();
            daPlaca.Fill(dsPlaca);
            dgvUpdatePlacas();
        }
        public void eliminarPuesto(int puestoVehiculo)
        {
            try
            {
                if (!ExistePuestoVehiculo(Convert.ToString(puestoVehiculo)))
                {
                    MessageBox.Show("El puesto vehiculo NO existe en la base de datos: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPuestoVehiculo1.Focus();
                    return;
                }

                daPuesto.DeleteCommand = new SqlCommand("delete from PuestoVehiculo where puestoVehiculo = @puestoVehiculo", cn);
                daPuesto.DeleteCommand.Parameters.Add("@puestoVehiculo", SqlDbType.Int).Value = puestoVehiculo;

                cn.Open();
                daPuesto.DeleteCommand.ExecuteNonQuery();
                cn.Close();

                dsPuesto.Clear();
                daPuesto.Fill(dsPuesto);
                dgvUpdatePuesto();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error eliminar puesto: " + ex);
            }
        }
        public void eliminarPuestoPlaca(string codigoPlaca)
        {
            try
            {
                if (!ExistePPlaca(codigoPlaca))
                {
                    MessageBox.Show("El puesto vehiculo NO existe en la base de datos: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                daPuesto.DeleteCommand = new SqlCommand("delete from PuestoVehiculo where codigoPlaca = @codigoPlaca", cn);
                daPuesto.DeleteCommand.Parameters.Add("@codigoPlaca", SqlDbType.VarChar).Value = codigoPlaca;

                cn.Open();
                daPuesto.DeleteCommand.ExecuteNonQuery();
                cn.Close();

                dsPuesto.Clear();
                daPuesto.Fill(dsPuesto);
                dgvUpdatePuesto();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error eliminar puesto: " + ex);
            }
        }
        private void dgvUpdatePuesto()
        {
            dgvPuestoVehiculo.ClearSelection();
            dgvPuestoVehiculo.AllowUserToAddRows = false;
            // dgvPuestoVehiculo.Rows[bsPuesto.Position].Selected = true;
        }

        public void generarPuestoVehiculo()
        {
            txtPuestoVehiculo.Text = "";
            while (txtPuestoVehiculo.Text == "")
            {
                txtPuestoVehiculo.Text = datos();
            }
        }
        public string insertarPuestoVehiculo()
        {
            string mensaje = "";

            dtpFechaEntrada.Refresh();
            dtpFechaEntrada.CustomFormat = "dd/MM/yy HH:mm:ss tt";
            dtpFechaEntrada.Format = DateTimePickerFormat.Custom;
            dtpFechaEntrada.Value = DateTime.Now;
            dtpFechaEntrada.ShowUpDown = false;

            try
            {
                daPuesto.InsertCommand = new SqlCommand("Insert into PuestoVehiculo values(@codigoPlaca,@fechaEntrada,@puestoVehiculo)", cn);

                daPuesto.InsertCommand.Parameters.Add("@codigoPlaca", SqlDbType.VarChar).Value = txtCodigoPlaca.Text;
                daPuesto.InsertCommand.Parameters.Add("@fechaEntrada", SqlDbType.DateTime).Value = dtpFechaEntrada.Text;
                daPuesto.InsertCommand.Parameters.Add("@puestoVehiculo", SqlDbType.Int).Value = txtPuestoVehiculo.Text;

                cn.Open();
                daPuesto.InsertCommand.ExecuteNonQuery();
                mensaje = "Se inserto el puesto correctamente";
                cn.Close();

                dsPuesto.Clear();
                daPuesto.Fill(dsPuesto);
                dgvUpdatePuesto();
            }
            catch (Exception ex)
            {
                mensaje = "No se inserto el puesto: " + ex.ToString();
            }
            return mensaje;
        }

        private void btnPrimeroV_Click(object sender, EventArgs e)
        {
            bsPuesto.MoveFirst();
            dgvUpdatePuesto();
        }

        private void btnAnteriorV_Click(object sender, EventArgs e)
        {
            bsPuesto.MovePrevious();
            dgvUpdatePuesto();
        }

        private void btnSiguienteV_Click(object sender, EventArgs e)
        {
            bsPuesto.MoveNext();
            dgvUpdatePuesto();
        }

        private void btnUltimoV_Click(object sender, EventArgs e)
        {
            bsPuesto.MoveLast();
            dgvUpdatePuesto();
        }
        public string datos()
        {
            string cadena = "";

            List<int> miListadgvPuesto = new List<int>();

            foreach (DataGridViewRow fila in dgvPuestoVehiculo.Rows)
            {
                miListadgvPuesto.Add(Convert.ToInt32(fila.Cells[2].Value));
            }

            bool encontrado = false;
            int miPuesto = 0;
            Random rnd = new Random();

            //Random queda bloquedo
            miPuesto = rnd.Next(1, 11);


            foreach (int fila in miListadgvPuesto)
            {
                if (fila == miPuesto)
                {
                    encontrado = true;
                }
            }

            if (encontrado == false)
            {
                cadena = Convert.ToString(miPuesto);

            }
            return cadena;
        }

        private void BtnGenerarPuesto_Click(object sender, EventArgs e)
        {
            txtPuestoVehiculo.Text = "";
            while (txtPuestoVehiculo.Text == "")
            {
                txtPuestoVehiculo.Text = datos();
            }
        }

        private void btnEliminarPuesto_Click(object sender, EventArgs e)
        {

            if (ExistePuestoVehiculo(txtPuestoVehiculo1.Text))
            {
                eliminarPuesto(Convert.ToInt32(txtPuestoVehiculo1.Text));
                dsPuesto.Clear();
                daPuesto.Fill(dsPuesto);
                dgvUpdatePuesto();
                return;
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el puesto", "Error");
            }

        }
        public void EnviarCorreoElectronico()
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            // msg.To.Add("alfonso.gallego.66@hotmail.com.ar");
            // msg.To.Add("andrescamilo_95@hotmail.com");
            // msg.To.Add("acgallegol@uqvirtual.edu.co");
            msg.To.Add(txtEmail.Text);
            msg.Subject = "Su puesto de parqueo es: A" + txtPuestoVehiculo.Text + " UNIQUÍNDIO ARMENIA COLOMBIA";
            msg.Body = "Hola: " + txtNombreApellidos.Text + ", su puesto de parqueo es: A" + txtPuestoVehiculo.Text + " /FACULTAD DE INGENIERIA";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new System.Net.Mail.MailAddress("alfonso.gallego.66@hotmail.com.ar");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential("alfonso.gallego.66@hotmail.com.ar", "18390475alfonso");

            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp-mail.outlook.com";//"sntp.gmail.com"

            try
            {
                cliente.Send(msg);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al enviar el correo: " + ex);
            }
            msg.To.Add("");
        }

        private void rbnCodigoPlaca_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigoPlaca.Text = "";
            txtCodigoPlaca.Focus();
        }

        public void buscarPropietario(string codigoPlaca)
        {
            LlenarGrids llenarGrids = new LlenarGrids("Parametros.xml");
            if (rbnCodigoPlaca.Checked)
            {
                llenarGrids.SQL = "select nombreApellidos,email, codigoPlaca from DatosPropietarioVehiculo where codigoPlaca like '" + codigoPlaca + "%' order by 3";
            }

            llenarGrids.LlenarGridWindows(dgvDatosPropietarios);

            string email = "";
            string nombreApellidos = "";
            email = dgvDatosPropietarios.Rows[0].Cells["email"].Value.ToString();
            nombreApellidos = dgvDatosPropietarios.Rows[0].Cells["nombreApellidos"].Value.ToString();
            txtEmail.Text = email;
            txtNombreApellidos.Text = nombreApellidos;

            codigoPlaca = "";
        }
        public bool ExisteDatoPropietario(string codigoPlaca)
        {
            int aux = 0;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select(1) from DatosPropietarioVehiculo where codigoPlaca = '" + codigoPlaca + "'", cn);
                aux = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
                cmd.Dispose();

                dgvUpdateDatosPropietario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion BD Existe codigoPlaca: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return aux == 1;
            cn.Close();
        }

        private void txtCodigoPlaca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                insertarCodigoPlaca(txtCodigoPlaca.Text);
               
                cn.Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dgvUpdateSalida()
        {
            dgvSalidaVehiculos.ClearSelection();
            dgvSalidaVehiculos.AllowUserToAddRows = false;
            // dgvSalidaVehiculos.Rows[bsSalida.Position].Selected = true;
        }

        private void btnPrimeroS_Click(object sender, EventArgs e)
        {
            bsSalida.MoveFirst();
            dgvUpdateSalida();
        }

        private void btnAnteriorS_Click(object sender, EventArgs e)
        {
            bsSalida.MovePrevious();
            dgvUpdateSalida();
        }

        private void btnSiguienteS_Click(object sender, EventArgs e)
        {
            bsSalida.MoveNext();
            dgvUpdateSalida();
        }

        private void btnUltimoS_Click(object sender, EventArgs e)
        {
            bsSalida.MoveLast();
           // dsSalida.Clear();
           // daSalida.Fill(dsSalida);
           // dgvUpdateSalida();
        }

        private void btnEliminarS_Click(object sender, EventArgs e)
        {
            if (ExisteSalidaVehiculo(txtCodigoPlacaSalida.Text))
            {
                eliminarSalidaVehiculo(txtCodigoPlacaSalida.Text);
                dsSalida.Clear();
                daSalida.Fill(dsSalida);
                dgvUpdateSalida();
                return;
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el codigo placa salida", "Error");
            }
        }
        public bool ExisteSalidaVehiculo(string codigoPlacaSalida)
        {
            int aux = 0;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("select(1) from SalidaVehiculo where codigoPlacaPuesto = '" + codigoPlacaSalida + "'", cn);
                aux = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();

                cmd.Dispose();
                codigoPlacaSalida = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error de conexion BD Existe codigo placa salida: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return aux == 1;
        }
        public void eliminarSalidaVehiculo(string codigoPlacaPuesto)
        {
            try
            {
                if (!ExisteSalidaVehiculo(codigoPlacaPuesto))
                {
                    MessageBox.Show("El codigo placa salida NO existe en la base de datos: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodigoPlacaSalida.Focus();
                    return;
                }

                daSalida.DeleteCommand = new SqlCommand("delete from SalidaVehiculo where codigoPlacaPuesto = @codigoPlacaPuesto", cn);
                daSalida.DeleteCommand.Parameters.Add("@codigoPlacaPuesto", SqlDbType.VarChar).Value = codigoPlacaPuesto;

                cn.Open();
                daSalida.DeleteCommand.ExecuteNonQuery();
                cn.Close();
                ///Malo
               // dsSalida.Clear();
                //daSalida.Fill(dsSalida);
               // dgvUpdateSalida();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error eliminar puesto: " + ex);
            }
        }
        public string insertarSalidaVehiculo(string codigoPlacaPuesto)
        {
            string mensaje = "";

            if (!ExisteSalidaVehiculo(codigoPlacaPuesto) && ExistePPlaca(codigoPlacaPuesto))
            {
                dtpFechaSalida.Refresh();
                dtpFechaSalida.CustomFormat = "dd/MM/yy HH:mm:ss tt";
                dtpFechaSalida.Format = DateTimePickerFormat.Custom;
                dtpFechaSalida.Value = DateTime.Now;
                dtpFechaSalida.ShowUpDown = false;

                try
                {
                    daSalida.InsertCommand = new SqlCommand("Insert into SalidaVehiculo values(@codigoPlacaPuesto,@fechaSalida)", cn);
                    daSalida.InsertCommand.Parameters.Add("@codigoPlacaPuesto", SqlDbType.VarChar).Value = codigoPlacaPuesto;
                    daSalida.InsertCommand.Parameters.Add("@fechaSalida", SqlDbType.DateTime).Value = dtpFechaSalida.Text;


                    cn.Open();
                    daSalida.InsertCommand.ExecuteNonQuery();
                    mensaje = "Se inserto la salida del vehículo correctamente";
                    cn.Close();

                    dsSalida.Clear();
                    daSalida.Fill(dsSalida);
                    dgvUpdateSalida();

                    daSalida.Dispose();
                    codigoPlacaPuesto = "";
                }
                catch (Exception ex)
                {
                    mensaje = "No se inserto la salida del vehículo: " + ex.ToString();
                }
            }
            return mensaje;
        }
        public string insertarSalidaVehiculo2(string codigoPlacaPuesto)
        {
            string mensaje = "";

            if (!ExisteSalidaVehiculo(codigoPlacaPuesto) && ExistePPlaca(codigoPlacaPuesto))
            {
                dtpFechaSalida.Refresh();
                dtpFechaSalida.CustomFormat = "dd/MM/yy HH:mm:ss tt";
                dtpFechaSalida.Format = DateTimePickerFormat.Custom;
                dtpFechaSalida.Value = DateTime.Now;
                dtpFechaSalida.ShowUpDown = false;

                try
                {
                    daSalida2.InsertCommand = new SqlCommand("Insert into SalidaVehiculo2 values(@codigoPlacaPuesto,@fechaSalida)", cn);
                    daSalida2.InsertCommand.Parameters.Add("@codigoPlacaPuesto", SqlDbType.VarChar).Value = codigoPlacaPuesto;
                    daSalida2.InsertCommand.Parameters.Add("@fechaSalida", SqlDbType.DateTime).Value = dtpFechaSalida.Text;


                    cn.Open();
                    daSalida2.InsertCommand.ExecuteNonQuery();
                    mensaje = "Se inserto la salida del vehículo correctamente";
                    cn.Close();

                    daSalida2.Dispose();
                    codigoPlacaPuesto = "";
                }
                catch (Exception ex)
                {
                    mensaje = "No se inserto la salida del vehículo: " + ex.ToString();
                }
            }
            return mensaje;
        }

        private void txtSalida_TextChanged(object sender, EventArgs e)
        {
           
        }
        public void cargarImagenes(ComboBox cbImg)
        {
            try
            {
                cn.Open();
                cmd = new SqlCommand("Select codigoPlaca from PlacasVehiculo", cn);
                sqldr = cmd.ExecuteReader();
                while (sqldr.Read())
                {
                    cbImg.Items.Add(sqldr["codigoPlaca"]);
                }
                sqldr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron las imagenes en el ComboBox: " + ex.ToString());
            }
        }
        public void verImagen(PictureBox pbFoto, string codigoPlaca)
        {
            try
            {
                cn.Open();
                da = new SqlDataAdapter("Select imagenPlaca from PlacasVehiculo where codigoPlaca = '" + codigoPlaca + "'", cn);
                ds = new DataSet();
                da.Fill(ds, "PlacasVehiculo");
                byte[] datos = new byte[0];
                dr = ds.Tables["PlacasVehiculo"].Rows[0];
                datos = (byte[])dr["imagenPlaca"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);
                pbFoto.Image = System.Drawing.Bitmap.FromStream(ms);
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar la Imagen: " + ex.ToString());
            }
        }
        public string insertarImagen(string codigoPlaca, PictureBox pbImagen)
        {
            string mensaje = "Se inserto la imagen placa correctamente";

            if (!ExisteCodigoPlaca(txtCodigoPlaca.Text))
            {
                try
                {
                    cmd = new SqlCommand("Insert into PlacasVehiculo(codigoPlaca,imagenPlaca) values(@codigoPlaca,@imagenPlaca)", cn);
                    cmd.Parameters.Add("@codigoPlaca", SqlDbType.VarChar);
                    cmd.Parameters.Add("@imagenPlaca", SqlDbType.Image);

                    cmd.Parameters["@codigoPlaca"].Value = codigoPlaca;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    cmd.Parameters["@imagenPlaca"].Value = ms.GetBuffer();

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    ms.Dispose();
                    cmd.Dispose();

                    dsPlaca.Clear();
                    daPlaca.Fill(dsPlaca);
                    dgvUpdatePlacas();
                }
                catch (Exception ex)
                {
                    mensaje = "No se inserto la imagen placa: " + ex.ToString();
                }

            }
            return mensaje;
        }
        public void insertarCodigoPlaca(string codigoPlaca)
        {
            txtSalida.Text = txtCodigoPlaca.Text;
            if (ExisteDatoPropietario(codigoPlaca))
            {
                buscarPropietario(txtCodigoPlaca.Text);

                if (txtCodigoPlaca.Text == "")
                {
                    MessageBox.Show("Debe ingresar un codigo placa: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodigoPlaca.Focus();
                }
                insertarNoExistePuestoPlaca();
                insertarSiExistePuestoPlaca();
                
                txtCodigoPlaca.Text = "";
                cn.Close();
            }
            else
            {
                return;
            }
        }
        public void insertarNoExistePuestoPlaca()
        {
            generarPuestoVehiculo();
            if (!ExisteCodigoPlaca(txtCodigoPlaca.Text))
            {
                try
                {
                    insertarImagen(txtCodigoPlaca.Text, PictureBoxORIGINAL);
                    cn.Close();
                }
                catch (Exception ex)
                {
                    return;
                }

                try
                {
                    insertarPuestoVehiculo();
                    EnviarCorreoElectronico();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    return;
                }
                txtCodigoPlaca.Text = "";
            }
            else
            {
                return;
            }
        }
        public void insertarSiExistePuestoPlaca()
        {
            generarPuestoVehiculo();
           
            if (!ExistePPlaca(txtCodigoPlaca.Text))
            {
                try
                {
                    insertarPuestoVehiculo();
                   
                    EnviarCorreoElectronico();
                    txtCodigoPlaca.Text = "";
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                try
                {
                    insertarSalidaVehiculo(txtCodigoPlaca.Text);
                    eliminarPuestoPlacaPuestoSalida();
                    txtCodigoPlaca.Text = "";
                }
                catch (Exception ex)
                {
                    return;
                }
               
                return;
            }
        }
        public void eliminarPuestoPlacaPuestoSalida()
        {
            if(ExistePPlaca(txtCodigoPlaca.Text) && ExisteSalidaVehiculo(txtCodigoPlaca.Text))
            {
                insertarSalidaVehiculo2(txtCodigoPlaca.Text);
                eliminarPuestoPlaca(txtCodigoPlaca.Text);
                eliminarSalidaVehiculo(txtCodigoPlaca.Text);
                txtCodigoPlaca.Text = "";
            }else
            {
                return;
            }
        }
    }
}  
