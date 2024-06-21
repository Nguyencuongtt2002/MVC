using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QuanLyShopThoiTrang.Models;

namespace QuanLyShopThoiTrang.Controllers
{
    public class HomeController : Controller
    {
        SanPhamModel dbsp = new SanPhamModel();
        LoaiSPModel dblsp = new LoaiSPModel();
        TinTucModel dbtt = new TinTucModel();
        KhuyenMaiModel dbkm = new KhuyenMaiModel();
            // GET: Home
        public ViewResult Index()
        {
            if (Session["HoTen"] == null)
            {
              

                Session["TaiKhoan"] = "";
                Session["Email"] = "";
                Session["DiaChi"] = "";
                Session["Phone"] = "";

                Session["DangNhap"] = "Đăng nhập ";
                Session["LinkDangKy"] = "/Login/DangNhap";

                Session["HoTen"] = " Đăng ký ";
                Session["LinkDangNhap"] = "/Login/Logout";
            }
            return View();//nhớ mang danh sách sản phẩm sang view
        }
        //lấy tất cả sản phẩm trả ra dạng Json 
        public JsonResult getAllSP()
        {
            List<SanPham> li = dbsp.getAllSP();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        //lấy tất cả tin tức trả ra dạng Json 
        public ActionResult TinTuc()
        {
           
            return View();//nhớ mang danh sách sản phẩm sang view
        }
        public JsonResult getAllTT()
        {
            List<TinTuc> li = dbtt.getAllTT();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public ViewResult SanPhamKhuyenMai()
        {
           
            return View();
        }
        public JsonResult getAllKM()
        {
            List<KhuyenMai> li = dbkm.getAllKM();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
    }
}