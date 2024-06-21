//chuyên thực hiện các hàm trên đối tượng loại sản phẩm
myApp.controller("LoaiSPAdController", ['$scope', 'CrudService', function ($scope, CrudService) {

    $scope.listdata = [];
    $scope.currentPage = 1;
    $scope.itemsPerPage = 10;
    //khai báo thư mục gốc
    var baseurl = "/Admin/LoaiSPAd/";
    //khởi tạo các giá trị ban đầu cho modal
    $scope.btnText = "Save";
    $scope.MaLoaiSP= "";
    $scope.TenLoaiSP = "";
   
    //viết hàm lấy tất cả sản phẩm
    $scope.LoadData = function () {
        var apiRoute = baseurl + "getAllLSP";
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
        $scope.MaLoaiSP = "";
        $scope.TenLoaiSP = "";
    }

    $scope.getbyID = function (s) {
        var apiRoute = baseurl + "get1LSP";
        var oneData = CrudService.getByID(apiRoute, s.MaLoaiSP);
        oneData.then(function (res) {
            $scope.MaLoaiSP = res.data.MaLoaiSP;
            $scope.TenLoaiSP = res.data.TenLoaiSP;
            $scope.btnText = "Update";
        }, function (error) {
            console.log("Lỗi: " + error);
        });
    }
    //viết hàm thêm/sửa
    $scope.CreateUpdate = function () {
        var singleData = {
            MaLoaiSP: $scope.MaLoaiSP,
            TenLoaiSP: $scope.TenLoaiSP,
        }
        //duyệt nếu btn là save -->thêm
        if ($scope.btnText == "Save") {
            $.get("/Admin/LoaiSPAd/KiemTraMaTrung", { id: $scope.MaLoaiSP }, function (data) {
                if (data == 1) {
                    alert("Mã đã tồn tại");
                }
                else {
                    var apiRoute = baseurl + "createLSP";
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
            var apiRoute = baseurl + "updateLSP";
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
        if (!confirm("Bạn có chắc chắn muốn xóa phần tử: " + s.TenLoaiSP + " không???")) {
            return;
        }
        var apiRoute = baseurl + "deleteLSP";
        var delData = CrudService.getByID(apiRoute, s.MaLoaiSP);
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