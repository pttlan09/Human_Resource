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
/// <summary>
/// test ne
/// </summary>
namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class FBoPhan : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        public FBoPhan()
        {
            InitializeComponent();
            LoadData();
            dateTimePickerNgayThanhLap.Format = DateTimePickerFormat.Custom;
            dateTimePickerNgayThanhLap.CustomFormat = "dd/MM/yyyy";
        }
        private void LoadData()
        {
            var sql = "Select MaBP,TenBP,NgayTL,GhiChu  from tblBoPhan  ";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();

            // Xóa dữ liệu cũ trong datagridview
            dgv.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview

            while (dr.Read())
            {
                var i = dgv.Rows.Add();
                var row = dgv.Rows[i];
                row.Cells["MaBP"].Value = dr["MaBP"];
                row.Cells["TenBP"].Value = dr["TenBP"];
                row.Cells["NgayTL"].Value = dr["NgayTL"];
                row.Cells["GhiChu"].Value = dr["GhiChu"];
               
            }
            dr.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtMaBP.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaBP.Focus();
                    return;
                }
                if (txtTenBP.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenBP.Focus();
                    return;
                }

               
                var MaBP = dgv.SelectedRows[0].Cells["MaBP"].Value.ToString();
                var sql = "UPDATE tblBoPhan SET TenBP = @TenBP ,NgayTL = @NgayTL ,GhiChu = @GhiChu WHERE MaBP = @MaBP";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaBP", MaBP);
                cmd.Parameters.AddWithValue("TenBP", txtTenBP.Text);
                cmd.Parameters.AddWithValue("NgayTL", dateTimePickerNgayThanhLap.Value);
                cmd.Parameters.AddWithValue("GhiChu", txtghichu.Text);
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
                if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var MaBP = dgv.SelectedRows[0].Cells["MaBP"].Value.ToString();
                    var sql = "DELETE tblBoPhan WHERE MaBP = @MaBP";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("MaBP", MaBP);
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
                if (txtMaBP.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaBP.Focus();
                    return;
                }
                if (txtTenBP.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenBP.Focus();
                    return;
                }
                var sql = "insert into tblBoPhan(MaBP,TenBP,NgayTL,GhiChu) values (@MaBP,@TenBP,@NgayTL,@GhiChu)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaBP", txtMaBP.Text);
                cmd.Parameters.AddWithValue("TenBP", txtTenBP.Text);
                cmd.Parameters.AddWithValue("NgayTL", dateTimePickerNgayThanhLap.Value);
                cmd.Parameters.AddWithValue("GhiChu", txtghichu.Text);
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
                    MessageBox.Show("Mã bộ phận đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            txtMaBP.ReadOnly = false;
            txtMaBP.Clear();
            txtTenBP.Clear();
            dateTimePickerNgayThanhLap.ResetText();
            txtghichu.Clear();
            txtMaBP.Focus();

            txt_timkiem.Clear();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaBP.Text = dgv.SelectedRows[0].Cells["MaBP"].Value.ToString();
            txtMaBP.ReadOnly = true; // không cho sửa mã
            txtTenBP.Text = dgv.SelectedRows[0].Cells["TenBP"].Value.ToString();
            dateTimePickerNgayThanhLap.Text = dgv.SelectedRows[0].Cells["NgayTL"].Value.ToString();
            txtghichu.Text = dgv.SelectedRows[0].Cells["GhiChu"].Value.ToString();

        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }
        public void loadgridkeyword()
        {
            string str = "Select* from tblBoPhan where MaBP like'%" + txt_timkiem.Text + "%' or TenBP like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }
    }
}
