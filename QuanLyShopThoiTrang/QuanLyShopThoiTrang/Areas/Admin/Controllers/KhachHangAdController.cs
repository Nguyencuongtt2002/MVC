using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;

namespace QuanLyShopThoiTrang.Areas.Admin.Controllers
{
    public class KhachHangAdController : Controller
    {
        // GET: Admin/KhachHangAd
        KhachHangModel dbkh = new KhachHangModel();
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            return View();
        }
        //Lấy toàn bộ sản phẩm
        public JsonResult getALLKH()
        {
            List<KhachHang> li = dbkh.getAllKH();
            return Json(li, JsonRequestBehavior.AllowGet);
        }

        //Lấy 1 sản phẩm
        public JsonResult get1KH(string id)
        {
            KhachHang kh = dbkh.get1KH(id);
            return Json(kh, JsonRequestBehavior.AllowGet);
        }

        //Tạo mới sản phẩm
        [HttpPost]
        public JsonResult createKH(KhachHang kh)
        {
            dbkh.CreateKH(kh);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Sửa sản phẩm
        [HttpPost]
        public JsonResult updateKH(KhachHang kh)
        {
            dbkh.UpdateKH(kh);
            return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Xoá sản phẩm
        public JsonResult deleteKH(string id)
        {
            dbkh.DeleteKH(id);
            return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }

        public int kiemtramatrung(string id)
        {
            return dbkh.kiemtramatrung(id);
        }
    }
}