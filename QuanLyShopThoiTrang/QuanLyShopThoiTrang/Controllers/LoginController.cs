using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyShopThoiTrang.Models;
using System.Security.Cryptography;
namespace ProjectMVC5.Controllers
{
    public class LoginController : Controller
    {
        NguoiDungModel dlnd = new NguoiDungModel();
        private DoAn3_NguyenVanCuongEntities _db = new DoAn3_NguyenVanCuongEntities();
        // GET: Home


        //session đẻ lưu trữ 1 biến hoặc giá trị để trang view gọi ra hiển thị ra gd 
        public ActionResult Index()
        {
            if (Session["HoTen"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //GET: Register

        public ActionResult DangKy()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(NguoiDung _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.NguoiDung.FirstOrDefault(s => s.email == _user.email);
                if (check == null)
                {
                    _user.MatKhau = GetMD5(_user.MatKhau);
                    _user.Confirm_MatKhau = GetMD5(_user.Confirm_MatKhau);
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.NguoiDung.Add(_user);
                    _db.SaveChanges();
                    return RedirectToAction("DangNhap","Login");
                }
                else
                {
                    return View();
                }


            }
            return View();


        }

        public ActionResult DangNhap()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(NguoiDung _user, string MatKhau)
        {
            string userMail = _user.email;
            string password = GetMD5(MatKhau);
            // kiểm tra email và mk có tồn tại hay ko 
            var islogin = _db.NguoiDung.SingleOrDefault(x => x.email.Equals(userMail) && x.MatKhau.Equals(password));
            var nd = dlnd.getAllND();
            if (islogin != null)
            {
                if (userMail == "Admin@gmail.com")
                {
                    var hoten = nd.SingleOrDefault(s => s.email.ToString().Contains(_user.email)).HoTen;
                     Session["HoTen"] = hoten;
                    //Session["Email"] = userMail;
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Admin/HomeAd");
                }
                else
                {

                    var taikhoan = nd.SingleOrDefault(s => s.email.ToString().Contains(_user.email)).TaiKhoan;
                    var hoten = nd.SingleOrDefault(s => s.email.ToString().Contains(_user.email)).HoTen;
                    var diachi = nd.SingleOrDefault(s => s.email.ToString().Contains(_user.email)).DiaChi;
                    var sdt = nd.SingleOrDefault(s => s.email.ToString().Contains(_user.email)).Phone;
                    // sử dụng truy vấn linq để lấy ra các thông tin sau đó session lưu các thông tin đấy 

                    Session["TaiKhoan"] = taikhoan;
                    Session["HoTen"] = hoten;
                    Session["DiaChi"] = diachi;
                    Session["Phone"] = sdt;


                    Session["Email"] = userMail;
                    Session["DangNhap"] = "Đăng xuất ";
                    Session["LinkDangNhap"] = "/Login/DangXuat";
                    Session["LinkDangKy"] = "";
                    Session["use"] = islogin;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("DangNhap");
            }


        }


        //Logout
        public ActionResult Logout()
        {
            //Session.Clear();//remove session
            Session["HoTen"] = "Đăng ký";
            Session["LinkDangKy"] = "/Login/DangKy";

            Session["TaiKhoan"] = "";
            Session["Email"] = "";
            Session["DiaChi"] = "";
            Session["Phone"] = "";

            Session["DangNhap"] = "Đăng nhập";
            Session["LinkDangNhap"] = "/Login/DangNhap";
            return RedirectToAction("DangNhap","Login");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}