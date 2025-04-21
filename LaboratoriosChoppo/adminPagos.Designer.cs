namespace LaboratoriosChoppo
{
    partial class adminPagos
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.estudionombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadestudiosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preciounitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeparcialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vistaAdministradorPagosBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.vistaAdministradorPagosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.vistaAdministradorPagosBindingSource = new System.Windows.Forms.BindingSource(this.components);

            this.btnGenerarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaAdministradorPagosBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaAdministradorPagosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaAdministradorPagosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 90);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administrador de pagos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.estudionombreDataGridViewTextBoxColumn,
            this.cantidadestudiosDataGridViewTextBoxColumn,
            this.preciounitarioDataGridViewTextBoxColumn,
            this.importeparcialDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vistaAdministradorPagosBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 141);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(961, 236);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // estudionombreDataGridViewTextBoxColumn
            // 
            this.estudionombreDataGridViewTextBoxColumn.DataPropertyName = "estudio_nombre";
            this.estudionombreDataGridViewTextBoxColumn.HeaderText = "estudio_nombre";
            this.estudionombreDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.estudionombreDataGridViewTextBoxColumn.Name = "estudionombreDataGridViewTextBoxColumn";
            this.estudionombreDataGridViewTextBoxColumn.Width = 150;
            // 
            // cantidadestudiosDataGridViewTextBoxColumn
            // 
            this.cantidadestudiosDataGridViewTextBoxColumn.DataPropertyName = "cantidad_estudios";
            this.cantidadestudiosDataGridViewTextBoxColumn.HeaderText = "cantidad_estudios";
            this.cantidadestudiosDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cantidadestudiosDataGridViewTextBoxColumn.Name = "cantidadestudiosDataGridViewTextBoxColumn";
            this.cantidadestudiosDataGridViewTextBoxColumn.Width = 150;
            // 
            // preciounitarioDataGridViewTextBoxColumn
            // 
            this.preciounitarioDataGridViewTextBoxColumn.DataPropertyName = "precio_unitario";
            this.preciounitarioDataGridViewTextBoxColumn.HeaderText = "precio_unitario";
            this.preciounitarioDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.preciounitarioDataGridViewTextBoxColumn.Name = "preciounitarioDataGridViewTextBoxColumn";
            this.preciounitarioDataGridViewTextBoxColumn.Width = 150;
            // 
            // importeparcialDataGridViewTextBoxColumn
            // 
            this.importeparcialDataGridViewTextBoxColumn.DataPropertyName = "importe_parcial";
            this.importeparcialDataGridViewTextBoxColumn.HeaderText = "importe_parcial";
            this.importeparcialDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.importeparcialDataGridViewTextBoxColumn.Name = "importeparcialDataGridViewTextBoxColumn";
            this.importeparcialDataGridViewTextBoxColumn.Width = 150;
            // 
            // vistaAdministradorPagosBindingSource2
            // 
            this.vistaAdministradorPagosBindingSource2.DataMember = "VistaAdministradorPagos";
            // 
            // choppoDataSet2
            // 

            // 
            // vistaAdministradorPagosBindingSource1
            // 
            this.vistaAdministradorPagosBindingSource1.DataMember = "VistaAdministradorPagos";
            // 
 
            // 
            // vistaAdministradorPagosBindingSource
            // 
            this.vistaAdministradorPagosBindingSource.DataMember = "VistaAdministradorPagos";
     
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGenerarFactura.Location = new System.Drawing.Point(653, 437);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(163, 58);
            this.btnGenerarFactura.TabIndex = 3;
            this.btnGenerarFactura.Text = "Generar Factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = true;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // adminPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 616);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "adminPagos";
            this.Text = "adminPagos";
            this.Load += new System.EventHandler(this.adminPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaAdministradorPagosBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaAdministradorPagosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vistaAdministradorPagosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource vistaAdministradorPagosBindingSource;
        private System.Windows.Forms.BindingSource vistaAdministradorPagosBindingSource1;
        private System.Windows.Forms.BindingSource vistaAdministradorPagosBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn estudionombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadestudiosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn preciounitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeparcialDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnGenerarFactura;
    }
}