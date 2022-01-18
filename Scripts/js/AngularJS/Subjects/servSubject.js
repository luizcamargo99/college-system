(function () {

    angular.module('app').service('servSubject', ['$http', function ($http) {

        this.Get = function (query) {
            return $http.get("/Subject/GetSubjects", { params: { query: query } })
                .then(function (response) {
                    return response.data;
                });
        };

        this.GetInfoModal = function () {
            return $http.get("/Subject/GetInfoModal")
                .then(function (response) {
                    return response.data;
                });
        };

    }]);
})();
