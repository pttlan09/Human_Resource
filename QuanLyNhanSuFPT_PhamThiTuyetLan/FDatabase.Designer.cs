
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    partial class FDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDatabase));
            this.panelrestore = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnChonRestore = new System.Windows.Forms.Button();
            this.txtDuongDanRestore = new System.Windows.Forms.TextBox();
            this.lblDuongDanRestore = new System.Windows.Forms.Label();
            this.lblRestore = new System.Windows.Forms.Label();
            this.panelbackup = new System.Windows.Forms.Panel();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblSN = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnSaoLuu = new System.Windows.Forms.Button();
            this.btnChonBakup = new System.Windows.Forms.Button();
            this.txtDuongDanBakup = new System.Windows.Forms.TextBox();
            this.lblDuongDanBakup = new System.Windows.Forms.Label();
            this.lblBakup = new System.Windows.Forms.Label();
            this.panelrestore.SuspendLayout();
            this.panelbackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelrestore
            // 
            this.panelrestore.BackgroundImage = global::QuanLyNhanSuFPT_PhamThiTuyetLan.Properties.Resources.bg_1_;
            this.panelrestore.Controls.Add(this.textBox1);
            this.panelrestore.Controls.Add(this.label1);
            this.panelrestore.Controls.Add(this.label2);
            this.panelrestore.Controls.Add(this.btnPhucHoi);
            this.panelrestore.Controls.Add(this.btnChonRestore);
            this.panelrestore.Controls.Add(this.txtDuongDanRestore);
            this.panelrestore.Controls.Add(this.lblDuongDanRestore);
            this.panelrestore.Controls.Add(this.lblRestore);
            this.panelrestore.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelrestore.Location = new System.Drawing.Point(0, 393);
            this.panelrestore.Margin = new System.Windows.Forms.Padding(4);
            this.panelrestore.Name = "panelrestore";
            this.panelrestore.Size = new System.Drawing.Size(1223, 405);
            this.panelrestore.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox1.Location = new System.Drawing.Point(338, 167);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(378, 33);
            this.textBox1.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(172, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "Server Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(371, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "PHỤC HỒI CƠ SỞ DỮ LIỆU";
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.BackColor = System.Drawing.Color.White;
            this.btnPhucHoi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.BackgroundImage")));
            this.btnPhucHoi.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPhucHoi.Location = new System.Drawing.Point(455, 299);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(124, 51);
            this.btnPhucHoi.TabIndex = 42;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.UseVisualStyleBackColor = false;
            this.btnPhucHoi.Click += new System.EventHandler(this.btnPhucHoi_Click);
            // 
            // btnChonRestore
            // 
            this.btnChonRestore.BackColor = System.Drawing.Color.White;
            this.btnChonRestore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChonRestore.BackgroundImage")));
            this.btnChonRestore.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChonRestore.Location = new System.Drawing.Point(741, 216);
            this.btnChonRestore.Name = "btnChonRestore";
            this.btnChonRestore.Size = new System.Drawing.Size(163, 41);
            this.btnChonRestore.TabIndex = 41;
            this.btnChonRestore.Text = "Chọn";
            this.btnChonRestore.UseVisualStyleBackColor = false;
            this.btnChonRestore.Click += new System.EventHandler(this.btnChonRestore_Click);
            // 
            // txtDuongDanRestore
            // 
            this.txtDuongDanRestore.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDuongDanRestore.Location = new System.Drawing.Point(338, 221);
            this.txtDuongDanRestore.Name = "txtDuongDanRestore";
            this.txtDuongDanRestore.Size = new System.Drawing.Size(378, 33);
            this.txtDuongDanRestore.TabIndex = 40;
            // 
            // lblDuongDanRestore
            // 
            this.lblDuongDanRestore.AutoSize = true;
            this.lblDuongDanRestore.BackColor = System.Drawing.Color.Transparent;
            this.lblDuongDanRestore.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDuongDanRestore.Location = new System.Drawing.Point(172, 224);
            this.lblDuongDanRestore.Name = "lblDuongDanRestore";
            this.lblDuongDanRestore.Size = new System.Drawing.Size(109, 25);
            this.lblDuongDanRestore.TabIndex = 39;
            this.lblDuongDanRestore.Text = "Đường dẫn";
            // 
            // lblRestore
            // 
            this.lblRestore.AutoSize = true;
            this.lblRestore.BackColor = System.Drawing.Color.Transparent;
            this.lblRestore.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblRestore.Location = new System.Drawing.Point(172, 96);
            this.lblRestore.Name = "lblRestore";
            this.lblRestore.Size = new System.Drawing.Size(386, 25);
            this.lblRestore.TabIndex = 38;
            this.lblRestore.Text = "Phục hồi cơ sở dữ liệu (Restore Database)";
            // 
            // panelbackup
            // 
            this.panelbackup.BackgroundImage = global::QuanLyNhanSuFPT_PhamThiTuyetLan.Properties.Resources.background_dep_5;
            this.panelbackup.Controls.Add(this.txtServerName);
            this.panelbackup.Controls.Add(this.lblSN);
            this.panelbackup.Controls.Add(this.lblTieuDe);
            this.panelbackup.Controls.Add(this.btnSaoLuu);
            this.panelbackup.Controls.Add(this.btnChonBakup);
            this.panelbackup.Controls.Add(this.txtDuongDanBakup);
            this.panelbackup.Controls.Add(this.lblDuongDanBakup);
            this.panelbackup.Controls.Add(this.lblBakup);
            this.panelbackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbackup.Location = new System.Drawing.Point(0, 0);
            this.panelbackup.Margin = new System.Windows.Forms.Padding(4);
            this.panelbackup.Name = "panelbackup";
            this.panelbackup.Size = new System.Drawing.Size(1223, 393);
            this.panelbackup.TabIndex = 0;
            // 
            // txtServerName
            // 
            this.txtServerName.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtServerName.Location = new System.Drawing.Point(351, 175);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(378, 33);
            this.txtServerName.TabIndex = 38;
            // 
            // lblSN
            // 
            this.lblSN.AutoSize = true;
            this.lblSN.BackColor = System.Drawing.Color.Transparent;
            this.lblSN.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSN.Location = new System.Drawing.Point(185, 180);
            this.lblSN.Name = "lblSN";
            this.lblSN.Size = new System.Drawing.Size(127, 25);
            this.lblSN.TabIndex = 37;
            this.lblSN.Text = "Server Name";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTieuDe.Location = new System.Drawing.Point(315, 16);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(268, 25);
            this.lblTieuDe.TabIndex = 36;
            this.lblTieuDe.Text = "SAO LƯU CƠ SỞ DỮ LIỆU";
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.BackColor = System.Drawing.Color.White;
            this.btnSaoLuu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaoLuu.BackgroundImage")));
            this.btnSaoLuu.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSaoLuu.Location = new System.Drawing.Point(457, 313);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.Size = new System.Drawing.Size(139, 50);
            this.btnSaoLuu.TabIndex = 35;
            this.btnSaoLuu.Text = "Sao lưu";
            this.btnSaoLuu.UseVisualStyleBackColor = false;
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // btnChonBakup
            // 
            this.btnChonBakup.BackColor = System.Drawing.Color.White;
            this.btnChonBakup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChonBakup.BackgroundImage")));
            this.btnChonBakup.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChonBakup.ImageKey = "(none)";
            this.btnChonBakup.Location = new System.Drawing.Point(744, 227);
            this.btnChonBakup.Name = "btnChonBakup";
            this.btnChonBakup.Size = new System.Drawing.Size(155, 43);
            this.btnChonBakup.TabIndex = 34;
            this.btnChonBakup.Text = "Chọn";
            this.btnChonBakup.UseVisualStyleBackColor = false;
            this.btnChonBakup.Click += new System.EventHandler(this.btnChonBakup_Click);
            // 
            // txtDuongDanBakup
            // 
            this.txtDuongDanBakup.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDuongDanBakup.Location = new System.Drawing.Point(351, 233);
            this.txtDuongDanBakup.Name = "txtDuongDanBakup";
            this.txtDuongDanBakup.Size = new System.Drawing.Size(378, 33);
            this.txtDuongDanBakup.TabIndex = 33;
            // 
            // lblDuongDanBakup
            // 
            this.lblDuongDanBakup.AutoSize = true;
            this.lblDuongDanBakup.BackColor = System.Drawing.Color.Transparent;
            this.lblDuongDanBakup.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDuongDanBakup.Location = new System.Drawing.Point(183, 242);
            this.lblDuongDanBakup.Name = "lblDuongDanBakup";
            this.lblDuongDanBakup.Size = new System.Drawing.Size(109, 25);
            this.lblDuongDanBakup.TabIndex = 32;
            this.lblDuongDanBakup.Text = "Đường dẫn";
            // 
            // lblBakup
            // 
            this.lblBakup.AutoSize = true;
            this.lblBakup.BackColor = System.Drawing.Color.Transparent;
            this.lblBakup.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblBakup.Location = new System.Drawing.Point(190, 82);
            this.lblBakup.Name = "lblBakup";
            this.lblBakup.Size = new System.Drawing.Size(378, 25);
            this.lblBakup.TabIndex = 31;
            this.lblBakup.Text = "Sao lưu cơ sở dữ liệu (Backup Database)";
            // 
            // FDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 806);
            this.Controls.Add(this.panelrestore);
            this.Controls.Add(this.panelbackup);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FDatabase";
            this.panelrestore.ResumeLayout(false);
            this.panelrestore.PerformLayout();
            this.panelbackup.ResumeLayout(false);
            this.panelbackup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbackup;
        private System.Windows.Forms.Panel panelrestore;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblSN;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnSaoLuu;
        private System.Windows.Forms.Button btnChonBakup;
        private System.Windows.Forms.TextBox txtDuongDanBakup;
        private System.Windows.Forms.Label lblDuongDanBakup;
        private System.Windows.Forms.Label lblBakup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Button btnChonRestore;
        private System.Windows.Forms.TextBox txtDuongDanRestore;
        private System.Windows.Forms.Label lblDuongDanRestore;
        private System.Windows.Forms.Label lblRestore;
    }
}