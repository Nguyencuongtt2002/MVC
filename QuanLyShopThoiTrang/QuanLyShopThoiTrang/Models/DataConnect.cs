using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace QuanLyShopThoiTrang.Models
{
    public class DataConnect
    {
        string chuoikn = ConfigurationManager.ConnectionStrings["MVC"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public DataConnect()
        {
            con = new SqlConnection(chuoikn);
        }
        //đọc, ghi CSDL: đọc -->lấy dữ liệu, ghi --> thực thi câu truy vấn sql
        public DataTable getData(string sql)
        {
            con.Open();
            da = new SqlDataAdapter(sql, con);
            dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void thucthisql(string sql)
        {
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int Kiemtramatrung(string sql)
        {
            con.Open();
            int i;
            cmd = new SqlCommand(sql, con);
            i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }
    }
}