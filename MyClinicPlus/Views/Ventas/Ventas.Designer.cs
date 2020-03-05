namespace MyClinicPlus.Views.Ventas
{
    partial class Ventas
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelMenuIzquierda = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BtnAhora = new System.Windows.Forms.Button();
            this.btnSevenDays = new System.Windows.Forms.Button();
            this.btnThisMonth = new System.Windows.Forms.Button();
            this.btnThisYear = new System.Windows.Forms.Button();
            this.btnCustom = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLast30Days = new System.Windows.Forms.Button();
            this.panelMenuIzquierda.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(57)))), ((int)(((byte)(177)))));
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1093, 54);
            this.panelHeader.TabIndex = 2;
            // 
            // panelMenuIzquierda
            // 
            this.panelMenuIzquierda.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelMenuIzquierda.Controls.Add(this.btnLast30Days);
            this.panelMenuIzquierda.Controls.Add(this.label2);
            this.panelMenuIzquierda.Controls.Add(this.label1);
            this.panelMenuIzquierda.Controls.Add(this.dtpToDate);
            this.panelMenuIzquierda.Controls.Add(this.dtpFromDate);
            this.panelMenuIzquierda.Controls.Add(this.btnCustom);
            this.panelMenuIzquierda.Controls.Add(this.btnThisYear);
            this.panelMenuIzquierda.Controls.Add(this.btnThisMonth);
            this.panelMenuIzquierda.Controls.Add(this.btnSevenDays);
            this.panelMenuIzquierda.Controls.Add(this.BtnAhora);
            this.panelMenuIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuIzquierda.Location = new System.Drawing.Point(0, 54);
            this.panelMenuIzquierda.Name = "panelMenuIzquierda";
            this.panelMenuIzquierda.Size = new System.Drawing.Size(200, 721);
            this.panelMenuIzquierda.TabIndex = 3;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyClinicPlus.Reportes.ReporteDeVentas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(200, 54);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(893, 721);
            this.reportViewer1.TabIndex = 4;
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
            // btnThisYear
            // 
            this.btnThisYear.Location = new System.Drawing.Point(21, 279);
            this.btnThisYear.Name = "btnThisYear";
            this.btnThisYear.Size = new System.Drawing.Size(152, 33);
            this.btnThisYear.TabIndex = 3;
            this.btnThisYear.Text = "Este Año";
            this.btnThisYear.UseVisualStyleBackColor = true;
            this.btnThisYear.Click += new System.EventHandler(this.btnThisYear_Click);
            // 
            // btnCustom
            // 
            this.btnCustom.Location = new System.Drawing.Point(21, 436);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(152, 33);
            this.btnCustom.TabIndex = 4;
            this.btnCustom.Text = "Personalizado";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(80, 351);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(93, 20);
            this.dtpFromDate.TabIndex = 5;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(80, 398);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(93, 20);
            this.dtpToDate.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hasta";
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
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 775);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panelMenuIzquierda);
            this.Controls.Add(this.panelHeader);
            this.Name = "Ventas";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.Ventas_Load);
            this.panelMenuIzquierda.ResumeLayout(false);
            this.panelMenuIzquierda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMenuIzquierda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.Button btnThisYear;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.Button btnSevenDays;
        private System.Windows.Forms.Button BtnAhora;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnLast30Days;
    }
}