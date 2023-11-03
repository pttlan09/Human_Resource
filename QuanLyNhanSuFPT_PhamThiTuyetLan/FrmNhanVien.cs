using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class FrmNhanVien : Form
    {




        SqlConnection strConn = new SqlConnection(@"Data Source=MSLAN\SQLEXPRESS;Initial Catalog=KLTN_QuanLyNhanSu;Integrated Security=True");
        //SqlCommand cmd;
        ClassKetNoi data = new ClassKetNoi();
        //String imgLoc = "";
        public FrmNhanVien()
        {
            InitializeComponent();
            LoadData();
            picEmp.Image = null;

        }
        public static string Quyen;
        //private object fileMode;

        private void LoadData()
        {

            dateTimePickerngaysinh.CustomFormat = " MM / dd / yyyy ";
            dateTimePickerngayvaolam.CustomFormat = " MM / dd / yyyy ";

            string sql = "Select * from tblLyLichNhanVien  ";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();

            //Xóa dữ liệu cũ trong datagridview
            // dgvNhanVien.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview
            //while (dr.Read())
            //{
            //   var i = dgvNhanVien.Rows.Add();
            //    var row = dgvNhanVien.Rows[i];
            //    row.Cells["MaNV"].Value = dr["MaNV"];
            //    row.Cells["TenNV"].Value = dr["TenNV"];
            //    row.Cells["NgaySinh"].Value = dr["NgaySinh"];
            //    row.Cells["GioiTinh"].Value = dr["GioiTinh"];
            //    row.Cells["DanToc"].Value = dr["DanToc"];
            //    row.Cells["CMND_CCCD"].Value = dr["CMND_CCCD"];
            //    row.Cells["Email"].Value = dr["Email"];
            //    row.Cells["DiaChi"].Value = dr["DiaChi"];

            //    row.Cells["SDT"].Value = dr["SDT"];
            //    row.Cells["Hinh"].Value = dr["Hinh"];

            //}
            //dr.Close();
            string str = "Select * from tblLyLichNhanVien   ";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhanVien.DataSource = dt;

            //string bophan = "Select  MaBP from tblBoPhan";
            //SqlDataAdapter da1 = new SqlDataAdapter(bophan, data.getConnect());
            //DataTable dt1 = new DataTable();
            //da1.Fill(dt1);
            //cbomabophan.DataSource = dt1;
            //cbomabophan.DisplayMember = "MaBP";
            //////this.aREATableAdapter.Fill(this.wATERandPOWERDataSet.AREA);

            //string pb = "Select  MaPB from tblPhongBan";
            //SqlDataAdapter da2 = new SqlDataAdapter(pb, data.getConnect());
            //DataTable dt2 = new DataTable();
            //da2.Fill(dt2);
            //cbomaphong.DataSource = dt2;
            //cbomaphong.DisplayMember = "MaPB";

            //string capbac = "Select  MaCB from tblCapBac";
            //SqlDataAdapter da3 = new SqlDataAdapter(capbac, data.getConnect());
            //DataTable dt3 = new DataTable();
            //da3.Fill(dt3);
            //cbomacapbac.DataSource = dt3;
            //cbomacapbac.DisplayMember = "MaCB";
        }
        //private void FrmNhanVien_Load(object sender, EventArgs e)
        //{
        //TODO: This line of code loads data into the 'kLTN_QuanLyNhanSuDataSet.tblNhanVien' table.You can move, or remove it, as needed.
        //    this.tblNhanVienTableAdapter.Fill(this.kLTN_QuanLyNhanSuDataSet.tblNhanVien);
        //    LoadData();
        //}

        private void btnThemMoi_Click(object sender, EventArgs e)
        {

            txtMaNv.ReadOnly = false;
            txtHotenNV.Clear();
            dateTimePickerngaysinh.Text = "";
            cbogioitinh.Text = "";
            txtDanToc.Clear();
            txtCMND_CCCD.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            picEmp.Refresh();
            picEmp.Image = null;
            txtMaNv.Focus();


            LoadData();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "insert into tblNhanVien(MaNV,TenNV ,NgaySinh,GioiTinh ,DanToc ,CMND_CCCD , Email ,DiaChi,SDT,Hinh)values" +
                    "(@MaNV,@TenNv,@NgaySinh,@GioiTinh,@DanToc,@CMND_CCCD,@Email,@DiaChi,@SDT,Hinh)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", txtMaNv.Text);
                cmd.Parameters.AddWithValue("TenNv", txtHotenNV.Text);
                cmd.Parameters.AddWithValue("NgaySinh", dateTimePickerngaysinh.Value);
                cmd.Parameters.AddWithValue("GioiTinh", cbogioitinh.Text);
                cmd.Parameters.AddWithValue("DanToc", txtDanToc.Text);
                cmd.Parameters.AddWithValue("CMND_CCCD", txtCMND_CCCD.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("Hinh", txtAnhSanPham.Text);
                var kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                if (exception.HResult == -2146232060)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    private void FrmNhanVien_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kLTN_QuanLyNhanSuDataSet1.tblLyLichNhanVien' table. You can move, or remove it, as needed.
            this.tblLyLichNhanVienTableAdapter1.Fill(this.kLTN_QuanLyNhanSuDataSet1.tblLyLichNhanVien);
            // TODO: This line of code loads data into the 'kLTN_QuanLyNhanSuDataSet.tblLyLichNhanVien' table. You can move, or remove it, as needed.
         //   this.tblLyLichNhanVienTableAdapter.Fill(this.kLTN_QuanLyNhanSuDataSet.tblLyLichNhanVien);

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Choose Image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;*.bmp;|All Files|*.*";
            ofd.ShowDialog();
            txtAnhSanPham.Text = ofd.FileName;
            if (txtAnhSanPham.Text != "")
                picEmp.Image = Image.FromFile(txtAnhSanPham.Text);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNv.Text = dgvNhanVien.SelectedRows[0].Cells["MaNV"].Value.ToString();
            txtMaNv.ReadOnly = true; // không cho sửa mã
            txtHotenNV.Text = dgvNhanVien.SelectedRows[0].Cells["TenNV"].Value.ToString();
            dateTimePickerngaysinh.Text = dgvNhanVien.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
            cbogioitinh.Text = dgvNhanVien.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
            txtDanToc.Text = dgvNhanVien.SelectedRows[0].Cells["DanToc"].Value.ToString();
            txtCMND_CCCD.Text = dgvNhanVien.SelectedRows[0].Cells["CMND_CCCD"].Value.ToString();
            txtEmail.Text = dgvNhanVien.SelectedRows[0].Cells["Email"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.SelectedRows[0].Cells["DiaChi"].Value.ToString();

            txtSDT.Text = dgvNhanVien.SelectedRows[0].Cells["SDT"].Value.ToString();
            txtAnhSanPham.Text = dgvNhanVien.SelectedRows[0].Cells["Hinh"].Value.ToString();

            ////Chọn giá trị combobox Tình trạng nếu giá trị combobox = giá trị lưu trong csdl
            //foreach (var item in cbTinhTrang.Items)
            //    if ((string)item == dgv.SelectedRows[0].Cells["TinhTrang"].Value.ToString())
            //        cbTinhTrang.SelectedItem = item;

            ////đặt ngày theo dữ liệu trong csdl
            //dateNgayNhap.Value = DateTime.ParseExact(
            //    dgv.SelectedRows[0].Cells["NgayNhap"].Value.ToString(),
            //    "dd/MM/yyyy",
            //    CultureInfo.InvariantCulture);

            //load hình ảnh
            if (dgvNhanVien.SelectedRows[0].Cells["Hinh"].Value.ToString() != "")
                picEmp.Image = Image.FromFile(dgvNhanVien.SelectedRows[0].Cells["Hinh"].Value.ToString());
            else
                picEmp.Image = null;//ảnh mặc định
        }
    }
        //private void dgvNhanVien_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        //{
        //    dgvNhanVien.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        //}

      
    

}