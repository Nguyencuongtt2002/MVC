using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Models
{
    public class NguoiDungModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<NguoiDung> getAllND()
        {
            DataTable dt = dc.getData("Select * from NguoiDung");
            List<NguoiDung> li = new List<NguoiDung>();
            foreach (DataRow dr in dt.Rows)
            {
                NguoiDung nd = new NguoiDung();
                nd.TaiKhoan = dr[0].ToString();
                nd.HoTen = dr[1].ToString();
                nd.DiaChi = dr[2].ToString();
                nd.Phone = dr[3].ToString();
                nd.email = dr[4].ToString();
                nd.MatKhau = dr[5].ToString();
                nd.Confirm_MatKhau = dr[6].ToString();
                li.Add(nd);
            }
            return li;
        }
        public NguoiDung get1ND(string ma)
        {
            NguoiDung nd = new NguoiDung();
            DataTable dt = dc.getData("Select * from NguoiDung where TaiKhoan='" + ma.Trim() + "'");
            nd.TaiKhoan = dt.Rows[0][0].ToString();
            nd.HoTen = dt.Rows[0][1].ToString();
            nd.DiaChi = dt.Rows[0][2].ToString();
            nd.Phone = dt.Rows[0][3].ToString();
            nd.email = dt.Rows[0][4].ToString();
            nd.MatKhau = dt.Rows[0][5].ToString();
            nd.Confirm_MatKhau = dt.Rows[0][6].ToString();
            return nd;
        }

        public void CreateND(NguoiDung nd)
        {
            string sql = "Insert into NguoiDung values('" + nd.TaiKhoan + "',N'" + nd.HoTen + "',N'" + nd.DiaChi+ "',N'" + nd.Phone + "','" + nd.email + "','" + nd.MatKhau + "','" + nd.Confirm_MatKhau+ "')";
            dc.thucthisql(sql);
        }
        public void UpdateND(NguoiDung nd)
        {
            string sql = "Update NguoiDung set HoTen=N'" + nd.HoTen + "', DiaChi=N'" + nd.DiaChi + "', Phone='" + nd.Phone + "',email=N'" + nd.email + "' ,MatKhau='" + nd.MatKhau + "',Confirm_MatKhau='" + nd.Confirm_MatKhau + "'  where TaiKhoan='" + nd.TaiKhoan + "'";
            dc.thucthisql(sql);
        }

        public void DeleteND(string id)
        {
            string sql = "Delete from NguoiDung where TaiKhoan='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public int kiemtramatrung(string id)
        {
            string sql = "Select count (*) from NguoiDung where TaiKhoan ='" + id + "'";
            return dc.Kiemtramatrung(sql);
        }
    }
}