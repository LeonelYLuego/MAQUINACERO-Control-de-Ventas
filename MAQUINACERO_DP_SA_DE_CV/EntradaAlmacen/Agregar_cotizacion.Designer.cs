namespace MAQUINACERO_DP_SA_DE_CV.EntradaAlmacen
{
    partial class Agregar_cotizacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKilogramos = new System.Windows.Forms.TextBox();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnNoAgregar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lbCanatidadBarra = new System.Windows.Forms.Label();
            this.txtCantidadBarra = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lbPrecio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(85, 10);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(367, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kilogramos:";
            // 
            // txtKilogramos
            // 
            this.txtKilogramos.Location = new System.Drawing.Point(85, 41);
            this.txtKilogramos.Name = "txtKilogramos";
            this.txtKilogramos.Size = new System.Drawing.Size(148, 20);
            this.txtKilogramos.TabIndex = 2;
            this.txtKilogramos.TextChanged += new System.EventHandler(this.txtKilogramos_TextChanged);
            this.txtKilogramos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKilogramos_KeyPress_1);
            // 
            // lbCantidad
            // 
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.Location = new System.Drawing.Point(37, 77);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(42, 13);
            this.lbCantidad.TabIndex = 4;
            this.lbCantidad.Text = "Metros:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(85, 74);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(148, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress_1);
            // 
            // btnNoAgregar
            // 
            this.btnNoAgregar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNoAgregar.Location = new System.Drawing.Point(377, 100);
            this.btnNoAgregar.Name = "btnNoAgregar";
            this.btnNoAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnNoAgregar.TabIndex = 6;
            this.btnNoAgregar.Text = "No agregar";
            this.btnNoAgregar.UseVisualStyleBackColor = true;
            this.btnNoAgregar.Click += new System.EventHandler(this.btnNoAgregar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(296, 100);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lbCanatidadBarra
            // 
            this.lbCanatidadBarra.AutoSize = true;
            this.lbCanatidadBarra.Location = new System.Drawing.Point(246, 77);
            this.lbCanatidadBarra.Name = "lbCanatidadBarra";
            this.lbCanatidadBarra.Size = new System.Drawing.Size(41, 13);
            this.lbCanatidadBarra.TabIndex = 8;
            this.lbCanatidadBarra.Text = "Piezas:";
            // 
            // txtCantidadBarra
            // 
            this.txtCantidadBarra.Location = new System.Drawing.Point(304, 74);
            this.txtCantidadBarra.Name = "txtCantidadBarra";
            this.txtCantidadBarra.Size = new System.Drawing.Size(148, 20);
            this.txtCantidadBarra.TabIndex = 4;
            this.txtCantidadBarra.TextChanged += new System.EventHandler(this.txtCantidadBarra_TextChanged);
            this.txtCantidadBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadBarra_KeyPress_1);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(304, 41);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(148, 20);
            this.txtPrecio.TabIndex = 9;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // lbPrecio
            // 
            this.lbPrecio.AutoSize = true;
            this.lbPrecio.Location = new System.Drawing.Point(258, 44);
            this.lbPrecio.Name = "lbPrecio";
            this.lbPrecio.Size = new System.Drawing.Size(40, 13);
            this.lbPrecio.TabIndex = 10;
            this.lbPrecio.Text = "Precio:";
            // 
            // Agregar_cotizacion
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnNoAgregar;
            this.ClientSize = new System.Drawing.Size(464, 133);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lbPrecio);
            this.Controls.Add(this.txtCantidadBarra);
            this.Controls.Add(this.lbCanatidadBarra);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnNoAgregar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lbCantidad);
            this.Controls.Add(this.txtKilogramos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Agregar_cotizacion";
            this.ShowInTaskbar = false;
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.Agregar_cotizacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKilogramos;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnNoAgregar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lbCanatidadBarra;
        private System.Windows.Forms.TextBox txtCantidadBarra;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lbPrecio;
    }
}