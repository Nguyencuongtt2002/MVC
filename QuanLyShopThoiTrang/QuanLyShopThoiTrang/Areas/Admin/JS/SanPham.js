//chuyên thực hiện các hàm trên đối tượng loại sản phẩm
myApp.controller("SanPhamAdController", ['$scope', 'CrudService', function ($scope, CrudService) {

    $scope.listdata = [];
    $scope.currentPage = 1;//khi nào trang web tải nó sẽ hiển thị trang đầu tiên dưới dạng trang hiện tại.
    $scope.itemsPerPage = 10;// số lượng sản phẩm hiển thị trong 1 trang
    //khai báo thư mục gốc
    var baseurl = "/Admin/SanPhamAd/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Save";
    $scope.MaSP = "";
    $scope.TenSP = "";
    $scope.MoTa = "";
    $scope.SoLuong = "";
    $scope.DonGia = "";
    $scope.MaLoaiSP = "";
    $scope.MaThuongHieu = "";
    $scope.Anh = "";

    //viết hàm lấy tất cả sản phẩm
    $scope.LoadData = function () {
        var apiRoute = baseurl + "getALLSP";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.listdata = res.data;
            $scope.Dem = Object.keys($scope.listdata).length;
            $scope.HienThiSoLuong = 10;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadData();
    //nut update --> save , chuyen ve rong 
    $scope.taomoi = function () {
        $scope.btnText = "Save";
        $scope.MaSP = "";
        $scope.TenSP = "";
        $scope.MoTa = "";
        $scope.SoLuong = "";
        $scope.DonGia = "";
        $scope.MaLoaiSP = "";
        $scope.MaThuongHieu = "";
        $scope.Anh = "";
    }



    //viết hàm lấy tất cả loai sản phẩm
    var baseurlLSP = "/Admin/LoaiSPAd/";
    $scope.LoadDataLSP = function () {
        var apiRoute = baseurlLSP + "getAllLSP";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.LSP = res.data;
        });
    }
    $scope.LoadDataLSP();
    //viết hàm lấy tất cả thương hiệu
    var baseurlTH = "/Admin/ThuongHieuAd/";
    $scope.LoadThuongHieu = function () {
        var apiRoute = baseurlTH + "getALLTH";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.TH = res.data;
        });
    }
    $scope.LoadThuongHieu();


    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1SP";
        var oneData = CrudService.getByID(apiRoute, s.MaSP);
        oneData.then(function (res) {
            $scope.MaSP = res.data.MaSP;
            $scope.TenSP = res.data.TenSP;
            $scope.MoTa = res.data.MoTa;
            $scope.SoLuong = res.data.SoLuong;
            $scope.DonGia = res.data.DonGia;
            $scope.MaLoaiSP = res.data.MaLoaiSP;
            $scope.MaThuongHieu = res.data.MaThuongHieu;
            $scope.Anh = res.data.Anh;
            $scope.btnText = "Update";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm thêm/sửa
    $scope.CreateUpdate = function () {
        var singleData = {
            MaSP: $scope.MaSP,
            TenSP: $scope.TenSP,
            MoTa: $scope.MoTa,
            SoLuong: $scope.SoLuong,
            DonGia: $scope.DonGia,
            MaLoaiSP: $scope.MaLoaiSP,
            MaThuongHieu: $scope.MaThuongHieu,
            Anh: $scope.Anh
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Save") {
            $.get("/Admin/SanPhamAd/KiemTraMaTrung", { id: $scope.MaSP }, function (data) {
                if (data == 1) {
                    alert("Mã đã tồn tại");
                }
                else {
                    var apiRoute = baseurl + "createSP";
                    var creData = CrudService.post(apiRoute, singleData);
                    creData.then(function (res) {
                        if (res.data != "") {
                            alert("Thêm thành công!");
                            $scope.LoadData();
                        }
                        else {
                            alert("Lỗi hệ thống!");
                        }
                    });
                }
            });
        }
        else {
            var apiRoute = baseurl + "updateSP";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Sửa thành công!");
                    $scope.LoadData();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        $("#exampleModal").modal("hide");
    }

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa sản phẩm: " + s.TenSP + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteSP";
        var delData = CrudService.getByID(apiRoute, s.MaSP);
        delData.then(function (res) {
            if (res != "") {
                alert("Xóa thành công!!!");
                $scope.LoadData();
            }
            else {
                alert("Lỗi hệ thống");
            }
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
  
   
}]);