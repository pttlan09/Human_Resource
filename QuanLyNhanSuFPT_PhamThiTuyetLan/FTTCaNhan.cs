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
//using System.Collections.Generic;
using AForge;
using AForge.Video;
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class FTTCaNhan : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = GS-LANPTT13\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;
        

        ClassKetNoi data = new ClassKetNoi();
        public FTTCaNhan()
        {
            InitializeComponent();
        }
        public static string Quyen;
        private void FTTCaNhan_Load(object sender, EventArgs e)
        {
            
            lblMa.Text = ClassKetNoi.manhanvien;
           
            Load_data();
        }
        private void Load_data()
        {
            if (lblMa.Text == "admin")
            {
                lblten.Text = "Admin";
                lblemail.Text = "";
                lblbp.Text = "";
                lblpb.Text = "";
                lbltinhtrang.Text = "";
            }
            else
            {
                string sql = "select * from tblQTLamViec";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                //while (dr.Read())
                //{
                //    cbMaNV.Items.Add(dr["MaNV"]);
                //}
                conn.Close();
                //
                cmd = new SqlCommand("Select tblQTLamViec.MaNV, TenNV, Email, tblBoPhan.TenBP, tblPhongBan.TenPB from tblQTLamViec , tblBoPhan, tblPhongBan where MaNV = @MaNV and tblQTlamViec.MaBP = tblBoPhan.MaBP and tblQTlamViec.MaPB = tblPhongBan.MaPB ", conn);
                cmd.Parameters.AddWithValue("@MaNV", lblMa.Text);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string TenNV = dr["TenNV"].ToString();
                    string Email = dr["Email"].ToString();
                    string bophan = dr["TenBP"].ToString();
                    string phongban = dr["TenPB"].ToString();
                   // string TinhTrang = dr["SoNgayHetHan"].ToString();

                    //int so = SoNgayHetHan;
                    lblten.Text = TenNV;
                    lblemail.Text = Email;
                    lblbp.Text = bophan;
                    lblpb.Text = phongban;
                    lbltinhtrang.Text = "Đang làm việc";
                      
                   
                }
                conn.Close();
                 
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtPWCu.Text == "" || txtPWMoi.Text == "" || txtPW1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                if(txtPWCu.Text == ClassKetNoi.matkhau)
                {
                    if (txtPWMoi.Text == txtPW1.Text)
                    {
                        string mkmoi = txtPWMoi.Text;
                        data.ExecuteNonQuery("update tblTaiKhoan set MatKhau=N'" + mkmoi + "'where TenDangNhap='" + lblMa.Text + "'");
                        MessageBox.Show("Đổi mật khẩu thành công");
                        txtPWCu.Clear();
                        txtPWMoi.Clear();
                        txtPW1.Clear();

                    }
                    else MessageBox.Show("Mật khẩu mới phải giống nhau");
                }
                else MessageBox.Show("Sai mật khẩu cũ");
              
            }
        }

        private void txtPW1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnDoiMatKhau.PerformClick();
            }   
        }
    }
}
