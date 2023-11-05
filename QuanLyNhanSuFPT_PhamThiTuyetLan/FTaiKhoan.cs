using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ZXing;
using System.IO;

namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class FTaiKhoan : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source = GS-LANPTT13\SQLEXPRESS; Initial Catalog = TN_QuanLyNhanSu; Integrated Security = True;");
        SqlCommand cmd;
        SqlDataReader dr;

        ClassKetNoi data = new ClassKetNoi();
        public FTaiKhoan()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            var sql = "Select TenDangNhap,MatKhau,MaNV,Quyen,QRCode  from tblTaiKhoan  ";
            var cmd = new SqlCommand(sql, DBConnect.Connect());
            var dr = cmd.ExecuteReader();

            // Xóa dữ liệu cũ trong datagridview
            dgv.Rows.Clear();

            // lập qua từng dòng trong bảng SanPham, thêm vào datagridview

            while (dr.Read())
            {
                var i = dgv.Rows.Add();
                var row = dgv.Rows[i];
                row.Cells["TenDangNhap"].Value = dr["TenDangNhap"];
                row.Cells["MatKhau"].Value = dr["MatKhau"];
                row.Cells["MaNV"].Value = dr["MaNV"];
                row.Cells["Quyen"].Value = dr["Quyen"];
                row.Cells["QRCode"].Value = dr["QRCode"];
             
            }
            dr.Close();

        }
        private void btnQRcode_Click(object sender, EventArgs e)
        {
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    textBox1.Text = dlg.FileName();

            string qrData = txttenDangNhap.Text;
          
            string qrImageFileName = cbMaNV.Text;
            //check
        //    if()
           
            //create
            BarcodeWriter barcodew = new BarcodeWriter();
            //specify
            barcodew.Format = BarcodeFormat.QR_CODE;
            picQR.Image = barcodew.Write(qrData);

           // txtAnhSanPham.Text= @"D:\Lan\KLTN_PhamThiTuyetLan\Chương Trình\QuanLyNhanSuFPT_PhamThiTuyetLan\QuanLyNhanSuFPT_PhamThiTuyetLan\Resources\QRCode\" +qrImageFileName + ".png";
            txtAnhSanPham.Text = @"D:\Lan\Learns\1921006722_PhamThiTuyetLan\2.Chương trình\QuanLyNhanSuFPT_PhamThiTuyetLan\QuanLyNhanSuFPT_PhamThiTuyetLan\Resources\QRCode\" + qrImageFileName + ".png";


            //D:\Lan\Learns\1921006722_PhamThiTuyetLan\2.Chương trình\QuanLyNhanSuFPT_PhamThiTuyetLan\QuanLyNhanSuFPT_PhamThiTuyetLan\Resources\QRCode
            //burn dât into qr
            //barcodew.Write(qrData).Save(@"D:\Lan\KLTN_PhamThiTuyetLan\Chương Trình\QuanLyNhanSuFPT_PhamThiTuyetLan\QuanLyNhanSuFPT_PhamThiTuyetLan\Resources\QRCode\"+qrImageFileName+".png");

            //get image
            // picQR.Image = Image.FromFile(@"D:\Lan\KLTN_PhamThiTuyetLan\Chương Trình\QuanLyNhanSuFPT_PhamThiTuyetLan\QuanLyNhanSuFPT_PhamThiTuyetLan\Resources\QRCode\" + qrImageFileName + ".png");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMatMa.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMatMa.Focus();
                    return;
                }
                
                var TenDangNhap = dgv.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();
                var sql = "UPDATE tblTaiKhoan SET MatKhau = @MatKhau ,MaNV = @MaNV ,Quyen = @Quyen ,QRCode=@QRCode WHERE TenDangNhap = @TenDangNhap";
                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("TenDangNhap", txttenDangNhap.Text);
                cmd.Parameters.AddWithValue("MatKhau", txtMatMa.Text);

                cmd.Parameters.AddWithValue("MaNV", cbMaNV.Text);
                cmd.Parameters.AddWithValue("Quyen", cboQuyen.Text);

                cmd.Parameters.AddWithValue("QRCode", txtAnhSanPham.Text);
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

        private void FTaiKhoan_Load(object sender, EventArgs e)
        {
            
            string sql = "Select  a.MaNV from tblQTlamViec a inner join tblHopDong b on a.MaNV = b.MaNV where b.NgayKT >= GETDATE() group by a.MaNV order by a.MaNV asc";
            cmd = new SqlCommand(sql, conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbMaNV.Items.Add(dr["MaNV"]);
            }
            conn.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                //hiện thông báo
                if (MessageBox.Show("Bạn có thật sự muốn xóa tài khoản này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var TenDangNhap = dgv.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();
                    var sql = "DELETE tblTaiKhoan WHERE TenDangNhap = @TenDangNhap";
                    var cmd = new SqlCommand(sql, DBConnect.Connect());
                    cmd.Parameters.AddWithValue("TenDangNhap", TenDangNhap);
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
            string qrData = txttenDangNhap.Text;
            string qrImageFileName = cbMaNV.Text;
          //  check
            //if(File.Exists(@"D:\Lan\KLTN_PhamThiTuyetLan\Chương Trình\QuanLyNhanSuFPT_PhamThiTuyetLan\QuanLyNhanSuFPT_PhamThiTuyetLan\Resources\QRCode\" + qrImageFileName + ".png"))
            //{
            //    MessageBox.Show("Mã QR Code đã tồn tại !\n Vui lòng chọn tên khác !", "Error");
            //    return;
            //}    


            //create
            BarcodeWriter barcodew = new BarcodeWriter();
            barcodew.Format = BarcodeFormat.QR_CODE;
            //     SaveFileDialog dlg = new SaveFileDialog();
            //burn dât into qr
         //   barcodew.Write(qrData).Save(@"D:\Lan\KLTN_PhamThiTuyetLan\Chương Trình\QuanLyNhanSuFPT_PhamThiTuyetLan\QuanLyNhanSuFPT_PhamThiTuyetLan\Resources\QRCode\"+qrImageFileName+".png");
            barcodew.Write(qrData).Save(@"D:\Lan\Learns\1921006722_PhamThiTuyetLan\2.Chương trình\QuanLyNhanSuFPT_PhamThiTuyetLan\QuanLyNhanSuFPT_PhamThiTuyetLan\Resources\QRCode\" + qrImageFileName+".png");


            try
            {
                if (txttenDangNhap.Text.Trim().Length == 0)
                {

                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txttenDangNhap.Focus();
                    return;
                }
                
                
                var sql = "insert into tblTaiKhoan(TenDangNhap,MatKhau,MaNV,Quyen,QRCode) values (@TenDangNhap,@MatKhau,@MaNV,@Quyen,@QRCode)";

                var cmd = new SqlCommand(sql, DBConnect.Connect());
                cmd.Parameters.AddWithValue("TenDangNhap", txttenDangNhap.Text);
                cmd.Parameters.AddWithValue("MatKhau", txtMatMa.Text);
                cmd.Parameters.AddWithValue("MaNV", cbMaNV.Text);
                cmd.Parameters.AddWithValue("Quyen", cboQuyen.Text);
                cmd.Parameters.AddWithValue("QRCode", txtAnhSanPham.Text);

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
                    MessageBox.Show("Tài khoản đã tồn tại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(exception.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txttenDangNhap.Text = dgv.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();
            txttenDangNhap.ReadOnly = true; // không cho sửa mã
            txtMatMa.Text = dgv.SelectedRows[0].Cells["MatKhau"].Value.ToString();
          
            cbMaNV.Text = dgv.SelectedRows[0].Cells["MaNV"].Value.ToString();
            cboQuyen.Text = dgv.SelectedRows[0].Cells["Quyen"].Value.ToString();
            
            txtAnhSanPham.Text = dgv.SelectedRows[0].Cells["QRCode"].Value.ToString();

            //Chọn giá trị combobox Tình trạng nếu giá trị combobox = giá trị lưu trong csdl
            foreach (var item in cbMaNV.Items)
                if ((string)item == dgv.SelectedRows[0].Cells["MaNV"].Value.ToString())
                    cbMaNV.SelectedItem = item;

            foreach (var item in cboQuyen.Items)
                if ((string)item == dgv.SelectedRows[0].Cells["Quyen"].Value.ToString())
                    cboQuyen.SelectedItem = item;

            //load hình ảnh
            if (dgv.SelectedRows[0].Cells["QRCode"].Value.ToString() != "")
              picQR.Image = Image.FromFile(dgv.SelectedRows[0].Cells["QRCode"].Value.ToString());
               // picQR.Image = Image.FromFile(@"D:\Lan\KLTN_PhamThiTuyetLan\Chương Trình\QuanLyNhanSuFPT_PhamThiTuyetLan\QuanLyNhanSuFPT_PhamThiTuyetLan\Resources\QRCode\" + txtAnhSanPham.Text );

            else
                picQR.Image = null;//ảnh mặc định
          
        }

        private void btnthemmoi_Click(object sender, EventArgs e)
        {
            txttenDangNhap.ReadOnly = false;
            txttenDangNhap.Clear();
            txtMatMa.Clear();
            cbMaNV.SelectedIndex = -1;
            cboQuyen.SelectedIndex = -1;
           

            picQR.Refresh();
            picQR.Image = null;
            txttenDangNhap.Focus();

           // txt_timkiem.Clear();
        }

        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

      
    }
}
