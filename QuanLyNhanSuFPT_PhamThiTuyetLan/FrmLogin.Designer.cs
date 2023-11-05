
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    partial class FrmLogin
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
            this.btnlogin = new System.Windows.Forms.Button();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.chkghinho = new System.Windows.Forms.CheckBox();
            this.btn_eye = new System.Windows.Forms.Button();
            this.btn_hide = new System.Windows.Forms.Button();
            this.pic = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.DarkOrange;
            this.btnlogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(691, 399);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(183, 46);
            this.btnlogin.TabIndex = 0;
            this.btnlogin.Text = "Đăng nhập";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtuser.Location = new System.Drawing.Point(611, 187);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(299, 30);
            this.txtuser.TabIndex = 3;
            this.txtuser.Text = "Tên đăng nhập";
            this.txtuser.Click += new System.EventHandler(this.txtuser_Click);
            // 
            // txtpass
            // 
            this.txtpass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtpass.Location = new System.Drawing.Point(611, 270);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(299, 30);
            this.txtpass.TabIndex = 4;
            this.txtpass.Text = "Mật khẩu";
            this.txtpass.Click += new System.EventHandler(this.txtpass_Click);
            this.txtpass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpass_KeyDown);
            // 
            // chkghinho
            // 
            this.chkghinho.AutoSize = true;
            this.chkghinho.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkghinho.Location = new System.Drawing.Point(611, 340);
            this.chkghinho.Name = "chkghinho";
            this.chkghinho.Size = new System.Drawing.Size(169, 26);
            this.chkghinho.TabIndex = 5;
            this.chkghinho.Text = "Ghi nhớ mật khẩu";
            this.chkghinho.UseVisualStyleBackColor = true;
            // 
            // btn_eye
            // 
            this.btn_eye.Image = global::QuanLyNhanSuFPT_PhamThiTuyetLan.Properties.Resources._39170522;
            this.btn_eye.Location = new System.Drawing.Point(916, 268);
            this.btn_eye.Name = "btn_eye";
            this.btn_eye.Size = new System.Drawing.Size(34, 30);
            this.btn_eye.TabIndex = 9;
            this.btn_eye.UseVisualStyleBackColor = true;
            this.btn_eye.Click += new System.EventHandler(this.btn_hide_Click);
            // 
            // btn_hide
            // 
            this.btn_hide.Image = global::QuanLyNhanSuFPT_PhamThiTuyetLan.Properties.Resources.unhide3;
            this.btn_hide.Location = new System.Drawing.Point(916, 268);
            this.btn_hide.Name = "btn_hide";
            this.btn_hide.Size = new System.Drawing.Size(34, 30);
            this.btn_hide.TabIndex = 8;
            this.btn_hide.UseVisualStyleBackColor = true;
            this.btn_hide.Click += new System.EventHandler(this.btn_eye_Click);
            // 
            // pic
            // 
            this.pic.Location = new System.Drawing.Point(638, 12);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(224, 150);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 11;
            this.pic.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(868, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(42, 24);
            this.comboBox1.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(652, 512);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cơ hội việc làm tại FIS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::QuanLyNhanSuFPT_PhamThiTuyetLan.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1001, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.btn_eye);
            this.Controls.Add(this.btn_hide);
            this.Controls.Add(this.chkghinho);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.btnlogin);
            this.DoubleBuffered = true;
            this.Name = "FrmLogin";
            this.Text = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.CheckBox chkghinho;
        private System.Windows.Forms.Button btn_hide;
        private System.Windows.Forms.Button btn_eye;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}