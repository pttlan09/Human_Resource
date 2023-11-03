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
    public partial class FQTLamViec : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source = GS-LANPTT13\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;

        ClassKetNoi data = new ClassKetNoi();
        

        public FQTLamViec()
        {
            InitializeComponent();
            LoadData();
            dateTimePickerngayvaolam.Format = DateTimePickerFormat.Custom;
            dateTimePickerngayvaolam.CustomFormat = "dd/MM/yyyy";


            //string nv = "Select  MaNV from tblLyLichNhanVien";
            //SqlDataAdapter da = new SqlDataAdapter(nv, data.getConnect());
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //cbMaNV.DataSource = dt;
            //cbMaNV.DisplayMember = "MaNV";

            string bophan = "Select  MaBP from tblBoPhan";
            SqlDataAdapter da1 = new SqlDataAdapter(bophan, data.getConnect());
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbomabophan.DataSource = dt1;
            cbomabophan.DisplayMember = "MaBP";
            ////this.aREATableAdapter.Fill(this.wATERandPOWERDataSet.AREA);

            string pb = "Select  MaPB from tblPhongBan";
            SqlDataAdapter da2 = new SqlDataAdapter(pb, data.getConnect());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            cbomaphong.DataSource = dt2;
            cbomaphong.DisplayMember = "MaPB";

            string capbac = "Select  MaCB from tblCapBac";
            SqlDataAdapter da3 = new SqlDataAdapter(capbac, data.getConnect());
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            cbomacapbac.DataSource = dt3;
            cbomacapbac.DisplayMember = "MaCB";

        }
        private void LoadData()
        {
            var sql = "Select MaNV,TenNV,Email,NgayVaolam,LuongCB,MaBP,MaPB,MaCB  from tblQTLamViec order by NgayVaoLam asc  ";
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
                row.Cells["Email"].Value = dr["Email"];
                row.Cells["NgayVaoLam"].Value = dr["NgayVaoLam"];
                row.Cells["LuongCB"].Value = dr["LuongCB"];
                row.Cells["MaBP"].Value = dr["MaBP"];
                row.Cells["MaPB"].Value = dr["MaPB"];
                row.Cells["MaCB"].Value = dr["MaCB"];

            }


            dr.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTen.Focus();
                    return;
                }

                if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }
                if (txtLuongCB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLuongCB.Focus();
                    return;
                }
                
                var MaNV = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
                var sql = "UPDATE tblQTLamViec SET TenNV = @TenNV ,Email = @Email ,NgayVaoLam = @NgayVaoLam ,LuongCB=@LuongCB,MaBP=@MaBP,MaPB=@MaPB,MaCB=@MaCB WHERE MaNV = @MaNV";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", MaNV);
                cmd.Parameters.AddWithValue("TenNV", txtTen.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("LuongCB", txtLuongCB.Text);
                cmd.Parameters.AddWithValue("NgayVaoLam", dateTimePickerngayvaolam.Value);
                cmd.Parameters.AddWithValue("MaBP", cbomabophan.Text);
                cmd.Parameters.AddWithValue("MaPB", cbomaphong.Text);
                cmd.Parameters.AddWithValue("MaCB", cbomacapbac.Text);
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
                    var sql = "DELETE tblQTLamViec WHERE MaNV = @MaNV";
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

                if (txtLuongCB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLuongCB.Focus();
                    return;
                }
               
                var sql = "insert into tblQTLamViec(MaNV,TenNV ,Email,NgayVaoLam,LuongCB,MaBP,MaPB,MaCB) values (@MaNV,@TenNv,@Email,@NgayVaoLam,@LuongCB,@MaBP,@MaPB,@MaCB)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("MaNV", cbMaNV.Text);
                cmd.Parameters.AddWithValue("TenNv", txtTen.Text);
                cmd.Parameters.AddWithValue("NgayVaoLam", dateTimePickerngayvaolam.Value);
                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("LuongCB", txtLuongCB.Text);
                cmd.Parameters.AddWithValue("MaBP", cbomabophan.Text);
                cmd.Parameters.AddWithValue("MaPB", cbomaphong.Text);
                cmd.Parameters.AddWithValue("MaCB", cbomacapbac.Text);
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
            //    if (exception.HResult == -2146232060)
            //    {
            //        MessageBox.Show("Nhân viên đã tồn lại thông tin quá trình làm việc", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

       

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            cbMaNV.Enabled = true;
            cbMaNV.SelectedIndex = -1;
            txtTen.Clear();
            txtEmail.Clear();
            txtLuongCB.Clear();
            dateTimePickerngayvaolam.ResetText();
            cbomabophan.SelectedIndex = -1;
            cbomaphong.SelectedIndex = -1;
            cbomacapbac.SelectedIndex = -1;

            cbMaNV.Focus();

            txt_timkiem.Clear();

        }


        public void loadgridkeyword()
        {
            string str = "Select* from tblQTLamViec where MaNV like'%" + txt_timkiem.Text + "%' or TenNV like'%" + txt_timkiem.Text + "%'";


            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable tk = new DataTable();
            da.Fill(tk);
            dgv.DataSource = tk;
        }

        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            loadgridkeyword();
        }

        private void dgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            cbMaNV.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
          cbMaNV.Enabled = false; // không cho sửa mã
            txtTen.Enabled = false;
            txtEmail.Enabled = false;
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            txtTen.Text = dgv.SelectedRows[0].Cells["TenNV"].Value.ToString();
            dateTimePickerngayvaolam.Text = dgv.SelectedRows[0].Cells["NgayVaoLam"].Value.ToString();
            cbomabophan.Text = dgv.SelectedRows[0].Cells["MaBP"].Value.ToString();
            
                 txtLuongCB.Text = dgv.SelectedRows[0].Cells["LuongCB"].Value.ToString();
            txtEmail.Text = dgv.SelectedRows[0].Cells["Email"].Value.ToString();

            cbomaphong.Text = dgv.SelectedRows[0].Cells["MaPB"].Value.ToString();
            cbomacapbac.Text = dgv.SelectedRows[0].Cells["MaCB"].Value.ToString();

            //Chọn giá trị combobox Tình trạng nếu giá trị combobox = giá trị lưu trong csdl
            //foreach (var item in cbomabophan.Items)
            //    if ((string)item == dgv.SelectedRows[0].Cells["MaBP"].Value.ToString())
            //        cbomabophan.SelectedItem = item;
            //foreach (var item in cbomaphong.Items)
            //    if ((string)item == dgv.SelectedRows[0].Cells["MaPB"].Value.ToString())
            //        cbomaphong.SelectedItem = item;
            //foreach (var item in cbomacapbac.Items)
            //    if ((string)item == dgv.SelectedRows[0].Cells["MaCB"].Value.ToString())
            //        cbomacapbac.SelectedItem = item;
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void FQTLamViec_Load(object sender, EventArgs e)
        {
            txtTen.Enabled = false;
            txtEmail.Enabled = false;
            string sql = "select * from tblLyLichNhanVien order by MaNV asc";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read())
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
            while(dr.Read())
            {
                string TenNV = dr["TenNV"].ToString();
                string Email = dr["Email"].ToString();

                txtTen.Text = TenNV;
                txtEmail.Text = Email;
            }
            conn.Close();
        }
    }
}
