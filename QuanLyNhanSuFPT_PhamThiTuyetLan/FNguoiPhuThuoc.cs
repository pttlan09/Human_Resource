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
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class FNguoiPhuThuoc : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = GS-LANPTT13\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;
        ClassKetNoi data = new ClassKetNoi();
        public FNguoiPhuThuoc()
        {
            InitializeComponent();
            dateTimePickerngaysinh.Format = DateTimePickerFormat.Custom;
            dateTimePickerngaysinh.CustomFormat = "dd/MM/yyyy";
            LoadData();
            string nv = "Select  a.MaNV from tblQTlamViec a inner join tblHopDong b on a.MaNV = b.MaNV where b.NgayKT >= GETDATE() group by a.MaNV order by a.MaNV asc";
            SqlDataAdapter da = new SqlDataAdapter(nv, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboMaNv.DataSource = dt;
            cboMaNv.DisplayMember = "MaNV";
        }
        private void LoadData()
        {

            var sql = "Select MaNPT,MaNV,HoTen,GioiTinh,NgaySinh,CMND_CCCD,QuanHe,SDT  from tblNguoiPhuThuoc  ";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();

            // Xóa dữ liệu cũ trong datagridview
            dgv.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview

            while (dr.Read())
            {
                var i = dgv.Rows.Add();
                var row = dgv.Rows[i];
                row.Cells["MaNPT"].Value = dr["MaNPT"];
                row.Cells["MaNV"].Value = dr["MaNV"];
                row.Cells["HoTen"].Value = dr["HoTen"];
                row.Cells["GioiTinh"].Value = dr["GioiTinh"];
                row.Cells["NgaySinh"].Value = dr["NgaySinh"];

                row.Cells["CMND_CCCD"].Value = dr["CMND_CCCD"];
                row.Cells["QuanHe"].Value = dr["QuanHe"];
                row.Cells["SDT"].Value = dr["SDT"];

            }

            dr.Close();
        }
        private void FNguoiPhuThuoc_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda=new SqlDataAdapter("select isnull(max(cast(MaNPT as int)),0)+1 from tblNguoiPhuThuoc",conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtMaNPT.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = cboMaNv;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHoten.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoten.Focus();
                    return;
                }

                if (cbogioitinh.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbogioitinh.Focus();
                    return;
                }

                var MaNPT = dgv.SelectedRows[0].Cells["MaNPT"].Value.ToString();
                var sql = "UPDATE tblNguoiPhuThuoc SET MaNV=@MaNV, HoTen = @HoTen ,NgaySinh = @NgaySinh , QuanHe = @QuanHe,GioiTinh=@GioiTinh, CMND_CCCD=@CMND_CCCD,SDT=@SDT WHERE MaNPT = @MaNPT ";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNPT", MaNPT);
                cmd.Parameters.AddWithValue("MaNV", cboMaNv.Text);
                cmd.Parameters.AddWithValue("HoTen", txtHoten.Text);
                cmd.Parameters.AddWithValue("NgaySinh", dateTimePickerngaysinh.Value);
                cmd.Parameters.AddWithValue("QuanHe", cbquanhe.Text);
                cmd.Parameters.AddWithValue("GioiTinh", cbogioitinh.Text);
                cmd.Parameters.AddWithValue("CMND_CCCD", txtCMND_CCCD.Text);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);

                var kq = cmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //hiện thông báo
                if (MessageBox.Show("Bạn có thật sự muốn thông tin này này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var MaNPT = dgv.SelectedRows[0].Cells["MaNPT"].Value.ToString();
                    var sql = "DELETE tblNguoiPhuThuoc WHERE MaNPT = @MaNPT";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("MaNPT", MaNPT);
                    var kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa dữ liệu thất bại!", "Thông báo lỗi", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHoten.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoten.Focus();
                    return;
                }

                if (cbogioitinh.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbogioitinh.Focus();
                    return;
                }

                var sql = "insert into tblNguoiPhuThuoc(MaNPT,MaNV,HoTen,GioiTinh,NgaySinh, CMND_CCCD,QuanHe,SDT) values (@MaNPT,@MaNV,@HoTen,@GioiTinh,@NgaySinh, @CMND_CCCD,@QuanHe,@SDT)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNPT", txtMaNPT.Text);
                cmd.Parameters.AddWithValue("MaNV", cboMaNv.Text);
                cmd.Parameters.AddWithValue("HoTen", txtHoten.Text);
                cmd.Parameters.AddWithValue("GioiTinh", cbogioitinh.Text);
                cmd.Parameters.AddWithValue("NgaySinh", dateTimePickerngaysinh.Value);
                cmd.Parameters.AddWithValue("CMND_CCCD", txtCMND_CCCD.Text);
                cmd.Parameters.AddWithValue("QuanHe", cbquanhe.Text);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);

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
               
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(MaNPT as int)),0)+1 from tblNguoiPhuThuoc", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtMaNPT.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = cboMaNv;
            // txtMaHD.ReadOnly = false;

            cboMaNv.SelectedIndex = -1;
            txtHoten.Clear();
            cbogioitinh.SelectedIndex = -1;

            dateTimePickerngaysinh.ResetText();
            txtCMND_CCCD.Clear();
            cbquanhe.SelectedIndex = -1;
            txtSDT.Clear();
            // txtMaTN.Focus();

            txt_timkiem.Clear();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNPT.Text = dgv.SelectedRows[0].Cells["MaNPT"].Value.ToString();
            cboMaNv.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
            txtMaNPT.Enabled = false; // không cho sửa mã
                                     //  cbMaNV.Enabled = false;
            txtHoten.Text = dgv.SelectedRows[0].Cells["HoTen"].Value.ToString();
            cbogioitinh.Text = dgv.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
            dateTimePickerngaysinh.Text = dgv.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
            txtCMND_CCCD.Text = dgv.SelectedRows[0].Cells["CMND_CCCD"].Value.ToString();

            cbquanhe.Text = dgv.SelectedRows[0].Cells["QuanHe"].Value.ToString();
            txtSDT.Text = dgv.SelectedRows[0].Cells["SDT"].Value.ToString();
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();

        }
        public void loadgridkeyword()
        {
            string str = "Select* from tblNguoiPhuThuoc where MaNV like'%" + txt_timkiem.Text + "%' or MaNPT like'%" + txt_timkiem.Text + "%'or HoTen like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }
    }
}
