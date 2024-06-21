using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Models
{
    public class ThuongHieuModel
    {

        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<ThuongHieu> getAllTH()
        {
            DataTable dt = dc.getData("Select * from ThuongHieu");
            List<ThuongHieu> li = new List<ThuongHieu>();
            foreach (DataRow dr in dt.Rows)
            {
                ThuongHieu th = new ThuongHieu();
                th.MaThuongHieu = dr[0].ToString();
                th.TenThuongHieu = dr[1].ToString();
                th.GioiThieu = dr[2].ToString();
                li.Add(th);
            }
            return li;
        }

        public ThuongHieu get1TH(string ma)
        {
            ThuongHieu th = new ThuongHieu();
            DataTable dt = dc.getData("Select * from ThuongHieu where MaThuongHieu='" + ma.Trim() + "'");
            th.MaThuongHieu = dt.Rows[0][0].ToString();
            th.TenThuongHieu = dt.Rows[0][1].ToString();
            th.GioiThieu = dt.Rows[0][2].ToString();
            return th;
        }
        public void CreateTH(ThuongHieu th)
        {
            string sql = "Insert into ThuongHieu values('" + th.MaThuongHieu + "',N'" + th.TenThuongHieu + "',N'" + th.GioiThieu + "')";
            dc.thucthisql(sql);
        }

        public void UpdateTH(ThuongHieu th)
        {
            string sql = "Update ThuongHieu set TenThuongHieu=N'" + th.TenThuongHieu + "', GioiThieu=N'" + th.GioiThieu + "' where MaThuongHieu='" + th.MaThuongHieu + "'";
            dc.thucthisql(sql);
        }

        public void DeleteTH(string id)
        {
            string sql = "Delete from ThuongHieu where MaThuongHieu='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public int kiemtramatrung(string id)
        {
            string sql = "Select count (*) from ThuongHieu where MaThuongHieu='" + id + "'";
            return dc.Kiemtramatrung(sql);
        }
    }
}