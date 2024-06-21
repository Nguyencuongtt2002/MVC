myApp.controller("HomeController", ['$scope', 'CrudService', function ($scope, CrudService) {
  $scope.listdata = [];
  $scope.list = [];
  $scope.currentPage = 1;
  $scope.itemsPerPage = 10;
    //khai báo thư mục gốc
    var baseurl = "/Home/";
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadData = function () {
        var apiRoute = baseurl + "getAllSP";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
          $scope.listdata = res.data;
       
        });
    }
  $scope.LoadData();
  //khai báo thư mục gốc
  var baseurl1 = "/Home/";
  //viết hàm lấy tất cả tin tức 
  $scope.LoadData1 = function () {
    var apiRoute = baseurl1 + "getAllTT";
    var allData = CrudService.getAll(apiRoute);

    allData.then(function (res) {
      $scope.listdata1 = res.data;
    });
  }
  $scope.LoadData1();


  var baseurl2 = "/SanPham/";
  //viết hàm lấy tất cả loại SP
  $scope.LoadData2 = function () {
    var apiRoute = baseurl2 + "getAllLSP";
    var allData = CrudService.getAll(apiRoute);

    allData.then(function (res) {
      $scope.listloaisp = res.data;
    });
  }
  $scope.LoadData2();
  var baseurl3 = "/SanPham/";
  //viết hàm lấy tất cả thương hiêu
  $scope.LoadData3 = function () {
    var apiRoute = baseurl3 + "getAllTH";
    var allData = CrudService.getAll(apiRoute);

    allData.then(function (res) {
      $scope.listthuonghieu = res.data;
    });
  }
  $scope.LoadData3();
  var baseurl4 = "/Home/";
  //viết hàm lấy tất cả Khuyến mại
  $scope.LoadData4 = function () {
    var apiRoute = baseurl4 + "getAllKM";
    var allData = CrudService.getAll(apiRoute);

    allData.then(function (res) {
      $scope.list = res.data;
    });
  }
  $scope.LoadData4();

  //Mua hàng  
  $scope.muahang = function (s) {
    alert("thêm vào giỏ hàng thành công");
    $.get("/GioHang/MuaHang", { id: s }, function (data) {
      $("#count-cart").html(data.soluong);
      $("#total_price").html(numberWithCommas(data.tongtien));
      $("#show-cart").html("");
      $.each(data.giohang, function (i, val) {
        $("#show-cart").append("<tr class='cart_item'>"
          + "<td class='product-remove'>"
          + "<div class='bt_remove_product left' data-product-code='" + val.ID + "'>" + "</div>"
          + "</td>"
          + "<td class='product-name'>"
          + "<b>" + val.Ten + "</b>"
          + "<div class='clr'></div>"
          + "<div class='box_quantity left'>"
          + "<div class='quantity right'>"
          + "<input class='bt_minus' type='button' value='-' data-product-code='" + val.ID + "'>"
          + "<input type='text' disabled='' name='product_cart_qty' value='" + val.SL + "' title='Qty' class='input-text qty text product_qty' size='4'>"
          + "<input class='bt_plus' type='button' value='+' data-product-code='" + val.ID + "'>"
          + "</div>"
          + "</div>"
          + "</td>"
          + "<td class='product-price' valign='top'>"
          + "<span class='amount'>" + numberWithCommas(val.SL * val.Gia) + "</span>"
          + "</td>"
          + "</tr>");
        
      });
    });
   
  }

  //chuyển thành dang tiền 
  function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
  }
  //hiển thị giỏ hàng bé
  $scope.hienthigio = function() {
    $.get("/GioHang/LoadGioHang", function (data) {
      $("#count-cart").html(data.soluong);
      $("#total_price").html(numberWithCommas(data.tongtien));
      $("#show-cart").html("");
      $.each(data.giohang, function (i, val) {
        
        $("#show-cart").append("<tr class='cart_item'>"
          + "<td class='product-remove'>"
          + "<div class='bt_remove_product left' data-product-code='" + val.ID + "'>" + "</div>"
          + "</td>"
          + "<td class='product-name'>"
          + "<b>" + val.Ten + "</b>"
          + "<div class='clr'></div>"
          + "<div class='box_quantity left'>"
          + "<div class='quantity right'>"
          + "<input class='bt_minus' type='button' value='-' data-product-code='" + val.ID + "'>"
          + "<input type='text' disabled='' name='product_cart_qty' value='" + val.SL + "' title='Qty' class='input-text qty text product_qty' size='4'>"
          + "<input class='bt_plus' type='button' value='+' data-product-code='" + val.ID + "'>"
          + "</div>"
          + "</div>"
          + "</td>"
          + "<td class='product-price' valign='top'>"
          + "<span class='amount'>" + numberWithCommas(val.SL * val.Gia) + "</span>"
          + "</td>"
          + "</tr>");
      });
    });
  }
  $scope.hienthigio();
  //tăng 1 sản phẩm trong giỏ hàng nhỏ 
  $("#show-cart").on("click", ".bt_plus", function (event) {
    var productcode = $(this).attr("data-product-code");
    $.get("/GioHang/Tang1SP", { id: productcode }, function (data) {
      if (data.success == true) {
        window.location.reload();//tu reset
      }
    });
  });
  // giảm 1 sản phẩm trong giỏ hàng nhỏ
  $("#show-cart").on("click", ".bt_minus", function (event) {
    var productcode = $(this).attr("data-product-code");
    $.get("/GioHang/Giam1SP", { id: productcode }, function (data) {
      if (data.success == true) {
        window.location.reload();
      }
    });
  });
  // xóa 1 Sản Phẩm trong giỏ hàng nhỏ 
  $("#show-cart").on("click", ".bt_remove_product", function (event) {
    var productcode = $(this).attr("data-product-code");
    $.get("/GioHang/Xoa1SP", { id: productcode }, function (data) {
      if (data.success == true) {
        window.location.reload();
      }
    });
  });

  // hiển thị sản phẩm trong trang giỏ hàng 
  $scope.hienthitrangGH = function ()  {
    $.get("/GioHang/LoadGioHang", function (data) {
      $("#count-item-cart").html(data.soluong);
      $("#total-item-price").html(numberWithCommas(data.tongtien));
      $("#show-item-cart").html("");
      $.each(data.giohang, function (i, val) {
        $("#show-item-cart").append("<tr>"
          + "<td class='cart_product'>"
          + "<a href='#'><img src='/Content/images/" + val.Anh + "' alt='Product'></a>"
          + "</td>"
          + "<td class='cart_description'>"
          + "<p class='product-name'><a href='#'>" + val.Ten + "</a></p>"
          + "<small class='cart_ref'>Product Code : " + val.ID + "</small>"
          + "<br>"
          + "</td>"
          //+ "<td class='cart_avail'><span class='label label-success'>In stock</span></td>"
          + "<td class='price'><span style='color: #e84d1c; font-size: 18px; font-weight: bold;'>" + numberWithCommas(val.Gia) + "</span></td>"
          + "<td class='qty'>"
          + "<input class='form-control input-sm' type='text' readonly value='" + val.SL + "'>"
          + "<a class='plus' data-product-code='" + val.ID + "'><i class='fa fa-caret-up'></i></a>"
          + "<a class='minus' data-product-code='" + val.ID + "'><i class='fa fa-caret-down'></i></a>"
          + "</td>"
          + "<td class='price'>"
          + "<span style='color: #e84d1c; font-size: 18px; font-weight: bold;'>" + numberWithCommas(val.SL * val.Gia) + "</span>"
          + "</td>"
          + "<td class='action'>"
          + "<a class='remove_product' data-product-code='" + val.ID + "'>Delete item</a>"
          + "</td>"
          + "</tr>");
      });
    });
  }
  // xóa 1 sản phẩm bên trang giỏ hàng 
  $scope.hienthitrangGH();
  $("#show-item-cart").on("click", ".remove_product", function (event) {
    var productcode = $(this).attr("data-product-code");
    $.get("/GioHang/Xoa1SP", { id: productcode }, function (data) {
      if (data.success == true) {
        window.location.reload();
      }
    });
  });
  // giảm 1 sản phẩm trong trang giỏ hàng 
  $("#show-item-cart").on("click", ".minus", function (event) {
    var productcode = $(this).attr("data-product-code");
    $.get("/GioHang/Giam1SP", { id: productcode }, function (data) {
      if (data.success == true) {
        window.location.reload();
      }
    });
  });
  // tăng 1 sản phẩm trong trang giỏ hàng 
  $("#show-item-cart").on("click", ".plus", function (event) {
    var productcode = $(this).attr("data-product-code");
    $.get("/GioHang/Tang1SP", { id: productcode }, function (data) {
      if (data.success == true) {
        window.location.reload();
      }
    });
  });


  //Đặt hàng kiểm tra tài khoản
  $scope.DatHang = function () {
    $.get("/GioHang/KiemTraTaiKhoan", function (data) {
      if (data.success == false) {
        if (confirm("Vui lòng đăng nhâp  trước khi mua hàng ! ")) {
           window.location.href = '/Login/DangNhap/';
         
        }
      }
      else {
        $.get("/GioHang/LoadGioHang", function (data1) {
          if (data1.soluong == 0) {
            alert("Chưa có sản phẩm nào trong giỏ hàng");
          }
          else {
            alert("Đặt hàng thành công");
            window.location.href = '/GioHang/Payment/';
          }
        });
      }
    });
  }
  //Hiển thị thanh toán
  $scope.hienthithanhtoan = function () {
    $.get("/GioHang/LoadGioHang", function (data) {
      //data là các thông tin 
      $scope.HoTen = data.HoTen;
      $scope.diachi = data.diachi;
      $scope.sdt = data.sdt;
      $scope.Email = data.Email;
      $scope.soluong = data.soluong;
      $scope.TongTien = data.tongtien;
      $scope.TaiKhoan = data.taikhoan;
    });
  }
  $scope.hienthithanhtoan();

  //thanh toán
  $scope.ThanhToan = function () {
    var donhang = {  // tạo  json để lưu  1 đơn hàng 
      NgayDat: LayNgay(),
      DiaChi: $scope.diachi,
      MaKH: $scope.TaiKhoan,
      MaNV: $scope.TaiKhoan,
      HoTen: $scope.HoTen,
      Email: $scope.Email,
      Phone: $scope.sdt,
      TongTien: $scope.TongTien,


    }
    // thêm 1 đơn hàng vào trong bảng đơn hàng 
    var baseurl1 = "/DonHang/";
    var apiRoute = baseurl1 + "CreateDH";
    var creData = CrudService.post(apiRoute, donhang);
    creData.then(function (res) { 
      if (res.data != "") {
        alert("Thanh toán thành công ");
        $.get("/DonHang/get1DHMOI", function (data1) { //lấy ra 1 đơn hàng mới nhất 
          $.get("/GioHang/LoadGioHang", function (datagh) {
            // trong trang giỏ hàng có bao nhiêu sản phẩm thì lặp bấy nhiêu lần 
            $.each(datagh.giohang, function (i, val) { //i là số lần lặp , val là các thông tin của sản phẩm trong bảng chi tiết 
              var CTDonHang = {
                MaDH: data1.MaDH,
                MaSP: val.ID,
                SoLuong: val.SL,
                GiaTien: val.Gia,
              }
              var apiRoute1 = baseurl1 + "createCTDH";
              CrudService.post(apiRoute1, CTDonHang);
            });
            // khi mua sản phẩm xong thì xóa all số lượng sản phẩm trong giỏ 
            $.get("/GioHang/XoaALLSP", function (data) {
              window.location.href = '/Home/Index';
            });
          });
        });
      }
    });

  }
  // lấy ngày 
  function LayNgay() {
    let today = new Date();

    let dd = (today.getDate());
    let MM = today.getMonth() + 1;
    let yyyy= today.getFullYear();

    return (dd + "-" + MM + "-" + yyyy);
  }

  //Chi tiết sản phẩm -------------------------------------------
  $scope.chitiet = function (masp) {
    $.get("/SanPham/get1SP", { id: masp }, function (data) {
      window.location.href = "/SanPham/ChiTiet/" + masp
    });
  }
  // lấy ra các thuộc tính lưu vào biến $scope hiển thị ra giao diện
  $scope.loadchitiet = function () {
    $.get("/SanPham/LoadChiTiet", function (data) {
      $scope.masp = data.ctsp.MaSP;
      $scope.tensp = data.ctsp.TenSP;
      $scope.mota = data.ctsp.MoTa;
      $scope.soluong = data.ctsp.SoLuong;
      $scope.dongia = data.ctsp.DonGia;
      $scope.maloaisp = data.ctsp.MaLoaiSP;
      $scope.mathuonghieu = data.ctsp.MaThuongHieu;
      $scope.anh = data.ctsp.Anh;
    })
  }
  $scope.loadchitiet();

  $scope.loaiSP = function (masp) {
    $.get("/SanPham/getSPByLSP", { id: masp }, function (data) {
      window.location.href = "/SanPham/LoaiSanPham/" + masp
    });
  }
  // lấy ra các thuộc tính lưu vào 1 list hiển thị ra giao diện
  $scope.loadLoai = function () {
    $.get("/SanPham/LoadLoaiSP", function (data) {
      $scope.listloai = data.loaisp
    })
  }
  $scope.loadLoai();

  $scope.Thuonghieu = function (masp) {
    $.get("/SanPham/getSPByTH", { id: masp }, function (data) {
      window.location.href = "/SanPham/ThuongHieu/" + masp
    });
  }
  // lấy ra các thuộc tính lưu vào 1 list hiển thị ra giao diện
  $scope.LoadTH = function () {
    $.get("/SanPham/LoadThuongHieu", function (data) {
      $scope.listTH = data.thuonghieu
      //console.log($scope.listthuonghieu)
      console.log(data);
    })
  }
  $scope.LoadTH();
}]);
