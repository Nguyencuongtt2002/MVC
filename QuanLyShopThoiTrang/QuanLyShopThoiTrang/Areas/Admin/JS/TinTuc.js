//chuyên thực hiện các hàm trên đối tượng loại sản phẩm
myApp.controller("TinTucAdController", ['$scope', 'CrudService', function ($scope, CrudService) {
    //khai báo thư mục gốc
    var baseurl = "/Admin/TinTucAd/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Save";
    $scope.MaTinTuc = "";
    $scope.TieuDe = "";
    $scope.NoiDung = "";
    $scope.NgayDang = "";
    $scope.MaNV = "";
    $scope.Anh = "";

    //viết hàm lấy tất cả sản phẩm
    $scope.LoadData = function () {
        var apiRoute = baseurl + "getAllTT";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.listdata = res.data;
            $scope.Dem = Object.keys($scope.listdata).length;
            $scope.HienThiSoLuong = $scope.Dem;
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    $scope.LoadData();
    //nut update --> save , chuyen ve rong 
    $scope.taomoi = function () {
        $scope.btnText = "Save";
        $scope.MaTinTuc = "";
        $scope.TieuDe = "";
        $scope.NoiDung = "";
        $scope.NgayDang = "";
        $scope.MaNV = "";
        $scope.Anh = "";
    }
    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1TT";
        var oneData = CrudService.getByID(apiRoute, s.MaTinTuc);
        oneData.then(function (res) {
            $scope.MaTinTuc = res.data.MaTinTuc;
            $scope.TieuDe = res.data.TieuDe;
            $scope.NoiDung = res.data.NoiDung;
            $scope.NgayDang = res.data.NgayDang;
            $scope.MaNV = res.data.MaNV;
            $scope.Anh = res.data.Anh;
            $scope.btnText = "Update";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm thêm/sửa
    $scope.CreateUpdate = function () {
        var singleData = {
            MaTinTuc: $scope.MaTinTuc,
            TieuDe: $scope.TieuDe,
            NoiDung: $scope.NoiDung,
            NgayDang: $scope.NgayDang,
            MaNV: $scope.MaNV,
            Anh: $scope.Anh
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Save") {
            $.get("/Admin/TinTucAd/KiemTraMaTrung", { id: $scope.MaTinTuc }, function (data) {
                if (data == 1) {
                    alert("Mã đã tồn tại");
                }
                else {
                    var apiRoute = baseurl + "createTT";
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
            var apiRoute = baseurl + "updateTT";
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
        if (!confirm("Bạn có chắc chắn muốn xóa Tin Tức có mã : " + s.MaTinTuc + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteTT";
        var delData = CrudService.getByID(apiRoute, s.MaTinTuc);
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