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
    public partial class FCapBac : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        public FCapBac()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            var sql = "Select MaCB,TenCB,GhiChu  from tblCapBac  ";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();

            // Xóa dữ liệu cũ trong datagridview
            dgv.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview

            while (dr.Read())
            {
                var i = dgv.Rows.Add();
                var row = dgv.Rows[i];
                row.Cells["MaCB"].Value = dr["MaCB"];
                row.Cells["TenCB"].Value = dr["TenCB"];
                row.Cells["GhiChu"].Value = dr["GhiChu"];

            }
            dr.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaCB.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaCB.Focus();
                    return;
                }
                if (txtTenCB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenCB.Focus();
                    return;
                }


                var MaCB = dgv.SelectedRows[0].Cells["MaCB"].Value.ToString();
                var sql = "UPDATE tblCapBac SET TenCB = @TenCB ,GhiChu = @GhiChu WHERE MaCB = @MaCB";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaCB", MaCB);
                cmd.Parameters.AddWithValue("TenCB", txtTenCB.Text);
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
                    var MaCB = dgv.SelectedRows[0].Cells["MaCB"].Value.ToString();
                    var sql = "DELETE tblCapBac WHERE MaCB = @MaCB";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("MaCB", MaCB);
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
                if (txtMaCB.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaCB.Focus();
                    return;
                }
                if (txtTenCB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenCB.Focus();
                    return;
                }

                var sql = "insert into tblCapBac(MaCB,TenCB,GhiChu) values (@MaCB,@TenCB,@GhiChu)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaCB", txtMaCB.Text);
                cmd.Parameters.AddWithValue("TenCB", txtTenCB.Text);
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
                    MessageBox.Show("Cấp bậc đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            txtMaCB.ReadOnly = false;
            txtMaCB.Clear();
            txtTenCB.Clear();
            txtghichu.Clear();
            txtMaCB.Focus();

            txt_timkiem.Clear();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCB.Text = dgv.SelectedRows[0].Cells["MaCB"].Value.ToString();
            txtMaCB.ReadOnly = true; // không cho sửa mã
            txtTenCB.Text = dgv.SelectedRows[0].Cells["TenCB"].Value.ToString();
            txtghichu.Text = dgv.SelectedRows[0].Cells["GhiChu"].Value.ToString();
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }
        public void loadgridkeyword()
        {
            string str = "Select* from tblCapBac where MaCB like'%" + txt_timkiem.Text + "%' or TenCB like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }
    }
}
