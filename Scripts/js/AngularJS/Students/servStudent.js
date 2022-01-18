(function () {

    angular.module('app').service('servStudent', ['$http', function ($http) {

        this.Get = function (query) {
            return $http.get("/Student/GetStudents", { params: { query: query } })
                .then(function (response) {
                    return response.data;
                });
        };

        this.Edit = function (student) {
            return $http.post("/Student/EditStudent", student)
                .then(function (response) {
                    return response.data;
                });
        };

        this.Delete = function (student) {
            return $http.post("/Student/RemoveStudent", student)
                .then(function (response) {
                    return response.data;
                });
        };

    }]);

})();
