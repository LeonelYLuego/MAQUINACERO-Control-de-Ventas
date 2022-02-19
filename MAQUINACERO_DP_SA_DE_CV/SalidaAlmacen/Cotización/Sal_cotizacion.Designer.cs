namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización
{
    partial class SalCotizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalCotizacion));
            this.tblCotizacion = new System.Windows.Forms.DataGridView();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.lbPrecioTotal = new System.Windows.Forms.Label();
            this.txtPrecioTotal = new System.Windows.Forms.TextBox();
            this.lbPrecioMXN = new System.Windows.Forms.Label();
            this.txtPrecioTotalMXN = new System.Windows.Forms.TextBox();
            this.btnOrdenCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblCotizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // tblCotizacion
            // 
            this.tblCotizacion.AllowUserToAddRows = false;
            this.tblCotizacion.AllowUserToDeleteRows = false;
            this.tblCotizacion.BackgroundColor = System.Drawing.Color.White;
            this.tblCotizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblCotizacion.Location = new System.Drawing.Point(12, 41);
            this.tblCotizacion.Name = "tblCotizacion";
            this.tblCotizacion.ReadOnly = true;
            this.tblCotizacion.Size = new System.Drawing.Size(776, 368);
            this.tblCotizacion.TabIndex = 0;
            this.tblCotizacion.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.tblCotizacion_RowsAdded);
            // 
            // btnRegresar
            // 
            this.btnRegresar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRegresar.Location = new System.Drawing.Point(713, 443);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(686, 12);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(102, 23);
            this.btnAgregarProducto.TabIndex = 2;
            this.btnAgregarProducto.Text = "Agregar producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(605, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(524, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(551, 443);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 6;
            this.btnImportar.Text = "Importar .txt";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // lbPrecioTotal
            // 
            this.lbPrecioTotal.AutoSize = true;
            this.lbPrecioTotal.Location = new System.Drawing.Point(12, 420);
            this.lbPrecioTotal.Name = "lbPrecioTotal";
            this.lbPrecioTotal.Size = new System.Drawing.Size(87, 13);
            this.lbPrecioTotal.TabIndex = 7;
            this.lbPrecioTotal.Text = "Precio sin envío:";
            // 
            // txtPrecioTotal
            // 
            this.txtPrecioTotal.Enabled = false;
            this.txtPrecioTotal.Location = new System.Drawing.Point(103, 417);
            this.txtPrecioTotal.Name = "txtPrecioTotal";
            this.txtPrecioTotal.Size = new System.Drawing.Size(164, 20);
            this.txtPrecioTotal.TabIndex = 8;
            // 
            // lbPrecioMXN
            // 
            this.lbPrecioMXN.AutoSize = true;
            this.lbPrecioMXN.Location = new System.Drawing.Point(273, 420);
            this.lbPrecioMXN.Name = "lbPrecioMXN";
            this.lbPrecioMXN.Size = new System.Drawing.Size(82, 13);
            this.lbPrecioMXN.TabIndex = 9;
            this.lbPrecioMXN.Text = "Precio en MXN:";
            // 
            // txtPrecioTotalMXN
            // 
            this.txtPrecioTotalMXN.Enabled = false;
            this.txtPrecioTotalMXN.Location = new System.Drawing.Point(361, 417);
            this.txtPrecioTotalMXN.Name = "txtPrecioTotalMXN";
            this.txtPrecioTotalMXN.Size = new System.Drawing.Size(164, 20);
            this.txtPrecioTotalMXN.TabIndex = 10;
            // 
            // btnOrdenCompra
            // 
            this.btnOrdenCompra.Location = new System.Drawing.Point(551, 414);
            this.btnOrdenCompra.Name = "btnOrdenCompra";
            this.btnOrdenCompra.Size = new System.Drawing.Size(237, 23);
            this.btnOrdenCompra.TabIndex = 11;
            this.btnOrdenCompra.Text = "Generar cotizacion";
            this.btnOrdenCompra.UseVisualStyleBackColor = true;
            this.btnOrdenCompra.Click += new System.EventHandler(this.button1_Click);
            // 
            // SalCotizacion
            // 
            this.AcceptButton = this.btnOrdenCompra;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnRegresar;
            this.ClientSize = new System.Drawing.Size(800, 478);
            this.Controls.Add(this.btnOrdenCompra);
            this.Controls.Add(this.txtPrecioTotalMXN);
            this.Controls.Add(this.lbPrecioMXN);
            this.Controls.Add(this.txtPrecioTotal);
            this.Controls.Add(this.lbPrecioTotal);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.tblCotizacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(559, 295);
            this.Name = "SalCotizacion";
            this.ShowInTaskbar = false;
            this.Text = "Cotización";
            this.Load += new System.EventHandler(this.SalCotizacion_Load);
            this.Resize += new System.EventHandler(this.SalCotizacion_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tblCotizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label lbPrecioTotal;
        private System.Windows.Forms.TextBox txtPrecioTotal;
        private System.Windows.Forms.Label lbPrecioMXN;
        private System.Windows.Forms.TextBox txtPrecioTotalMXN;
        private System.Windows.Forms.DataGridView tblCotizacion;
        protected System.Windows.Forms.Button btnOrdenCompra;
    }
}