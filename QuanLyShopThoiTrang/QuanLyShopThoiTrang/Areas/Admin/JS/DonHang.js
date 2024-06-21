//chuyên thực hiện các hàm trên đối tượng loại sản phẩm
myApp.controller("DonHangAdController", ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/DonHangAd/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Save";
    $scope.NgayDat = "";
    $scope.DiaChi = "";
    $scope.MaKH = "";
    $scope.MaNV  = "";
    $scope.HoTen = "";
    $scope.Email = "";
    $scope.Phone = "";
    $scope.TongTien = "";
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadData = function () {
        var apiRoute = baseurl + "getAllDH";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.listdata = res.data;
            $scope.Dem = Object.keys($scope.listdata).length;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadData();
    //nut update --> save , chuyen ve rong 
    $scope.taomoi = function () {
        $scope.btnText = "Save";
        $scope.NgayDat = "";
        $scope.DiaChi = "";
        $scope.MaKH = "";
        $scope.MaNV  = "";
        $scope.HoTen = "";
        $scope.Email = "";
        $scope.Phone = "";
        $scope.TongTien = "";
    }


    var baseurl1 = "/DonHangAd/";
    //viết hàm lấy tất cả tin tức 
    $scope.LoadData1 = function () {
        var apiRoute = baseurl1 + "getAllCTDH";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.list = res.data;
            $scope.Dem = Object.keys($scope.list).length;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadData1();

    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1DH";
        var oneData = CrudService.getByID(apiRoute, s.MaDH);
        oneData.then(function (res) {
            $scope.MaDH = res.data.MaDH;
            $scope.NgayDat = res.data.NgayDat;
            $scope.DiaChi = res.data.DiaChi;
            $scope.MaKH = res.data.MaKH;
            $scope.MaNV = res.data.MaNV ;
            $scope.HoTen = res.data.HoTen;
            $scope.Email = res.data.Email;
            $scope.Phone = res.data.Phone;
            $scope.TongTien = res.data.TongTien;
            $scope.btnText = "Update";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm thêm/sửa
    $scope.CreateUpdate = function () {
        var singleData = {
            NgayDat: $scope.NgayDat,
            DiaChi: $scope.DiaChi,
            MaKH: $scope.MaKH,
            MaNV: $scope.MaNV ,
            HoTen: $scope.HoTen,
            Email: $scope.Email,
            Phone: $scope.Phone,
            TongTien: $scope.TongTien,
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Save") {
            var apiRoute = baseurl + "createDH";
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
            var apiRoute = baseurl + "updateDH";
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
        if (!confirm("Bạn có chắc chắn muốn xóa mã HDN: " + s.MaDH + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteDH";
        var delData = CrudService.getByID(apiRoute, s.MaDH);
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
        window.location.reload();
    }


}]);