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
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class rpPhieuLuong : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = MSLAN\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;


        ClassKetNoi data = new ClassKetNoi();
           public static string Quyen;
        public static string quyennhanvien;
        public rpPhieuLuong()
        {
            InitializeComponent(); 
            dtp_ngay.Format = DateTimePickerFormat.Custom;
            dtp_ngay.CustomFormat = "dd/MM/yyyy";
            string nv = "Select  a.MaNV from tblQTlamViec a inner join tblHopDong b on a.MaNV = b.MaNV where b.NgayKT >= GETDATE()";
            //  string nv = "Select  MaNV from tblQTlamViec a inner join tblHopDong b on a.MaNV = b.MaNV where b.NgayKT >= GETDATE()";

            SqlDataAdapter da1 = new SqlDataAdapter(nv, data.getConnect());
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbomaNV.DataSource = dt1;
            cbomaNV.DisplayMember = "MaNV";

        }

        private void rpPhieuLuong_Load(object sender, EventArgs e)
        {

           cbomaNV.Text = ClassKetNoi.manhanvien;

            Load_data();

        }
        private void Load_data()
        {
            if (Quyen == "Nhân viên")
            {
                
                string sql = "select * from tblQTLamViec";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                cbomaNV.Enabled = false;
                conn.Close();
                cmd = new SqlCommand("Select tblQTLamViec.MaNV, TenNV, Email, tblBoPhan.TenBP, tblPhongBan.TenPB from tblQTLamViec , tblBoPhan, tblPhongBan where MaNV = @MaNV and tblQTlamViec.MaBP = tblBoPhan.MaBP and tblQTlamViec.MaPB = tblPhongBan.MaPB ", conn);
                cmd.Parameters.AddWithValue("@MaNV", cbomaNV.Text);
               
            }
           

        }
       
        private void btnchon_Click(object sender, EventArgs e)
        {  // TODO: This line of code loads data into the 'TN_QuanLyNhanSuDataSet.sp_LuongCB' table. You can move, or remove it, as needed.
            this.sp_LuongCBTableAdapter.Fill(this.TN_QuanLyNhanSuDataSet.sp_LuongCB,cbomaNV.Text);
            // TODO: This line of code loads data into the 'TN_QuanLyNhanSuDataSet.sp_SoCong' table. You can move, or remove it, as needed.
            this.sp_SoCongTableAdapter.Fill(this.TN_QuanLyNhanSuDataSet.sp_SoCong,cbomaNV.Text,dtp_ngay.Value);
            // TODO: This line of code loads data into the 'TN_QuanLyNhanSuDataSet.sp_Thuong' table. You can move, or remove it, as needed.
            this.sp_ThuongTableAdapter.Fill(this.TN_QuanLyNhanSuDataSet.sp_Thuong, cbomaNV.Text, dtp_ngay.Value);
            // TODO: This line of code loads data into the 'TN_QuanLyNhanSuDataSet.sp_Thue' table. You can move, or remove it, as needed.
            this.sp_ThueTableAdapter.Fill(this.TN_QuanLyNhanSuDataSet.sp_Thue, cbomaNV.Text, dtp_ngay.Value);
            // TODO: This line of code loads data into the 'TN_QuanLyNhanSuDataSet.sp_BaoHiem' table. You can move, or remove it, as needed.
            this.sp_BaoHiemTableAdapter.Fill(this.TN_QuanLyNhanSuDataSet.sp_BaoHiem, cbomaNV.Text, dtp_ngay.Value);
            // TODO: This line of code loads data into the 'TN_QuanLyNhanSuDataSet.sp_Phat' table. You can move, or remove it, as needed.
            this.sp_PhatTableAdapter.Fill(this.TN_QuanLyNhanSuDataSet.sp_Phat, cbomaNV.Text, dtp_ngay.Value);

            this.reportViewer1.RefreshReport();

        }
    }
}
