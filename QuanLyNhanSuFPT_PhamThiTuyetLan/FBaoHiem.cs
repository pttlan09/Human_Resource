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
    public partial class FBaoHiem : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        public FBaoHiem()
        {
            InitializeComponent(); 
            LoadData();
            dateTimePickerNgayCap.Format = DateTimePickerFormat.Custom;
            dateTimePickerNgayCap.CustomFormat = "dd/MM/yyyy";

            string nv = "Select  a.MaNV from tblQTlamViec a inner join tblHopDong b on a.MaNV = b.MaNV where b.NgayKT >= GETDATE()  group by a.MaNV order by a.MaNV asc";
            SqlDataAdapter da = new SqlDataAdapter(nv, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboMaNv.DataSource = dt;
            cboMaNv.DisplayMember = "MaNV";
        }
        private void LoadData()
        {
            var sql = "Select MaNV,TinhTrang,NgayDong,LoaiBH  from tblBaoHiem  ";
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
                row.Cells["TinhTrang"].Value = dr["TinhTrang"];
                row.Cells["NgayDong"].Value = dr["NgayDong"];
                row.Cells["LoaiBH"].Value = dr["LoaiBH"];

            }
            dr.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLoaiBH.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLoaiBH.Focus();
                    return;
                }

                if (cboMaNv.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaNv.Focus();
                    return;
                }
               
                var MaNV = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
                var sql = "UPDATE tblBaoHiem SET TinhTrang=@TinhTrang, NgayDong = @NgayDong ,LoaiBH = @LoaiBH  WHERE MaNV = @MaNV ";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                cmd.Parameters.AddWithValue("TinhTrang", rdTgia.Checked?"Tham gia":"Không tham gia");
                cmd.Parameters.AddWithValue("NgayDong", dateTimePickerNgayCap.Value);
                cmd.Parameters.AddWithValue("LoaiBH", txtLoaiBH.Text);
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
                    var MaNV = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
                    var sql = "DELETE tblBaoHiem WHERE MaNV = @MaNV";
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
                if (txtLoaiBH.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLoaiBH.Focus();
                    return;
                }
              
             
                var sql = "insert into tblBaoHiem(MaNV,TinhTrang,NgayDong,LoaiBH) values (@MaNV,@TinhTrang,@NgayDong,@LoaiBH)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", cboMaNv.Text);
                cmd.Parameters.AddWithValue("TinhTrang", rdTgia.Checked ? "Tham gia" : "Không tham gia");
                cmd.Parameters.AddWithValue("NgayDong", dateTimePickerNgayCap.Value);
                cmd.Parameters.AddWithValue("LoaiBH", txtLoaiBH.Text);

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
            txtLoaiBH.Clear();
            cboMaNv.Enabled = true;
            cboMaNv.SelectedIndex = -1;
            dateTimePickerNgayCap.ResetText();
         cboMaNv.Focus();
            txt_timkiem.Clear();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLoaiBH.Text = dgv.SelectedRows[0].Cells["LoaiBH"].Value.ToString();
            cboMaNv.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
           cboMaNv.Enabled = false;
            dateTimePickerNgayCap.Text = dgv.SelectedRows[0].Cells["NgayDong"].Value.ToString();
               rdTgia.Checked = dgv.SelectedRows[0].Cells["TinhTrang"].Value.ToString() == "Tham gia";
            rdkoTGia.Checked = dgv.SelectedRows[0].Cells["TinhTrang"].Value.ToString() == "Không tham gia";

        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }
        public void loadgridkeyword()
        {
            string str = "Select* from tblBaoHiem where MaNV like'%" + txt_timkiem.Text + "%' or TinhTrang like'%" + txt_timkiem.Text + "%'or LoaiBH like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }

        private void btnthemmoi_KeyDown(object sender, KeyEventArgs e)
        {
          

                if (e.KeyCode == Keys.Enter)
                {
                    btnthemmoi.PerformClick();
                }
          
        }
    }
}
