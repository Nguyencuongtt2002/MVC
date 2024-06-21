using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Controllers
{
    public class GioHangController : Controller
    {
        SanPhamModel dbsp = new SanPhamModel();
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult MuaHang(string id)
        {
            List<GioHang> gh = null;//tao danh sach gio hang khoi tao null
            int tongtien = 0;
            int soluong = 0;
            if (Session["giohang"] == null)
            {
                //thêm( a là 1 đối tượng sản phẩm khi ấn mua add vào giỏ hàng )
                GioHang a = new GioHang();
                var sp = dbsp.get1SP(id);
                a.ID = sp.MaSP;
                a.Ten = sp.TenSP;
                a.Anh = sp.Anh;
                a.SL = 1;
                a.Gia = (int)sp.DonGia;
                //thêm vào list
                gh = new List<GioHang>();
                gh.Add(a);
                soluong = soluong + 1;
                tongtien = soluong * a.Gia;
                Session["giohang"] = gh;// mua sản phẩm đc lưu vào list từ list lưu vào session 
            }
            else
            {
                gh = (List<GioHang>)Session["giohang"];
                //khai báo biến lưu trữ sp đang có trong gio hang
                var test = gh.Find(s => s.ID == id);
                if (test == null)
                {
                    GioHang a = new GioHang();
                    var sp = dbsp.get1SP(id);
                    a.ID = sp.MaSP;
                    a.Ten = sp.TenSP;
                    a.Anh = sp.Anh;
                    a.SL = 1;
                    a.Gia = (int)sp.DonGia;
                    gh.Add(a);
                    tongtien = tongtien + (a.SL * a.Gia);
                    Session["giohang"] = gh;
                }
                else
                {
                    test.SL = int.Parse(test.SL.ToString()) + 1;
                }
                Session["giohang"] = gh;
                foreach (GioHang x in gh)
                {
                    tongtien += x.SL * x.Gia;
                    soluong += x.SL;
                }
            }
            return Json(new { giohang = gh, tongtien = tongtien, soluong = soluong }, JsonRequestBehavior.AllowGet);
        }
        // hiển thị sản phẩm đã mua ra trang giỏ hàng 
        public JsonResult LoadGioHang()
        {
            List<GioHang> gh = new List<GioHang>(); // tạo 1 list đặt tên là gh 
            int tongtien = 0;
            int soluong = 0;
            if (Session["giohang"] != null)
            {
                gh = (List<GioHang>)Session["giohang"];//gh lưu tất cả các thông tin trong session giỏ hàng 
            }
            foreach (GioHang a in gh)
            {
                tongtien += a.SL * a.Gia;
                soluong += a.SL;
            }
            // đăng nhập để lưu các thông tinvào session sau đó taọ  ra các biến để lưu các thông tin trong session 
            string taikhoan = Session["TaiKhoan"].ToString();
            string HoTen = Session["HoTen"].ToString();
            string diachi = Session["DiaChi"].ToString();
            string sdt = Session["Phone"].ToString();
            string Email = Session["Email"].ToString();

            

            // trả ra các thông tin 
            return Json(new { giohang = gh, tongtien = tongtien, soluong = soluong , HoTen= HoTen,diachi= diachi,sdt= sdt , taikhoan = taikhoan ,Email = Email}, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Tang1SP(string id)
        {
            List<GioHang> gh = (List<GioHang>)Session["giohang"];
            var test = gh.Find(s => s.ID == id);
            if (test != null)
            {
                test.SL = int.Parse(test.SL.ToString()) + 1;
            }
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Giam1SP(string id)
        {

            List<GioHang> gh = (List<GioHang>)Session["giohang"];
            var test = gh.Find(s => s.ID == id);
            int sl = int.Parse(test.SL.ToString());
            if (sl > 1)
            {
                test.SL = sl - 1;
            }
            else
            {
                gh.Remove(test);
            }
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Xoa1SP(string id)
        {
            List<GioHang> gh = (List<GioHang>)Session["giohang"];
            var test = gh.Find(s => s.ID == id);
            if (test != null)
            {
                gh.Remove(test);
            }
            Session["giohang"] = gh;
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
        public ViewResult Payment()
        {
            return View();
        }
        public JsonResult XoaALLSP()
        {
            Session.Remove("giohang");
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult KiemTraTaiKhoan()
        {
            if (Session["TaiKhoan"].ToString() == "")
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}