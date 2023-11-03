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
    public partial class FThanNhan : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        public FThanNhan()
        {
            InitializeComponent();
            dateTimePickerngaysinh.Format = DateTimePickerFormat.Custom;
            dateTimePickerngaysinh.CustomFormat = "dd/MM/yyyy";
            LoadData();
            string nv = "Select a.MaNV from tblQTlamViec a inner join tblHopDong b on a.MaNV = b.MaNV where b.NgayKT >= GETDATE() group by a.MaNV order by MaNV asc";

          //  string nv = "Select  MaNV from tblLyLichNhanVien order by MaNV asc";
            SqlDataAdapter da = new SqlDataAdapter(nv, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "MaNV";
        }
        private void LoadData()
        {

            var sql = "Select MaTN,MaNV,HoTen,GioiTinh,NgaySinh,CMND_CCCD,Quanhe,SDT  from tblThanNhan  ";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();

            // Xóa dữ liệu cũ trong datagridview
            dgv.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview

            while (dr.Read())
            {
                var i = dgv.Rows.Add();
                var row = dgv.Rows[i];
                row.Cells["MaTN"].Value = dr["MaTN"];
                row.Cells["MaNV"].Value = dr["MaNV"];
                row.Cells["HoTen"].Value = dr["HoTen"];
                row.Cells["GioiTinh"].Value = dr["GioiTinh"];
                 row.Cells["NgaySinh"].Value = dr["NgaySinh"];
                
                row.Cells["CMND_CCCD"].Value = dr["CMND_CCCD"];
                row.Cells["Quanhe"].Value = dr["Quanhe"];
                row.Cells["SDT"].Value = dr["SDT"];

            }

            dr.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtMaTN.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTN.Focus();
                    return;
                }

                if (cbMaNV.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbMaNV.Focus();
                    return;
                }

                var MaTN = dgv.SelectedRows[0].Cells["MaTN"].Value.ToString();
                var sql = "UPDATE tblThanNhan SET MaNV=@MaNV, HoTen = @HoTen ,NgaySinh = @NgaySinh , Quanhe = @Quanhe,GioiTinh=@GioiTinh, CMND_CCCD=@CMND_CCCD,SDT=@SDT WHERE MaTN = @MaTN ";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaTN", MaTN);
                cmd.Parameters.AddWithValue("MaNV", cbMaNV.Text);
                cmd.Parameters.AddWithValue("HoTen", txtHoten.Text);
                cmd.Parameters.AddWithValue("NgaySinh", dateTimePickerngaysinh.Value);
                cmd.Parameters.AddWithValue("Quanhe", cbquanhe.Text);
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
                    var MaTN = dgv.SelectedRows[0].Cells["MaTN"].Value.ToString();
                    var sql = "DELETE tblThanNhan WHERE MaTN = @MaTN";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("MaTN", MaTN);
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
                if (txtMaTN.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTN.Focus();
                    return;
                }
                if (txtHoten.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoten.Focus();
                    return;
                }
                if (cbMaNV.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbMaNV.Focus();
                    return;
                }
                if (cbquanhe.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbquanhe.Focus();
                    return;
                }


                if (dateTimePickerngaysinh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateTimePickerngaysinh.Focus();
                    return;
                }


                var sql = "insert into tblThanNhan(MaTN,MaNV,HoTen,GioiTinh,NgaySinh, CMND_CCCD,Quanhe,SDT) values (@MaTN,@MaNV,@HoTen,@GioiTinh,@NgaySinh, @CMND_CCCD,@Quanhe,@SDT)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaTN", txtMaTN.Text);
                cmd.Parameters.AddWithValue("MaNV", cbMaNV.Text);
                cmd.Parameters.AddWithValue("HoTen", txtHoten.Text);
                cmd.Parameters.AddWithValue("GioiTinh", cbogioitinh.Text);
                cmd.Parameters.AddWithValue("NgaySinh", dateTimePickerngaysinh.Value);
                cmd.Parameters.AddWithValue("CMND_CCCD", txtCMND_CCCD.Text);
                cmd.Parameters.AddWithValue("Quanhe", cbquanhe.Text);
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
                //if (exception.HResult == -2146232060)
                //{
                //    MessageBox.Show("Thông tin này đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            {
                // txtMaHD.ReadOnly = false;
                txtMaTN.Clear();
                txtMaTN.Enabled = true;
                cbMaNV.SelectedIndex = -1;
                txtHoten.Clear();
                cbogioitinh.SelectedIndex = -1;

                dateTimePickerngaysinh.ResetText();
                txtCMND_CCCD.Clear();
                cbquanhe.SelectedIndex = -1;
                txtSDT.Clear();
               // txtMaTN.Focus();

                txt_timkiem.Clear();
            }
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTN.Text = dgv.SelectedRows[0].Cells["MaTN"].Value.ToString();
            cbMaNV.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
            txtMaTN.Enabled = false; // không cho sửa mã
          //cbMaNV.Enabled = false;
             txtHoten.Text = dgv.SelectedRows[0].Cells["HoTen"].Value.ToString();
            cbogioitinh.Text = dgv.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
            dateTimePickerngaysinh.Text = dgv.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
            txtCMND_CCCD.Text = dgv.SelectedRows[0].Cells["CMND_CCCD"].Value.ToString();

            cbquanhe.Text = dgv.SelectedRows[0].Cells["Quanhe"].Value.ToString();
            txtSDT.Text = dgv.SelectedRows[0].Cells["SDT"].Value.ToString();


        }
        public void loadgridkeyword()
        {
            string str = "Select* from tblThanNhan where MaNV like'%" + txt_timkiem.Text + "%' or MaTN like'%" + txt_timkiem.Text + "%'or HoTen like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }
    }
}
