//chuyên khai báo các hàm dùng  chung trong ứng dụng (dịch vụ dùng chung)
myApp.service('CrudService', function ($http) {
    //mọi hàm thực hiện sẽ viết ở đây
    var geturl = '';
    //viết hàm lấy về tất cả dữ liệu
    this.getAll = function (apiRoute) {
        geturl = apiRoute;
        return $http.get(geturl);
    }
    //viết hàm lấy về 1 sản phẩm
    this.getByID = function (apiRoute, maloai) {
        geturl = apiRoute + '/' + maloai;
        return $http.get(geturl);
    }
    //Viết hàm xóa một bản ghi
    //this.delete = function (apiRoute) {
    //    var request = $http({
    //        method: "delete",
    //        url: apiRoute
    //    });
    //    return request;
    //}

    //viết hàm đưa dữ liệu lên webserver
    this.post = function (apiRoute, Model) {
        var request = $http({
            method: "post",
            url: apiRoute,
            data: Model
        });
        return request;
    }
});