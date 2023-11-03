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
    public partial class FLyLichNV : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        public FLyLichNV()
        {
            InitializeComponent();
            LoadData();
            dateTimePickerngaysinh.Format = DateTimePickerFormat.Custom;
            dateTimePickerngaysinh.CustomFormat = "dd/MM/yyyy";


        }
        private void LoadData()
        {
            var sql = "Select MaNV,TenNV,NgaySinh,GioiTinh,DanToc,CMND_CCCD,Email,DiaChi,SDT,Hinh  from tblLyLichNhanVien  ";
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
                row.Cells["TenNV"].Value = dr["TenNV"];
                row.Cells["NgaySinh"].Value = dr["NgaySinh"];
                row.Cells["GioiTinh"].Value = dr["GioiTinh"];
                row.Cells["DanToc"].Value = dr["DanToc"];
                row.Cells["CMND_CCCD"].Value = dr["CMND_CCCD"];
                row.Cells["Email"].Value = dr["Email"];
                row.Cells["DiaChi"].Value = dr["DiaChi"];

                row.Cells["SDT"].Value = dr["SDT"];
                row.Cells["Hinh"].Value = dr["Hinh"];
            }


            dr.Close();
           
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaNv.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNv.Focus();
                    return;
                }
                if (txtTen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTen.Focus();
                    return;
                }

                if (txtdanToc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdanToc.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return;
                }
                if (txtSDT.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }
                if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (txtCMND_CCCD.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCMND_CCCD.Focus();
                    return;
                }
                var MaNV = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
                var sql = "UPDATE tblLyLichNhanVien SET TenNV = @TenNV ,DiaChi = @DiaChi ,Email = @Email ,CMND_CCCD = @CMND_CCCD ,GioiTinh = @GioiTinh ,NgaySinh = @NgaySinh ,SDT = @SDT ,DanToc = @DanToc ,Hinh = @Hinh WHERE MaNV = @MaNV";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                cmd.Parameters.AddWithValue("TenNV", txtTen.Text);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("GioiTinh", cbogioitinh.Text);
                cmd.Parameters.AddWithValue("NgaySinh", dateTimePickerngaysinh.Value);
                cmd.Parameters.AddWithValue("CMND_CCCD", txtCMND_CCCD.Text);
                cmd.Parameters.AddWithValue("DanToc", txtdanToc.Text);
                cmd.Parameters.AddWithValue("Hinh", txtAnhSanPham.Text);
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
                if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var MaNV = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
                    var sql = "DELETE tblLyLichNhanVien WHERE MaNV = @MaNV";
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
                if (txtMaNv.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNv.Focus();
                    return;
                }
                if (txtTen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTen.Focus();
                    return;
                }

                if (txtdanToc.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtdanToc.Focus();
                    return;
                }
                if (txtDiaChi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiaChi.Focus();
                    return;
                }
                if (txtSDT.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return;
                }
                if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                if (txtCMND_CCCD.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCMND_CCCD.Focus();
                    return;
                }
                var sql = "insert into tblLyLichNhanVien(MaNV,TenNV ,NgaySinh,GioiTinh ,DanToc ,CMND_CCCD , Email ,DiaChi,SDT,Hinh) values (@MaNV,@TenNv,@NgaySinh,@GioiTinh,@DanToc,@CMND_CCCD,@Email,@DiaChi,@SDT,@Hinh)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", txtMaNv.Text);
                cmd.Parameters.AddWithValue("TenNv", txtTen.Text);
                cmd.Parameters.AddWithValue("NgaySinh", dateTimePickerngaysinh.Value);
                cmd.Parameters.AddWithValue("GioiTinh", cbogioitinh.Text);
                cmd.Parameters.AddWithValue("DanToc", txtdanToc.Text);
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
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            txtMaNv.ReadOnly = false;
            txtMaNv.Clear();
            txtTen.Clear();
            txtdanToc.Clear();
            txtEmail.Clear();
            txtCMND_CCCD.Clear();
            dateTimePickerngaysinh.ResetText();
            cbogioitinh.SelectedIndex = -1;
            txtSDT.Clear();
            txtDiaChi.Clear();

            picEmp.Refresh();
            picEmp.Image = null;
            txtMaNv.Focus();

            txt_timkiem.Clear();

        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNv.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
            txtMaNv.ReadOnly = true; // không cho sửa mã
            txtTen.Text = dgv.SelectedRows[0].Cells["TenNV"].Value.ToString();
            dateTimePickerngaysinh.Text = dgv.SelectedRows[0].Cells["NgaySinh"].Value.ToString();
            cbogioitinh.Text = dgv.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
            txtdanToc.Text = dgv.SelectedRows[0].Cells["DanToc"].Value.ToString();
            txtCMND_CCCD.Text = dgv.SelectedRows[0].Cells["CMND_CCCD"].Value.ToString();
            txtEmail.Text = dgv.SelectedRows[0].Cells["Email"].Value.ToString();
            txtDiaChi.Text = dgv.SelectedRows[0].Cells["DiaChi"].Value.ToString();

            txtSDT.Text = dgv.SelectedRows[0].Cells["SDT"].Value.ToString();
            txtAnhSanPham.Text = dgv.SelectedRows[0].Cells["Hinh"].Value.ToString();

            //Chọn giá trị combobox Tình trạng nếu giá trị combobox = giá trị lưu trong csdl
            foreach (var item in cbogioitinh.Items)
                if ((string)item == dgv.SelectedRows[0].Cells["GioiTinh"].Value.ToString())
                    cbogioitinh.SelectedItem = item;

            //load hình ảnh
            if (dgv.SelectedRows[0].Cells["Hinh"].Value.ToString() != "")
                picEmp.Image = Image.FromFile(dgv.SelectedRows[0].Cells["Hinh"].Value.ToString());
            else
                picEmp.Image = null;//ảnh mặc định

        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            string str = "Select tblLyLichNhanVien.MaNV , TenNV ,NgaySinh , GioiTinh, DanToc ,CMND_CCCD ,Email , DiaChi, SDT   from tblLyLichNhanVien ";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            //  DataTable dt = new DataTable();
            ExportToExcel obj = new ExportToExcel();
            saveFileDialog1.InitialDirectory = "D:\\Lan\\KLTN_PhamThiTuyetLan\\Chương Trình";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && dgv.RowCount > 0)
            {

                bool export = obj.ToExcel(dt, saveFileDialog1.FileName);
                if (export)
                {
                    MessageBox.Show("Xuất dữ liệu thành công.!");
                }
            }
        }

       
        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }

       
        public void loadgridkeyword()
        {
            string str = "Select* from tblLyLichNhanVien where MaNV like'%" + txt_timkiem.Text + "%' or TenNV like'%" + txt_timkiem.Text + "%'";

           
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }

    }
}
