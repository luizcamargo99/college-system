(function () {

    angular.module('app').service('servShared', ['$http', function ($http) {


        this.Create = function (item, url) {
            return $http.post(url, item)
                .then(function (response) {
                    return response.data;
                });
        };

        this.Edit = function (item, url) {
            return $http.post(url, item)
                .then(function (response) {
                    return response.data;
                });
        };

        this.Delete = function (item, url) {
            return $http.post(url, item)
                .then(function (response) {
                    return response.data;
                });
        };

    }]);

})();
