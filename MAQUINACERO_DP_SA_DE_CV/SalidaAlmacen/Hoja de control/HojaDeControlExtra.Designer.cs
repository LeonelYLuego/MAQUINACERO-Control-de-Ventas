namespace MAQUINACERO_DP_SA_DE_CV.Hoja_de_control
{
    partial class HojaDeControlExtra
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
            this.btnCliente = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnUbicacionArchivo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.txtNoHojacControl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTiempo = new System.Windows.Forms.TextBox();
            this.chkEnvio = new System.Windows.Forms.CheckBox();
            this.txtNumCotizacion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(268, 113);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(26, 20);
            this.btnCliente.TabIndex = 6;
            this.btnCliente.Text = "...";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(118, 113);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(144, 20);
            this.txtCliente.TabIndex = 5;
            // 
            // btnUbicacionArchivo
            // 
            this.btnUbicacionArchivo.Location = new System.Drawing.Point(268, 165);
            this.btnUbicacionArchivo.Name = "btnUbicacionArchivo";
            this.btnUbicacionArchivo.Size = new System.Drawing.Size(26, 20);
            this.btnUbicacionArchivo.TabIndex = 9;
            this.btnUbicacionArchivo.Text = "...";
            this.btnUbicacionArchivo.UseVisualStyleBackColor = true;
            this.btnUbicacionArchivo.Click += new System.EventHandler(this.btnUbicacionArchivo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Ubicacion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Nombre archivo:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Enabled = false;
            this.txtUbicacion.Location = new System.Drawing.Point(118, 165);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(144, 20);
            this.txtUbicacion.TabIndex = 8;
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Location = new System.Drawing.Point(118, 139);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(144, 20);
            this.txtNombreArchivo.TabIndex = 7;
            this.txtNombreArchivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreArchivo_KeyPress);
            // 
            // txtNoHojacControl
            // 
            this.txtNoHojacControl.Location = new System.Drawing.Point(118, 12);
            this.txtNoHojacControl.Name = "txtNoHojacControl";
            this.txtNoHojacControl.Size = new System.Drawing.Size(144, 20);
            this.txtNoHojacControl.TabIndex = 1;
            this.txtNoHojacControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoCompra_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "No. Hoja de control:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(219, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(132, 200);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Hrs.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tiempo:";
            // 
            // txtTiempo
            // 
            this.txtTiempo.Enabled = false;
            this.txtTiempo.Location = new System.Drawing.Point(118, 87);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Size = new System.Drawing.Size(144, 20);
            this.txtTiempo.TabIndex = 4;
            this.txtTiempo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTiempo_KeyPress);
            // 
            // chkEnvio
            // 
            this.chkEnvio.AutoSize = true;
            this.chkEnvio.Location = new System.Drawing.Point(118, 64);
            this.chkEnvio.Name = "chkEnvio";
            this.chkEnvio.Size = new System.Drawing.Size(110, 17);
            this.chkEnvio.TabIndex = 3;
            this.chkEnvio.Text = "Cuenta con envio";
            this.chkEnvio.UseVisualStyleBackColor = true;
            this.chkEnvio.CheckedChanged += new System.EventHandler(this.chkEnvio_CheckedChanged);
            // 
            // txtNumCotizacion
            // 
            this.txtNumCotizacion.Location = new System.Drawing.Point(118, 38);
            this.txtNumCotizacion.Name = "txtNumCotizacion";
            this.txtNumCotizacion.Size = new System.Drawing.Size(144, 20);
            this.txtNumCotizacion.TabIndex = 2;
            this.txtNumCotizacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "No. Cotización:";
            // 
            // HojaDeControlExtra
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(305, 229);
            this.Controls.Add(this.txtNumCotizacion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnUbicacionArchivo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.txtNoHojacControl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTiempo);
            this.Controls.Add(this.chkEnvio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "HojaDeControlExtra";
            this.ShowInTaskbar = false;
            this.Text = "Datos";
            this.Load += new System.EventHandler(this.HojaDeControlExtra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnUbicacionArchivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtUbicacion;
        public System.Windows.Forms.TextBox txtNombreArchivo;
        public System.Windows.Forms.TextBox txtNoHojacControl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtTiempo;
        public System.Windows.Forms.CheckBox chkEnvio;
        public System.Windows.Forms.TextBox txtNumCotizacion;
        private System.Windows.Forms.Label label9;
    }
}