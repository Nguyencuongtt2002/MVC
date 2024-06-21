using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Models
{
    public class KhachHangModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<KhachHang> getAllKH()
        {
            DataTable dt = dc.getData("Select * from KhachHang");
            List<KhachHang> li = new List<KhachHang>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang kh = new KhachHang();
                kh.MaKH = dr[0].ToString();
                kh.TenKH = dr[1].ToString();
                kh.DiaChi = dr[2].ToString();
                kh.SoDT = dr[3].ToString();
                li.Add(kh);
            }
            return li;
        }
        public KhachHang get1KH(string ma)
        {
            KhachHang kh = new KhachHang();
            DataTable dt = dc.getData("Select * from KhachHang where MaKH='" + ma.Trim() + "'");
            kh.MaKH = dt.Rows[0][0].ToString();
            kh.TenKH = dt.Rows[0][1].ToString();
            kh.DiaChi = dt.Rows[0][2].ToString();
            kh.SoDT = dt.Rows[0][3].ToString();
            return kh;
        }
        public void CreateKH(KhachHang kh)
        {
            string sql = "Insert into KhachHang values('" + kh.MaKH + "',N'" + kh.TenKH + "',N'" + kh.DiaChi + "',N'" + kh.SoDT + "')";
            dc.thucthisql(sql);
        }

        public void UpdateKH(KhachHang kh)
        {
            string sql = "Update KhachHang set TenKH=N'" + kh.TenKH + "', DiaChi=N'" + kh.DiaChi + "', SoDT='" + kh.SoDT + "' where MaKH='" + kh.MaKH + "'";
            dc.thucthisql(sql);
        }

        public void DeleteKH(string id)
        {
            string sql = "Delete from KhachHang where MaKH='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public int kiemtramatrung(string id)
        {
            string sql = "Select count (*) from KhachHang where MaKH='" + id + "'";
            return dc.Kiemtramatrung(sql);
        }
    }
}