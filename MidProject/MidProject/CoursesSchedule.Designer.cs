namespace MidProject
{
    partial class CoursesSchedule
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.admin8BLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.admin8BLBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon3 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon4 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon5 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon6 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon7 = new System.Windows.Forms.NotifyIcon(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.admin8BLBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.admin8BLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin8BLBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin8BLBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // admin8BLBindingSource
            // 
            this.admin8BLBindingSource.DataSource = typeof(MidProject.Admin8BL);
            // 
            // admin8BLBindingSource1
            // 
            this.admin8BLBindingSource1.DataSource = typeof(MidProject.Admin8BL);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.Text = "notifyIcon2";
            this.notifyIcon2.Visible = true;
            // 
            // notifyIcon3
            // 
            this.notifyIcon3.Text = "notifyIcon3";
            this.notifyIcon3.Visible = true;
            // 
            // notifyIcon4
            // 
            this.notifyIcon4.Text = "notifyIcon4";
            this.notifyIcon4.Visible = true;
            // 
            // notifyIcon5
            // 
            this.notifyIcon5.Text = "notifyIcon5";
            this.notifyIcon5.Visible = true;
            // 
            // notifyIcon6
            // 
            this.notifyIcon6.Text = "notifyIcon6";
            this.notifyIcon6.Visible = true;
            // 
            // notifyIcon7
            // 
            this.notifyIcon7.Text = "notifyIcon7";
            this.notifyIcon7.Visible = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.admin8BLBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MidProject.CourseSchedule.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // admin8BLBindingSource2
            // 
            this.admin8BLBindingSource2.DataSource = typeof(MidProject.Admin8BL);
            // 
            // CoursesSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CoursesSchedule";
            this.Text = "CoursesSchedule";
            this.Load += new System.EventHandler(this.CoursesSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.admin8BLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin8BLBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin8BLBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource admin8BLBindingSource;
        private System.Windows.Forms.BindingSource admin8BLBindingSource1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.Windows.Forms.NotifyIcon notifyIcon3;
        private System.Windows.Forms.NotifyIcon notifyIcon4;
        private System.Windows.Forms.NotifyIcon notifyIcon5;
        private System.Windows.Forms.NotifyIcon notifyIcon6;
        private System.Windows.Forms.NotifyIcon notifyIcon7;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource admin8BLBindingSource2;
    }
}