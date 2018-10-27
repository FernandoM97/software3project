using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;
using IdentificadorPlacasDeVehiculos.Clases;
using openalprnet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IdentificadorPlacasDeVehiculos.Formularios
{
    public partial class IdentificadorPlacas : Form
    {
        //Conexion Base de datos SqlServer
        ConexionBD conectar = new ConexionBD();

        private FilterInfoCollection Dispositivos; // Todas las camaras
        private VideoCaptureDevice FuenteDeVideo; // La camara
        string confPath = Application.StartupPath + "\\openalpr.conf";
        string runtimePath = Application.StartupPath + "\\runtime_data\\";
        AlprNet alpr;


        // inicializador valores de filtro

        private int minr = 189;
        private int ming = 129;
        private int minb = 32;
        private int maxr = 255;
        private int maxg = 255;
        private int maxb = 226;

        public IdentificadorPlacas()
        {
            InitializeComponent();
        }

        //Variables de detenccion

        MotionDetector Dectector;
        float NivelDeDetenccion;

        private void IdentificadorPlacas_Load(object sender, EventArgs e)
        {
            txtCodigoPlaca.Text = Random();
            try
            {
                conectar.abrirConexion();
                conectar.cargarImagenes(cbListaImagenes);
                cbListaImagenes.SelectedIndex = 0;
                
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
            cbbCamaras.SelectedIndex = 0;
            PictureBoxORIGINAL.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBoxFILTRADO.SizeMode = PictureBoxSizeMode.StretchImage;
            alpr = new AlprNet("us", confPath, runtimePath);
        }
        
        private void VideoNewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap imagenOriginal = (Bitmap)eventArgs.Frame.Clone(); // Imagen de la camara
            Bitmap imagenFiltrada = (Bitmap)eventArgs.Frame.Clone(); // Imagen filtrada
             

            alpr.DetectRegion = true;


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
            try
            {
                AlprResultsNet results = alpr.Recognize(imagenFiltrada);
                PictureBoxORIGINAL.Image = imagenOriginal; // Proyecta las imagenes real
                PictureBoxFILTRADO.Image = imagenFiltrada; // Proyecta las imagenes filtradas
               if (results.Plates.Count > 0)
                {
                    
                    //MessageBox.Show("La placa reconocida es:" + results.Plates[0].BestPlate.Characters);
                    string text = results.Plates[0].BestPlate.Characters;
                    PictureBoxORIGINAL.Image = imagenOriginal; // Proyecta las imagenes real
                    PictureBoxFILTRADO.Image = imagenFiltrada;
                    if (text.Length == 6)
                    {
                        txtCodigoPlaca.Text = text;
                        txtCodigoPlaca.ForeColor = Color.LightGreen;
                        PictureBoxORIGINAL.Image = imagenOriginal; // Proyecta las imagenes real
                        PictureBoxFILTRADO.Image = imagenFiltrada;
                        detenerCaptura();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Inicia la captura de imagenes de la camara y el Thread viideo_NewFrame

            iniciarDeteccion();
           
            cbbCamaras.Visible = true;
            
        }
        //Detiene la captura de la Fuente de video
        private void btnDetenerCaptura_Click(object sender, EventArgs e)
        {
            FuenteDeVideo.SignalToStop();
        }

        private void detenerCaptura()
        {

            FuenteDeVideo.SignalToStop();
        }

        private void btnIniciarDetenccion_Click(object sender, EventArgs e)
        {
            //Establecer el dispositivo seleccionado como fuente de video
            FuenteDeVideo = new VideoCaptureDevice(Dispositivos[cbbCamaras.SelectedIndex].MonikerString);
            //Inicial el control
            videoSourcePlayer1.VideoSource = FuenteDeVideo;
            //Iniciar recepcion de imagen
            videoSourcePlayer1.Start();
        }

        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            NivelDeDetenccion = Dectector.ProcessFrame(image);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(conectar.insertarImagen(txtCodigoPlaca.Text, PictureBoxORIGINAL));
            cbListaImagenes.Items.Clear();
            conectar.cargarImagenes(cbListaImagenes);
            txtCodigoPlaca.Text = Random();
            txtCodigoPlaca.Focus();

        }

        private void cbListaImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // FuenteDeVideo.Stop();
                conectar.verImagen(PictureBoxORIGINAL, cbListaImagenes.SelectedItem.ToString());
            } 
            catch (Exception ex)
            { 
                MessageBox.Show("Error "+ ex);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //foreach (Process proceso in Process.GetProcesses())
            //{
                    Process.GetCurrentProcess().Kill();
            //}
            Application.Exit();
        }

        public string Random()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 100);
            string cadena = Convert.ToString("A" + num);
            return cadena;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuenteDeVideo.Start();
        }

        private void iniciarDeteccion()
        {
            FuenteDeVideo = new VideoCaptureDevice(Dispositivos[cbbCamaras.SelectedIndex].MonikerString);
            FuenteDeVideo.NewFrame += new NewFrameEventHandler(VideoNewFrame);
            FuenteDeVideo.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
