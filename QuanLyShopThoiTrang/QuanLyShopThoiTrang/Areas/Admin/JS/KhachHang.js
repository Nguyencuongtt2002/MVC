//chuyên thực hiện các hàm trên đối tượng loại sản phẩm
myApp.controller("KhachHangAdController", ['$scope', 'CrudService', function ($scope, CrudService) {

    $scope.listdata = [];
    $scope.currentPage = 1;
    $scope.itemsPerPage = 5;

    //khai báo thư mục gốc
    var baseurl = "/Admin/KhachHangAd/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Save";
    $scope.MaKH  = "";
    $scope.TenKH  = "";
    $scope.DiaChi = "";
    $scope.SoDT = "";

    //viết hàm lấy tất cả sản phẩm
    $scope.LoadData = function () {
        var apiRoute = baseurl + "getALLKH";
        var allData = CrudService.getAll(apiRoute);

        allData.then(function (res) {
            $scope.listdata = res.data;
            $scope.Dem = Object.keys($scope.listdata).length;
        });
    }
    $scope.LoadData();

    //nut update --> save , chuyen ve rong 
    $scope.taomoi = function () {
        $scope.btnText = "Save";
        $scope.MaKH = "";
        $scope.TenKH = "";
        $scope.DiaChi = "";
        $scope.SoDT = "";
    }

    //lấy về 1 bản ghi
    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1KH";
        var oneData = CrudService.getByID(apiRoute, s.MaKH );
        oneData.then(function (res) {
            $scope.MaKH = res.data.MaKH ;
            $scope.TenKH = res.data.TenKH ;
            $scope.DiaChi = res.data.DiaChi;
            $scope.SoDT = res.data.SoDT;
            $scope.btnText = "Update";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }

    //viết hàm thêm/sửa
    $scope.CreateUpdate = function () {
        var singleData = {
            MaKH: $scope.MaKH ,
            TenKH: $scope.TenKH ,
            DiaChi: $scope.DiaChi,
            SoDT: $scope.SoDT,
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Save") {
            $.get("/Admin/KhachHangAd/KiemTraMaTrung", { id: $scope.MaKH }, function (data) {
                if (data == 1) {
                    alert("Mã đã tồn tại");
                }
                else {
                    var apiRoute = baseurl + "createKH";
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
            var apiRoute = baseurl + "updateKH";
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

    //$scope.CreateUpdate = function (MaKH) {
    //    if (listdata.artNr === MaKH.artNr) {
    //        $scope.message = 'artNr already exists!';
    //    }
    //};

    //viết hàm xóa bản ghi
    $scope.deletebyID = function (s) {
        if (!confirm("Bạn có chắc chắn muốn xóa Khach hang: " + s.TenKH  + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteKH";
        var delData = CrudService.getByID(apiRoute, s.MaKH );
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