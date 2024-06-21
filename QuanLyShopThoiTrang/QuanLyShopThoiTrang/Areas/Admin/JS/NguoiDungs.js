//chuyên thực hiện các hàm trên đối tượng loại sản phẩm
myApp.controller("NguoiDungsController", ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/NguoiDungs/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Save";
    $scope.TaiKhoan = "";
    $scope.HoTen = "";
    $scope.DiaChi = "";
    $scope.Phone = "";
    $scope.email = "";
    $scope.MatKhau  = "";
    $scope.Confirm_MatKhau = "";

    //viết hàm lấy tất cả sản phẩm
    $scope.LoadData = function () {
        var apiRoute = baseurl + "getALLND";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.listdata = res.data;
            $scope.HienThiSoLuong = 5;
        });
    }
    $scope.LoadData();
    //nut update --> save , chuyen ve rong 
    $scope.taomoi = function () {
        $scope.btnText = "Save";
        $scope.TaiKhoan = "";
        $scope.HoTen  = "";
        $scope.DiaChi = "";
        $scope.Phone = "";
        $scope.email = "";
        $scope.MatKhau  = "";
        $scope.Confirm_MatKhau = "";
    }



    ////viết hàm lấy tất cả loai sản phẩm
    //var baseurlLSP = "/Admin/LoaiSPAd/";
    //$scope.LoadDataLSP = function () {
    //    var apiRoute = baseurlLSP + "getAllLSP";
    //    var allData = CrudService.getAll(apiRoute);

    //    allData.then(function (res) {
    //        $scope.LSP = res.data;
    //    });
    //}
    //$scope.LoadDataLSP();
    ////viết hàm lấy tất cả thương hiệu
    //var baseurlTH = "/Admin/ThuongHieuAd/";
    //$scope.LoadThuongHieu = function () {
    //    var apiRoute = baseurlTH + "getALLTH";
    //    var allData = CrudService.getAll(apiRoute);

    //    allData.then(function (res) {
    //        $scope.TH = res.data;
    //    });
    //}
    //$scope.LoadThuongHieu();


    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1ND";
        var oneData = CrudService.getByID(apiRoute, s.TaiKhoan);
        oneData.then(function (res) {
            $scope.TaiKhoan = res.data.TaiKhoan;
            $scope.HoTen = res.data.HoTen ;
            $scope.DiaChi = res.data.DiaChi;
            $scope.Phone = res.data.Phone;
            $scope.email = res.data.email;
            $scope.MatKhau = res.data.MatKhau ;
            $scope.Confirm_MatKhau = res.data.Confirm_MatKhau;
            $scope.btnText = "Update";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm thêm/sửa
    $scope.CreateUpdate = function () {
        var singleData = {
            TaiKhoan: $scope.TaiKhoan,
            HoTen: $scope.HoTen ,
            DiaChi: $scope.DiaChi,
            Phone: $scope.Phone,
            email: $scope.email,
            MatKhau: $scope.MatKhau ,
            Confirm_MatKhau: $scope.Confirm_MatKhau,
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Save") {
            $.get("/Admin/NguoiDungs/KiemTraMaTrung", { id: $scope.TaiKhoan }, function (data) {
                if (data == 1) {
                    alert("Mã đã tồn tại");
                }
                else {
                    var apiRoute = baseurl + "createND";
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
            var apiRoute = baseurl + "updateND";
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
        if (!confirm("Bạn có chắc chắn muốn xóa người dùng: " + s.TaiKhoan + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteND";
        var delData = CrudService.getByID(apiRoute, s.TaiKhoan);
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