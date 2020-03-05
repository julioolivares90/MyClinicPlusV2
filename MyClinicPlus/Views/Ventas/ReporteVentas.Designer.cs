namespace MyClinicPlus.Views.Ventas
{
    partial class ReporteVentas
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelMenuIzquierda = new System.Windows.Forms.Panel();
            this.btnLast30Days = new System.Windows.Forms.Button();
            this.btnThisMonth = new System.Windows.Forms.Button();
            this.btnSevenDays = new System.Windows.Forms.Button();
            this.BtnAhora = new System.Windows.Forms.Button();
            this.panelMenuIzquierda.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyClinicPlus.Reportes.ReporteVentas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(200, 54);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(785, 675);
            this.reportViewer1.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(57)))), ((int)(((byte)(177)))));
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(985, 54);
            this.panelHeader.TabIndex = 3;
            // 
            // panelMenuIzquierda
            // 
            this.panelMenuIzquierda.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelMenuIzquierda.Controls.Add(this.btnLast30Days);
            this.panelMenuIzquierda.Controls.Add(this.btnThisMonth);
            this.panelMenuIzquierda.Controls.Add(this.btnSevenDays);
            this.panelMenuIzquierda.Controls.Add(this.BtnAhora);
            this.panelMenuIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuIzquierda.Location = new System.Drawing.Point(0, 54);
            this.panelMenuIzquierda.Name = "panelMenuIzquierda";
            this.panelMenuIzquierda.Size = new System.Drawing.Size(200, 675);
            this.panelMenuIzquierda.TabIndex = 4;
            // 
            // btnLast30Days
            // 
            this.btnLast30Days.Location = new System.Drawing.Point(21, 197);
            this.btnLast30Days.Name = "btnLast30Days";
            this.btnLast30Days.Size = new System.Drawing.Size(152, 33);
            this.btnLast30Days.TabIndex = 9;
            this.btnLast30Days.Text = "Ultimos 30 dias";
            this.btnLast30Days.UseVisualStyleBackColor = true;
            this.btnLast30Days.Click += new System.EventHandler(this.btnLast30Days_Click);
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.Location = new System.Drawing.Point(21, 131);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(152, 33);
            this.btnThisMonth.TabIndex = 2;
            this.btnThisMonth.Text = "Este Mes";
            this.btnThisMonth.UseVisualStyleBackColor = true;
            this.btnThisMonth.Click += new System.EventHandler(this.btnThisMonth_Click);
            // 
            // btnSevenDays
            // 
            this.btnSevenDays.Location = new System.Drawing.Point(21, 78);
            this.btnSevenDays.Name = "btnSevenDays";
            this.btnSevenDays.Size = new System.Drawing.Size(152, 33);
            this.btnSevenDays.TabIndex = 1;
            this.btnSevenDays.Text = "Ultimos 7 Dias";
            this.btnSevenDays.UseVisualStyleBackColor = true;
            this.btnSevenDays.Click += new System.EventHandler(this.btnSevenDays_Click);
            // 
            // BtnAhora
            // 
            this.BtnAhora.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnAhora.Location = new System.Drawing.Point(21, 22);
            this.BtnAhora.Name = "BtnAhora";
            this.BtnAhora.Size = new System.Drawing.Size(152, 33);
            this.BtnAhora.TabIndex = 0;
            this.BtnAhora.Text = "Ahora";
            this.BtnAhora.UseVisualStyleBackColor = false;
            this.BtnAhora.Click += new System.EventHandler(this.BtnAhora_Click);
            // 
            // ReporteVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 729);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panelMenuIzquierda);
            this.Controls.Add(this.panelHeader);
            this.Name = "ReporteVentas";
            this.Text = "ReporteVentas";
            this.Load += new System.EventHandler(this.ReporteVentas_Load);
            this.panelMenuIzquierda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMenuIzquierda;
        private System.Windows.Forms.Button btnLast30Days;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.Button btnSevenDays;
        private System.Windows.Forms.Button BtnAhora;
    }
}