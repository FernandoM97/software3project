using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
using LibConexionBD;
using IdentificadorPlacasDeVehiculos.Formularios;

namespace IdentificadorPlacasDeVehiculos.Clases
{
    class clsMetodos
    {
        
        clsDatosPropietarios propietarios = new clsDatosPropietarios();

        //Conexion Base de datos SqlServer
        SqlConnection cn = new SqlConnection();

        SqlCommand cmd;
        SqlDataReader sqldr;
        DataSet ds;
        SqlDataAdapter da;
        DataRow dr;

        SqlDataAdapter daPropietario = new SqlDataAdapter();
        BindingSource bsDatosPropietario = new BindingSource();
        DataSet dsDatosPropietario = new DataSet();

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

       // private FilterInfoCollection Dispositivos = null; // Todas las camaras
       //private VideoCaptureDevice FuenteDeVideo; // La camara

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

        //Variables de detenccion

       // private MotionDetector Dectector;
      //  private float NivelDeDetenccion;

        //Creacion de objetos necesarios
        private DataGridView dgvDatosPropietario = new DataGridView();
        private DataGridView dgvPlacas = new DataGridView();
        private DataTable tabla = new DataTable();
        private TextBox txtCodigoPlaca = new TextBox();
        private TextBox txtCodigoPlaca1 = new TextBox();
        private DataGridView dgvPuestoVehiculo = new DataGridView();
        private TextBox txtPuestoVehiculo = new TextBox();
        private TextBox txtPuestoVehiculo1 = new TextBox();
        private DataGridView dgvSalidaVehiculos = new DataGridView();
        private TextBox txtCodigoPlacaSalida = new TextBox();
        private ComboBox cbListaImagenes = new ComboBox();
        private ComboBox cbbCamaras = new ComboBox();
        private PictureBox PictureBoxORIGINAL = new PictureBox();
        private PictureBox PictureBoxFILTRADO = new PictureBox();
        private DateTimePicker dtpFechaSalida = new DateTimePicker();
        private DateTimePicker dtpFechaEntrada = new DateTimePicker();
        private TextBox txtEmail = new TextBox();
        private TextBox txtNombreApellidos = new TextBox();
        RadioButton rbnCodigoPlaca = new RadioButton();
        TextBox txtSalida = new TextBox();

        public DataGridView DgvPlacas
        {
            get
            {
                return dgvPlacas;
            }

            set
            {
                dgvPlacas = value;
            }
        }

        public TextBox TxtCodigoPlaca1
        {
            get
            {
                return txtCodigoPlaca1;
            }

            set
            {
                txtCodigoPlaca1 = value;
            }
        }

        public DataGridView DgvPuestoVehiculo
        {
            get
            {
                return dgvPuestoVehiculo;
            }

            set
            {
                dgvPuestoVehiculo = value;
            }
        }

        public TextBox TxtPuestoVehiculo1
        {
            get
            {
                return txtPuestoVehiculo1;
            }

            set
            {
                txtPuestoVehiculo1 = value;
            }
        }

        public DataGridView DgvSalidaVehiculos
        {
            get
            {
                return dgvSalidaVehiculos;
            }

            set
            {
                dgvSalidaVehiculos = value;
            }
        }

        public TextBox TxtCodigoPlacaSalida
        {
            get
            {
                return txtCodigoPlacaSalida;
            }

            set
            {
                txtCodigoPlacaSalida = value;
            }
        }

        public ComboBox CbListaImagenes
        {
            get
            {
                return cbListaImagenes;
            }

            set
            {
                cbListaImagenes = value;
            }
        }

        public ComboBox CbbCamaras
        {
            get
            {
                return cbbCamaras;
            }

            set
            {
                cbbCamaras = value;
            }
        }

        public PictureBox PictureBoxORIGINAL1
        {
            get
            {
                return PictureBoxORIGINAL;
            }

            set
            {
                PictureBoxORIGINAL = value;
            }
        }

        public PictureBox PictureBoxFILTRADO1
        {
            get
            {
                return PictureBoxFILTRADO;
            }

            set
            {
                PictureBoxFILTRADO = value;
            }
        }

