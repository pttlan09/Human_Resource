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
    public partial class FKhenThuong : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        public FKhenThuong()
        {
            InitializeComponent();
            dateTimePickerNgayThuong.Format = DateTimePickerFormat.Custom;
            dateTimePickerNgayThuong.CustomFormat = "dd/MM/yyyy";
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
            var sql = "Select MaNV,NgayThuong,TienThuong,LyDo from tblKhenThuong order by NgayThuong desc  ";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();

            // Xóa dữ liệu cũ trong datagridview
            dgv.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview

            while (dr.Read())
            {
                var i = dgv.Rows.Add();
                var row = dgv.Rows[i];
                row.Cells["MaNV"].Value = dr["MaNV"];
                row.Cells["NgayThuong"].Value = dr["NgayThuong"];
                row.Cells["TienThuong"].Value = dr["TienThuong"];
                row.Cells["LyDo"].Value = dr["LyDo"];

            }

            dr.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTienThuong.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTienThuong.Focus();
                    return;
                }

                if (txtlydo.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtlydo.Focus();
                    return;
                }

                var MaNV = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
                var sql = "UPDATE tblKhenThuong SET NgayThuong=@NgayThuong, TienThuong = @TienThuong ,LyDo = @LyDo  WHERE MaNV = @MaNV ";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                cmd.Parameters.AddWithValue("NgayThuong", dateTimePickerNgayThuong.Value);
                cmd.Parameters.AddWithValue("TienThuong", txtTienThuong.Text);
                cmd.Parameters.AddWithValue("LyDo", txtlydo.Text);
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
                if (MessageBox.Show("Bạn có thật sự muốn thông tin này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var MaNV = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
                    var sql = "DELETE tblKhenThuong WHERE MaNV = @MaNV";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("MaNV", MaNV);
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
                if (txtTienThuong.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTienThuong.Focus();
                    return;
                }

                if (txtlydo.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtlydo.Focus();
                    return;
                }
                var sql = "insert into tblKhenThuong(MaNV,NgayThuong,TienThuong,LyDo) values (@MaNV,@NgayThuong,@TienThuong,@LyDo)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", cboMaNv.Text);
                cmd.Parameters.AddWithValue("NgayThuong", dateTimePickerNgayThuong.Value);
                cmd.Parameters.AddWithValue("TienThuong",txtTienThuong.Text);
                cmd.Parameters.AddWithValue("LyDo", txtlydo.Text);

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
                    MessageBox.Show("Thông tin này đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            // txtMaHD.ReadOnly = false;
            txtTienThuong.Clear();
            cboMaNv.SelectedIndex = -1;

            dateTimePickerNgayThuong.ResetText();
            txtlydo.Clear();
             

            txt_timkiem.Clear();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTienThuong.Text = dgv.SelectedRows[0].Cells["TienThuong"].Value.ToString();
            cboMaNv.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
            dateTimePickerNgayThuong.Text = dgv.SelectedRows[0].Cells["NgayThuong"].Value.ToString();
            txtlydo.Text = dgv.SelectedRows[0].Cells["LyDo"].Value.ToString();
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }
        public void loadgridkeyword()
        {
            string str = "Select* from tblKhenThuong where MaNV like'%" + txt_timkiem.Text + "%' or NgayThuong like'%" + txt_timkiem.Text  + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }
    }
}
