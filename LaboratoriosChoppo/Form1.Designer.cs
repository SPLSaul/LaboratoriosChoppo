namespace LaboratoriosChoppo
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnRevGeneral = new System.Windows.Forms.Button();
            this.btnEstudHombe = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnPagos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(74, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Laboratorios Chopo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRevGeneral
            // 
            this.btnRevGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRevGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRevGeneral.ForeColor = System.Drawing.Color.Black;
            this.btnRevGeneral.Location = new System.Drawing.Point(30, 115);
            this.btnRevGeneral.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRevGeneral.Name = "btnRevGeneral";
            this.btnRevGeneral.Size = new System.Drawing.Size(175, 277);
            this.btnRevGeneral.TabIndex = 1;
            this.btnRevGeneral.Text = "Check Up Preventivo";
            this.btnRevGeneral.UseVisualStyleBackColor = false;
            this.btnRevGeneral.Click += new System.EventHandler(this.btnRevGeneral_Click);
            // 
            // btnEstudHombe
            // 
            this.btnEstudHombe.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEstudHombe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstudHombe.ForeColor = System.Drawing.Color.Black;
            this.btnEstudHombe.Location = new System.Drawing.Point(253, 115);
            this.btnEstudHombe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEstudHombe.Name = "btnEstudHombe";
            this.btnEstudHombe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnEstudHombe.Size = new System.Drawing.Size(184, 277);
            this.btnEstudHombe.TabIndex = 2;
            this.btnEstudHombe.Text = "Estudios para hombre";
            this.btnEstudHombe.UseVisualStyleBackColor = false;
            this.btnEstudHombe.Click += new System.EventHandler(this.btnEstudHombe_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MistyRose;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(491, 115);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 277);
            this.button2.TabIndex = 3;
            this.button2.Text = "Estudios para mujer";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnPagos
            // 
            this.btnPagos.Location = new System.Drawing.Point(233, 402);
            this.btnPagos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPagos.Name = "btnPagos";
            this.btnPagos.Size = new System.Drawing.Size(219, 40);
            this.btnPagos.TabIndex = 4;
            this.btnPagos.Text = "Pagos";
            this.btnPagos.UseVisualStyleBackColor = true;
            this.btnPagos.Click += new System.EventHandler(this.btnPagos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 450);
            this.Controls.Add(this.btnPagos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnEstudHombe);
            this.Controls.Add(this.btnRevGeneral);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRevGeneral;
        private System.Windows.Forms.Button btnEstudHombe;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnPagos;
    }
}

