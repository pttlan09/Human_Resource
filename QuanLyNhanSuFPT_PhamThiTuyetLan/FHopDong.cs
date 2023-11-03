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
    public partial class FHopDong : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = GS-LANPTT13\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;
        ClassKetNoi data = new ClassKetNoi();
        public FHopDong()
        {
            InitializeComponent();
            dateTimePickerBD.Format = DateTimePickerFormat.Custom;
            dateTimePickerBD.CustomFormat = "dd/MM/yyyy";
            dateTimePickerKT.Format = DateTimePickerFormat.Custom;
            dateTimePickerKT.CustomFormat = "dd/MM/yyyy";
            LoadData();

            string nv = "Select  MaNV from tblLyLichNhanVien order by MaNV asc";
            SqlDataAdapter da = new SqlDataAdapter(nv, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbMaNV.DataSource = dt;
            cbMaNV.DisplayMember = "MaNV";

        }
        private void LoadData()
        {
            var sql = "Select MaHD,MaNV,LoaiHD,NgayBD,NgayKT,GhiChu  from tblHopDong order by NgayBD asc  ";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();

            // Xóa dữ liệu cũ trong datagridview
            dgv.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview

            while (dr.Read())
            {
                var i = dgv.Rows.Add();
                var row = dgv.Rows[i];
                row.Cells["MaHD"].Value = dr["MaHD"];
                row.Cells["MaNV"].Value = dr["MaNV"];
                row.Cells["LoaiHD"].Value = dr["LoaiHD"];
                row.Cells["NgayBD"].Value = dr["NgayBD"];
                row.Cells["NgayKT"].Value = dr["NgayKT"];
                row.Cells["GhiChu"].Value = dr["GhiChu"];
             
            }

            dr.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHD.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaHD.Focus();
                    return;
                }

                if (cboLoaiHD.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboLoaiHD.Focus();
                    return;
                }

                var MaHD = dgv.SelectedRows[0].Cells["MaHD"].Value.ToString();
                var sql = "UPDATE tblHopDong SET LoaiHD=@LoaiHD, NgayBD = @NgayBD ,NgayKT = @NgayKT , GhiChu = @GhiChu WHERE MaHD = @MaHD ";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaHD", MaHD);
                cmd.Parameters.AddWithValue("LoaiHD", cboLoaiHD.Text);
                cmd.Parameters.AddWithValue("NgayBD", dateTimePickerBD.Value);
                cmd.Parameters.AddWithValue("NgayKT", dateTimePickerKT.Value);
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
                if (MessageBox.Show("Bạn có thật sự muốn xóa hợp đồng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var MaHD = dgv.SelectedRows[0].Cells["MaHD"].Value.ToString();
                    var sql = "DELETE tblHopDong WHERE MaHD = @MaHD";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("MaHD", MaHD);
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
                if (txtMaHD.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaHD.Focus();
                    return;
                }
                if (cbMaNV.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbMaNV.Focus();
                    return;
                }
                if (cboLoaiHD.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboLoaiHD.Focus();
                    return;
                }

                
                if (dateTimePickerBD.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateTimePickerBD.Focus();
                    return;
                }

                if (dateTimePickerKT.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dateTimePickerKT.Focus();
                    return;
                }
                var sql = "insert into tblHopDong(MaHD,MaNV,LoaiHD,NgayBD,NgayKT,GhiChu) values (@MaHD,@MaNV,@LoaiHD,@NgayBD,@NgayKT,@GhiChu)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaHD", txtMaHD.Text);
                cmd.Parameters.AddWithValue("MaNV", cbMaNV.Text);
                cmd.Parameters.AddWithValue("LoaiHD", cboLoaiHD.Text);
                cmd.Parameters.AddWithValue("NgayBD", dateTimePickerBD.Value);
                cmd.Parameters.AddWithValue("NgayKT", dateTimePickerKT.Value);
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
                //if (exception.HResult == -2146232060)
                //{
                //    MessageBox.Show("Hợp đồng này đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                //else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
        
            SqlDataAdapter sda1 = new SqlDataAdapter("select isnull(max(cast(MaHD as int)),0)+1 from tblHopDong", conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            txtMaHD.Text = dt1.Rows[0][0].ToString();
            this.ActiveControl = cbMaNV;
            //txtMaHD.Enabled = false;
            // txtMaHD.ReadOnly = false;
            txtMaHD.Enabled = true; // không cho sửa mã
            cbMaNV.Enabled = true;
          //  txtMaHD.Clear();
            cbMaNV.SelectedIndex = -1;
            cboLoaiHD.SelectedIndex = -1;
           
            dateTimePickerBD.ResetText();
            dateTimePickerKT.ResetText();
            txtghichu.Clear();
         //   txtMaHD.Focus();

            txt_timkiem.Clear();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHD.Text = dgv.SelectedRows[0].Cells["MaHD"].Value.ToString();
            cbMaNV.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
            txtMaHD.Enabled = false; // không cho sửa mã
            cbMaNV.Enabled = false;
            cboLoaiHD.Text = dgv.SelectedRows[0].Cells["LoaiHD"].Value.ToString();
            dateTimePickerBD.Text = dgv.SelectedRows[0].Cells["NgayBD"].Value.ToString();
            dateTimePickerKT.Text = dgv.SelectedRows[0].Cells["NgayKT"].Value.ToString();
          
            txtghichu.Text = dgv.SelectedRows[0].Cells["GhiChu"].Value.ToString();

        }
    


        public void loadgridkeyword()
        {
            string str = "Select* from tblHopDong where MaNV like'%" + txt_timkiem.Text + "%' or MaHD like'%" + txt_timkiem.Text + "%'or LoaiHD like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }

        private void txt_timkiem_TextChanged_1(object sender, EventArgs e)
        {
            loadgridkeyword();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            string str = "Select *   from tblHopDong ";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            //  DataTable dt = new DataTable();
            ExportToExcel obj = new ExportToExcel();
            saveFileDialog1.InitialDirectory = "D:\\Lan\\KLTN_PhamThiTuyetLan\\Báo cáo";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && dgv.RowCount > 0)
            {

                bool export = obj.ToExcel(dt, saveFileDialog1.FileName);
                if (export)
                {
                    MessageBox.Show("Xuất dữ liệu thành công.!");
                }
            }
        }

        private void FHopDong_Load(object sender, EventArgs e)
        {
            txtMaHD.Enabled = false;
            SqlDataAdapter sda = new SqlDataAdapter("select isnull(max(cast(MaHD as int)),0)+1 from tblHopDong", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtMaHD.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = cbMaNV;
        }
    }
}
