using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        SanPhamModel dbsp = new SanPhamModel();
        LoaiSPModel dblsp = new LoaiSPModel();
        ThuongHieuModel dbth = new ThuongHieuModel();
        KhuyenMaiModel dbkm = new KhuyenMaiModel();
        DoAn3_NguyenVanCuongEntities db = new DoAn3_NguyenVanCuongEntities();
        // GET: Home
        public ActionResult Index()
        {
                //List<SanPham> li = dbsp.getAllSP();
                return View(/*li*/);
            
        }
        //Xem chi tiet 
        public ViewResult ChiTiet(/*string id*/)
        {
            
            //SanPham sp = dbsp.get1SP(id);
            return View(/*sp*/);
        }

        //lấy 1 sp
        public JsonResult get1SP(string id)
        {
            SanPham sp = dbsp.get1SP(id);
            Session["ChiTietSP"] = sp;
            return Json(sp, JsonRequestBehavior.AllowGet);
        }
        //load chi tiết
        public JsonResult LoadChiTiet()
        {
            SanPham ctsp = (SanPham)Session["ChiTietSP"];
            return Json(new {ctsp = ctsp}, JsonRequestBehavior.AllowGet);
        }
        //loai san pham 

        public JsonResult getAllLSP()
        {
            List<LoaiSanPham> li = dblsp.getAllLSP();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public ViewResult LoaiSanPham()
        {
           
            return View();
        }
        //session đẻ lưu trữ 1 biến hoặc giá trị để trang view gọi ra hiển thị ra gd 

        public JsonResult getSPByLSP(string id)
        {
            List<SanPham> li = dbsp.getSPbyLSP(id);
            Session["LoaiSP"] = li;
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadLoaiSP()
        {
            List<SanPham> loaisp = new List<SanPham>();
            loaisp = (List<SanPham>)Session["LoaiSP"];
            return Json(new { loaisp = loaisp }, JsonRequestBehavior.AllowGet);
        }

        public ViewResult ThuongHieu()
        {
          
            return View();
        }
        public JsonResult getSPbyTH(string id)
        {
            List<SanPham> li = dbsp.getSPbyTH(id);
            Session["ThuongHieu"] = li;
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadThuongHieu()
        {
            List<SanPham> thuonghieu = new List<SanPham>();
            thuonghieu = (List<SanPham>)Session["ThuongHieu"];
            return Json(new { thuonghieu = thuonghieu }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAllTH()
        {
            List<ThuongHieu> li = dbth.getAllTH();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
    }
}