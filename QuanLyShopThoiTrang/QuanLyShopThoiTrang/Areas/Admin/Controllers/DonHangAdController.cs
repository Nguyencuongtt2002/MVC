using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Areas.Admin.Controllers
{
    public class DonHangAdController : Controller
    {
        DonHangModel dbdh = new DonHangModel();
        // GET: Admin/DonHangAd
        public ActionResult Index()
        {
           
            return View();
        }
        public JsonResult getAllDH()
        {
            List<DonHang> li = dbdh.getAllDH();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getAllCTDH()
        {
            List<CTDonHang> li = dbdh.getAllCTDH();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get1DH(string id)
        {
            DonHang dh = dbdh.get1DH(id);
            return Json(dh, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult createDH(DonHang dh)
        {
            dbdh.CreateDH(dh);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult updateDH(DonHang dh)
        {
            dbdh.UpdateDH(dh);
            return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult deleteDH(string id)
        {
            dbdh.DeleteDH(id);
            return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult deleteCTDH(string id)
        {
            dbdh.DeleteCTDH(id);
            return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }
    }
}