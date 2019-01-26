namespace IdentificadorPlacasDeVehiculos.Consultas
{
    partial class frmBuscarDatosPropietarios
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
            this.rbnCodigoPlaca = new System.Windows.Forms.RadioButton();
            this.rbnCedula = new System.Windows.Forms.RadioButton();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            this.dgvBusqueda = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // rbnCodigoPlaca
            // 
            this.rbnCodigoPlaca.AutoSize = true;
            this.rbnCodigoPlaca.Checked = true;
            this.rbnCodigoPlaca.Location = new System.Drawing.Point(12, 12);
            this.rbnCodigoPlaca.Name = "rbnCodigoPlaca";
            this.rbnCodigoPlaca.Size = new System.Drawing.Size(137, 17);
            this.rbnCodigoPlaca.TabIndex = 0;
            this.rbnCodigoPlaca.TabStop = true;
            this.rbnCodigoPlaca.Text = "Busqueda codigo placa";
            this.rbnCodigoPlaca.UseVisualStyleBackColor = true;
            this.rbnCodigoPlaca.CheckedChanged += new System.EventHandler(this.rbnCodigoPlaca_CheckedChanged);
            // 
            // rbnCedula
            // 
            this.rbnCedula.AutoSize = true;
            this.rbnCedula.Location = new System.Drawing.Point(173, 12);
            this.rbnCedula.Name = "rbnCedula";
            this.rbnCedula.Size = new System.Drawing.Size(108, 17);
            this.rbnCedula.TabIndex = 1;
            this.rbnCedula.Text = "Busqueda cedula";
            this.rbnCedula.UseVisualStyleBackColor = true;
            this.rbnCedula.CheckedChanged += new System.EventHandler(this.rbnCedula_CheckedChanged);
            // 
            // txtCriterio
            // 
            this.txtCriterio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCriterio.Location = new System.Drawing.Point(13, 36);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(260, 20);
            this.txtCriterio.TabIndex = 2;
            this.txtCriterio.TextChanged += new System.EventHandler(this.txtCriterio_TextChanged);
            // 
            // dgvBusqueda
            // 
            this.dgvBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBusqueda.Location = new System.Drawing.Point(12, 62);
            this.dgvBusqueda.Name = "dgvBusqueda";
            this.dgvBusqueda.Size = new System.Drawing.Size(261, 232);
            this.dgvBusqueda.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(119, 295);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(200, 295);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmBuscarDatosPropietarios
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(285, 322);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dgvBusqueda);
            this.Controls.Add(this.txtCriterio);
            this.Controls.Add(this.rbnCedula);
            this.Controls.Add(this.rbnCodigoPlaca);
            this.Name = "frmBuscarDatosPropietarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar datos propietarios";
            this.Load += new System.EventHandler(this.frmBuscarDatosPropietarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbnCodigoPlaca;
        private System.Windows.Forms.RadioButton rbnCedula;
        private System.Windows.Forms.TextBox txtCriterio;
        private System.Windows.Forms.DataGridView dgvBusqueda;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}