using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
namespace QuanLyShopThoiTrang.Areas.Admin.Controllers
{
    public class SanPhamAdController : Controller
    {
        SanPhamModel dbsp = new SanPhamModel();
        // GET: Admin/SanPham
        public ActionResult Index( string MatKhau)
        {
            
            return View();
        }
        //Lấy toàn bộ sản phẩm
        public JsonResult getALLSP()
        {
            List<SanPham> li = dbsp.getAllSP();
            return Json(li, JsonRequestBehavior.AllowGet);
        }

        //Lấy 1 sản phẩm
        public JsonResult get1SP(string id)
        {
            SanPham sp = dbsp.get1SP(id);
            return Json(sp, JsonRequestBehavior.AllowGet);
        }
        
       
        //Tạo mới sản phẩm
        [HttpPost]
        public JsonResult createSP(SanPham sp)
        {
            dbsp.CreateSP(sp);
            return Json(new { success = "Thêm thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Sửa sản phẩm
        [HttpPost]
        public JsonResult updateSP(SanPham sp)
        {
            dbsp.UpdateSP(sp);
            return Json(new { success = "Sửa thành công" }, JsonRequestBehavior.AllowGet);
        }

        //Xoá sản phẩm
        public JsonResult deleteSP(string id)
        {
            dbsp.DeleteSP(id);
            return Json(new { success = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
        }
        //kiểm tra mã trùng
        public int kiemtramatrung(string id)
        {
            return dbsp.kiemtramatrung(id);
        }

    }
}