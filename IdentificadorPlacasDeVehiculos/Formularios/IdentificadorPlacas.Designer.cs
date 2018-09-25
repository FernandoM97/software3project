namespace IdentificadorPlacasDeVehiculos.Formularios
{
    partial class IdentificadorPlacas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdentificadorPlacas));
            this.PictureBoxORIGINAL = new AForge.Controls.PictureBox();
            this.PictureBoxFILTRADO = new AForge.Controls.PictureBox();
            this.cbbCamaras = new System.Windows.Forms.ComboBox();
            this.btnDetenerCaptura = new System.Windows.Forms.Button();
            this.btnIniciarDetenccion = new System.Windows.Forms.Button();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.cbListaImagenes = new System.Windows.Forms.ComboBox();
            this.txtCodigoPlaca = new System.Windows.Forms.TextBox();
            this.panelControlesExaminarBD = new System.Windows.Forms.Panel();
            this.lblControlesExaminarBD = new System.Windows.Forms.Label();
            this.panelControlesCamara = new System.Windows.Forms.Panel();
            this.lblControlesCamara = new System.Windows.Forms.Label();
            this.ControlesGuardarImagen = new System.Windows.Forms.Panel();
            this.lblControlesGuardarImagen = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelSensorMovimiento = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblControlesSensorMovimiento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxORIGINAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxFILTRADO)).BeginInit();
            this.panelControlesExaminarBD.SuspendLayout();
            this.panelControlesCamara.SuspendLayout();
            this.ControlesGuardarImagen.SuspendLayout();
            this.panelSensorMovimiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBoxORIGINAL
            // 
            this.PictureBoxORIGINAL.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PictureBoxORIGINAL.Image = null;
            this.PictureBoxORIGINAL.Location = new System.Drawing.Point(12, 11);
            this.PictureBoxORIGINAL.Name = "PictureBoxORIGINAL";
            this.PictureBoxORIGINAL.Size = new System.Drawing.Size(480, 360);
            this.PictureBoxORIGINAL.TabIndex = 0;
            this.PictureBoxORIGINAL.TabStop = false;
            // 
            // PictureBoxFILTRADO
            // 
            this.PictureBoxFILTRADO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxFILTRADO.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PictureBoxFILTRADO.Image = null;
            this.PictureBoxFILTRADO.Location = new System.Drawing.Point(510, 11);
            this.PictureBoxFILTRADO.Name = "PictureBoxFILTRADO";
            this.PictureBoxFILTRADO.Size = new System.Drawing.Size(480, 360);
            this.PictureBoxFILTRADO.TabIndex = 1;
            this.PictureBoxFILTRADO.TabStop = false;
            // 
            // cbbCamaras
            // 
            this.cbbCamaras.BackColor = System.Drawing.SystemColors.GrayText;
            this.cbbCamaras.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCamaras.ForeColor = System.Drawing.SystemColors.Info;
            this.cbbCamaras.FormattingEnabled = true;
            this.cbbCamaras.Location = new System.Drawing.Point(3, 36);
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
            this.btnDetenerCaptura.Location = new System.Drawing.Point(107, 20);
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
            this.btnIniciarDetenccion.Location = new System.Drawing.Point(160, 47);
            this.btnIniciarDetenccion.Name = "btnIniciarDetenccion";
            this.btnIniciarDetenccion.Size = new System.Drawing.Size(80, 40);
            this.btnIniciarDetenccion.TabIndex = 69;
            this.btnIniciarDetenccion.Text = "Iniciar detenccion";
            this.btnIniciarDetenccion.UseVisualStyleBackColor = true;
            this.btnIniciarDetenccion.Click += new System.EventHandler(this.btnIniciarDetenccion_Click);
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoSourcePlayer1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.videoSourcePlayer1.Location = new System.Drawing.Point(740, 378);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(250, 220);
            this.videoSourcePlayer1.TabIndex = 70;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame);
            // 
            // cbListaImagenes
            // 
            this.cbListaImagenes.BackColor = System.Drawing.SystemColors.GrayText;
            this.cbListaImagenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbListaImagenes.ForeColor = System.Drawing.SystemColors.Info;
            this.cbListaImagenes.FormattingEnabled = true;
            this.cbListaImagenes.Location = new System.Drawing.Point(3, 66);
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
            this.txtCodigoPlaca.Location = new System.Drawing.Point(3, 37);
            this.txtCodigoPlaca.Name = "txtCodigoPlaca";
            this.txtCodigoPlaca.Size = new System.Drawing.Size(237, 22);
            this.txtCodigoPlaca.TabIndex = 71;
            // 
            // panelControlesExaminarBD
            // 
            this.panelControlesExaminarBD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControlesExaminarBD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelControlesExaminarBD.Controls.Add(this.lblControlesExaminarBD);
            this.panelControlesExaminarBD.Controls.Add(this.btnDetenerCaptura);
            this.panelControlesExaminarBD.Controls.Add(this.cbListaImagenes);
            this.panelControlesExaminarBD.Location = new System.Drawing.Point(12, 496);
            this.panelControlesExaminarBD.Name = "panelControlesExaminarBD";
            this.panelControlesExaminarBD.Size = new System.Drawing.Size(348, 102);
            this.panelControlesExaminarBD.TabIndex = 75;
            // 
            // lblControlesExaminarBD
            // 
            this.lblControlesExaminarBD.AutoSize = true;
            this.lblControlesExaminarBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControlesExaminarBD.Location = new System.Drawing.Point(78, -5);
            this.lblControlesExaminarBD.Name = "lblControlesExaminarBD";
            this.lblControlesExaminarBD.Size = new System.Drawing.Size(188, 20);
            this.lblControlesExaminarBD.TabIndex = 77;
            this.lblControlesExaminarBD.Text = "Controles examinarBD";
            // 
            // panelControlesCamara
            // 
            this.panelControlesCamara.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelControlesCamara.Controls.Add(this.lblControlesCamara);
            this.panelControlesCamara.Controls.Add(this.cbbCamaras);
            this.panelControlesCamara.Location = new System.Drawing.Point(12, 379);
            this.panelControlesCamara.Name = "panelControlesCamara";
            this.panelControlesCamara.Size = new System.Drawing.Size(348, 98);
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
            this.ControlesGuardarImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ControlesGuardarImagen.Controls.Add(this.lblControlesGuardarImagen);
            this.ControlesGuardarImagen.Controls.Add(this.txtCodigoPlaca);
            this.ControlesGuardarImagen.Controls.Add(this.btnAgregar);
            this.ControlesGuardarImagen.Location = new System.Drawing.Point(371, 378);
            this.ControlesGuardarImagen.Name = "ControlesGuardarImagen";
            this.ControlesGuardarImagen.Size = new System.Drawing.Size(348, 98);
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
            this.btnAgregar.Location = new System.Drawing.Point(160, 56);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(80, 40);
            this.btnAgregar.TabIndex = 74;
            this.btnAgregar.Text = "Agregar placa";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelSensorMovimiento
            // 
            this.panelSensorMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSensorMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSensorMovimiento.Controls.Add(this.btnSalir);
            this.panelSensorMovimiento.Controls.Add(this.lblControlesSensorMovimiento);
            this.panelSensorMovimiento.Controls.Add(this.btnIniciarDetenccion);
            this.panelSensorMovimiento.Location = new System.Drawing.Point(371, 496);
            this.panelSensorMovimiento.Name = "panelSensorMovimiento";
            this.panelSensorMovimiento.Size = new System.Drawing.Size(348, 102);
            this.panelSensorMovimiento.TabIndex = 78;
            // 
            // btnSalir
            // 
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(74, 47);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(80, 40);
            this.btnSalir.TabIndex = 79;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            // IdentificadorPlacas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1001, 606);
            this.ControlBox = false;
            this.Controls.Add(this.panelSensorMovimiento);
            this.Controls.Add(this.ControlesGuardarImagen);
            this.Controls.Add(this.panelControlesCamara);
            this.Controls.Add(this.panelControlesExaminarBD);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Controls.Add(this.PictureBoxFILTRADO);
            this.Controls.Add(this.PictureBoxORIGINAL);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IdentificadorPlacas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identificador placas vehiculos      (Andres Camilo Gallego Lopez)";
            this.Load += new System.EventHandler(this.IdentificadorPlacas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxORIGINAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxFILTRADO)).EndInit();
            this.panelControlesExaminarBD.ResumeLayout(false);
            this.panelControlesExaminarBD.PerformLayout();
            this.panelControlesCamara.ResumeLayout(false);
            this.panelControlesCamara.PerformLayout();
            this.ControlesGuardarImagen.ResumeLayout(false);
            this.ControlesGuardarImagen.PerformLayout();
            this.panelSensorMovimiento.ResumeLayout(false);
            this.panelSensorMovimiento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.PictureBox PictureBoxORIGINAL;
        private AForge.Controls.PictureBox PictureBoxFILTRADO;
        private System.Windows.Forms.ComboBox cbbCamaras;
        private System.Windows.Forms.Button btnDetenerCaptura;
        private System.Windows.Forms.Button btnIniciarDetenccion;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
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
        private System.Windows.Forms.Button btnSalir;
    }
}