using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
using PagedList;
namespace QuanLyShopThoiTrang.Areas.Admin.Controllers
{
    public class LoaiSPAdController : Controller
    {
        LoaiSPModel dblsp = new LoaiSPModel();
        // GET: Admin/LoaiSPAd
        public ActionResult Index(int? page = 1)
        {
            List<LoaiSanPham> li = dblsp.getAllLSP();
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(li.ToPagedList(pageNumber, pageSize));
        }
        public JsonResult getAllLSP()
        {
            List<LoaiSanPham> li = dblsp.getAllLSP();
            return Json(li, JsonRequestBehavior.AllowGet);
        }

        //lay 1 loai san pham
        public JsonResult get1LSP(string id)
        {
            LoaiSanPham lsp = dblsp.get1LSP(id);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        //them loai SP
        [HttpPost]
        public JsonResult createLSP(LoaiSanPham lsp)
        {
            dblsp.CreateLSP(lsp);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }

        // Sua loai SP
        [HttpPost]
        public JsonResult updateLSP(LoaiSanPham lsp)
        {
            dblsp.UpdateLSP(lsp);
            return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Xoa loai SP
        public JsonResult deleteLSP(string id)
        {
            dblsp.DeleteLSP(id);
            return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }

        public int kiemtramatrung(string id)
        {
            return dblsp.kiemtramatrung(id);
        }
    }
}