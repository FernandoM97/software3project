namespace IdentificadorPlacasDeVehiculos.Consultas
{
    partial class ctaBuscarEntradas
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            this.rbnPuesto = new System.Windows.Forms.RadioButton();
            this.rbnCodigoPlaca = new System.Windows.Forms.RadioButton();
            this.dgvEntradas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(531, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(450, 286);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // txtCriterio
            // 
            this.txtCriterio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCriterio.Location = new System.Drawing.Point(337, 27);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(269, 20);
            this.txtCriterio.TabIndex = 6;
            this.txtCriterio.TextChanged += new System.EventHandler(this.txtCriterio_TextChanged);
            // 
            // rbnPuesto
            // 
            this.rbnPuesto.AutoSize = true;
            this.rbnPuesto.Location = new System.Drawing.Point(477, 3);
            this.rbnPuesto.Name = "rbnPuesto";
            this.rbnPuesto.Size = new System.Drawing.Size(126, 17);
            this.rbnPuesto.TabIndex = 9;
            this.rbnPuesto.Text = "Busqueda por puesto";
            this.rbnPuesto.UseVisualStyleBackColor = true;
            this.rbnPuesto.CheckedChanged += new System.EventHandler(this.rbnPuesto_CheckedChanged);
            // 
            // rbnCodigoPlaca
            // 
            this.rbnCodigoPlaca.AutoSize = true;
            this.rbnCodigoPlaca.Checked = true;
            this.rbnCodigoPlaca.Location = new System.Drawing.Point(337, 3);
            this.rbnCodigoPlaca.Name = "rbnCodigoPlaca";
            this.rbnCodigoPlaca.Size = new System.Drawing.Size(137, 17);
            this.rbnCodigoPlaca.TabIndex = 8;
            this.rbnCodigoPlaca.TabStop = true;
            this.rbnCodigoPlaca.Text = "Busqueda codigo placa";
            this.rbnCodigoPlaca.UseVisualStyleBackColor = true;
            this.rbnCodigoPlaca.CheckedChanged += new System.EventHandler(this.rbnCodigoPlaca_CheckedChanged);
            // 
            // dgvEntradas
            // 
            this.dgvEntradas.AllowUserToAddRows = false;
            this.dgvEntradas.AllowUserToDeleteRows = false;
            this.dgvEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntradas.Location = new System.Drawing.Point(8, 53);
            this.dgvEntradas.Name = "dgvEntradas";
            this.dgvEntradas.ReadOnly = true;
            this.dgvEntradas.Size = new System.Drawing.Size(598, 227);
            this.dgvEntradas.TabIndex = 7;
            // 
            // ctaBuscarEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 313);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCriterio);
            this.Controls.Add(this.rbnPuesto);
            this.Controls.Add(this.rbnCodigoPlaca);
            this.Controls.Add(this.dgvEntradas);
            this.Name = "ctaBuscarEntradas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ctaBuscarEntradas";
            this.Load += new System.EventHandler(this.ctaBuscarEntradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtCriterio;
        private System.Windows.Forms.RadioButton rbnPuesto;
        private System.Windows.Forms.RadioButton rbnCodigoPlaca;
        private System.Windows.Forms.DataGridView dgvEntradas;
    }
}