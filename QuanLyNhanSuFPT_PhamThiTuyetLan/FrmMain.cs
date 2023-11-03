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
    public partial class FrmMain : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = GS-LANPTT13\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;

        ClassKetNoi data = new ClassKetNoi();
        public FrmMain()
        {
            InitializeComponent();
            custimizeDesing();
        }
        private void custimizeDesing()
        {
            panelnhansu.Visible = false;
            panelquanly.Visible = false;
            panelchedo.Visible = false;
            panelchinhsach.Visible = false;
            panelLuong.Visible = false;
            panelbaocao.Visible = false;

        }
        private void hidesubmenu()
        {
            if (panelnhansu.Visible == true)
                panelnhansu.Visible = false;
            if (panelquanly.Visible == true)
                panelquanly.Visible = false;
            if (panelchedo.Visible == true)
                panelchedo.Visible = false;
            if (panelchinhsach.Visible == true)
                panelchinhsach.Visible = false;
            if (panelLuong.Visible == true)
                panelLuong.Visible = false;
            if (panelbaocao.Visible == true)
                panelbaocao.Visible = false;

        }

        private void  showsubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hidesubmenu();
                submenu.Visible = true;

            }
            else
                submenu.Visible = false;
        }

        public static string Quyen;
        private void Load_data()
        {
            timer1.Start();
            lbltime.Text = DateTime.Now.ToLongTimeString();
            if (lbluser.Text == "admin")
            {
                lblten.Text = "Admin";
            }
            else
            {
                string sql = "select * from tblLyLichNhanVien";
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                //while (dr.Read())
                //{
                //    cbMaNV.Items.Add(dr["MaNV"]);
                //}
                conn.Close();
                //
                cmd = new SqlCommand("Select * from tblLyLichNhanVien where  MaNV=@MaNV", conn);
                cmd.Parameters.AddWithValue("@MaNV", lbluser.Text);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string TenNV = dr["TenNV"].ToString();
                    lblten.Text = TenNV;
                   // txtEmail.Text = Email;
                }
                conn.Close();
                
            }
        }

        // xử lí mở form con
        private Form activeform = null;
        private void openChildForm(Form childForm)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelControl.Controls.Add(childForm);
            panelControl.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

       
        private void FrmMain_Load(object sender, EventArgs e)
        {

            lblquyen.Text = Quyen;
            if (lblquyen.Text == "Nhân viên")
            {
                btnnhansu.Visible = false;
                btnchedo.Visible = false;
                btnChinhsach.Visible = false;
                btnquanly.Visible = false;
                btnchamcong.Visible = false;
                btnreport.Visible = false;
            }
                lbluser.Text = ClassKetNoi.manhanvien;
            Load_data();
        }

        private void btnnhansu_Click(object sender, EventArgs e)
        {
            showsubmenu(panelnhansu);

            //FrmNhanVien nv = new FrmNhanVien();
            //nv.ShowDialog();
            //this.Show();

           // ActivateButton(sender);
           // openChildForm(new FrmNhanVien());
        }


        private void btnLLNV_Click(object sender, EventArgs e)
        {
            openChildForm(new FLyLichNV());
        }

        private void btnQTLV_Click(object sender, EventArgs e)
        {
            openChildForm(new FQTLamViec());
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            openChildForm(new FHopDong());
        }

        private void btnThanNhan_Click(object sender, EventArgs e)
        {
            openChildForm(new FThanNhan());

        }

        private void btnquanly_Click(object sender, EventArgs e)
        {
            showsubmenu(panelquanly);
        }

        private void btnbophan_Click(object sender, EventArgs e)
        {
            openChildForm(new FBoPhan());
        }

        private void btnphongban_Click(object sender, EventArgs e)
        {
            openChildForm(new FPhongBan());
        }

        private void btncapbac_Click(object sender, EventArgs e)
        {
            openChildForm(new FCapBac());
        }

        private void btntaikhoan_Click(object sender, EventArgs e)
        {
            openChildForm(new FTaiKhoan());
        }

        private void btnchedo_Click_1(object sender, EventArgs e)
        { showsubmenu(panelnhansu);
            showsubmenu(panelchedo);
        }

        private void btnChinhsach_Click(object sender, EventArgs e)
        {
            showsubmenu(panelchinhsach);
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            showsubmenu(panelLuong);
        }

        private void btnDuLieu_Click(object sender, EventArgs e)
        {
            openChildForm(new FDatabase());
        }

        private void btnchamcong_Click(object sender, EventArgs e)
        {
            openChildForm(new FTongHopCong());
        }

        private void btnnguoidung_Click(object sender, EventArgs e)
        {
            openChildForm(new FTTCaNhan());
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //FrmLogin f = new FrmLogin();
            //f.ShowDialog();
            //this.Show();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard());
        }

        private void btnkhenthuong_Click(object sender, EventArgs e)
        {
            openChildForm(new FKhenThuong());
        }

        private void btnphat_Click(object sender, EventArgs e)
        {
            openChildForm(new FPhat());
        }

        private void btnbaohiem_Click(object sender, EventArgs e)
        {
            openChildForm(new FBaoHiem());
        }

        private void btnthue_Click(object sender, EventArgs e)
        {
            openChildForm(new FThue());
        }

        private void btnthaisan_Click(object sender, EventArgs e)
        {
            openChildForm(new FThaiSan());
        }

        private void btnTTluong_Click(object sender, EventArgs e)
        {
            openChildForm(new rpPhieuLuong());
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            showsubmenu(panelbaocao);
        }

        private void btnDSNghiViec_Click(object sender, EventArgs e)
        {
            openChildForm(new rpNghiViec());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new rpCanhbaohethan());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new ReportNhanVienPB());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new rpChamCongThang());
        }

        private void btnNPT_Click(object sender, EventArgs e)
        {

            openChildForm(new FNguoiPhuThuoc());
        }
    }
}
