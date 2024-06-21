using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using QuanLyShopThoiTrang.Models;

namespace QuanLyShopThoiTrang.Models
{
    public class SanPhamModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<SanPham> getAllSP()
        {
            DataTable dt = dc.getData("Select * from SanPham");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MoTa = dr[2].ToString();
                sp.SoLuong = int.Parse(dr[3].ToString());
                sp.DonGia = int.Parse(dr[4].ToString());
                sp.MaLoaiSP = dr[5].ToString();
                sp.MaThuongHieu = dr[6].ToString();
                sp.Anh = dr[7].ToString();
                li.Add(sp);
            }
            return li;
        }

        public SanPham get1SP(string ma)
        {
            SanPham sp = new SanPham();
            DataTable dt = dc.getData("Select * from SanPham where MaSP='" + ma.Trim() + "'");
            sp.MaSP = dt.Rows[0][0].ToString();
            sp.TenSP = dt.Rows[0][1].ToString();
            sp.MoTa = dt.Rows[0][2].ToString();
            sp.SoLuong = int.Parse(dt.Rows[0][3].ToString());
            sp.DonGia = int.Parse(dt.Rows[0][4].ToString());
            sp.MaLoaiSP = dt.Rows[0][5].ToString();
            sp.MaThuongHieu = dt.Rows[0][6].ToString();
            sp.Anh = dt.Rows[0][7].ToString();
            return sp;
        }
        public List<SanPham> getSPbyLSP(string id)
        {
            DataTable dt = dc.getData("select * from SanPham where MaLoaiSP='" + id.Trim() + "'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MoTa = dr[2].ToString();
                sp.SoLuong = int.Parse(dr[3].ToString());
                sp.DonGia = int.Parse(dr[4].ToString());
                sp.MaLoaiSP = dr[5].ToString();
                sp.MaThuongHieu = dr[6].ToString();
                sp.Anh = dr[7].ToString();
                li.Add(sp);
            }
            return li;
        }
        public List<SanPham> getSPbyTH(string id)
        {
            DataTable du = dc.getData("select * from SanPham where MaThuongHieu='" + id.Trim() + "'");
            List<SanPham> li = new List<SanPham>();
            foreach (DataRow dr in du.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr[0].ToString();
                sp.TenSP = dr[1].ToString();
                sp.MoTa = dr[2].ToString();
                sp.SoLuong = int.Parse(dr[3].ToString());
                sp.DonGia = int.Parse(dr[4].ToString());
                sp.MaLoaiSP = dr[5].ToString();
                sp.MaThuongHieu = dr[6].ToString();
                sp.Anh = dr[7].ToString();
                li.Add(sp);
            }
            return li;

        }
        public void CreateSP(SanPham sp)
        {
            string sql = "Insert into SanPham values('" + sp.MaSP + "',N'" + sp.TenSP + "',N'" + sp.MoTa + "','" + sp.SoLuong + "','" + sp.DonGia + "','" + sp.MaLoaiSP + "','" + sp.MaThuongHieu + "','" + sp.Anh + "')";
            dc.thucthisql(sql);
        }

        public void UpdateSP(SanPham sp)
        {
            string sql = "Update SanPham set TenSP=N'" + sp.TenSP + "', MoTa=N'" + sp.MoTa + "', SoLuong='" + sp.SoLuong + "', DonGia='" + sp.DonGia + "', MaLoaiSP='" + sp.MaLoaiSP + "', MaThuongHieu='" + sp.MaThuongHieu + "', Anh='" + sp.Anh + "' where MaSP='" + sp.MaSP + "'";
            dc.thucthisql(sql);
        }

        public void DeleteSP(string id)
        {
            string sql = "Delete from SanPham where MaSP='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public int kiemtramatrung(string id)
        {
            string sql = "Select count (*) from SanPham where MaSP='" + id + "'";
            return dc.Kiemtramatrung(sql);
        }
    }
}