using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
using PagedList;
namespace QuanLyShopThoiTrang.Areas.Admin.Controllers
{
    public class TinTucAdController : Controller
    {
        TinTucModel dbtt = new TinTucModel();
        // GET: Admin/TinTucAd
        public ActionResult Index(int? page = 1)
        {
            List<TinTuc> li = dbtt.getAllTT();
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(li.ToPagedList(pageNumber, pageSize));
        }
        public JsonResult getALLTT()
        {
            List<TinTuc> li = dbtt.getAllTT();
            return Json(li, JsonRequestBehavior.AllowGet);
        }

        //Lấy 1 sản phẩm
        public JsonResult get1TT(string id)
        {
            TinTuc tt = dbtt.get1TT(id);
            return Json(tt, JsonRequestBehavior.AllowGet);
        }

        //Tạo mới sản phẩm
        [HttpPost]
        public JsonResult createTT(TinTuc tt)
        {
            dbtt.CreateTT(tt);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Sửa sản phẩm
        [HttpPost]
        public JsonResult updateTT(TinTuc tt)
        {
            dbtt.UpdateTT(tt);
            return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Xoá sản phẩm
        public JsonResult deleteTT(string id)
        {
            dbtt.DeleteTT(id);
            return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }

        public int kiemtramatrung(string id)
        {
            return dbtt.kiemtramatrung(id);
        }
    }
}