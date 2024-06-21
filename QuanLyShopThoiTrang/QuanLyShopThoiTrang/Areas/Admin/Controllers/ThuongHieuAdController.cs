using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
using PagedList;
namespace QuanLyShopThoiTrang.Areas.Admin.Controllers
{
    public class ThuongHieuAdController : Controller
    {
        ThuongHieuModel dbth = new ThuongHieuModel();
        // GET: Admin/ThuongHieuAd
        public ActionResult Index(int? page = 1)
        {
            List<ThuongHieu> li = dbth.getAllTH();
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(li.ToPagedList(pageNumber, pageSize));
        }
        //Lấy toàn bộ sản phẩm
        public JsonResult getALLTH()
        {
            List<ThuongHieu> li = dbth.getAllTH();
            return Json(li, JsonRequestBehavior.AllowGet);
        }

        //Lấy 1 sản phẩm
        public JsonResult get1TH(string id)
        {
            ThuongHieu th = dbth.get1TH(id);
            return Json(th, JsonRequestBehavior.AllowGet);
        }

        //Tạo mới sản phẩm
        [HttpPost]
        public JsonResult createTH(ThuongHieu th)
        {
            dbth.CreateTH(th);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Sửa sản phẩm
        [HttpPost]
        public JsonResult updateTH(ThuongHieu th)
        {
            dbth.UpdateTH(th);
            return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Xoá sản phẩm
        public JsonResult deleteTH(string id)
        {
            dbth.DeleteTH(id);
            return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }

        public int kiemtramatrung(string id)
        {
            return dbth.kiemtramatrung(id);
        }
    }
}