        public bool CheckForIllegalCrossThreadCalls { get; private set; }
        public System.Drawing.Point Location { get; private set; }
        
        public TextBox TxtCodigoPlaca
        {
            get
            {
                return txtCodigoPlaca;
            }

            set
            {
                txtCodigoPlaca = value;
            }
        }

        public DataTable Tabla
        {
            get
            {
                return tabla;
            }

            set
            {
                tabla = value;
            }
        }

        public DataGridView DgvDatosPropietario
        {
            get
            {
                return dgvDatosPropietario;
            }

            set
            {
                dgvDatosPropietario = value;
            }
        }

        public TextBox TxtPuestoVehiculo
        {
            get
            {
                return txtPuestoVehiculo;
            }

            set
            {
                txtPuestoVehiculo = value;
            }
        }

        public DateTimePicker DtpFechaSalida
        {
            get
            {
                return dtpFechaSalida;
            }

            set
            {
                dtpFechaSalida = value;
            }
        }

        public DateTimePicker DtpFechaEntrada
        {
            get
            {
                return dtpFechaEntrada;
            }

            set
            {
                dtpFechaEntrada = value;
            }
        }

        public TextBox TxtEmail
        {
            get
            {
                return txtEmail;
            }

            set
            {
                txtEmail = value;
            }
        }

        public TextBox TxtNombreApellidos
        {
            get
            {
                return txtNombreApellidos;
            }

            set
            {
                txtNombreApellidos = value;
            }
        }

        public RadioButton RbnCodigoPlaca
        {
            get
            {
                return rbnCodigoPlaca;
            }

            set
            {
                rbnCodigoPlaca = value;
            }
        }

        public TextBox TxtSalida
        {
            get
            {
                return txtSalida;
            }

            set
            {
                txtSalida = value;
            }
        }

        public BindingSource BsDatosPropietario
        {
            get
            {
                return bsDatosPropietario;
            }

            set
            {
                bsDatosPropietario = value;
            }
        }

        public BindingSource BsPlaca
        {
            get
            {
                return bsPlaca;
            }

            set
            {
                bsPlaca = value;
            }
        }

        public BindingSource BsPuesto
        {
            get
            {
                return bsPuesto;
            }

            set
            {
                bsPuesto = value;
            }
        }

        public BindingSource BsSalida
        {
            get
            {
                return bsSalida;
            }

            set
            {
                bsSalida = value;
            }
        }

        public SqlDataAdapter DaPlaca
        {
            get
            {
                return daPlaca;
            }

            set
            {
                daPlaca = value;
            }
        }

