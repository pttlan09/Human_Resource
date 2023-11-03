
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    partial class rpChamCongThang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpChamCongThang));
            this.sp_ChamCongTheoThangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TN_QuanLyNhanSuDataSet = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSet();
            this.dtp_ngaychotcong = new System.Windows.Forms.DateTimePicker();
            this.lblNgayChotCong = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnchon = new System.Windows.Forms.Button();
            this.sp_ChamCongTheoThangTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.sp_ChamCongTheoThangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_ChamCongTheoThangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_ChamCongTheoThangBindingSource
            // 
            this.sp_ChamCongTheoThangBindingSource.DataMember = "sp_ChamCongTheoThang";
            this.sp_ChamCongTheoThangBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // TN_QuanLyNhanSuDataSet
            // 
            this.TN_QuanLyNhanSuDataSet.DataSetName = "TN_QuanLyNhanSuDataSet";
            this.TN_QuanLyNhanSuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtp_ngaychotcong
            // 
            this.dtp_ngaychotcong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dtp_ngaychotcong.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ngaychotcong.Location = new System.Drawing.Point(214, 22);
            this.dtp_ngaychotcong.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_ngaychotcong.Name = "dtp_ngaychotcong";
            this.dtp_ngaychotcong.Size = new System.Drawing.Size(199, 33);
            this.dtp_ngaychotcong.TabIndex = 149;
            // 
            // lblNgayChotCong
            // 
            this.lblNgayChotCong.AutoSize = true;
            this.lblNgayChotCong.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayChotCong.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNgayChotCong.Location = new System.Drawing.Point(22, 28);
            this.lblNgayChotCong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayChotCong.Name = "lblNgayChotCong";
            this.lblNgayChotCong.Size = new System.Drawing.Size(79, 25);
            this.lblNgayChotCong.TabIndex = 148;
            this.lblNgayChotCong.Text = "Tháng ";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sp_ChamCongTheoThangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhanSuFPT_PhamThiTuyetLan.TTChamCongTheoThang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 68);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1187, 700);
            this.reportViewer1.TabIndex = 150;
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
            this.btnchon.Location = new System.Drawing.Point(460, 20);
            this.btnchon.Margin = new System.Windows.Forms.Padding(4);
            this.btnchon.Name = "btnchon";
            this.btnchon.Size = new System.Drawing.Size(98, 41);
            this.btnchon.TabIndex = 147;
            this.btnchon.Text = "Report";
            this.btnchon.UseVisualStyleBackColor = true;
            this.btnchon.Click += new System.EventHandler(this.btnchon_Click);
            // 
            // sp_ChamCongTheoThangTableAdapter
            // 
            this.sp_ChamCongTheoThangTableAdapter.ClearBeforeFill = true;
            // 
            // rpChamCongThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 806);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dtp_ngaychotcong);
            this.Controls.Add(this.lblNgayChotCong);
            this.Controls.Add(this.btnchon);
            this.Name = "rpChamCongThang";
            this.Text = "rpChamCongThang";
            this.Load += new System.EventHandler(this.rpChamCongThang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_ChamCongTheoThangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_ngaychotcong;
        private System.Windows.Forms.Label lblNgayChotCong;
        private System.Windows.Forms.Button btnchon;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_ChamCongTheoThangBindingSource;
        private TN_QuanLyNhanSuDataSet TN_QuanLyNhanSuDataSet;
        private TN_QuanLyNhanSuDataSetTableAdapters.sp_ChamCongTheoThangTableAdapter sp_ChamCongTheoThangTableAdapter;
    }
}