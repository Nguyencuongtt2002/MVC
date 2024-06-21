using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Models
{
    public class LoaiSPModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả loại sản phẩm
        public List<LoaiSanPham> getAllLSP()
        {
            DataTable dt = dc.getData("Select * from LoaiSanPham");
            List<LoaiSanPham> li = new List<LoaiSanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSanPham lsp = new LoaiSanPham();
                lsp.MaLoaiSP = dr[0].ToString();
                lsp.TenLoaiSP = dr[1].ToString();

                li.Add(lsp);
            }
            return li;
        }
        public LoaiSanPham get1LSP(string id)
        {
            DataTable dt = dc.getData("Select * from LoaiSanPham where MaLoaiSP='" + id.Trim() + "'");
            LoaiSanPham lsp = new LoaiSanPham();
            lsp.MaLoaiSP = dt.Rows[0][0].ToString();
            lsp.TenLoaiSP = dt.Rows[0][1].ToString();
            return lsp;
        }

        public void CreateLSP(LoaiSanPham lsp)
        {
            string sql = "Insert into LoaiSanPham values('" + lsp.MaLoaiSP + "',N'" + lsp.TenLoaiSP + "')";
            dc.thucthisql(sql);
        }
        public void UpdateLSP(LoaiSanPham lsp)
        {
            string sql = "Update LoaiSanPham set TenLoaiSP=N'" + lsp.TenLoaiSP + "' where MaLoaiSP='" + lsp.MaLoaiSP + "'";
            dc.thucthisql(sql);
        }

        public void DeleteLSP(string id)
        {
            string sql = "Delete from LoaiSanPham where MaLoaiSP='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public int kiemtramatrung(string id)
        {
            string sql = "Select count (*) from LoaiSanPham where MaLoaiSP='" + id + "'";
            return dc.Kiemtramatrung(sql);
        }

    }
}