using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Models
{
    public class KhuyenMaiModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<KhuyenMai> getAllKM()
        {
            DataTable dt = dc.getData("Select * from KhuyenMai");
            List<KhuyenMai> li = new List<KhuyenMai>();
            foreach (DataRow dr in dt.Rows)
            {
                KhuyenMai km = new KhuyenMai();
                km.MaKM = dr[0].ToString();
                km.TenSPKM = dr[1].ToString();
                km.GiaKM = int.Parse(dr[2].ToString());
                km.Anh = dr[3].ToString();
                km.giamgia = int.Parse(dr[4].ToString());
                km.MaSP = dr[5].ToString();
                km.NgayBD = dr[6].ToString();
                km.NgyKT = dr[7].ToString();

                li.Add(km);
            }
            return li;
        }
        public KhuyenMai get1KM(string ma)
        {
            KhuyenMai km = new KhuyenMai();
            DataTable dt = dc.getData("Select * from KhuyenMai where MaKM='" + ma.Trim() + "'");
            km.MaKM = dt.Rows[0][0].ToString();
            km.TenSPKM = dt.Rows[0][1].ToString();
            km.GiaKM = int.Parse(dt.Rows[0][2].ToString());
            km.Anh = dt.Rows[0][3].ToString();
            km.giamgia = int.Parse(dt.Rows[0][4].ToString());
            km.MaSP = dt.Rows[0][5].ToString();
            km.NgayBD = dt.Rows[0][6].ToString();
            km.NgyKT = dt.Rows[0][7].ToString();
            return km;
        }
       
    }
}