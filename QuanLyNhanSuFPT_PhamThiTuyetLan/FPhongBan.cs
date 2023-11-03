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
    public partial class FPhongBan : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = GS-LANPTT13\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;

        ClassKetNoi data = new ClassKetNoi();
        public FPhongBan()
        {
            InitializeComponent();

            string bophan = "Select  TenBP,MaBP from tblBoPhan";
            SqlDataAdapter da1 = new SqlDataAdapter(bophan, data.getConnect());
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbbophan.DataSource = dt1;
            cbbophan.DisplayMember = "MaBP";
            ///cbbophan.ValueMember = "MaBP";

            LoadData();
        }
        private void LoadData()
        {
            var sql = "Select MaBP,MaPB,TenPB,SDT,GhiChu  from tblPhongBan  ";
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
                row.Cells["MaPB"].Value = dr["MaPB"];
                row.Cells["TenPB"].Value = dr["TenPB"];
                row.Cells["SDT"].Value = dr["SDT"];
                row.Cells["GhiChu"].Value = dr["GhiChu"];

            }
            dr.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaPB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPB.Focus();
                    return;
                }

                if (txtTenPB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenPB.Focus();
                    return;
                }
                if (txtSDT.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                var MaPB = dgv.SelectedRows[0].Cells["MaPB"].Value.ToString();
                var sql = "UPDATE tblPhongBan SET MaBP=@MaBP,TenPB = @TenBP ,SDT = @SDT ,GhiChu = @GhiChu WHERE MaPB = @MaPB";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaPB", MaPB);
                cmd.Parameters.AddWithValue("MaBP", cbbophan.Text);
                cmd.Parameters.AddWithValue("TenBP", txtTenPB.Text);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
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
                if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var MaPB = dgv.SelectedRows[0].Cells["MaPB"].Value.ToString();
                    var sql = "DELETE tblPhongBan WHERE MaPB = @MaPB";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("MaPB", MaPB);
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
                if (txtMaPB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPB.Focus();
                    return;
                }

                if (txtTenPB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenPB.Focus();
                    return;
                }
                if (txtSDT.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }

                var sql = "insert into tblPhongBan(MaBP,MaPB,TenPB,SDT,GhiChu) values (@MaBP,@MaPB,@TenPB,@SDT,@GhiChu)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaBP", cbbophan.Text);
                cmd.Parameters.AddWithValue("MaPB", txtMaPB.Text);
                cmd.Parameters.AddWithValue("TenPB", txtTenPB.Text);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
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
                    MessageBox.Show("Phòng ban đã tồn lại thông tin ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            cbbophan.Enabled = true;
            txtMaPB.Enabled = true;
            cbbophan.SelectedIndex = -1;
            txtMaPB.Clear();
            txtTenPB.Clear();
            txtSDT.Clear();
            txtghichu.Clear();

            cbbophan.Focus();

            txt_timkiem.Clear();
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }
        public void loadgridkeyword()
        {
            string str = "Select* from tblPhongBan where MaBP like'%" + txt_timkiem.Text + "%' or MaPB like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cbbophan.Text = dgv.SelectedRows[0].Cells["MaBP"].Value.ToString();
            txtMaPB.Enabled = false; // không cho sửa mã
            this.cbbophan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            txtMaPB.Text = dgv.SelectedRows[0].Cells["MaPB"].Value.ToString();
            txtTenPB.Text = dgv.SelectedRows[0].Cells["TenPB"].Value.ToString();
            txtSDT.Text = dgv.SelectedRows[0].Cells["SDT"].Value.ToString();
            txtghichu.Text = dgv.SelectedRows[0].Cells["GhiChu"].Value.ToString();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void FPhongBan_Load(object sender, EventArgs e)
        {

        }
    }
}
