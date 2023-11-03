
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    partial class rpPhieuLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpPhieuLuong));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sp_LuongCBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TN_QuanLyNhanSuDataSet = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSet();
            this.sp_SoCongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ThuongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_ThueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_BaoHiemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_PhatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtp_ngay = new System.Windows.Forms.DateTimePicker();
            this.cbomaNV = new System.Windows.Forms.ComboBox();
            this.btnchon = new System.Windows.Forms.Button();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_LuongCBTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.sp_LuongCBTableAdapter();
            this.sp_SoCongTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.sp_SoCongTableAdapter();
            this.sp_ThuongTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.sp_ThuongTableAdapter();
            this.sp_ThueTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.sp_ThueTableAdapter();
            this.sp_BaoHiemTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.sp_BaoHiemTableAdapter();
            this.sp_PhatTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.sp_PhatTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_LuongCBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_SoCongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ThuongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ThueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_BaoHiemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_PhatBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_LuongCBBindingSource
            // 
            this.sp_LuongCBBindingSource.DataMember = "sp_LuongCB";
            this.sp_LuongCBBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // TN_QuanLyNhanSuDataSet
            // 
            this.TN_QuanLyNhanSuDataSet.DataSetName = "TN_QuanLyNhanSuDataSet";
            this.TN_QuanLyNhanSuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_SoCongBindingSource
            // 
            this.sp_SoCongBindingSource.DataMember = "sp_SoCong";
            this.sp_SoCongBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // sp_ThuongBindingSource
            // 
            this.sp_ThuongBindingSource.DataMember = "sp_Thuong";
            this.sp_ThuongBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // sp_ThueBindingSource
            // 
            this.sp_ThueBindingSource.DataMember = "sp_Thue";
            this.sp_ThueBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // sp_BaoHiemBindingSource
            // 
            this.sp_BaoHiemBindingSource.DataMember = "sp_BaoHiem";
            this.sp_BaoHiemBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // sp_PhatBindingSource
            // 
            this.sp_PhatBindingSource.DataMember = "sp_Phat";
            this.sp_PhatBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // dtp_ngay
            // 
            this.dtp_ngay.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtp_ngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngay.Location = new System.Drawing.Point(410, 13);
            this.dtp_ngay.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_ngay.Name = "dtp_ngay";
            this.dtp_ngay.Size = new System.Drawing.Size(199, 33);
            this.dtp_ngay.TabIndex = 152;
            // 
            // cbomaNV
            // 
            this.cbomaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomaNV.FormattingEnabled = true;
            this.cbomaNV.Location = new System.Drawing.Point(189, 20);
            this.cbomaNV.Margin = new System.Windows.Forms.Padding(4);
            this.cbomaNV.Name = "cbomaNV";
            this.cbomaNV.Size = new System.Drawing.Size(189, 24);
            this.cbomaNV.TabIndex = 151;
            // 
            // btnchon
            // 
            this.btnchon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnchon.BackgroundImage")));
            this.btnchon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnchon.FlatAppearance.BorderSize = 0;
            this.btnchon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnchon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnchon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchon.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnchon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnchon.Location = new System.Drawing.Point(675, 3);
            this.btnchon.Margin = new System.Windows.Forms.Padding(4);
            this.btnchon.Name = "btnchon";
            this.btnchon.Size = new System.Drawing.Size(98, 41);
            this.btnchon.TabIndex = 150;
            this.btnchon.Text = "Report";
            this.btnchon.UseVisualStyleBackColor = true;
            this.btnchon.Click += new System.EventHandler(this.btnchon_Click);
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.BackColor = System.Drawing.Color.Transparent;
            this.lblMaNV.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMaNV.Location = new System.Drawing.Point(24, 21);
            this.lblMaNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(142, 25);
            this.lblMaNV.TabIndex = 149;
            this.lblMaNV.Text = "Mã nhân viên";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sp_LuongCBBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.sp_SoCongBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.sp_ThuongBindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.sp_ThueBindingSource;
            reportDataSource5.Name = "DataSet5";
            reportDataSource5.Value = this.sp_BaoHiemBindingSource;
            reportDataSource6.Name = "DataSet6";
            reportDataSource6.Value = this.sp_PhatBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhanSuFPT_PhamThiTuyetLan.TTPhieuLuongNV.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 65);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1199, 729);
            this.reportViewer1.TabIndex = 153;
            // 
            // sp_LuongCBTableAdapter
            // 
            this.sp_LuongCBTableAdapter.ClearBeforeFill = true;
            // 
            // sp_SoCongTableAdapter
            // 
            this.sp_SoCongTableAdapter.ClearBeforeFill = true;
            // 
            // sp_ThuongTableAdapter
            // 
            this.sp_ThuongTableAdapter.ClearBeforeFill = true;
            // 
            // sp_ThueTableAdapter
            // 
            this.sp_ThueTableAdapter.ClearBeforeFill = true;
            // 
            // sp_BaoHiemTableAdapter
            // 
            this.sp_BaoHiemTableAdapter.ClearBeforeFill = true;
            // 
            // sp_PhatTableAdapter
            // 
            this.sp_PhatTableAdapter.ClearBeforeFill = true;
            // 
            // rpPhieuLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 806);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dtp_ngay);
            this.Controls.Add(this.cbomaNV);
            this.Controls.Add(this.btnchon);
            this.Controls.Add(this.lblMaNV);
            this.Name = "rpPhieuLuong";
            this.Text = "rpPhieuLuong";
            this.Load += new System.EventHandler(this.rpPhieuLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_LuongCBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_SoCongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ThuongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ThueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_BaoHiemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_PhatBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_ngay;
        private System.Windows.Forms.ComboBox cbomaNV;
        private System.Windows.Forms.Button btnchon;
        private System.Windows.Forms.Label lblMaNV;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_LuongCBBindingSource;
        private TN_QuanLyNhanSuDataSet TN_QuanLyNhanSuDataSet;
        private System.Windows.Forms.BindingSource sp_SoCongBindingSource;
        private System.Windows.Forms.BindingSource sp_ThuongBindingSource;
        private System.Windows.Forms.BindingSource sp_ThueBindingSource;
        private System.Windows.Forms.BindingSource sp_BaoHiemBindingSource;
        private System.Windows.Forms.BindingSource sp_PhatBindingSource;
        private TN_QuanLyNhanSuDataSetTableAdapters.sp_LuongCBTableAdapter sp_LuongCBTableAdapter;
        private TN_QuanLyNhanSuDataSetTableAdapters.sp_SoCongTableAdapter sp_SoCongTableAdapter;
        private TN_QuanLyNhanSuDataSetTableAdapters.sp_ThuongTableAdapter sp_ThuongTableAdapter;
        private TN_QuanLyNhanSuDataSetTableAdapters.sp_ThueTableAdapter sp_ThueTableAdapter;
        private TN_QuanLyNhanSuDataSetTableAdapters.sp_BaoHiemTableAdapter sp_BaoHiemTableAdapter;
        private TN_QuanLyNhanSuDataSetTableAdapters.sp_PhatTableAdapter sp_PhatTableAdapter;
    }
}