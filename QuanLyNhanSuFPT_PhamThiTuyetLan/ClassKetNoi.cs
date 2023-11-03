using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanSuFPT_PhamThiTuyetLan
{
    class ClassKetNoi
    {
        public static SqlConnection Con; 

        private string strConn = @"Data Source=GS-LANPTT13\SQLEXPRESS;Initial Catalog=TN_QuanLyNhanSu;Integrated Security=True";
        public SqlConnection getConnect()
        {
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            return conn;
        }
        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection ketnoi = new SqlConnection(strConn))
            {
                ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, ketnoi);
                thucthi.ExecuteNonQuery();

                ketnoi.Close();
            }
            return data;
        }
     
        public DataTable ExcuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Ketnoi = new SqlConnection(strConn))
            {
                Ketnoi.Open();
                SqlCommand thucthi = new SqlCommand(query, Ketnoi);
                SqlDataAdapter laydulieu = new SqlDataAdapter(thucthi);
                laydulieu.Fill(dt);
                Ketnoi.Close();
            }
            return dt;
        }

        static string ma;
        static string ten;
        static string mk;
        static string quyen;
        public static string manhanvien
        {
            get
            {
                return ma;
            }
            set
            {
                ma = value;
            }
        }
        public static string tennhanvien
        {
            get
            {
                return ten;
            }
            set
            {
                ten = value;
            }
        }
        public static string matkhau
        {
            get
            {
                return mk;
            }
            set
            {
                mk = value;
            }
        }
        public static string quyennhanvien
        {
            get
            {
                return  quyen;
            }
            set
            {
                quyen = value;
            }
        }

    }
}
