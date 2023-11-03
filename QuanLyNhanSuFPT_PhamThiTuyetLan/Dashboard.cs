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
//using System.Windows.Forms.DataVisualization.Charting;


namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    
    public partial class Dashboard : Form
    {
        ClassKetNoi data = new ClassKetNoi();
        string CurrentMonth = DateTime.Now.ToString("yyyy");

        public Dashboard()
        {
            InitializeComponent();

        }

        private void Soluongnhanvien()
        {
            try
            {//sum nv
                var sum1 = ("select count(MaNV) as tong from tblLyLichNhanVien ");
                var cmd = new SqlCommand(sum1, DBConnect.Connect());

                var sum2 = ("select count(MaNV) as tong from tblQTlamViec where Year(NgayVaoLam)='" + CurrentMonth + "'");
                var cmd2 = new SqlCommand(sum2, DBConnect.Connect());
                //ty lệ nghỉ việc
                var sumnghiviec = (" select count(MaNV) from tblHopDong where NgayKT < GETDATE()");
                var cmd3 = new SqlCommand(sumnghiviec, DBConnect.Connect());



                float sum = Convert.ToInt32(cmd.ExecuteScalar());

                int sumnvnew = Convert.ToInt32(cmd2.ExecuteScalar());

                float nghiviec = Convert.ToInt32(cmd3.ExecuteScalar());
               
               float tyle = (100* nghiviec / sum);

                lblsumNV.Text = sum.ToString();
                lblslnvmoi.Text = sumnvnew.ToString();
                lblnvmoi.Text = lblslnvmoi.Text + " New user";
                lbltyle.Text = tyle.ToString() + "%";
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lbltime.Text = DateTime.Now.ToLongDateString();
            lbltimetyle.Text = DateTime.Now.ToLongDateString();
            // DateTime.Now.ToShortDateString()
            Soluongnhanvien();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //openChildForm(new Dashboard());
        }
    }
}
//select count(MaNV) from tblLyLichNhanVien                   
