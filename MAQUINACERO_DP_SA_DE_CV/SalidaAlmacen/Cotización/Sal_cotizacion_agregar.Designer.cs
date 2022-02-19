namespace MAQUINACERO_DP_SA_DE_CV.SalidaAlmacen.Cotización
{
    partial class SalCotizacionAgregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalCotizacionAgregar));
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtKilogramos = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtMetros = new System.Windows.Forms.TextBox();
            this.txtKilogramosAlmacen = new System.Windows.Forms.TextBox();
            this.txtKilogramosAlmacenRestantes = new System.Windows.Forms.TextBox();
            this.lbAKilogramosAlmacen = new System.Windows.Forms.Label();
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numPiezas = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMedidaPieza = new System.Windows.Forms.TextBox();
            this.checkPiezas = new System.Windows.Forms.CheckBox();
            this.cmbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrecioCorte = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPrecioCorteTotal = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPrecioMXN = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numCortes = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPiezas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCortes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtDescripcion.Location = new System.Drawing.Point(103, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(303, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // txtKilogramos
            // 
            this.txtKilogramos.BackColor = System.Drawing.SystemColors.Window;
            this.txtKilogramos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKilogramos.ForeColor = System.Drawing.Color.Black;
            this.txtKilogramos.Location = new System.Drawing.Point(103, 30);
            this.txtKilogramos.Name = "txtKilogramos";
            this.txtKilogramos.Size = new System.Drawing.Size(303, 20);
            this.txtKilogramos.TabIndex = 2;
            this.txtKilogramos.TextChanged += new System.EventHandler(this.txtKilogramos_TextChanged);
            this.txtKilogramos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKilogramos_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.SystemColors.Window;
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.ForeColor = System.Drawing.Color.Black;
            this.txtCantidad.Location = new System.Drawing.Point(103, 56);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(303, 20);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtMetros
            // 
            this.txtMetros.BackColor = System.Drawing.SystemColors.Window;
            this.txtMetros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMetros.ForeColor = System.Drawing.Color.Black;
            this.txtMetros.Location = new System.Drawing.Point(103, 82);
            this.txtMetros.Name = "txtMetros";
            this.txtMetros.Size = new System.Drawing.Size(303, 20);
            this.txtMetros.TabIndex = 4;
            this.txtMetros.TextChanged += new System.EventHandler(this.txtMetros_TextChanged);
            this.txtMetros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMetros_KeyPress);
            // 
            // txtKilogramosAlmacen
            // 
            this.txtKilogramosAlmacen.BackColor = System.Drawing.SystemColors.Window;
            this.txtKilogramosAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKilogramosAlmacen.Enabled = false;
            this.txtKilogramosAlmacen.ForeColor = System.Drawing.Color.Black;
            this.txtKilogramosAlmacen.Location = new System.Drawing.Point(424, 30);
            this.txtKilogramosAlmacen.Name = "txtKilogramosAlmacen";
            this.txtKilogramosAlmacen.Size = new System.Drawing.Size(303, 20);
            this.txtKilogramosAlmacen.TabIndex = 9;
            // 
            // txtKilogramosAlmacenRestantes
            // 
            this.txtKilogramosAlmacenRestantes.BackColor = System.Drawing.SystemColors.Window;
            this.txtKilogramosAlmacenRestantes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKilogramosAlmacenRestantes.Enabled = false;
            this.txtKilogramosAlmacenRestantes.ForeColor = System.Drawing.Color.Black;
            this.txtKilogramosAlmacenRestantes.Location = new System.Drawing.Point(424, 82);
            this.txtKilogramosAlmacenRestantes.Name = "txtKilogramosAlmacenRestantes";
            this.txtKilogramosAlmacenRestantes.Size = new System.Drawing.Size(303, 20);
            this.txtKilogramosAlmacenRestantes.TabIndex = 11;
            // 
            // lbAKilogramosAlmacen
            // 
            this.lbAKilogramosAlmacen.AutoSize = true;
            this.lbAKilogramosAlmacen.ForeColor = System.Drawing.Color.Red;
            this.lbAKilogramosAlmacen.Location = new System.Drawing.Point(424, 109);
            this.lbAKilogramosAlmacen.Name = "lbAKilogramosAlmacen";
            this.lbAKilogramosAlmacen.Size = new System.Drawing.Size(262, 13);
            this.lbAKilogramosAlmacen.TabIndex = 12;
            this.lbAKilogramosAlmacen.Text = "No se cuenta con el suficiente material en el almacén.";
            // 
            // cmbCriterio
            // 
            this.cmbCriterio.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Items.AddRange(new object[] {
            "Criterio 1",
            "Criterio 2",
            "Criterio 3",
            "A negociar"});
            this.cmbCriterio.Location = new System.Drawing.Point(103, 262);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(121, 21);
            this.cmbCriterio.TabIndex = 11;
            this.cmbCriterio.SelectedIndexChanged += new System.EventHandler(this.cmbCriterio_SelectedIndexChanged);
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Enabled = false;
            this.txtPrecio.ForeColor = System.Drawing.Color.Black;
            this.txtPrecio.Location = new System.Drawing.Point(103, 289);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(303, 20);
            this.txtPrecio.TabIndex = 12;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(57, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Precio:";
            // 
            // numPiezas
            // 
            this.numPiezas.BackColor = System.Drawing.SystemColors.Window;
            this.numPiezas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPiezas.ForeColor = System.Drawing.Color.Black;
            this.numPiezas.Location = new System.Drawing.Point(103, 158);
            this.numPiezas.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPiezas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPiezas.Name = "numPiezas";
            this.numPiezas.Size = new System.Drawing.Size(120, 20);
            this.numPiezas.TabIndex = 8;
            this.numPiezas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPiezas.ValueChanged += new System.EventHandler(this.numCortes_ValueChanged);
            this.numPiezas.Leave += new System.EventHandler(this.numCortes_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(56, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Piezas:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(52, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Medida:";
            // 
            // txtMedidaPieza
            // 
            this.txtMedidaPieza.BackColor = System.Drawing.SystemColors.Window;
            this.txtMedidaPieza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMedidaPieza.ForeColor = System.Drawing.Color.Black;
            this.txtMedidaPieza.Location = new System.Drawing.Point(103, 132);
            this.txtMedidaPieza.Name = "txtMedidaPieza";
            this.txtMedidaPieza.Size = new System.Drawing.Size(176, 20);
            this.txtMedidaPieza.TabIndex = 6;
            this.txtMedidaPieza.TextChanged += new System.EventHandler(this.txtMedidaPieza_TextChanged);
            this.txtMedidaPieza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMedidaPieza_KeyPress);
            // 
            // checkPiezas
            // 
            this.checkPiezas.AutoSize = true;
            this.checkPiezas.Location = new System.Drawing.Point(103, 109);
            this.checkPiezas.Name = "checkPiezas";
            this.checkPiezas.Size = new System.Drawing.Size(72, 17);
            this.checkPiezas.TabIndex = 5;
            this.checkPiezas.Text = "En piezas";
            this.checkPiezas.UseVisualStyleBackColor = true;
            this.checkPiezas.CheckedChanged += new System.EventHandler(this.checkPiezas_CheckedChanged);
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.BackColor = System.Drawing.SystemColors.Window;
            this.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadMedida.FormattingEnabled = true;
            this.cmbUnidadMedida.Location = new System.Drawing.Point(285, 132);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Size = new System.Drawing.Size(121, 21);
            this.cmbUnidadMedida.TabIndex = 7;
            this.cmbUnidadMedida.SelectedIndexChanged += new System.EventHandler(this.cmbUnidadMedida_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(12, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Precio por corte:";
            // 
            // txtPrecioCorte
            // 
            this.txtPrecioCorte.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecioCorte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioCorte.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioCorte.Location = new System.Drawing.Point(103, 210);
            this.txtPrecioCorte.Name = "txtPrecioCorte";
            this.txtPrecioCorte.Size = new System.Drawing.Size(303, 20);
            this.txtPrecioCorte.TabIndex = 9;
            this.txtPrecioCorte.TextChanged += new System.EventHandler(this.txtPrecioCorte_TextChanged);
            this.txtPrecioCorte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCorte_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Precio total corte:";
            // 
            // txtPrecioCorteTotal
            // 
            this.txtPrecioCorteTotal.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecioCorteTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioCorteTotal.Enabled = false;
            this.txtPrecioCorteTotal.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioCorteTotal.Location = new System.Drawing.Point(104, 236);
            this.txtPrecioCorteTotal.Name = "txtPrecioCorteTotal";
            this.txtPrecioCorteTotal.Size = new System.Drawing.Size(303, 20);
            this.txtPrecioCorteTotal.TabIndex = 10;
            this.txtPrecioCorteTotal.TextChanged += new System.EventHandler(this.txtPrecioCorteTotal_TextChanged);
            this.txtPrecioCorteTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCorteTotal_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(651, 315);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(31, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Descripción:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(36, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Kilogramos:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(1, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Tramos completos:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(55, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Metros:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(421, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Kilogramos en almacén:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(421, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(165, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Kilogramos en almacén restantes:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(571, 315);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(15, 317);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "Precio en MXN:";
            // 
            // txtPrecioMXN
            // 
            this.txtPrecioMXN.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecioMXN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioMXN.Enabled = false;
            this.txtPrecioMXN.ForeColor = System.Drawing.Color.Black;
            this.txtPrecioMXN.Location = new System.Drawing.Point(103, 315);
            this.txtPrecioMXN.Name = "txtPrecioMXN";
            this.txtPrecioMXN.Size = new System.Drawing.Size(303, 20);
            this.txtPrecioMXN.TabIndex = 13;
            this.txtPrecioMXN.TextChanged += new System.EventHandler(this.txtPrecioMXN_TextChanged);
            this.txtPrecioMXN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioMXN_KeyPress);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(571, 315);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 30;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(31, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Num. Cortés";
            // 
            // numCortes
            // 
            this.numCortes.BackColor = System.Drawing.SystemColors.Window;
            this.numCortes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCortes.ForeColor = System.Drawing.Color.Black;
            this.numCortes.Location = new System.Drawing.Point(104, 184);
            this.numCortes.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCortes.Name = "numCortes";
            this.numCortes.Size = new System.Drawing.Size(120, 20);
            this.numCortes.TabIndex = 31;
            this.numCortes.ValueChanged += new System.EventHandler(this.numCortes_ValueChanged);
            this.numCortes.Leave += new System.EventHandler(this.numCortes_Leave_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Dólares";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Dólares";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Dólares";
            // 
            // SalCotizacionAgregar
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(738, 349);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numCortes);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtPrecioMXN);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPrecioCorteTotal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPrecioCorte);
            this.Controls.Add(this.cmbUnidadMedida);
            this.Controls.Add(this.checkPiezas);
            this.Controls.Add(this.txtMedidaPieza);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numPiezas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.cmbCriterio);
            this.Controls.Add(this.lbAKilogramosAlmacen);
            this.Controls.Add(this.txtKilogramosAlmacenRestantes);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtKilogramosAlmacen);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtMetros);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtKilogramos);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SalCotizacionAgregar";
            this.ShowInTaskbar = false;
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.SalCotizacionAgregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPiezas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCortes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtKilogramos;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtMetros;
        private System.Windows.Forms.TextBox txtKilogramosAlmacen;
        private System.Windows.Forms.TextBox txtKilogramosAlmacenRestantes;
        private System.Windows.Forms.Label lbAKilogramosAlmacen;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numPiezas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMedidaPieza;
        private System.Windows.Forms.CheckBox checkPiezas;
        private System.Windows.Forms.ComboBox cmbUnidadMedida;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrecioCorte;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPrecioCorteTotal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPrecioMXN;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCortes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}