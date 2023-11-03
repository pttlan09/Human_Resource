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
    public partial class FThaiSan : Form
    { SqlConnection conn = new SqlConnection(@"Data Source = GS-LANPTT13\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;

        ClassKetNoi data = new ClassKetNoi();
        
        public FThaiSan()
        {
            InitializeComponent();
            LoadData();
            dateTimePickerBD.Format = DateTimePickerFormat.Custom;
            dateTimePickerBD.CustomFormat = "dd/MM/yyyy";
            dateTimePickerKT.Format = DateTimePickerFormat.Custom;
            dateTimePickerKT.CustomFormat = "dd/MM/yyyy";
        }
        private void LoadData()
        {
            var sql = "Select MaNV,HoTen,NgayBatDau,NgayKetThuc  from tblThaiSan  ";
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
                row.Cells["HoTen"].Value = dr["HoTen"];
                row.Cells["NgayKetThuc"].Value = dr["NgayKetThuc"];
                row.Cells["NgayBatDau"].Value = dr["NgayBatDau"];

            }
            dr.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {

                var MaNV = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
                var sql = "UPDATE tblThaiSan SET NgayBatDau = @NgayBatDau ,NgayKetThuc=@NgayKetThuc WHERE MaNV = @MaNV";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", MaNV);
              
                cmd.Parameters.AddWithValue("NgayBatDau", dateTimePickerBD.Value);
                cmd.Parameters.AddWithValue("NgayKetThuc", dateTimePickerKT.Value);
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
                    var sql = "DELETE tblThaiSan WHERE MaNV = @MaNV";
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

                var sql = "insert into tblThaiSan(MaNV,HoTen,NgayBatDau,NgayKetThuc) values (@MaNV,@HoTen,@NgayBatDau,@NgayKetThuc)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", cbMaNV.Text);
                cmd.Parameters.AddWithValue("HoTen", txtHoten.Text);
                cmd.Parameters.AddWithValue("NgayBatDau", dateTimePickerBD.Value);
                cmd.Parameters.AddWithValue("NgayKetThuc", dateTimePickerKT.Value);
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
            cbMaNV.Enabled = true;
            cbMaNV.SelectedIndex = -1;
            txtHoten.Clear();
               dateTimePickerBD.ResetText();
            dateTimePickerKT.ResetText();

            cbMaNV.Focus();

            txt_timkiem.Clear();

        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }
        public void loadgridkeyword()
        {
            string str = "Select* from tblThaiSan where MaNV like'%" + txt_timkiem.Text + "%' or HoTen like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cbMaNV.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
            cbMaNV.Enabled = false; // không cho sửa mã
            txtHoten.Enabled = false;
            
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            txtHoten.Text = dgv.SelectedRows[0].Cells["HoTen"].Value.ToString();
            dateTimePickerBD.Text = dgv.SelectedRows[0].Cells["NgayBatDau"].Value.ToString();

            dateTimePickerKT.Text = dgv.SelectedRows[0].Cells["NgayKetThuc"].Value.ToString();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void FThaiSan_Load(object sender, EventArgs e)
        {
            txtHoten.Enabled = false;
            
            string sql = "Select a.MaNV from tblQTlamViec a inner join tblHopDong b on a.MaNV = b.MaNV inner join tblLyLichNhanVien c on a.MaNV=c.MaNV where b.NgayKT >= GETDATE() and c.GioiTinh=N'Nữ' group by a.MaNV order by a.MaNV asc";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbMaNV.Items.Add(dr["MaNV"]);
            }
            conn.Close();
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * from tblLyLichNhanVien where  MaNV=@MaNV", conn);
            cmd.Parameters.AddWithValue("@MaNV", cbMaNV.Text);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string TenNV = dr["TenNV"].ToString();
               
                txtHoten.Text = TenNV;
               
            }
            conn.Close();
        }
    }
}
