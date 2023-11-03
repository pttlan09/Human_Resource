using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    public partial class FTongHopCong : Form
    {
        ClassKetNoi data = new ClassKetNoi();


        public FTongHopCong()
        {
            InitializeComponent();
           
        }
        

        private void btnchon_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select File";
            fdlg.FileName = txtduongdan.Text;
            fdlg.Filter = "Excel Sheet (*.xlsx)|*.xls|All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtduongdan.Text = fdlg.FileName;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                OleDbConnection cnn = new OleDbConnection();
                cnn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + txtduongdan.Text +
              @"; Extended Properties=""Excel 8.0; HDR=Yes; IMEX=1; ImportMixedTypes=Text; TypeGuessRows=1""";
                OleDbCommand cmd = new OleDbCommand
                (
                    "SELECT * FROM [SHEET1$]", cnn
                );
                OleDbDataAdapter adt = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adt.Fill(ds);
                dgv.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!" + ex.Message);
            }
        }
  
        private void btnluu_Click(object sender, EventArgs e)
        {
            // data.getConnect().Open();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("Insert into tblTongHopCong(MaNV,ThoiGian,SoCong,GhiChu)values('" + dgv.Rows[i].Cells[0].Value + "',N'" + dgv.Rows[i].Cells[1].Value + "','" + dgv.Rows[i].Cells[2].Value + "','" + dgv.Rows[i].Cells[3].Value +  "')", data.getConnect());
                cmd.ExecuteNonQuery();
            }
            data.getConnect().Close();
            MessageBox.Show("Saved...");
            //fillGrid();

        }

        private void FTongHopCong_Load(object sender, EventArgs e)
        {
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = false;
            string str = "Select * from tblTongHopCong order by ThoiGian asc,MaNV asc ";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
          // dgv.datasource = datatable;

            dgv.Columns[0].ValueType = typeof(DateTime);
        }
    }
}
