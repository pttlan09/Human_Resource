
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AForge.Video;
using AForge;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;
using System.Diagnostics;

namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class FrmLogin : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = GS-LANPTT13\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;

        ClassKetNoi data = new ClassKetNoi();
        public FrmLogin()
        {
            InitializeComponent();
            //  LoadData();
        }

        //thêm camera
        
        FilterInfoCollection filterInfoCollection;
         VideoCaptureDevice captureDevice;
    
        private void captureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pic.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            captureDevice.NewFrame += captureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();

            string str = "Select * From tblTaiKhoan where TenDangNhap='" + txtuser.Text + "' and MatKhau='" + txtpass.Text + "'";
            SqlCommand cm = new SqlCommand(str, data.getConnect());
            SqlDataReader reader = cm.ExecuteReader();
            if (reader.Read())
            {
                if (txtuser.Text == reader.GetString(0).Trim() && txtpass.Text == reader.GetString(1).Trim())
                {
                    ClassKetNoi.manhanvien = txtuser.Text;
                    ClassKetNoi.matkhau = txtpass.Text;

                    //FrmMain.TenNV= data.ExcuteQuery("Select tblNhanVien.TenNV from tblNhanVien,tblTaiKhoan where tblNhanVien.MaNV='" + txtuser.Text +  "'").Rows[0][0].ToString().Trim();

                    FrmMain.Quyen = data.ExcuteQuery("Select Quyen from tblTaiKhoan where TenDangNhap='" + txtuser.Text + "'and MatKhau='" + txtpass.Text + "'").Rows[0][0].ToString().Trim();
                    FrmMain f = new FrmMain();
                    this.Hide();
                    f.ShowDialog();

                    rpPhieuLuong.Quyen = data.ExcuteQuery("Select Quyen from tblTaiKhoan where TenDangNhap='" + txtuser.Text + "'and MatKhau='" + txtpass.Text + "'").Rows[0][0].ToString().Trim();
                    rpPhieuLuong luong = new rpPhieuLuong();
                   

                    FTTCaNhan.Quyen = data.ExcuteQuery("Select Quyen from tblTaiKhoan where TenDangNhap='" + txtuser.Text + "'and MatKhau='" + txtpass.Text + "'").Rows[0][0].ToString().Trim();
                    FTTCaNhan canhan = new FTTCaNhan();
                    

                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }


        }


        private void btn_eye_Click(object sender, EventArgs e)
        {


            if (txtpass.PasswordChar == '\0')
            {
                btn_eye.BringToFront();
                txtpass.PasswordChar = '*';
            }
        }

        private void btn_hide_Click(object sender, EventArgs e)
        {
            if (txtpass.PasswordChar == '*')
            {
                btn_hide.BringToFront();
                txtpass.PasswordChar = '\0';
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
         
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                comboBox1.Items.Add(filterInfo.Name);
            comboBox1.SelectedIndex = 0;
            //  captureDevice.Start();

        }
        //03.11 
        //private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //
        //    if (captureDevice.IsRunning)
        //     captureDevice.Stop();
            
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pic.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pic.Image);
                if(result !=null)
                {
                    txtuser.Text = result.ToString();
                    timer1.Stop();
                    if (captureDevice.IsRunning)
                        captureDevice.Stop();
                }    
            }
            cmd = new SqlCommand("Select * from tblTaiKhoan where  TenDangNhap=@TenDangNhap", conn);
            cmd.Parameters.AddWithValue("@TenDangNhap", txtuser.Text);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string MatKhau = dr["MatKhau"].ToString();
                txtpass.Text = MatKhau;
                
            }
            conn.Close();


        }

        private void txtuser_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
        }

        private void txtpass_Click(object sender, EventArgs e)
        {
            txtpass.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string url = "https://sites.google.com/view/kltn-quanlynhansu/trang-ch%E1%BB%A7"; // URL cần được mở trên trình duyệt.


            Process.Start(url); // Thực hiện mở URL trên trình duyệt.
        }



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
        //    //captureDevice.NewFrame += captureDevice_NewFrame;
        //    //captureDevice.Start();
        //    //timer1.Start();
        //}
    }
}