        public void clsMetodosLogicos()
        {
            //Conexion Base de datos SqlServer
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

            //Datos propietarios
            daPropietario.SelectCommand = new SqlCommand("select * from DatosPropietarioVehiculo", cn);
            dsDatosPropietario.Clear();
            daPropietario.Fill(dsDatosPropietario);
            DgvDatosPropietario.DataSource = dsDatosPropietario.Tables[0];
            BsDatosPropietario.DataSource = dsDatosPropietario.Tables[0];
            
            //Placas vehiculos
            daPlaca.SelectCommand = new SqlCommand("select * from PlacasVehiculo", cn);
            dsPlaca.Clear();
            daPlaca.Fill(dsPlaca);
            dgvPlacas.DataSource = dsPlaca.Tables[0];
            BsPlaca.DataSource = dsPlaca.Tables[0];
            TxtCodigoPlaca1.DataBindings.Add(new Binding("Text", BsPlaca, "codigoPlaca"));
            
            //Puesto vehiculos
            daPuesto.SelectCommand = new SqlCommand("select * from PuestoVehiculo", cn);
            dsPuesto.Clear();
            daPuesto.Fill(dsPuesto);
            DgvPuestoVehiculo.DataSource = dsPuesto.Tables[0];
            BsPuesto.DataSource = dsPuesto.Tables[0];
            TxtPuestoVehiculo1.DataBindings.Add(new Binding("Text", bsPuesto, "puestoVehiculo"));
            
            //Puesto vehiculos2
            daPuesto2.SelectCommand = new SqlCommand("select * from PuestoVehiculo", cn);

            //Salida vehiculos
            daSalida.SelectCommand = new SqlCommand("select * from SalidaVehiculo", cn);
            dsSalida.Clear();
            daSalida.Fill(dsSalida);
            DgvSalidaVehiculos.DataSource = dsSalida.Tables[0];
            BsSalida.DataSource = dsSalida.Tables[0];
            TxtCodigoPlacaSalida.DataBindings.Add(new Binding("Text", bsSalida, "codigoPlacaPuesto"));
            
            //Salida vehiculos2
            daSalida2.SelectCommand = new SqlCommand("select * from SalidaVehiculo", cn);


            try
            {
               cargarImagenes(CbListaImagenes);
               //cbListaImagenes.SelectedIndex = 0;
            }
            catch (IOException ex)
            {

                MessageBox.Show("" + ex);
            }

            //Listar dispositivos de entrada de video
            //Dispositivos1 = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //Cargar todos los dispositivos al combo
            //foreach (FilterInfo x in Dispositivos1)
           // {
               // CbbCamaras.Items.Add(x.Name.ToString());
               // CheckForIllegalCrossThreadCalls = false; //Permite que se escriba en las etiquetas durante el Thread video_NewFrame
               // this.Location = new System.Drawing.Point(this.Location.X, 0); //Situa el recuadro parte superior de la pantalla
          //  }
          // CbbCamaras.SelectedIndex = 1;
           
            //lector placa
            PictureBoxORIGINAL1.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxFILTRADO1.SizeMode = PictureBoxSizeMode.StretchImage;

            alpr = new AlprNet("us", confPath, runtimePath);
            cn.Close();
        }
        public void cargarImagenes(ComboBox cbImg)
        {
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
        public void VideoNewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (!ExisteCodigoPlaca(TxtCodigoPlaca.Text))
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

                    try
                    {
                        if (results.Plates.Count > 0)
                        {
                            TxtCodigoPlaca.Text = results.Plates[0].BestPlate.Characters;
                            TxtCodigoPlaca.ForeColor = Color.Yellow;
                            PictureBoxORIGINAL.Image = imagenOriginal; // Proyecta las imagenes real
                            PictureBoxFILTRADO.Image = imagenFiltrada;
                        }
                        // txtCodigoPlaca.Text = "";
                    }
                    catch (Exception)
                    {
                        return;
                    }
                   
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Error " + ex);
                    return;
                }
            }
        }

       
        public void dgvUpdateDatosPropietrios()
        {
            DgvDatosPropietario.ClearSelection();
            DgvDatosPropietario.AllowUserToAddRows = false;
            //dgvPlacas.Rows[bsPlaca.Position].Selected = true;
        }
       public void detenerVideo()
        {
            frmIdentificadorPlacas frmPlacas = new frmIdentificadorPlacas();
            // if (FuenteDeVideo1.IsRunning == true)
            frmPlacas.FuenteDeVideo1.Stop();
        }
        public void FinalFrame_newFrame(Object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            PictureBoxORIGINAL1.Image = video;
        }
        public void dgvUpdatePlacas()
        {
            dgvPlacas.ClearSelection();
            dgvPlacas.AllowUserToAddRows = false;
            // dgvPlacas.Rows[bsPlaca.Position].Selected = true;
        }
        public void dgvUpdateDatosPropietario()
        {
            dgvDatosPropietario.ClearSelection();
            dgvDatosPropietario.AllowUserToAddRows = false;
            //dgvDatosPropietarios.Rows[bsPlaca.Position].Selected = true;
        }
        public bool ExisteCodigoPlaca(string codigoPlaca)
        {
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
        public void botonEliminarCodigoPlaca(string codigoPlaca)
        {
            TxtCodigoPlaca1.Text = codigoPlaca;
            if (!ExistePPlaca(txtCodigoPlaca1.Text))
            {
                EliminarCodigoPlaca(txtCodigoPlaca1.Text);
                dsPlaca.Clear();
                DaPlaca.Fill(dsPlaca);
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
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
            DaPlaca.DeleteCommand = new SqlCommand("delete from PlacasVehiculo where codigoPlaca = @codigoPlaca", cn);
            DaPlaca.DeleteCommand.Parameters.Add("@codigoPlaca", SqlDbType.VarChar).Value = codigoPlaca;

            cn.Open();
            DaPlaca.DeleteCommand.ExecuteNonQuery();
            cn.Close();

            dsPlaca.Clear();
            DaPlaca.Fill(dsPlaca);
            dgvUpdatePlacas();
        }
        public void eliminarPuesto(int puestoVehiculo)
        {
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
            TxtPuestoVehiculo.Text = "";
            while (TxtPuestoVehiculo.Text == "")
            {
                TxtPuestoVehiculo.Text = datos();
            }
        }
        public string insertarPuestoVehiculo()
        {
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

            string mensaje = "";

            DtpFechaEntrada.Refresh();
            DtpFechaEntrada.CustomFormat = "dd/MM/yy HH:mm:ss tt";
            DtpFechaEntrada.Format = DateTimePickerFormat.Custom;
            DtpFechaEntrada.Value = DateTime.Now;
            DtpFechaEntrada.ShowUpDown = false;

            try
            {
                daPuesto.InsertCommand = new SqlCommand("Insert into PuestoVehiculo values(@codigoPlaca,@fechaEntrada,@puestoVehiculo)", cn);

                daPuesto.InsertCommand.Parameters.Add("@codigoPlaca", SqlDbType.VarChar).Value = txtCodigoPlaca.Text;
                daPuesto.InsertCommand.Parameters.Add("@fechaEntrada", SqlDbType.DateTime).Value = DtpFechaEntrada.Text;
                daPuesto.InsertCommand.Parameters.Add("@puestoVehiculo", SqlDbType.Int).Value = TxtPuestoVehiculo.Text;

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
        public void EnviarCorreoElectronico()
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            // msg.To.Add("alfonso.gallego.66@hotmail.com.ar");
            // msg.To.Add("andrescamilo_95@hotmail.com");
            // msg.To.Add("acgallegol@uqvirtual.edu.co");
            msg.To.Add(TxtEmail.Text);
            msg.Subject = "Su puesto de parqueo es: A" + TxtPuestoVehiculo.Text + " UNIQUÍNDIO ARMENIA COLOMBIA";
            msg.Body = "Hola: " + TxtNombreApellidos.Text + ", su puesto de parqueo es: A" + TxtPuestoVehiculo.Text + " /FACULTAD DE INGENIERIA";
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
        public void buscarPropietario(string codigoPlaca)
        {
            LlenarGrids llenarGrids = new LlenarGrids("Parametros.xml");
            if (RbnCodigoPlaca.Checked)
            {
                llenarGrids.SQL = "select nombreApellidos,email, codigoPlaca from DatosPropietarioVehiculo where codigoPlaca like '" + codigoPlaca + "%' order by 3";
            }

            llenarGrids.LlenarGridWindows(dgvDatosPropietario);

            string email = "";
            string nombreApellidos = "";
            email = dgvDatosPropietario.Rows[0].Cells["email"].Value.ToString();
            nombreApellidos = dgvDatosPropietario.Rows[0].Cells["nombreApellidos"].Value.ToString();
            TxtEmail.Text = email;
            TxtNombreApellidos.Text = nombreApellidos;

            codigoPlaca = "";
        }
        public bool ExisteDatoPropietario(string codigoPlaca)
        {
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
        private void dgvUpdateSalida()
        {
            dgvSalidaVehiculos.ClearSelection();
            dgvSalidaVehiculos.AllowUserToAddRows = false;
            // dgvSalidaVehiculos.Rows[bsSalida.Position].Selected = true;
        }
        public bool ExisteSalidaVehiculo(string codigoPlacaSalida)
        {
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

            string mensaje = "";

            if (!ExisteSalidaVehiculo(codigoPlacaPuesto) && ExistePPlaca(codigoPlacaPuesto))
            {
                DtpFechaSalida.Refresh();
                DtpFechaSalida.CustomFormat = "dd/MM/yy HH:mm:ss tt";
                DtpFechaSalida.Format = DateTimePickerFormat.Custom;
                DtpFechaSalida.Value = DateTime.Now;
                DtpFechaSalida.ShowUpDown = false;

                try
                {
                    daSalida.InsertCommand = new SqlCommand("Insert into SalidaVehiculo values(@codigoPlacaPuesto,@fechaSalida)", cn);
                    daSalida.InsertCommand.Parameters.Add("@codigoPlacaPuesto", SqlDbType.VarChar).Value = codigoPlacaPuesto;
                    daSalida.InsertCommand.Parameters.Add("@fechaSalida", SqlDbType.DateTime).Value = DtpFechaSalida.Text;


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
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

            string mensaje = "";

            if (!ExisteSalidaVehiculo(codigoPlacaPuesto) && ExistePPlaca(codigoPlacaPuesto))
            {
                DtpFechaSalida.Refresh();
                DtpFechaSalida.CustomFormat = "dd/MM/yy HH:mm:ss tt";
                DtpFechaSalida.Format = DateTimePickerFormat.Custom;
                DtpFechaSalida.Value = DateTime.Now;
                DtpFechaSalida.ShowUpDown = false;

                try
                {
                    daSalida2.InsertCommand = new SqlCommand("Insert into SalidaVehiculo2 values(@codigoPlacaPuesto,@fechaSalida)", cn);
                    daSalida2.InsertCommand.Parameters.Add("@codigoPlacaPuesto", SqlDbType.VarChar).Value = codigoPlacaPuesto;
                    daSalida2.InsertCommand.Parameters.Add("@fechaSalida", SqlDbType.DateTime).Value = DtpFechaSalida.Text;


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
        public void verImagen1(PictureBox pbFoto, string codigoPlaca)
        {
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
                    DaPlaca.Fill(dsPlaca);
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
            TxtCodigoPlaca.Text = codigoPlaca;
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;
           
            TxtSalida.Text = txtCodigoPlaca.Text;
            if (ExisteDatoPropietario(codigoPlaca))
            {
                buscarPropietario(txtCodigoPlaca.Text);

                if (txtCodigoPlaca.Text == "")
                {
                    MessageBox.Show("Debe ingresar un codigo placa: ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodigoPlaca.Focus();
                }
                insertarNoExistePuestoPlaca(TxtCodigoPlaca.Text);
                insertarSiExistePuestoPlaca(TxtCodigoPlaca.Text);

                txtCodigoPlaca.Text = "";
                cn.Close();
            }
            else
            {
                return;
            }
        }
        public void insertarNoExistePuestoPlaca(string codigoPlaca)
        {
            txtCodigoPlaca.Text = codigoPlaca;
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
        public void insertarSiExistePuestoPlaca(string codigoPlaca)
        {
            txtCodigoPlaca.Text = codigoPlaca;
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
            if (ExistePPlaca(txtCodigoPlaca.Text) && ExisteSalidaVehiculo(txtCodigoPlaca.Text))
            {
                insertarSalidaVehiculo2(txtCodigoPlaca.Text);
                eliminarPuestoPlaca(txtCodigoPlaca.Text);
                eliminarSalidaVehiculo(txtCodigoPlaca.Text);
                txtCodigoPlaca.Text = "";
            }
            else
            {
                return;
            }
        }
       
        public void eliminarPuesto()
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
        public void cargarImagenes1(ComboBox cbImg)
        {
            Parametros parametros = new Parametros();
            if (!parametros.GenerarCadenaConexion("Parametros.xml"))
            {
                MessageBox.Show(parametros.Error);
                Application.Exit();
            }
            cn.ConnectionString = parametros.CadenaConexion;

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
        public void botonEliminarSalida()
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
    }
}
