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
        clsMetodos metodos = new clsMetodos();

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

        public FilterInfoCollection Dispositivos1
        {
            get
            {
                return Dispositivos;
            }

            set
            {
                Dispositivos = value;
            }
        }

        public VideoCaptureDevice FuenteDeVideo1
        {
            get
            {
                return FuenteDeVideo;
            }

            set
            {
                FuenteDeVideo = value;
            }
        }

        private void IdentificadorPlacas_Load(object sender, EventArgs e)
        {
            metodos.clsMetodosLogicos();

            //Cargar todos los  DataGridVie en el formulario
            //Datos propietarios
            dgvDatosPropietarios.DataSource = metodos.DgvDatosPropietario.DataSource;
            //Placas vehiculos
            dgvPlacas.DataSource = metodos.DgvPlacas.DataSource;
            //Puesto vehiculos
            dgvPuestoVehiculo.DataSource = metodos.DgvPuestoVehiculo.DataSource;
            //Salida vehiculos
            dgvSalidaVehiculos.DataSource = metodos.DgvSalidaVehiculos.DataSource;

            try
            {
                // cargarImagenes(cbListaImagenes);
                metodos.cargarImagenes(cbListaImagenes);
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
            Dispositivos1 = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //Cargar todos los dispositivos al combo

            foreach (FilterInfo x in Dispositivos1)
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
            //cn.Close();
        }
        private void VideoNewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            clsMetodos metodos = new clsMetodos();
            if (!metodos.ExisteCodigoPlaca(txtCodigoPlaca.Text))
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
                   txtCodigoPlaca.Text = "";
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
            FuenteDeVideo1 = new VideoCaptureDevice(Dispositivos1[cbbCamaras.SelectedIndex].MonikerString);
            FuenteDeVideo1.NewFrame += new NewFrameEventHandler(VideoNewFrame);
            FuenteDeVideo1.Start();
            cbbCamaras.Visible = true;
        }
        //Detiene la captura de la Fuente de video

        private void btnDetenerCaptura_Click(object sender, EventArgs e)
        {
            FuenteDeVideo1.Stop();
        }
        private void btnIniciarDetenccion_Click(object sender, EventArgs e)
        {
            //Establecer el dispositivo seleccionado como fuente de video
            FuenteDeVideo1 = new VideoCaptureDevice(Dispositivos1[cbbCamaras.SelectedIndex].MonikerString);
            //Inicial el control
            videoSourcePlayerDMovimiento.VideoSource = FuenteDeVideo1;
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
               // insertarCodigoPlaca(txtCodigoPlaca.Text);
               // cn.Close();
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
               metodos.verImagen(PictureBoxORIGINAL, cbListaImagenes.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            metodos.BsPlaca.MoveFirst();
           
            metodos.dgvUpdatePlacas();
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            metodos.BsPlaca.MovePrevious();
            metodos.dgvUpdatePlacas();
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            metodos.BsPlaca.MoveNext(); ;
            metodos.dgvUpdatePlacas();
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            metodos.BsPlaca.MoveLast();
            metodos.dgvUpdatePlacas();
        }
        private void btnPrimeroV_Click(object sender, EventArgs e)
        {
           
        }
        private void btnAnteriorV_Click(object sender, EventArgs e)
        {
           
        }
        private void btnSiguienteV_Click(object sender, EventArgs e)
        {
           
        }
        private void btnUltimoV_Click(object sender, EventArgs e)
        {
           
        }
        private void BtnGenerarPuesto_Click(object sender, EventArgs e)
        {
            txtPuestoVehiculo.Text = "";
            while (txtPuestoVehiculo.Text == "")
            {
                txtPuestoVehiculo.Text = metodos.datos();
            }
        }
        private void btnEliminarPuesto_Click(object sender, EventArgs e)
        {
            metodos.eliminarPuesto();
        }
        private void rbnCodigoPlaca_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigoPlaca.Text = "";
            txtCodigoPlaca.Focus();
        }
        private void txtCodigoPlaca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                metodos.insertarCodigoPlaca(txtCodigoPlaca.Text);
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void btnPrimeroS_Click(object sender, EventArgs e)
        {
           
        }
        private void btnAnteriorS_Click(object sender, EventArgs e)
        {
           
        }
        private void btnSiguienteS_Click(object sender, EventArgs e)
        {
            
        }
        private void btnUltimoS_Click(object sender, EventArgs e)
        {
           
        }
        private void txtSalida_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void btnEliminarS_Click(object sender, EventArgs e)
        {
           metodos.botonEliminarSalida();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtCodigoPlaca1.Text = txtCodigoPlaca.Text;
            metodos.botonEliminarCodigoPlaca(txtCodigoPlaca.Text);
        }
    }
}  
