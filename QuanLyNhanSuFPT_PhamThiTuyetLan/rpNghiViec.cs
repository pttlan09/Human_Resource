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
    public partial class rpNghiViec : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        public rpNghiViec()
        {
            InitializeComponent();
        }

        private void rpNghiViec_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TN_QuanLyNhanSuDataSet.RP_DSNVNghiViec' table. You can move, or remove it, as needed.
            this.RP_DSNVNghiViecTableAdapter.Fill(this.TN_QuanLyNhanSuDataSet.RP_DSNVNghiViec);

            this.reportViewer1.RefreshReport();
        }
    }
}
