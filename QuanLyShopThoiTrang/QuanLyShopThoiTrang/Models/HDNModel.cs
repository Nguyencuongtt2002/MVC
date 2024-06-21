using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Models
{
    public class HDNModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<HDN> getAllHDN()
        {
            DataTable dt = dc.getData("Select * from HDN");
            List<HDN> li = new List<HDN>();
            foreach (DataRow dr in dt.Rows)
            {
                HDN hdn = new HDN();
                hdn.MaHDN = int.Parse(dr[0].ToString());
                hdn.MaNV = dr[1].ToString();
                hdn.MaNCC = dr[2].ToString();
                hdn.MaSP = dr[3].ToString();
                hdn.NgayNhap = dr[4].ToString();
                hdn.SoLuong = int.Parse(dr[5].ToString());
                hdn.DonGia = int.Parse(dr[6].ToString());
                li.Add(hdn);
            }
            return li;
        }
        public HDN get1HDN(string ma)
        {
            HDN hdn = new HDN();
            DataTable dt = dc.getData("Select * from HDN where MaHDN='" + ma.Trim() + "'");
            hdn.MaHDN = int.Parse(dt.Rows[0][0].ToString());
            hdn.MaNV = dt.Rows[0][1].ToString();
            hdn.MaNCC = dt.Rows[0][2].ToString();
            hdn.MaSP = dt.Rows[0][3].ToString();
            hdn.NgayNhap = dt.Rows[0][4].ToString();
            hdn.SoLuong = int.Parse(dt.Rows[0][5].ToString());
            hdn.DonGia = int.Parse(dt.Rows[0][6].ToString());
            return hdn;
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
        public void CreateHDN(HDN hdn)
        {
            string sql = "Insert into HDN values('" + hdn.MaNV + "','" + hdn.MaNCC + "','" + hdn.MaSP + "',N'" + hdn.NgayNhap + "','" + hdn.SoLuong + "','" + hdn.DonGia + "')";
            dc.thucthisql(sql);
        }

        public void UpdateHDN(HDN hdn)
        {
            string sql = "Update HDN set MaNV='" + hdn.MaNV + "', MaNCC=N'" + hdn.MaNCC + "', MaSP='" + hdn.MaSP + "', NgayNhap='" + hdn.NgayNhap + "', SoLuong='" + hdn.SoLuong + "', DonGia='" + hdn.DonGia + "' where MaHDN='" + hdn.MaHDN + "'";
            dc.thucthisql(sql);
        }

        public void DeleteHDN(string id)
        {
            string sql = "Delete from HDN where MaHDN='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
    }
}