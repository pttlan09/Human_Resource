
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    partial class rpCanhbaohethan
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TN_QuanLyNhanSuDataSet = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSet();
            this.RP_HopDonghethanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RP_HopDonghethanTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.RP_HopDonghethanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RP_HopDonghethanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.RP_HopDonghethanBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhanSuFPT_PhamThiTuyetLan.TTCanhBaoHetHanHD.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1223, 806);
            this.reportViewer1.TabIndex = 0;
            // 
            // TN_QuanLyNhanSuDataSet
            // 
            this.TN_QuanLyNhanSuDataSet.DataSetName = "TN_QuanLyNhanSuDataSet";
            this.TN_QuanLyNhanSuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RP_HopDonghethanBindingSource
            // 
            this.RP_HopDonghethanBindingSource.DataMember = "RP_HopDonghethan";
            this.RP_HopDonghethanBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // RP_HopDonghethanTableAdapter
            // 
            this.RP_HopDonghethanTableAdapter.ClearBeforeFill = true;
            // 
            // rpCanhbaohethan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 806);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rpCanhbaohethan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rpCanhbaohethan";
            this.Load += new System.EventHandler(this.rpCanhbaohethan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RP_HopDonghethanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RP_HopDonghethanBindingSource;
        private TN_QuanLyNhanSuDataSet TN_QuanLyNhanSuDataSet;
        private TN_QuanLyNhanSuDataSetTableAdapters.RP_HopDonghethanTableAdapter RP_HopDonghethanTableAdapter;
    }
}