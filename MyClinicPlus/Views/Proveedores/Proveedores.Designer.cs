namespace MyClinicPlus.Views.Proveedores
{
    partial class Proveedores
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
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(390, 378);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // panel3
            // 
            this.panel3.Size = new System.Drawing.Size(806, 378);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(137, 145);
            // 
            // label5
            // 
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.Text = "Numero Proveedor";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(137, 107);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(137, 69);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 30);
            // 
            // label4
            // 
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.Text = "Correo Proveedor";
            // 
            // label3
            // 
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.Text = "Nombre Proveedor";
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.Text = "ID";
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(221, 39);
            this.label1.Text = "Proveedores";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 747);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Proveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}