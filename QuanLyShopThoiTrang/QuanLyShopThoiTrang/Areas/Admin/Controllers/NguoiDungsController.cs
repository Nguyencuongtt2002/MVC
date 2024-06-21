using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Areas.Admin.Controllers
{
    public class NguoiDungsController : Controller
    {
        NguoiDungModel dbnd = new NguoiDungModel();
        // GET: Admin/NguoiDungs
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getAllND()
        {
            List<NguoiDung> li = dbnd.getAllND();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get1ND(string id)
        {
            NguoiDung nd = dbnd.get1ND(id);
            return Json(nd, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult createND(NguoiDung nd)
        {
            dbnd.CreateND(nd);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult updateND(NguoiDung nd)
        {
            dbnd.UpdateND(nd);
            return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult deleteND(string id)
        {
            dbnd.DeleteND(id);
            return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }
        public int kiemtramatrung(string id)
        {
            return dbnd.kiemtramatrung(id);
        }

    }
}