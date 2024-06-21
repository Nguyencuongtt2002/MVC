myApp.controller("HomeController", function ($scope) {
  Object.defineProperty($scope, "query", {
    get: function () {
      var out = {};
      out[$scope.queryBy || "$"] = $scope.query;
      return out;
    }
  })
}]);
