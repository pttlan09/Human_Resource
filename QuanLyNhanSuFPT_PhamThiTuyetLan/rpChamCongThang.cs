using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class rpChamCongThang : Form
    {
        public rpChamCongThang()
        {
            InitializeComponent();
            dtp_ngaychotcong.Format = DateTimePickerFormat.Custom;
            dtp_ngaychotcong.CustomFormat = "dd/MM/yyyy";
        }

        private void rpChamCongThang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TN_QuanLyNhanSuDataSet.sp_ChamCongTheoThang' table. You can move, or remove it, as needed.
           
        }

        private void btnchon_Click(object sender, EventArgs e)
        {
            this.sp_ChamCongTheoThangTableAdapter.Fill(this.TN_QuanLyNhanSuDataSet.sp_ChamCongTheoThang,dtp_ngaychotcong.Value);

            this.reportViewer1.RefreshReport();
        }
    }
}
