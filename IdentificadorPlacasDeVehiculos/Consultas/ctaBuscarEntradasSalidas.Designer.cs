namespace IdentificadorPlacasDeVehiculos.Consultas
{
    partial class ctaBuscarEntradasSalidas
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
            this.dgvEntradasSalidas = new System.Windows.Forms.DataGridView();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            this.rbnPuesto = new System.Windows.Forms.RadioButton();
            this.rbnCodigoPlaca = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradasSalidas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEntradasSalidas
            // 
            this.dgvEntradasSalidas.AllowUserToAddRows = false;
            this.dgvEntradasSalidas.AllowUserToDeleteRows = false;
            this.dgvEntradasSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntradasSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntradasSalidas.Location = new System.Drawing.Point(12, 57);
            this.dgvEntradasSalidas.Name = "dgvEntradasSalidas";
            this.dgvEntradasSalidas.ReadOnly = true;
            this.dgvEntradasSalidas.Size = new System.Drawing.Size(598, 227);
            this.dgvEntradasSalidas.TabIndex = 1;
            // 
            // txtCriterio
            // 
            this.txtCriterio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCriterio.Location = new System.Drawing.Point(341, 31);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(269, 20);
            this.txtCriterio.TabIndex = 0;
            this.txtCriterio.TextChanged += new System.EventHandler(this.txtCriterio_TextChanged);
            // 
            // rbnPuesto
            // 
            this.rbnPuesto.AutoSize = true;
            this.rbnPuesto.Location = new System.Drawing.Point(481, 7);
            this.rbnPuesto.Name = "rbnPuesto";
            this.rbnPuesto.Size = new System.Drawing.Size(126, 17);
            this.rbnPuesto.TabIndex = 3;
            this.rbnPuesto.Text = "Busqueda por puesto";
            this.rbnPuesto.UseVisualStyleBackColor = true;
            this.rbnPuesto.CheckedChanged += new System.EventHandler(this.rbnPuesto_CheckedChanged);
            // 
            // rbnCodigoPlaca
            // 
            this.rbnCodigoPlaca.AutoSize = true;
            this.rbnCodigoPlaca.Checked = true;
            this.rbnCodigoPlaca.Location = new System.Drawing.Point(341, 7);
            this.rbnCodigoPlaca.Name = "rbnCodigoPlaca";
            this.rbnCodigoPlaca.Size = new System.Drawing.Size(137, 17);
            this.rbnCodigoPlaca.TabIndex = 2;
            this.rbnCodigoPlaca.TabStop = true;
            this.rbnCodigoPlaca.Text = "Busqueda codigo placa";
            this.rbnCodigoPlaca.UseVisualStyleBackColor = true;
            this.rbnCodigoPlaca.CheckedChanged += new System.EventHandler(this.rbnCodigoPlaca_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(454, 290);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(535, 290);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ctaBuscarEntradasSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 313);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCriterio);
            this.Controls.Add(this.rbnPuesto);
            this.Controls.Add(this.rbnCodigoPlaca);
            this.Controls.Add(this.dgvEntradasSalidas);
            this.Name = "ctaBuscarEntradasSalidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entradas y Salidas vehículos (Estadística)";
            this.Load += new System.EventHandler(this.ctaBuscarEntradasSalidas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradasSalidas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEntradasSalidas;
        private System.Windows.Forms.TextBox txtCriterio;
        private System.Windows.Forms.RadioButton rbnPuesto;
        private System.Windows.Forms.RadioButton rbnCodigoPlaca;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}