//chuyên thực hiện các hàm trên đối tượng loại sản phẩm
myApp.controller("ThuongHieuAdController", ['$scope', 'CrudService', function ($scope, CrudService) {
    $scope.listdata = [];
    $scope.currentPage = 1;
    $scope.itemsPerPage = 10;
    //khai báo thư mục gốc
    var baseurl = "/Admin/ThuongHieuAd/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Save";
    $scope.MaThuongHieu = "";
    $scope.TenThuongHieu = "";
    $scope.GioiThieu = "";
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadData = function () {
        var apiRoute = baseurl + "getALLTH";
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
        $scope.MaThuongHieu = "";
        $scope.TenThuongHieu = "";
        $scope.GioiThieu = "";
    }



    ////viết hàm lấy tất cả loai sản phẩm
    //var baseurlLSP = "/Admin/HomeAd/";
    //$scope.DataLSP = function () {
    //    var apiRoute = baseurlLSP + "getAllLSP";
    //    var allData = CrudService.getAll(apiRoute);

    //    allData.then(function (res) {
    //        $scope.LSP = res.data;
    //    });
    //}
    //$scope.DataLSP();


    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1TH";
        var oneData = CrudService.getByID(apiRoute, s.MaThuongHieu);
        oneData.then(function (res) {
            $scope.MaThuongHieu = res.data.MaThuongHieu;
            $scope.TenThuongHieu = res.data.TenThuongHieu;
            $scope.GioiThieu = res.data.GioiThieu ;
            $scope.btnText = "Update";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm thêm/sửa
    $scope.CreateUpdate = function () {
        var singleData = {
            MaThuongHieu: $scope.MaThuongHieu,
            TenThuongHieu: $scope.TenThuongHieu,
            GioiThieu: $scope.GioiThieu ,
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Save") {
            $.get("/Admin/ThuongHieuAd/KiemTraMaTrung", { id: $scope.MaThuongHieu }, function (data) {
                if (data == 1) {
                    alert("Mã đã tồn tại");
                }
                else {
                    var apiRoute = baseurl + "createTH";
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
            var apiRoute = baseurl + "updateTH";
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
        if (!confirm("Bạn có chắc chắn muốn xóa sản phẩm: " + s.TenThuongHieu + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteTH";
        var delData = CrudService.getByID(apiRoute, s.MaThuongHieu);
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