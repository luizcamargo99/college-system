(function () {
    angular.module('app').service('servTeacher', ['$http', function ($http) {

        this.Get = function (query) {
            return $http.get("/Teacher/GetTeachers", { params: { query: query } })
                .then(function (response) {
                    return response.data;
                });
        };
    }]);
})();
