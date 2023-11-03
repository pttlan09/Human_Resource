using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class ReportNhanVienPB : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        public ReportNhanVienPB()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            string phongban = "Select  MaPB from tblPhongBan";
            SqlDataAdapter da1 = new SqlDataAdapter(phongban, data.getConnect());
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            cbomaphong.DataSource = dt1;
            cbomaphong.DisplayMember = "MaPB";

        }
        private void ReportNhanVienPB_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TN_QuanLyNhanSuDataSet.sp_NhanVienPB' table. You can move, or remove it, as needed.
            LoadData();
            this.reportViewer1.RefreshReport();
        }

        private void btnchon_Click(object sender, EventArgs e)
        {
            this.sp_NhanVienPBTableAdapter.Fill(this.TN_QuanLyNhanSuDataSet.sp_NhanVienPB, cbomaphong.Text);

            this.reportViewer1.RefreshReport();
        }
    }
    
}
