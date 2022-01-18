
angular.module('app').controller('HomeController', ['servHome', function (servHome) {

    var ctrlHome = this;

    ctrlHome.Initializer = function () {
        ctrlHome.GetInfoHome();
    };

    ctrlHome.GetInfoHome = function () {
        servHome.GetInfoHome().then(function (data) {
            ctrlHome.HomeViewModel = data.response;
        });
    };

    ctrlHome.Initializer();
    
}]);

