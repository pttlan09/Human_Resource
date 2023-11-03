
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    partial class rpNghiViec
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
            this.RP_DSNVNghiViecBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TN_QuanLyNhanSuDataSet = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RP_DSNVNghiViecTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.RP_DSNVNghiViecTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.RP_DSNVNghiViecBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // RP_DSNVNghiViecBindingSource
            // 
            this.RP_DSNVNghiViecBindingSource.DataMember = "RP_DSNVNghiViec";
            this.RP_DSNVNghiViecBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // TN_QuanLyNhanSuDataSet
            // 
            this.TN_QuanLyNhanSuDataSet.DataSetName = "TN_QuanLyNhanSuDataSet";
            this.TN_QuanLyNhanSuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.RP_DSNVNghiViecBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhanSuFPT_PhamThiTuyetLan.TTDSNghiViec.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1223, 806);
            this.reportViewer1.TabIndex = 0;
            // 
            // RP_DSNVNghiViecTableAdapter
            // 
            this.RP_DSNVNghiViecTableAdapter.ClearBeforeFill = true;
            // 
            // rpNghiViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 806);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rpNghiViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rpNghiViec";
            this.Load += new System.EventHandler(this.rpNghiViec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RP_DSNVNghiViecBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RP_DSNVNghiViecBindingSource;
        private TN_QuanLyNhanSuDataSet TN_QuanLyNhanSuDataSet;
        private TN_QuanLyNhanSuDataSetTableAdapters.RP_DSNVNghiViecTableAdapter RP_DSNVNghiViecTableAdapter;
    }
}