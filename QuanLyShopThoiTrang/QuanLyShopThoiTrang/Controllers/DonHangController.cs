using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Controllers
{
    public class DonHangController : Controller
    {
        DonHangModel dbdh = new DonHangModel();
        // GET: DonHang
        public JsonResult getALLDH()
        {
            List<DonHang> li = dbdh.getAllDH();
            return Json(li, JsonRequestBehavior.AllowGet);
        }

        //Lấy 1 sản phẩm
        public JsonResult get1DH(string id)
        {
            DonHang dh = dbdh.get1DH(id);
            return Json(dh, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }
        //Tạo mới sản phẩm
        [HttpPost]
        public JsonResult createDH(DonHang dh)
        {
            dbdh.CreateDH(dh);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult get1DHMOI()
        {
            DonHang dh = dbdh.get1DHMOI();
            return Json(dh, JsonRequestBehavior.AllowGet);
        }

        public JsonResult createCTDH(CTDonHang ctdh)
        {
            dbdh.CreateCTDH(ctdh);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }

    }
}