using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Models
{
    public class DonHangModel
    {
        DataConnect dc = new DataConnect();
        //viết hàm lấy tất cả sản phẩm
        public List<DonHang> getAllDH()
        {
            DataTable dt = dc.getData("Select * from DonHang");
            List<DonHang> li = new List<DonHang>();
            foreach (DataRow dr in dt.Rows)
            {
                DonHang dh = new DonHang();
                dh.MaDH = int.Parse(dr[0].ToString());
                dh.NgayDat = dr[1].ToString();
                dh.DiaChi = dr[2].ToString();
                dh.MaKH = dr[3].ToString();
                dh.MaNV = dr[4].ToString();
                dh.HoTen = dr[5].ToString();
                dh.Email = dr[6].ToString();
                dh.Phone = dr[7].ToString();
                dh.TongTien = int.Parse(dr[8].ToString());
                li.Add(dh);
            }
            return li;
        }
        public List<CTDonHang> getAllCTDH()
        {
            DataTable dt = dc.getData("Select * from CTDonHang");
            List<CTDonHang> li = new List<CTDonHang>();
            foreach (DataRow dr in dt.Rows)
            {
                CTDonHang ctdh = new CTDonHang();
                ctdh.MaDH = int.Parse(dr[0].ToString());
                ctdh.MaSP = dr[1].ToString();
                ctdh.SoLuong = int.Parse(dr[2].ToString());
                ctdh.GiaTien = int.Parse(dr[3].ToString());
                li.Add(ctdh);
            }
            return li;
        }
        public DonHang get1DH(string ma)
        {
            DonHang dh = new DonHang();
            DataTable dt = dc.getData("Select * from DonHang where MaDH='" + ma.Trim() + "'");
            dh.MaDH = int.Parse(dt.Rows[0][0].ToString()); ;
            dh.NgayDat = dt.Rows[0][1].ToString(); ;
            dh.DiaChi = dt.Rows[0][2].ToString(); ;
            dh.MaKH = dt.Rows[0][3].ToString(); ;
            dh.MaNV = dt.Rows[0][4].ToString(); ;
            dh.HoTen = dt.Rows[0][5].ToString(); ;
            dh.Email = dt.Rows[0][6].ToString(); ;
            dh.Phone = dt.Rows[0][7].ToString();
            dh.TongTien = int.Parse(dt.Rows[0][8].ToString());
            return dh;
        }

        //lấy 1 đơn hàng mới nhất 
        public DonHang get1DHMOI()
        {
            DonHang dh = new DonHang();
            DataTable dt = dc.getData("Select top 1 * from DonHang  Order by MaDH Desc");
            dh.MaDH = int.Parse(dt.Rows[0][0].ToString()); ;
            dh.NgayDat = dt.Rows[0][1].ToString(); ;
            dh.DiaChi = dt.Rows[0][2].ToString(); ;
            dh.MaKH = dt.Rows[0][3].ToString(); ;
            dh.MaNV = dt.Rows[0][4].ToString(); ;
            dh.HoTen = dt.Rows[0][5].ToString(); ;
            dh.Email = dt.Rows[0][6].ToString(); ;
            dh.Phone = dt.Rows[0][7].ToString();
            dh.TongTien = int.Parse(dt.Rows[0][8].ToString());
            return dh;
        }

        public void CreateCTDH(CTDonHang ctdh)
        {
            string sql = "Insert into CTDonHang values('" + ctdh.MaDH + "','" + ctdh.MaSP + "','" + ctdh.SoLuong+ "','" + ctdh.GiaTien + "')";
            dc.thucthisql(sql);
        }
        public void CreateDH(DonHang dh)
        {
            string sql = "Insert into DonHang values('" + dh.NgayDat + "',N'" + dh.DiaChi + "','" + dh.MaKH + "','" + dh.MaNV + "',N'" + dh.HoTen + "','" + dh.Email + "',N'" + dh.Phone + "','" + dh.TongTien + "')";
            dc.thucthisql(sql);
        }
        public void UpdateDH(DonHang dh)
        {

            string sql = "Update DonHang set NgayDat='" + dh.NgayDat + "', DiaChi='" + dh.DiaChi + "', MaKH='" + dh.MaKH + "', MaNV='" + dh.MaNV + "', HoTen=N'" + dh.HoTen + "', Email='" + dh.Email + "', Phone='" + dh.Phone + "' , TongTien='" + dh.TongTien + "' where MaDH='" + dh.MaDH + "'";
            dc.thucthisql(sql);
        }

        public void DeleteDH(string id)
        {
            string sql = "Delete from DonHang where MaDH='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
        public void DeleteCTDH(string id)
        {
            string sql = "Delete from CTDonHang where MaDH='" + id.Trim() + "'";
            dc.thucthisql(sql);
        }
    }
}