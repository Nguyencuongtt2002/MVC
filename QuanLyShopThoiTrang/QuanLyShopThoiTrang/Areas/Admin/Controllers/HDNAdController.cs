using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Areas.Admin.Controllers
{
    public class HDNAdController : Controller
    {
        HDNModel dbhdn = new HDNModel();
        // GET: Admin/HDNAd
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getAllHDN()
        {
            List<HDN> li = dbhdn.getAllHDN();
            return Json(li, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get1HDN(string id)
        {
            HDN hdn = dbhdn.get1HDN(id);
            return Json(hdn, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult createHDN(HDN hdn)
        {
            dbhdn.CreateHDN(hdn);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }

        // Sua loai SP
        [HttpPost]
        public JsonResult updateHDN(HDN hdn)
        {
            dbhdn.UpdateHDN(hdn);
            return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Xoa loai SP
        public JsonResult deleteHDN(string id)
        {
            dbhdn.DeleteHDN(id);
            return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }

    }
}