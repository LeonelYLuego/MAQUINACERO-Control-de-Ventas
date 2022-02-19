namespace MAQUINACERO_DP_SA_DE_CV.Informes
{
    partial class Informe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informe));
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.rbtnEntrada = new System.Windows.Forms.RadioButton();
            this.rbtnSalida = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnPorProducto = new System.Windows.Forms.RadioButton();
            this.rbtnTodo = new System.Windows.Forms.RadioButton();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.tblInforme = new System.Windows.Forms.DataGridView();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblInforme)).BeginInit();
            this.SuspendLayout();
            // 
            // dateInicio
            // 
            this.dateInicio.Checked = false;
            this.dateInicio.Location = new System.Drawing.Point(53, 8);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(200, 20);
            this.dateInicio.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fin:";
            // 
            // dateFin
            // 
            this.dateFin.Checked = false;
            this.dateFin.Location = new System.Drawing.Point(293, 8);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(200, 20);
            this.dateFin.TabIndex = 2;
            // 
            // rbtnEntrada
            // 
            this.rbtnEntrada.AutoSize = true;
            this.rbtnEntrada.Checked = true;
            this.rbtnEntrada.Location = new System.Drawing.Point(3, 3);
            this.rbtnEntrada.Name = "rbtnEntrada";
            this.rbtnEntrada.Size = new System.Drawing.Size(62, 17);
            this.rbtnEntrada.TabIndex = 4;
            this.rbtnEntrada.TabStop = true;
            this.rbtnEntrada.Text = "Entrada";
            this.rbtnEntrada.UseVisualStyleBackColor = true;
            // 
            // rbtnSalida
            // 
            this.rbtnSalida.AutoSize = true;
            this.rbtnSalida.Location = new System.Drawing.Point(3, 26);
            this.rbtnSalida.Name = "rbtnSalida";
            this.rbtnSalida.Size = new System.Drawing.Size(54, 17);
            this.rbtnSalida.TabIndex = 5;
            this.rbtnSalida.Text = "Salida";
            this.rbtnSalida.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnSalida);
            this.panel1.Controls.Add(this.rbtnEntrada);
            this.panel1.Location = new System.Drawing.Point(499, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(72, 45);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnPorProducto);
            this.panel2.Controls.Add(this.rbtnTodo);
            this.panel2.Location = new System.Drawing.Point(577, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(95, 45);
            this.panel2.TabIndex = 8;
            // 
            // rbtnPorProducto
            // 
            this.rbtnPorProducto.AutoSize = true;
            this.rbtnPorProducto.Location = new System.Drawing.Point(3, 25);
            this.rbtnPorProducto.Name = "rbtnPorProducto";
            this.rbtnPorProducto.Size = new System.Drawing.Size(86, 17);
            this.rbtnPorProducto.TabIndex = 1;
            this.rbtnPorProducto.Text = "Por producto";
            this.rbtnPorProducto.UseVisualStyleBackColor = true;
            // 
            // rbtnTodo
            // 
            this.rbtnTodo.AutoSize = true;
            this.rbtnTodo.Checked = true;
            this.rbtnTodo.Location = new System.Drawing.Point(3, 2);
            this.rbtnTodo.Name = "rbtnTodo";
            this.rbtnTodo.Size = new System.Drawing.Size(50, 17);
            this.rbtnTodo.TabIndex = 0;
            this.rbtnTodo.TabStop = true;
            this.rbtnTodo.Text = "Todo";
            this.rbtnTodo.UseVisualStyleBackColor = true;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Location = new System.Drawing.Point(699, 9);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(75, 23);
            this.btnVisualizar.TabIndex = 9;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // tblInforme
            // 
            this.tblInforme.AllowUserToAddRows = false;
            this.tblInforme.AllowUserToDeleteRows = false;
            this.tblInforme.BackgroundColor = System.Drawing.Color.White;
            this.tblInforme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblInforme.Location = new System.Drawing.Point(12, 60);
            this.tblInforme.Name = "tblInforme";
            this.tblInforme.Size = new System.Drawing.Size(776, 394);
            this.tblInforme.TabIndex = 10;
            // 
            // btnRegresar
            // 
            this.btnRegresar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRegresar.Location = new System.Drawing.Point(713, 460);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 11;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(632, 460);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 12;
            this.btnExportar.Text = "Exportar .txt";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // Informe
            // 
            this.AcceptButton = this.btnVisualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.CancelButton = this.btnRegresar;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.tblInforme);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 229);
            this.Name = "Informe";
            this.ShowInTaskbar = false;
            this.Text = "Informe";
            this.Resize += new System.EventHandler(this.Informe_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblInforme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFin;
        private System.Windows.Forms.RadioButton rbtnEntrada;
        private System.Windows.Forms.RadioButton rbtnSalida;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnPorProducto;
        private System.Windows.Forms.RadioButton rbtnTodo;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.DataGridView tblInforme;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnExportar;
    }
}