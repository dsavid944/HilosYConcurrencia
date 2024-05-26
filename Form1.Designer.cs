namespace Supermercado
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnIniciarSimulacion = new System.Windows.Forms.Button();
            this.btnDetenerSimulacion = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.btnAgregarCajera = new System.Windows.Forms.Button();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.listBoxCajeras = new System.Windows.Forms.ListBox();
            this.listBoxClientes = new System.Windows.Forms.ListBox();
            this.listBoxResumen = new System.Windows.Forms.ListBox();
            this.btnDetenerCajera = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciarSimulacion
            // 
            this.btnIniciarSimulacion.Location = new System.Drawing.Point(50, 20);
            this.btnIniciarSimulacion.Name = "btnIniciarSimulacion";
            this.btnIniciarSimulacion.Size = new System.Drawing.Size(150, 40);
            this.btnIniciarSimulacion.TabIndex = 0;
            this.btnIniciarSimulacion.Text = "Iniciar Simulación";
            this.btnIniciarSimulacion.UseVisualStyleBackColor = true;
            this.btnIniciarSimulacion.Click += new System.EventHandler(this.btnIniciarSimulacion_Click);
            // 
            // btnDetenerSimulacion
            // 
            this.btnDetenerSimulacion.Location = new System.Drawing.Point(220, 20);
            this.btnDetenerSimulacion.Name = "btnDetenerSimulacion";
            this.btnDetenerSimulacion.Size = new System.Drawing.Size(150, 40);
            this.btnDetenerSimulacion.TabIndex = 1;
            this.btnDetenerSimulacion.Text = "Detener Simulación";
            this.btnDetenerSimulacion.UseVisualStyleBackColor = true;
            this.btnDetenerSimulacion.Click += new System.EventHandler(this.btnDetenerSimulacion_Click);
            // 
            // btnAgregarCajera
            // 
            this.btnAgregarCajera.Location = new System.Drawing.Point(50, 80);
            this.btnAgregarCajera.Name = "btnAgregarCajera";
            this.btnAgregarCajera.Size = new System.Drawing.Size(150, 40);
            this.btnAgregarCajera.TabIndex = 2;
            this.btnAgregarCajera.Text = "Agregar Cajera";
            this.btnAgregarCajera.UseVisualStyleBackColor = true;
            this.btnAgregarCajera.Click += new System.EventHandler(this.btnAgregarCajera_Click);
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Location = new System.Drawing.Point(220, 80);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(150, 40);
            this.btnAgregarCliente.TabIndex = 3;
            this.btnAgregarCliente.Text = "Agregar Cliente";
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(50, 150);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(554, 175);
            this.dataGridView.TabIndex = 4;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Location = new System.Drawing.Point(50, 350);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(169, 17);
            this.lblTotalTime.TabIndex = 5;
            this.lblTotalTime.Text = "Tiempo Total: 0 segundos";
            // 
            // listBoxCajeras
            // 
            this.listBoxCajeras.FormattingEnabled = true;
            this.listBoxCajeras.ItemHeight = 16;
            this.listBoxCajeras.Location = new System.Drawing.Point(390, 20);
            this.listBoxCajeras.Name = "listBoxCajeras";
            this.listBoxCajeras.Size = new System.Drawing.Size(150, 100);
            this.listBoxCajeras.TabIndex = 6;
            // 
            // listBoxClientes
            // 
            this.listBoxClientes.FormattingEnabled = true;
            this.listBoxClientes.ItemHeight = 16;
            this.listBoxClientes.Location = new System.Drawing.Point(550, 20);
            this.listBoxClientes.Name = "listBoxClientes";
            this.listBoxClientes.Size = new System.Drawing.Size(150, 100);
            this.listBoxClientes.TabIndex = 7;
            // 
            // listBoxResumen
            // 
            this.listBoxResumen.FormattingEnabled = true;
            this.listBoxResumen.ItemHeight = 16;
            this.listBoxResumen.Location = new System.Drawing.Point(50, 380);
            this.listBoxResumen.Name = "listBoxResumen";
            this.listBoxResumen.Size = new System.Drawing.Size(554, 100);
            this.listBoxResumen.TabIndex = 8;
            // 
            // btnDetenerCajera
            // 
            this.btnDetenerCajera.Location = new System.Drawing.Point(50, 500);
            this.btnDetenerCajera.Name = "btnDetenerCajera";
            this.btnDetenerCajera.Size = new System.Drawing.Size(150, 40);
            this.btnDetenerCajera.TabIndex = 9;
            this.btnDetenerCajera.Text = "Detener Cajera";
            this.btnDetenerCajera.UseVisualStyleBackColor = true;
            this.btnDetenerCajera.Click += new System.EventHandler(this.btnDetenerCajera_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnDetenerCajera);
            this.Controls.Add(this.listBoxResumen);
            this.Controls.Add(this.listBoxClientes);
            this.Controls.Add(this.listBoxCajeras);
            this.Controls.Add(this.lblTotalTime);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.btnAgregarCajera);
            this.Controls.Add(this.btnDetenerSimulacion);
            this.Controls.Add(this.btnIniciarSimulacion);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnIniciarSimulacion;
        private System.Windows.Forms.Button btnDetenerSimulacion;
        private System.Windows.Forms.Button btnAgregarCajera;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.ListBox listBoxCajeras;
        private System.Windows.Forms.ListBox listBoxClientes;
        private System.Windows.Forms.ListBox listBoxResumen;
        private System.Windows.Forms.Button btnDetenerCajera;
    }
}
