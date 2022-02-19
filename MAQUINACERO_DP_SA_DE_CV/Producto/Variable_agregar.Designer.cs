namespace MAQUINACERO_DP_SA_DE_CV.Programa
{
    partial class Variable_agregar
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
            this.lbNuevo = new System.Windows.Forms.Label();
            this.lbTipo = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtNuevo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnAgregarOtro = new System.Windows.Forms.Button();
            this.lbPesoEspecifico = new System.Windows.Forms.Label();
            this.lbGrupo = new System.Windows.Forms.Label();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbNuevo
            // 
            this.lbNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNuevo.AutoSize = true;
            this.lbNuevo.Location = new System.Drawing.Point(12, 84);
            this.lbNuevo.Name = "lbNuevo";
            this.lbNuevo.Size = new System.Drawing.Size(63, 13);
            this.lbNuevo.TabIndex = 0;
            this.lbNuevo.Text = "Conversion:";
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(26, 18);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(44, 13);
            this.lbTipo.TabIndex = 1;
            this.lbTipo.Text = "Unidad:";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(76, 41);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(15, 14);
            this.checkBox.TabIndex = 2;
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(76, 15);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(182, 20);
            this.txtTipo.TabIndex = 1;
            this.txtTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTipo_KeyPress);
            // 
            // txtNuevo
            // 
            this.txtNuevo.Location = new System.Drawing.Point(76, 81);
            this.txtNuevo.Name = "txtNuevo";
            this.txtNuevo.Size = new System.Drawing.Size(182, 20);
            this.txtNuevo.TabIndex = 4;
            this.txtNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuevo_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(183, 113);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(102, 113);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(76, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnAgregarOtro
            // 
            this.btnAgregarOtro.Location = new System.Drawing.Point(21, 113);
            this.btnAgregarOtro.Name = "btnAgregarOtro";
            this.btnAgregarOtro.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarOtro.TabIndex = 5;
            this.btnAgregarOtro.Text = "Agregar otro";
            this.btnAgregarOtro.UseVisualStyleBackColor = true;
            this.btnAgregarOtro.Click += new System.EventHandler(this.btnAgregarOtro_Click);
            // 
            // lbPesoEspecifico
            // 
            this.lbPesoEspecifico.AutoSize = true;
            this.lbPesoEspecifico.Location = new System.Drawing.Point(73, 64);
            this.lbPesoEspecifico.Name = "lbPesoEspecifico";
            this.lbPesoEspecifico.Size = new System.Drawing.Size(144, 13);
            this.lbPesoEspecifico.TabIndex = 8;
            this.lbPesoEspecifico.Text = "Peso especifico en Kg/dm^3";
            // 
            // lbGrupo
            // 
            this.lbGrupo.AutoSize = true;
            this.lbGrupo.Location = new System.Drawing.Point(4, 44);
            this.lbGrupo.Name = "lbGrupo";
            this.lbGrupo.Size = new System.Drawing.Size(66, 13);
            this.lbGrupo.TabIndex = 10;
            this.lbGrupo.Text = "Grupo corte:";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Items.AddRange(new object[] {
            "S/G",
            "1",
            "2",
            "3"});
            this.cmbGrupo.Location = new System.Drawing.Point(76, 41);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(64, 21);
            this.cmbGrupo.TabIndex = 2;
            // 
            // Variable_agregar
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(264, 144);
            this.Controls.Add(this.cmbGrupo);
            this.Controls.Add(this.lbGrupo);
            this.Controls.Add(this.lbPesoEspecifico);
            this.Controls.Add(this.btnAgregarOtro);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtNuevo);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.lbTipo);
            this.Controls.Add(this.lbNuevo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Variable_agregar";
            this.ShowInTaskbar = false;
            this.Text = "Agregar";
            this.Load += new System.EventHandler(this.Variable_agregar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNuevo;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnAgregarOtro;
        private System.Windows.Forms.Label lbPesoEspecifico;
        private System.Windows.Forms.Label lbGrupo;
        private System.Windows.Forms.ComboBox cmbGrupo;
    }
}