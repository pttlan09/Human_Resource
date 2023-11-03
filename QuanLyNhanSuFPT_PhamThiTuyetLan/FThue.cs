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
    public partial class FThue : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        public FThue()
        {
            InitializeComponent();
            LoadData();
            dateTimePickerNgayTG.Format = DateTimePickerFormat.Custom;
            dateTimePickerNgayTG.CustomFormat = "dd/MM/yyyy";

            string nv = "Select a.MaNV from tblQTlamViec a inner join tblHopDong b on a.MaNV = b.MaNV where b.NgayKT >= GETDATE()  group by a.MaNV order by MaNV asc";

            SqlDataAdapter da = new SqlDataAdapter(nv, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboMaNv.DataSource = dt;
            cboMaNv.DisplayMember = "MaNV";
        }
        private void LoadData()
        {
            var sql = "Select MaSoThue,MaNV,LoaiThue,NgayThamGia,TyLe  from tblThue  ";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();

            // Xóa dữ liệu cũ trong datagridview
            dgv.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview

            while (dr.Read())
            {
                var i = dgv.Rows.Add();
                var row = dgv.Rows[i];
                row.Cells["MaSoThue"].Value = dr["MaSoThue"];
                row.Cells["MaNV"].Value = dr["MaNV"];
                row.Cells["LoaiThue"].Value = dr["LoaiThue"];
                row.Cells["NgayThamGia"].Value = dr["NgayThamGia"];
                row.Cells["TyLe"].Value = dr["TyLe"];

            }
            dr.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaSoThue.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSoThue.Focus();
                    return;
                }

                if (txtLoaiThue.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLoaiThue.Focus();
                    return;
                }
                if (txttyle.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttyle.Focus();
                    return;
                }

                var MaSoThue = dgv.SelectedRows[0].Cells["MaSoThue"].Value.ToString();
                var sql = "UPDATE tblThue set MaNV=@MaNV, LoaiThue = @LoaiThue ,TyLe = @TyLe , NgayThamGia = @NgayThamGia WHERE MaSoThue = @MaSoThue ";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaSoThue", MaSoThue);
                cmd.Parameters.AddWithValue("MaNV", cboMaNv.Text);
                cmd.Parameters.AddWithValue("LoaiThue", txtLoaiThue.Text);
                cmd.Parameters.AddWithValue("NgayThamGia", dateTimePickerNgayTG.Value);
                cmd.Parameters.AddWithValue("TyLe", txttyle.Text);
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                var sql = "INSERT INTO tblThue ( MaSoThue,MaNV,LoaiThue,NgayThamGia,TyLe ) VALUES ( @MaSoThue,@MaNV,@LoaiThue,@NgayThamGia,@TyLe )";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaSoThue", txtMaSoThue.Text);
                cmd.Parameters.AddWithValue("MaNV", cboMaNv.Text);
                cmd.Parameters.AddWithValue("LoaiThue", txtLoaiThue.Text);
                cmd.Parameters.AddWithValue("NgayThamGia", dateTimePickerNgayTG.Value);
                cmd.Parameters.AddWithValue("TyLe", txttyle.Text);
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
                    MessageBox.Show("Thông tin đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void NhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1) e.Handled = true;
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //hiện thông báo
                if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var MaSoThue = dgv.SelectedRows[0].Cells["MaSoThue"].Value.ToString();
                    var sql = "DELETE tblThue WHERE MaSoThue = @MaSoThue";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("MaSoThue", MaSoThue);
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

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            txtMaSoThue.ReadOnly = false;
            txtMaSoThue.Clear();
            txtMaSoThue.Enabled = true;
            cboMaNv.Enabled = true;
            cboMaNv.SelectedIndex = -1;
            dateTimePickerNgayTG.ResetText();
            txtLoaiThue.Clear();
            txttyle.Clear();
            txtMaSoThue.Focus();

            txt_timkiem.Clear();
        }

      

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSoThue.Text = dgv.SelectedRows[0].Cells["MaSoThue"].Value.ToString();
            cboMaNv.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
            cboMaNv.Enabled = false;
            txtMaSoThue.Enabled = false;
            dateTimePickerNgayTG.Text = dgv.SelectedRows[0].Cells["NgayThamGia"].Value.ToString();
            txtLoaiThue.Text = dgv.SelectedRows[0].Cells["LoaiThue"].Value.ToString();
            txttyle.Text = dgv.SelectedRows[0].Cells["TyLe"].Value.ToString();
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }
        public void loadgridkeyword()
        {
            string str = "Select* from tblThue where MaNV like'%" + txt_timkiem.Text + "%' or MaSoThue like'%" + txt_timkiem.Text + "%'or LoaiThue like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }
    }

}