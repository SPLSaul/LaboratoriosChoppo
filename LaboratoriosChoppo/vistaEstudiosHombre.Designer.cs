namespace LaboratoriosChoppo
{
    partial class vistaEstudiosHombre
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
            this.cLIENTESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chopoLabsDataSet = new LaboratoriosChoppo.chopoLabsDataSet();
            this.cLIENTESTableAdapter = new LaboratoriosChoppo.chopoLabsDataSetTableAdapters.CLIENTESTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CompleteCheckup = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.antigeno = new System.Windows.Forms.NumericUpDown();
            this.cultivo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.basicCheckUp = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Espermatobioscopia = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cLIENTESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chopoLabsDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompleteCheckup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antigeno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cultivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicCheckUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Espermatobioscopia)).BeginInit();
            this.SuspendLayout();
            // 
            // cLIENTESBindingSource
            // 
            this.cLIENTESBindingSource.DataMember = "CLIENTES";
            this.cLIENTESBindingSource.DataSource = this.chopoLabsDataSet;
            // 
            // chopoLabsDataSet
            // 
            this.chopoLabsDataSet.DataSetName = "chopoLabsDataSet";
            this.chopoLabsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cLIENTESTableAdapter
            // 
            this.cLIENTESTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Espermatobioscopia);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.basicCheckUp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRegresar);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CompleteCheckup);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.antigeno);
            this.groupBox1.Controls.Add(this.cultivo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(21, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(612, 419);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estudios";
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.AntiqueWhite;
            this.btnRegresar.Location = new System.Drawing.Point(189, 373);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(78, 33);
            this.btnRegresar.TabIndex = 15;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(337, 373);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(78, 33);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(51, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(347, 34);
            this.label5.TabIndex = 9;
            this.label5.Text = "Antigeno Prostatico Especifico Total ($1,500.00 mx)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CompleteCheckup
            // 
            this.CompleteCheckup.Location = new System.Drawing.Point(14, 116);
            this.CompleteCheckup.Margin = new System.Windows.Forms.Padding(2);
            this.CompleteCheckup.Name = "CompleteCheckup";
            this.CompleteCheckup.Size = new System.Drawing.Size(33, 26);
            this.CompleteCheckup.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(51, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(335, 36);
            this.label4.TabIndex = 13;
            this.label4.Text = "Check Up Masculino Completo Q45 ($3,500.00 mx)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // antigeno
            // 
            this.antigeno.Location = new System.Drawing.Point(14, 32);
            this.antigeno.Margin = new System.Windows.Forms.Padding(2);
            this.antigeno.Name = "antigeno";
            this.antigeno.Size = new System.Drawing.Size(33, 26);
            this.antigeno.TabIndex = 8;
            // 
            // cultivo
            // 
            this.cultivo.Location = new System.Drawing.Point(14, 70);
            this.cultivo.Margin = new System.Windows.Forms.Padding(2);
            this.cultivo.Name = "cultivo";
            this.cultivo.Size = new System.Drawing.Size(33, 26);
            this.cultivo.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(51, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(285, 33);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cultivo de liquido seminal  ($2,500.00 mx)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 58);
            this.label1.TabIndex = 15;
            this.label1.Text = "Estudios Hombre";
            // 
            // basicCheckUp
            // 
            this.basicCheckUp.Location = new System.Drawing.Point(14, 172);
            this.basicCheckUp.Margin = new System.Windows.Forms.Padding(2);
            this.basicCheckUp.Name = "basicCheckUp";
            this.basicCheckUp.Size = new System.Drawing.Size(33, 26);
            this.basicCheckUp.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(51, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 36);
            this.label2.TabIndex = 17;
            this.label2.Text = "Check Up Masculino Basico A45 ($2,500.00 mx)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Espermatobioscopia
            // 
            this.Espermatobioscopia.Location = new System.Drawing.Point(14, 233);
            this.Espermatobioscopia.Margin = new System.Windows.Forms.Padding(2);
            this.Espermatobioscopia.Name = "Espermatobioscopia";
            this.Espermatobioscopia.Size = new System.Drawing.Size(33, 26);
            this.Espermatobioscopia.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(51, 228);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 36);
            this.label3.TabIndex = 19;
            this.label3.Text = "Espermatobioscopia (Seminografia) ($1,200.00 mx)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vistaEstudiosHombre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 509);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "vistaEstudiosHombre";
            this.Text = "vistaEstudiosHombre";
            ((System.ComponentModel.ISupportInitialize)(this.cLIENTESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chopoLabsDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompleteCheckup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antigeno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cultivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basicCheckUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Espermatobioscopia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private chopoLabsDataSet chopoLabsDataSet;
        private System.Windows.Forms.BindingSource cLIENTESBindingSource;
        private chopoLabsDataSetTableAdapters.CLIENTESTableAdapter cLIENTESTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown CompleteCheckup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown antigeno;
        private System.Windows.Forms.NumericUpDown cultivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Espermatobioscopia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown basicCheckUp;
        private System.Windows.Forms.Label label2;
    }
}