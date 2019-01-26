namespace IdentificadorPlacasDeVehiculos.Formularios
{
    partial class frmIdentificadorPlacas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIdentificadorPlacas));
            this.PictureBoxFILTRADO = new AForge.Controls.PictureBox();
            this.cbbCamaras = new System.Windows.Forms.ComboBox();
            this.btnDetenerCaptura = new System.Windows.Forms.Button();
            this.btnIniciarDetenccion = new System.Windows.Forms.Button();
            this.videoSourcePlayerDMovimiento = new AForge.Controls.VideoSourcePlayer();
            this.cbListaImagenes = new System.Windows.Forms.ComboBox();
            this.txtCodigoPlaca = new System.Windows.Forms.TextBox();
            this.panelControlesExaminarBD = new System.Windows.Forms.Panel();
            this.lblControlesExaminarBD = new System.Windows.Forms.Label();
            this.panelControlesCamara = new System.Windows.Forms.Panel();
            this.lblControlesCamara = new System.Windows.Forms.Label();
            this.ControlesGuardarImagen = new System.Windows.Forms.Panel();
            this.lblControlesGuardarImagen = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.panelSensorMovimiento = new System.Windows.Forms.Panel();
            this.lblControlesSensorMovimiento = new System.Windows.Forms.Label();
            this.PictureBoxORIGINAL = new AForge.Controls.PictureBox();
            this.dgvPlacas = new System.Windows.Forms.DataGridView();
            this.txtCodigoPlaca1 = new System.Windows.Forms.TextBox();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.dgvPuestoVehiculo = new System.Windows.Forms.DataGridView();
            this.dtpFechaEntrada = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPuestoVehiculo = new System.Windows.Forms.TextBox();
            this.btnEliminarPuesto = new System.Windows.Forms.Button();
            this.txtPuestoVehiculo1 = new System.Windows.Forms.TextBox();
            this.lblFechaEntrada = new System.Windows.Forms.Label();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSiguienteV = new System.Windows.Forms.Button();
            this.btnPrimeroV = new System.Windows.Forms.Button();
            this.btnAnteriorV = new System.Windows.Forms.Button();
            this.btnUltimoV = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblNombreApellidos = new System.Windows.Forms.Label();
            this.txtNombreApellidos = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.rbnCodigoPlaca = new System.Windows.Forms.RadioButton();
            this.dgvDatosPropietarios = new System.Windows.Forms.DataGridView();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPlacas = new System.Windows.Forms.Label();
            this.lblPuestos = new System.Windows.Forms.Label();
            this.lblDatosPropietarios = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnEliminarS = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnSiguienteS = new System.Windows.Forms.Button();
            this.btnPrimeroS = new System.Windows.Forms.Button();
            this.btnAnteriorS = new System.Windows.Forms.Button();
            this.btnUltimoS = new System.Windows.Forms.Button();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.lblFechaSalida = new System.Windows.Forms.Label();
            this.txtCodigoPlacaSalida = new System.Windows.Forms.TextBox();
            this.lblSalidaVehiculo = new System.Windows.Forms.Label();
            this.dgvSalidaVehiculos = new System.Windows.Forms.DataGridView();
            this.txtSalida = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxFILTRADO)).BeginInit();
            this.panelControlesExaminarBD.SuspendLayout();
            this.panelControlesCamara.SuspendLayout();
            this.ControlesGuardarImagen.SuspendLayout();
            this.panelSensorMovimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxORIGINAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuestoVehiculo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPropietarios)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaVehiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxFILTRADO
            // 
            this.PictureBoxFILTRADO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PictureBoxFILTRADO.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PictureBoxFILTRADO.Image = null;
            this.PictureBoxFILTRADO.Location = new System.Drawing.Point(537, 1);
            this.PictureBoxFILTRADO.Name = "PictureBoxFILTRADO";
            this.PictureBoxFILTRADO.Size = new System.Drawing.Size(509, 429);
            this.PictureBoxFILTRADO.TabIndex = 1;
            this.PictureBoxFILTRADO.TabStop = false;
            // 
            // cbbCamaras
            // 
            this.cbbCamaras.BackColor = System.Drawing.SystemColors.GrayText;
            this.cbbCamaras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCamaras.ForeColor = System.Drawing.SystemColors.Info;
            this.cbbCamaras.FormattingEnabled = true;
            this.cbbCamaras.Location = new System.Drawing.Point(3, 46);
            this.cbbCamaras.Name = "cbbCamaras";
            this.cbbCamaras.Size = new System.Drawing.Size(184, 24);
            this.cbbCamaras.TabIndex = 66;
            this.cbbCamaras.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // btnDetenerCaptura
            // 
            this.btnDetenerCaptura.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetenerCaptura.BackgroundImage")));
            this.btnDetenerCaptura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetenerCaptura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetenerCaptura.Location = new System.Drawing.Point(261, 19);
            this.btnDetenerCaptura.Name = "btnDetenerCaptura";
            this.btnDetenerCaptura.Size = new System.Drawing.Size(80, 40);
            this.btnDetenerCaptura.TabIndex = 68;
            this.btnDetenerCaptura.Text = "Detener captura";
            this.btnDetenerCaptura.UseVisualStyleBackColor = true;
            this.btnDetenerCaptura.Click += new System.EventHandler(this.btnDetenerCaptura_Click);
            // 
            // btnIniciarDetenccion
            // 
            this.btnIniciarDetenccion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIniciarDetenccion.BackgroundImage")));
            this.btnIniciarDetenccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIniciarDetenccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarDetenccion.Location = new System.Drawing.Point(246, 28);
            this.btnIniciarDetenccion.Name = "btnIniciarDetenccion";
            this.btnIniciarDetenccion.Size = new System.Drawing.Size(80, 40);
            this.btnIniciarDetenccion.TabIndex = 69;
            this.btnIniciarDetenccion.Text = "Iniciar detenccion";
            this.btnIniciarDetenccion.UseVisualStyleBackColor = true;
            this.btnIniciarDetenccion.Click += new System.EventHandler(this.btnIniciarDetenccion_Click);
            // 
            // videoSourcePlayerDMovimiento
            // 
            this.videoSourcePlayerDMovimiento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.videoSourcePlayerDMovimiento.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.videoSourcePlayerDMovimiento.Location = new System.Drawing.Point(773, 496);
            this.videoSourcePlayerDMovimiento.Name = "videoSourcePlayerDMovimiento";
            this.videoSourcePlayerDMovimiento.Size = new System.Drawing.Size(271, 186);
            this.videoSourcePlayerDMovimiento.TabIndex = 70;
            this.videoSourcePlayerDMovimiento.Text = "videoSourcePlayerDMovimiento";
            this.videoSourcePlayerDMovimiento.VideoSource = null;
            this.videoSourcePlayerDMovimiento.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame);
            // 
            // cbListaImagenes
            // 
            this.cbListaImagenes.BackColor = System.Drawing.SystemColors.GrayText;
            this.cbListaImagenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListaImagenes.ForeColor = System.Drawing.SystemColors.Info;
            this.cbListaImagenes.FormattingEnabled = true;
            this.cbListaImagenes.Location = new System.Drawing.Point(3, 35);
            this.cbListaImagenes.Name = "cbListaImagenes";
            this.cbListaImagenes.Size = new System.Drawing.Size(184, 24);
            this.cbListaImagenes.TabIndex = 72;
            this.cbListaImagenes.SelectedIndexChanged += new System.EventHandler(this.cbListaImagenes_SelectedIndexChanged);
            // 
            // txtCodigoPlaca
            // 
            this.txtCodigoPlaca.BackColor = System.Drawing.SystemColors.GrayText;
            this.txtCodigoPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPlaca.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCodigoPlaca.Location = new System.Drawing.Point(3, 45);
            this.txtCodigoPlaca.Name = "txtCodigoPlaca";
            this.txtCodigoPlaca.Size = new System.Drawing.Size(237, 22);
            this.txtCodigoPlaca.TabIndex = 71;
            this.txtCodigoPlaca.TextChanged += new System.EventHandler(this.txtCodigoPlaca_TextChanged);
            // 
            // panelControlesExaminarBD
            // 
            this.panelControlesExaminarBD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelControlesExaminarBD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelControlesExaminarBD.Controls.Add(this.lblControlesExaminarBD);
            this.panelControlesExaminarBD.Controls.Add(this.btnDetenerCaptura);
            this.panelControlesExaminarBD.Controls.Add(this.cbListaImagenes);
            this.panelControlesExaminarBD.Location = new System.Drawing.Point(-7, 597);
            this.panelControlesExaminarBD.Name = "panelControlesExaminarBD";
            this.panelControlesExaminarBD.Size = new System.Drawing.Size(348, 85);
            this.panelControlesExaminarBD.TabIndex = 75;
            // 
            // lblControlesExaminarBD
            // 
            this.lblControlesExaminarBD.AutoSize = true;
            this.lblControlesExaminarBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlesExaminarBD.Location = new System.Drawing.Point(78, 0);
            this.lblControlesExaminarBD.Name = "lblControlesExaminarBD";
            this.lblControlesExaminarBD.Size = new System.Drawing.Size(188, 20);
            this.lblControlesExaminarBD.TabIndex = 77;
            this.lblControlesExaminarBD.Text = "Controles examinarBD";
            // 
            // panelControlesCamara
            // 
            this.panelControlesCamara.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelControlesCamara.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelControlesCamara.Controls.Add(this.lblControlesCamara);
            this.panelControlesCamara.Controls.Add(this.cbbCamaras);
            this.panelControlesCamara.Location = new System.Drawing.Point(-7, 496);
            this.panelControlesCamara.Name = "panelControlesCamara";
            this.panelControlesCamara.Size = new System.Drawing.Size(348, 90);
            this.panelControlesCamara.TabIndex = 76;
            // 
            // lblControlesCamara
            // 
            this.lblControlesCamara.AutoSize = true;
            this.lblControlesCamara.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlesCamara.Location = new System.Drawing.Point(97, 1);
            this.lblControlesCamara.Name = "lblControlesCamara";
            this.lblControlesCamara.Size = new System.Drawing.Size(150, 20);
            this.lblControlesCamara.TabIndex = 70;
            this.lblControlesCamara.Text = "Controles camara";
            // 
            // ControlesGuardarImagen
            // 
            this.ControlesGuardarImagen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ControlesGuardarImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ControlesGuardarImagen.Controls.Add(this.lblControlesGuardarImagen);
            this.ControlesGuardarImagen.Controls.Add(this.txtCodigoPlaca);
            this.ControlesGuardarImagen.Controls.Add(this.btnAgregar);
            this.ControlesGuardarImagen.Location = new System.Drawing.Point(409, 499);
            this.ControlesGuardarImagen.Name = "ControlesGuardarImagen";
            this.ControlesGuardarImagen.Size = new System.Drawing.Size(348, 92);
            this.ControlesGuardarImagen.TabIndex = 77;
            // 
            // lblControlesGuardarImagen
            // 
            this.lblControlesGuardarImagen.AutoSize = true;
            this.lblControlesGuardarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlesGuardarImagen.Location = new System.Drawing.Point(57, 1);
            this.lblControlesGuardarImagen.Name = "lblControlesGuardarImagen";
            this.lblControlesGuardarImagen.Size = new System.Drawing.Size(216, 20);
            this.lblControlesGuardarImagen.TabIndex = 78;
            this.lblControlesGuardarImagen.Text = "Controles guardar imagen";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(246, 45);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(80, 40);
            this.btnAgregar.TabIndex = 74;
            this.btnAgregar.Text = "Agregar placa";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(154, 118);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(55, 23);
            this.btnEliminar.TabIndex = 80;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // panelSensorMovimiento
            // 
            this.panelSensorMovimiento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelSensorMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSensorMovimiento.Controls.Add(this.lblControlesSensorMovimiento);
            this.panelSensorMovimiento.Controls.Add(this.btnIniciarDetenccion);
            this.panelSensorMovimiento.Location = new System.Drawing.Point(409, 597);
            this.panelSensorMovimiento.Name = "panelSensorMovimiento";
            this.panelSensorMovimiento.Size = new System.Drawing.Size(348, 85);
            this.panelSensorMovimiento.TabIndex = 78;
            // 
            // lblControlesSensorMovimiento
            // 
            this.lblControlesSensorMovimiento.AutoSize = true;
            this.lblControlesSensorMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlesSensorMovimiento.Location = new System.Drawing.Point(43, 1);
            this.lblControlesSensorMovimiento.Name = "lblControlesSensorMovimiento";
            this.lblControlesSensorMovimiento.Size = new System.Drawing.Size(265, 20);
            this.lblControlesSensorMovimiento.TabIndex = 78;
            this.lblControlesSensorMovimiento.Text = "Controles sensor de movimiento";
            // 
            // PictureBoxORIGINAL
            // 
            this.PictureBoxORIGINAL.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PictureBoxORIGINAL.Image = null;
            this.PictureBoxORIGINAL.Location = new System.Drawing.Point(3, 0);
            this.PictureBoxORIGINAL.Name = "PictureBoxORIGINAL";
            this.PictureBoxORIGINAL.Size = new System.Drawing.Size(509, 429);
            this.PictureBoxORIGINAL.TabIndex = 80;
            this.PictureBoxORIGINAL.TabStop = false;
            // 
            // dgvPlacas
            // 
            this.dgvPlacas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlacas.Location = new System.Drawing.Point(3, 3);
            this.dgvPlacas.Name = "dgvPlacas";
            this.dgvPlacas.Size = new System.Drawing.Size(231, 71);
            this.dgvPlacas.TabIndex = 82;
            // 
            // txtCodigoPlaca1
            // 
            this.txtCodigoPlaca1.Location = new System.Drawing.Point(18, 118);
            this.txtCodigoPlaca1.Name = "txtCodigoPlaca1";
            this.txtCodigoPlaca1.Size = new System.Drawing.Size(132, 20);
            this.txtCodigoPlaca1.TabIndex = 84;
            // 
            // btnPrimero
            // 
            this.btnPrimero.Location = new System.Drawing.Point(3, 3);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(41, 23);
            this.btnPrimero.TabIndex = 86;
            this.btnPrimero.Text = "<<";
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(50, 3);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(41, 23);
            this.btnAnterior.TabIndex = 87;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(97, 3);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(41, 23);
            this.btnSiguiente.TabIndex = 88;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Location = new System.Drawing.Point(144, 3);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(41, 23);
            this.btnUltimo.TabIndex = 89;
            this.btnUltimo.Text = ">>";
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // dgvPuestoVehiculo
            // 
            this.dgvPuestoVehiculo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPuestoVehiculo.Location = new System.Drawing.Point(5, 3);
            this.dgvPuestoVehiculo.Name = "dgvPuestoVehiculo";
            this.dgvPuestoVehiculo.Size = new System.Drawing.Size(231, 71);
            this.dgvPuestoVehiculo.TabIndex = 91;
            // 
            // dtpFechaEntrada
            // 
            this.dtpFechaEntrada.Location = new System.Drawing.Point(100, 144);
            this.dtpFechaEntrada.Name = "dtpFechaEntrada";
            this.dtpFechaEntrada.Size = new System.Drawing.Size(118, 20);
            this.dtpFechaEntrada.TabIndex = 95;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgvPlacas);
            this.panel1.Controls.Add(this.txtCodigoPlaca1);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Location = new System.Drawing.Point(1069, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 148);
            this.panel1.TabIndex = 96;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSiguiente);
            this.panel2.Controls.Add(this.btnPrimero);
            this.panel2.Controls.Add(this.btnAnterior);
            this.panel2.Controls.Add(this.btnUltimo);
            this.panel2.Location = new System.Drawing.Point(18, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 32);
            this.panel2.TabIndex = 97;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.txtPuestoVehiculo);
            this.panel3.Controls.Add(this.btnEliminarPuesto);
            this.panel3.Controls.Add(this.txtPuestoVehiculo1);
            this.panel3.Controls.Add(this.lblFechaEntrada);
            this.panel3.Controls.Add(this.lblPuesto);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.dgvPuestoVehiculo);
            this.panel3.Controls.Add(this.dtpFechaEntrada);
            this.panel3.Location = new System.Drawing.Point(1069, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 199);
            this.panel3.TabIndex = 97;
            // 
            // txtPuestoVehiculo
            // 
            this.txtPuestoVehiculo.Location = new System.Drawing.Point(100, 170);
            this.txtPuestoVehiculo.Name = "txtPuestoVehiculo";
            this.txtPuestoVehiculo.Size = new System.Drawing.Size(118, 20);
            this.txtPuestoVehiculo.TabIndex = 103;
            // 
            // btnEliminarPuesto
            // 
            this.btnEliminarPuesto.Location = new System.Drawing.Point(157, 116);
            this.btnEliminarPuesto.Name = "btnEliminarPuesto";
            this.btnEliminarPuesto.Size = new System.Drawing.Size(60, 23);
            this.btnEliminarPuesto.TabIndex = 102;
            this.btnEliminarPuesto.Text = "Eliminar";
            this.btnEliminarPuesto.UseVisualStyleBackColor = true;
            this.btnEliminarPuesto.Click += new System.EventHandler(this.btnEliminarPuesto_Click);
            // 
            // txtPuestoVehiculo1
            // 
            this.txtPuestoVehiculo1.Location = new System.Drawing.Point(23, 118);
            this.txtPuestoVehiculo1.Name = "txtPuestoVehiculo1";
            this.txtPuestoVehiculo1.Size = new System.Drawing.Size(118, 20);
            this.txtPuestoVehiculo1.TabIndex = 101;
            // 
            // lblFechaEntrada
            // 
            this.lblFechaEntrada.AutoSize = true;
            this.lblFechaEntrada.Location = new System.Drawing.Point(18, 151);
            this.lblFechaEntrada.Name = "lblFechaEntrada";
            this.lblFechaEntrada.Size = new System.Drawing.Size(79, 13);
            this.lblFechaEntrada.TabIndex = 99;
            this.lblFechaEntrada.Text = "Fecha entrada:";
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Location = new System.Drawing.Point(54, 178);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(43, 13);
            this.lblPuesto.TabIndex = 98;
            this.lblPuesto.Text = "Puesto:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnSiguienteV);
            this.panel4.Controls.Add(this.btnPrimeroV);
            this.panel4.Controls.Add(this.btnAnteriorV);
            this.panel4.Controls.Add(this.btnUltimoV);
            this.panel4.Location = new System.Drawing.Point(23, 80);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 32);
            this.panel4.TabIndex = 97;
            // 
            // btnSiguienteV
            // 
            this.btnSiguienteV.Location = new System.Drawing.Point(97, 4);
            this.btnSiguienteV.Name = "btnSiguienteV";
            this.btnSiguienteV.Size = new System.Drawing.Size(41, 23);
            this.btnSiguienteV.TabIndex = 92;
            this.btnSiguienteV.Text = ">";
            this.btnSiguienteV.UseVisualStyleBackColor = true;
            this.btnSiguienteV.Click += new System.EventHandler(this.btnSiguienteV_Click);
            // 
            // btnPrimeroV
            // 
            this.btnPrimeroV.Location = new System.Drawing.Point(3, 4);
            this.btnPrimeroV.Name = "btnPrimeroV";
            this.btnPrimeroV.Size = new System.Drawing.Size(41, 23);
            this.btnPrimeroV.TabIndex = 90;
            this.btnPrimeroV.Text = "<<";
            this.btnPrimeroV.UseVisualStyleBackColor = true;
            this.btnPrimeroV.Click += new System.EventHandler(this.btnPrimeroV_Click);
            // 
            // btnAnteriorV
            // 
            this.btnAnteriorV.Location = new System.Drawing.Point(50, 4);
            this.btnAnteriorV.Name = "btnAnteriorV";
            this.btnAnteriorV.Size = new System.Drawing.Size(41, 23);
            this.btnAnteriorV.TabIndex = 91;
            this.btnAnteriorV.Text = "<";
            this.btnAnteriorV.UseVisualStyleBackColor = true;
            this.btnAnteriorV.Click += new System.EventHandler(this.btnAnteriorV_Click);
            // 
            // btnUltimoV
            // 
            this.btnUltimoV.Location = new System.Drawing.Point(144, 4);
            this.btnUltimoV.Name = "btnUltimoV";
            this.btnUltimoV.Size = new System.Drawing.Size(41, 23);
            this.btnUltimoV.TabIndex = 93;
            this.btnUltimoV.Text = ">>";
            this.btnUltimoV.UseVisualStyleBackColor = true;
            this.btnUltimoV.Click += new System.EventHandler(this.btnUltimoV_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.lblNombreApellidos);
            this.panel5.Controls.Add(this.txtNombreApellidos);
            this.panel5.Controls.Add(this.lblEmail);
            this.panel5.Controls.Add(this.rbnCodigoPlaca);
            this.panel5.Controls.Add(this.dgvDatosPropietarios);
            this.panel5.Controls.Add(this.txtEmail);
            this.panel5.Location = new System.Drawing.Point(1069, 371);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(241, 166);
            this.panel5.TabIndex = 98;
            // 
            // lblNombreApellidos
            // 
            this.lblNombreApellidos.AutoSize = true;
            this.lblNombreApellidos.Location = new System.Drawing.Point(-2, 143);
            this.lblNombreApellidos.Name = "lblNombreApellidos";
            this.lblNombreApellidos.Size = new System.Drawing.Size(91, 13);
            this.lblNombreApellidos.TabIndex = 104;
            this.lblNombreApellidos.Text = "Nombre apellidos:";
            // 
            // txtNombreApellidos
            // 
            this.txtNombreApellidos.Location = new System.Drawing.Point(100, 140);
            this.txtNombreApellidos.Name = "txtNombreApellidos";
            this.txtNombreApellidos.Size = new System.Drawing.Size(133, 20);
            this.txtNombreApellidos.TabIndex = 103;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(54, 117);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 102;
            this.lblEmail.Text = "Email:";
            // 
            // rbnCodigoPlaca
            // 
            this.rbnCodigoPlaca.AutoSize = true;
            this.rbnCodigoPlaca.Checked = true;
            this.rbnCodigoPlaca.Location = new System.Drawing.Point(95, 3);
            this.rbnCodigoPlaca.Name = "rbnCodigoPlaca";
            this.rbnCodigoPlaca.Size = new System.Drawing.Size(137, 17);
            this.rbnCodigoPlaca.TabIndex = 101;
            this.rbnCodigoPlaca.TabStop = true;
            this.rbnCodigoPlaca.Text = "Busqueda codigo placa";
            this.rbnCodigoPlaca.UseVisualStyleBackColor = true;
            this.rbnCodigoPlaca.CheckedChanged += new System.EventHandler(this.rbnCodigoPlaca_CheckedChanged);
            // 
            // dgvDatosPropietarios
            // 
            this.dgvDatosPropietarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosPropietarios.Location = new System.Drawing.Point(3, 23);
            this.dgvDatosPropietarios.Name = "dgvDatosPropietarios";
            this.dgvDatosPropietarios.Size = new System.Drawing.Size(231, 86);
            this.dgvDatosPropietarios.TabIndex = 82;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 114);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(134, 20);
            this.txtEmail.TabIndex = 99;
            // 
            // lblPlacas
            // 
            this.lblPlacas.AutoSize = true;
            this.lblPlacas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlacas.Location = new System.Drawing.Point(1152, 0);
            this.lblPlacas.Name = "lblPlacas";
            this.lblPlacas.Size = new System.Drawing.Size(66, 16);
            this.lblPlacas.TabIndex = 98;
            this.lblPlacas.Text = "PLACAS";
            // 
            // lblPuestos
            // 
            this.lblPuestos.AutoSize = true;
            this.lblPuestos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuestos.Location = new System.Drawing.Point(1101, 158);
            this.lblPuestos.Name = "lblPuestos";
            this.lblPuestos.Size = new System.Drawing.Size(169, 16);
            this.lblPuestos.TabIndex = 103;
            this.lblPuestos.Text = "PUESTOS VEHICULOS";
            // 
            // lblDatosPropietarios
            // 
            this.lblDatosPropietarios.AutoSize = true;
            this.lblDatosPropietarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatosPropietarios.Location = new System.Drawing.Point(1112, 361);
            this.lblDatosPropietarios.Name = "lblDatosPropietarios";
            this.lblDatosPropietarios.Size = new System.Drawing.Size(176, 16);
            this.lblDatosPropietarios.TabIndex = 103;
            this.lblDatosPropietarios.Text = "DATOS PROPIETARIOS";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.btnEliminarS);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.dtpFechaSalida);
            this.panel6.Controls.Add(this.lblFechaSalida);
            this.panel6.Controls.Add(this.txtCodigoPlacaSalida);
            this.panel6.Controls.Add(this.lblSalidaVehiculo);
            this.panel6.Controls.Add(this.dgvSalidaVehiculos);
            this.panel6.Location = new System.Drawing.Point(1066, 539);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(241, 169);
            this.panel6.TabIndex = 104;
            // 
            // btnEliminarS
            // 
            this.btnEliminarS.Location = new System.Drawing.Point(166, 114);
            this.btnEliminarS.Name = "btnEliminarS";
            this.btnEliminarS.Size = new System.Drawing.Size(60, 23);
            this.btnEliminarS.TabIndex = 105;
            this.btnEliminarS.Text = "Eliminar";
            this.btnEliminarS.UseVisualStyleBackColor = true;
            this.btnEliminarS.Click += new System.EventHandler(this.btnEliminarS_Click);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.btnSiguienteS);
            this.panel7.Controls.Add(this.btnPrimeroS);
            this.panel7.Controls.Add(this.btnAnteriorS);
            this.panel7.Controls.Add(this.btnUltimoS);
            this.panel7.Location = new System.Drawing.Point(27, 78);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(194, 32);
            this.panel7.TabIndex = 105;
            // 
            // btnSiguienteS
            // 
            this.btnSiguienteS.Location = new System.Drawing.Point(97, 4);
            this.btnSiguienteS.Name = "btnSiguienteS";
            this.btnSiguienteS.Size = new System.Drawing.Size(41, 23);
            this.btnSiguienteS.TabIndex = 92;
            this.btnSiguienteS.Text = ">";
            this.btnSiguienteS.UseVisualStyleBackColor = true;
            this.btnSiguienteS.Click += new System.EventHandler(this.btnSiguienteS_Click);
            // 
            // btnPrimeroS
            // 
            this.btnPrimeroS.Location = new System.Drawing.Point(3, 4);
            this.btnPrimeroS.Name = "btnPrimeroS";
            this.btnPrimeroS.Size = new System.Drawing.Size(41, 23);
            this.btnPrimeroS.TabIndex = 90;
            this.btnPrimeroS.Text = "<<";
            this.btnPrimeroS.UseVisualStyleBackColor = true;
            this.btnPrimeroS.Click += new System.EventHandler(this.btnPrimeroS_Click);
            // 
            // btnAnteriorS
            // 
            this.btnAnteriorS.Location = new System.Drawing.Point(50, 4);
            this.btnAnteriorS.Name = "btnAnteriorS";
            this.btnAnteriorS.Size = new System.Drawing.Size(41, 23);
            this.btnAnteriorS.TabIndex = 91;
            this.btnAnteriorS.Text = "<";
            this.btnAnteriorS.UseVisualStyleBackColor = true;
            this.btnAnteriorS.Click += new System.EventHandler(this.btnAnteriorS_Click);
            // 
            // btnUltimoS
            // 
            this.btnUltimoS.Location = new System.Drawing.Point(144, 4);
            this.btnUltimoS.Name = "btnUltimoS";
            this.btnUltimoS.Size = new System.Drawing.Size(41, 23);
            this.btnUltimoS.TabIndex = 93;
            this.btnUltimoS.Text = ">>";
            this.btnUltimoS.UseVisualStyleBackColor = true;
            this.btnUltimoS.Click += new System.EventHandler(this.btnUltimoS_Click);
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.Location = new System.Drawing.Point(82, 142);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(152, 20);
            this.dtpFechaSalida.TabIndex = 108;
            // 
            // lblFechaSalida
            // 
            this.lblFechaSalida.AutoSize = true;
            this.lblFechaSalida.Location = new System.Drawing.Point(6, 148);
            this.lblFechaSalida.Name = "lblFechaSalida";
            this.lblFechaSalida.Size = new System.Drawing.Size(70, 13);
            this.lblFechaSalida.TabIndex = 107;
            this.lblFechaSalida.Text = "Fecha salida:";
            // 
            // txtCodigoPlacaSalida
            // 
            this.txtCodigoPlacaSalida.Location = new System.Drawing.Point(6, 116);
            this.txtCodigoPlacaSalida.Name = "txtCodigoPlacaSalida";
            this.txtCodigoPlacaSalida.Size = new System.Drawing.Size(151, 20);
            this.txtCodigoPlacaSalida.TabIndex = 106;
            // 
            // lblSalidaVehiculo
            // 
            this.lblSalidaVehiculo.AutoSize = true;
            this.lblSalidaVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalidaVehiculo.Location = new System.Drawing.Point(47, -3);
            this.lblSalidaVehiculo.Name = "lblSalidaVehiculo";
            this.lblSalidaVehiculo.Size = new System.Drawing.Size(150, 16);
            this.lblSalidaVehiculo.TabIndex = 105;
            this.lblSalidaVehiculo.Text = "SALIDA VEHÍCULOS";
            // 
            // dgvSalidaVehiculos
            // 
            this.dgvSalidaVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalidaVehiculos.Location = new System.Drawing.Point(3, 8);
            this.dgvSalidaVehiculos.Name = "dgvSalidaVehiculos";
            this.dgvSalidaVehiculos.Size = new System.Drawing.Size(231, 67);
            this.dgvSalidaVehiculos.TabIndex = 82;
            // 
            // txtSalida
            // 
            this.txtSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalida.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSalida.Location = new System.Drawing.Point(1034, 689);
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.Size = new System.Drawing.Size(10, 22);
            this.txtSalida.TabIndex = 105;
            this.txtSalida.TextChanged += new System.EventHandler(this.txtSalida_TextChanged);
            // 
            // frmIdentificadorPlacas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1316, 733);
            this.Controls.Add(this.txtSalida);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.lblDatosPropietarios);
            this.Controls.Add(this.lblPuestos);
            this.Controls.Add(this.lblPlacas);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PictureBoxORIGINAL);
            this.Controls.Add(this.panelSensorMovimiento);
            this.Controls.Add(this.ControlesGuardarImagen);
            this.Controls.Add(this.panelControlesCamara);
            this.Controls.Add(this.panelControlesExaminarBD);
            this.Controls.Add(this.videoSourcePlayerDMovimiento);
            this.Controls.Add(this.PictureBoxFILTRADO);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIdentificadorPlacas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identificador placas vehiculos      (Andres Camilo Gallego Lopez)";
            this.Load += new System.EventHandler(this.IdentificadorPlacas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxFILTRADO)).EndInit();
            this.panelControlesExaminarBD.ResumeLayout(false);
            this.panelControlesExaminarBD.PerformLayout();
            this.panelControlesCamara.ResumeLayout(false);
            this.panelControlesCamara.PerformLayout();
            this.ControlesGuardarImagen.ResumeLayout(false);
            this.ControlesGuardarImagen.PerformLayout();
            this.panelSensorMovimiento.ResumeLayout(false);
            this.panelSensorMovimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxORIGINAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlacas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuestoVehiculo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosPropietarios)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaVehiculos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AForge.Controls.PictureBox PictureBoxFILTRADO;
        private System.Windows.Forms.ComboBox cbbCamaras;
        private System.Windows.Forms.Button btnDetenerCaptura;
        private System.Windows.Forms.Button btnIniciarDetenccion;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayerDMovimiento;
        private System.Windows.Forms.ComboBox cbListaImagenes;
        private System.Windows.Forms.TextBox txtCodigoPlaca;
        private System.Windows.Forms.Panel panelControlesExaminarBD;
        private System.Windows.Forms.Label lblControlesExaminarBD;
        private System.Windows.Forms.Panel panelControlesCamara;
        private System.Windows.Forms.Label lblControlesCamara;
        private System.Windows.Forms.Panel ControlesGuardarImagen;
        private System.Windows.Forms.Label lblControlesGuardarImagen;
        private System.Windows.Forms.Panel panelSensorMovimiento;
        private System.Windows.Forms.Label lblControlesSensorMovimiento;
        private System.Windows.Forms.Button btnAgregar;
        private AForge.Controls.PictureBox PictureBoxORIGINAL;
        private System.Windows.Forms.DataGridView dgvPlacas;
        private System.Windows.Forms.TextBox txtCodigoPlaca1;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvPuestoVehiculo;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrada;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblFechaEntrada;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.Button btnSiguienteV;
        private System.Windows.Forms.Button btnPrimeroV;
        private System.Windows.Forms.Button btnAnteriorV;
        private System.Windows.Forms.Button btnUltimoV;
        private System.Windows.Forms.TextBox txtPuestoVehiculo1;
        private System.Windows.Forms.Button btnEliminarPuesto;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvDatosPropietarios;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.RadioButton rbnCodigoPlaca;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPlacas;
        private System.Windows.Forms.Label lblPuestos;
        private System.Windows.Forms.Label lblDatosPropietarios;
        private System.Windows.Forms.Label lblNombreApellidos;
        private System.Windows.Forms.TextBox txtNombreApellidos;
        private System.Windows.Forms.TextBox txtPuestoVehiculo;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblSalidaVehiculo;
        private System.Windows.Forms.DataGridView dgvSalidaVehiculos;
        private System.Windows.Forms.TextBox txtCodigoPlacaSalida;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.Label lblFechaSalida;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnSiguienteS;
        private System.Windows.Forms.Button btnPrimeroS;
        private System.Windows.Forms.Button btnAnteriorS;
        private System.Windows.Forms.Button btnUltimoS;
        private System.Windows.Forms.Button btnEliminarS;
        private System.Windows.Forms.TextBox txtSalida;
    }
}