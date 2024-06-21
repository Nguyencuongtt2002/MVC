//chuyên thực hiện các hàm trên đối tượng loại sản phẩm
myApp.controller("HDNAdController", ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/HDNAd/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Save";
    $scope.MaHDN = "";
    $scope.MaNV = "";
    $scope.MaNCC = "";
    $scope.MaSP = "";
    $scope.NgayNhap = "";
    $scope.SoLuong = "";
    $scope.DonGia = "";
    $scope.TongTien = "";
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadData = function () {
        var apiRoute = baseurl + "getALLHDN";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.listdata = res.data;
            $scope.HienThiSoLuong = Object.keys($scope.listdata).length;
        });
    }
    $scope.LoadData();
    // viết hàm lấy tất cả người dùng (nhân viên)
    var baseurlNV = "/Admin/NguoiDungs/";
    $scope.LoadNhanVien = function () {
        var apiRoute = baseurlNV + "getALLND";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.NV = res.data;
        });
    }
    $scope.LoadNhanVien();
    // viết hàm lấy tất cả sản phẩm
    var baseurlSP = "/Admin/SanPhamAd/";
    $scope.LoadDataSP = function () {
        var apiRoute = baseurlSP + "getAllSP";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.SP = res.data;
        });
    }
    $scope.LoadDataSP();

    //nut update --> save , chuyen ve rong 
    $scope.taomoi = function () {
        $scope.btnText = "Save";
        $scope.MaHDN = "";
        $scope.MaNV = "";
        $scope.MaNCC = "";
        $scope.MaSP = "";
        $scope.NgayNhap = "";
        $scope.SoLuong = "";
        $scope.DonGia = "";
    }

    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1HDN";
        var oneData = CrudService.getByID(apiRoute, s.MaHDN);
        oneData.then(function (res) {
            $scope.MaHDN = res.data.MaHDN;
            $scope.MaNV = res.data.MaNV;
            $scope.MaNCC = res.data.MaNCC;
            $scope.MaSP = res.data.MaSP;
            $scope.NgayNhap = res.data.NgayNhap;
            $scope.SoLuong = res.data.SoLuong;
            $scope.DonGia = res.data.DonGia;
            $scope.btnText = "Update";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm thêm/sửa
    $scope.CreateUpdate = function () {
        var singleData = {
            MaHDN: $scope.MaHDN,
            MaNV: $scope.MaNV,
            MaNCC: $scope.MaNCC,
            MaSP: $scope.MaSP,
            NgayNhap: $scope.NgayNhap,
            SoLuong: $scope.SoLuong,
            DonGia: $scope.DonGia,
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Save") {
            var apiRoute = baseurl + "createHDN";
            var creData = CrudService.post(apiRoute, singleData);
            creData.then(function (res) {
                if (res.data != "") {
                    alert("Thêm thành công!");
                    $scope.LoadData();
                }
                else {
                    alert("Lỗi hệ thống!");
                }
            }, function (error) {
                console.log("Lỗi: " + error);
            });
        }
        else {
            var apiRoute = baseurl + "updateHDN";
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
        if (!confirm("Bạn có chắc chắn muốn xóa mã HDN: " + s.MaHDN + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteHDN";
        var delData = CrudService.getByID(apiRoute, s.MaHDN);
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