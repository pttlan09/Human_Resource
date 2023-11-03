
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    partial class ReportNhanVienPB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportNhanVienPB));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cbomaphong = new System.Windows.Forms.ComboBox();
            this.btnchon = new System.Windows.Forms.Button();
            this.lblMaPB = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TN_QuanLyNhanSuDataSet = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSet();
            this.sp_NhanVienPBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_NhanVienPBTableAdapter = new QuanLyNhanSuFPT_PhamThiTuyetLan.TN_QuanLyNhanSuDataSetTableAdapters.sp_NhanVienPBTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_NhanVienPBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbomaphong
            // 
            this.cbomaphong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbomaphong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbomaphong.FormattingEnabled = true;
            this.cbomaphong.Location = new System.Drawing.Point(208, 30);
            this.cbomaphong.Margin = new System.Windows.Forms.Padding(4);
            this.cbomaphong.Name = "cbomaphong";
            this.cbomaphong.Size = new System.Drawing.Size(189, 30);
            this.cbomaphong.TabIndex = 146;
            // 
            // btnchon
            // 
            this.btnchon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnchon.BackgroundImage")));
            this.btnchon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnchon.FlatAppearance.BorderSize = 0;
            this.btnchon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnchon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnchon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnchon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnchon.Location = new System.Drawing.Point(427, 19);
            this.btnchon.Margin = new System.Windows.Forms.Padding(4);
            this.btnchon.Name = "btnchon";
            this.btnchon.Size = new System.Drawing.Size(98, 41);
            this.btnchon.TabIndex = 145;
            this.btnchon.Text = "Report";
            this.btnchon.UseVisualStyleBackColor = true;
            this.btnchon.Click += new System.EventHandler(this.btnchon_Click);
            // 
            // lblMaPB
            // 
            this.lblMaPB.AutoSize = true;
            this.lblMaPB.BackColor = System.Drawing.Color.Transparent;
            this.lblMaPB.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMaPB.Location = new System.Drawing.Point(43, 31);
            this.lblMaPB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaPB.Name = "lblMaPB";
            this.lblMaPB.Size = new System.Drawing.Size(121, 22);
            this.lblMaPB.TabIndex = 144;
            this.lblMaPB.Text = "Mã phòng ban";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet";
            reportDataSource1.Value = this.sp_NhanVienPBBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyNhanSuFPT_PhamThiTuyetLan.TTNhanVienPB.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 89);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1162, 705);
            this.reportViewer1.TabIndex = 147;
            // 
            // TN_QuanLyNhanSuDataSet
            // 
            this.TN_QuanLyNhanSuDataSet.DataSetName = "TN_QuanLyNhanSuDataSet";
            this.TN_QuanLyNhanSuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_NhanVienPBBindingSource
            // 
            this.sp_NhanVienPBBindingSource.DataMember = "sp_NhanVienPB";
            this.sp_NhanVienPBBindingSource.DataSource = this.TN_QuanLyNhanSuDataSet;
            // 
            // sp_NhanVienPBTableAdapter
            // 
            this.sp_NhanVienPBTableAdapter.ClearBeforeFill = true;
            // 
            // ReportNhanVienPB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 806);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cbomaphong);
            this.Controls.Add(this.btnchon);
            this.Controls.Add(this.lblMaPB);
            this.Name = "ReportNhanVienPB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportNhanVienPB";
            this.Load += new System.EventHandler(this.ReportNhanVienPB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TN_QuanLyNhanSuDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_NhanVienPBBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbomaphong;
        private System.Windows.Forms.Button btnchon;
        private System.Windows.Forms.Label lblMaPB;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_NhanVienPBBindingSource;
        private TN_QuanLyNhanSuDataSet TN_QuanLyNhanSuDataSet;
        private TN_QuanLyNhanSuDataSetTableAdapters.sp_NhanVienPBTableAdapter sp_NhanVienPBTableAdapter;
    }
}