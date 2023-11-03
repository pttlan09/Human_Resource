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

//ne he1


namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class FDatabase : Form
    {
        public FDatabase()
        {
            InitializeComponent();
        }

        private void btnChonBakup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDuongDanBakup.Text = dlg.SelectedPath;
                btnSaoLuu.Enabled = true;
            }

        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            if (txtServerName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Server Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServerName.Focus();
                return;
            }
            if (txtDuongDanBakup.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDuongDanBakup.Focus();
                return;
            }
            SqlConnection sqlConn = new SqlConnection("Data Source=" + txtServerName.Text + ";Initial Catalog=TN_QuanLyNhanSu;Integrated Security=True");
            string database = sqlConn.Database.ToString();
            try
            {
                if (txtDuongDanBakup.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng chọn thông tin đường dẫn");
                }
                else
                {
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK ='" + txtDuongDanBakup.Text + "\\" + "TN_QuanLyNhanSu"
                        + "-" + DateTime.Now.ToString("dddd, dd MMMM yyyy") + ".bak'";
                    using (SqlCommand command = new SqlCommand(cmd, sqlConn))
                    {
                        if (sqlConn.State != ConnectionState.Open)
                        {
                            sqlConn.Open();
                        }
                        command.ExecuteNonQuery();
                        sqlConn.Close();
                        MessageBox.Show("Sao lưu cơ sở dữ liệu TN_QuanLyNhanSu thành công. Vui lòng tìm kiếm file BAK có tên "
                             + "TN_QuanLyNhanSu" + "-" + DateTime.Now.ToString("dddd, dd MMMM yyyy") + ".bak tại đường dẫn đã chọn", "Thông Báo", MessageBoxButtons.OK);
                        btnSaoLuu.Enabled = false;
                    } 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo", MessageBoxButtons.OK);
            }

        }

        private void btnChonRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup file|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDuongDanRestore.Text = dlg.FileName;
                btnPhucHoi.Enabled = true;
            }

        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            if (txtServerName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Server Name", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServerName.Focus();
                return;
            }
            if (txtDuongDanRestore.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDuongDanRestore.Focus();
                return;
            }
            SqlConnection sqlConn = new SqlConnection("Data Source=" + txtServerName.Text + ";Initial Catalog=TN_QuanLyNhanSu;Integrated Security=True");
            string database = sqlConn.Database.ToString();
            if (sqlConn.State != ConnectionState.Open)
            {
                sqlConn.Open();
            }
            try
            {
                string sql1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand command1 = new SqlCommand(sql1, sqlConn);
                command1.ExecuteNonQuery();

                string sql2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + txtDuongDanRestore.Text + "'WITH REPLACE;";
                SqlCommand command2 = new SqlCommand(sql2, sqlConn);
                command2.ExecuteNonQuery();

                string sql3 = string.Format("ALTER DATABASE[" + database + "] SET MULTI_USER");
                SqlCommand command3 = new SqlCommand(sql3, sqlConn);
                command3.ExecuteNonQuery();

                MessageBox.Show("Phục hồi cơ sở dữ liệu " + database + " thành công", "Thông Báo", MessageBoxButtons.OK);
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo", MessageBoxButtons.OK);
            }

        }
    }
}
