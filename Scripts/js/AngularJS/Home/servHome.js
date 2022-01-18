(function () {

    angular.module('app').service('servHome', ['$http', function ($http) {

        this.GetInfoHome = function () {
            return $http.get("/Home/GetInfoHome")
                .then(function (response) {
                    return response.data;
                });
        };

    }]);

})();
