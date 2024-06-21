using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using QuanLyShopThoiTrang.Models;

namespace QuanLyShopThoiTrang.Models
{
    public class TinTucModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<TinTuc> getAllTT()
        {
            DataTable dt = dc.getData("Select * from TinTuc");
            List<TinTuc> li = new List<TinTuc>();
            foreach (DataRow dr in dt.Rows)
            {
                TinTuc tt = new TinTuc();
                tt.MaTinTuc = dr[0].ToString();
                tt.TieuDe = dr[1].ToString();
                tt.NoiDung = dr[2].ToString();
                tt.NgayDang = dr[3].ToString();
                tt.MaNV = dr[4].ToString();
                tt.Anh = dr[5].ToString();
                
                li.Add(tt);
            }
            return li;
        }
        public TinTuc get1TT(string ma)
        {
            TinTuc tt = new TinTuc();
            DataTable dt = dc.getData("Select * from TinTuc where MaTinTuc='" + ma.Trim() + "'");
            tt.MaTinTuc = dt.Rows[0][0].ToString();
            tt.TieuDe = dt.Rows[0][1].ToString();
            tt.NoiDung = dt.Rows[0][2].ToString();
            tt.NgayDang = dt.Rows[0][3].ToString();
            tt.MaNV = dt.Rows[0][4].ToString();
            tt.Anh = dt.Rows[0][5].ToString();
            return tt;
        }
        // 
        //public List<SanPham> getSPbyLSP(string id)
        //{
        //    DataTable dt = dc.getData("select * from SanPham where MaLoaiSP='" + id.Trim() + "'");
        //    List<SanPham> li = new List<SanPham>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        SanPham sp = new SanPham();
        //        sp.MaSP = dr[0].ToString();
        //        sp.TenSP = dr[1].ToString();
        //        sp.MoTa = dr[2].ToString();
        //        sp.SoLuong = int.Parse(dr[3].ToString());
        //        sp.DonGia = int.Parse(dr[4].ToString());
        //        sp.MaLoaiSP = dr[5].ToString();
        //        sp.MaThuongHieu = dr[6].ToString();
        //        sp.Anh = dr[7].ToString();
        //        li.Add(sp);
        //    }
        //    return li;
        //}
        public void CreateTT(TinTuc tt)
        {
            string sql = "Insert into TinTuc values('" + tt.MaTinTuc + "',N'" + tt.TieuDe + "',N'" + tt.NoiDung + "',N'" + tt.NgayDang + "',N'" + tt.MaNV + "',N'" + tt.Anh + "')";
            dc.thucthisql(sql);
        }

        public void UpdateTT(TinTuc tt)
        {
            string sql = "Update TinTuc set TieuDe=N'" + tt.TieuDe + "', NoiDung=N'"+tt.NoiDung + "', NgayDang=N'" + tt.NgayDang + "', MaNV='" + tt.MaNV + "', Anh=N'" + tt.Anh + "' where MaTinTuc='" + tt.MaTinTuc + "'";
            dc.thucthisql(sql);
        }

        public void DeleteTT(string id)
        {
            string sql = "Delete from TinTuc where MaTinTuc='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public int kiemtramatrung(string id)
        {
            string sql = "Select count (*) from TinTuc where MaTinTuc='" + id + "'";
            return dc.Kiemtramatrung(sql);
        }
    }
}