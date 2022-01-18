(function () {

    angular.module('app').service('servCourse', ['$http', function ($http) {

        this.Get = function (query) {
            return $http.get("/Course/GetCourses", { params: { query: query } })
                .then(function (response) {
                    return response.data;
                });
        };
     
    }]);

})();
