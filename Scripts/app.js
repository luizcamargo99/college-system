var app = angular.module('app', ["ui.bootstrap"]);

app.directive('ngEnterPress', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngEnterPress);
                });

                event.preventDefault();
            }
        });
    };
});


app.filter('filter', ['$filter', function ($filter) {
    return function (input, format) {
        input = new Date(parseInt(input.substr(6)));
        return (input) ? $filter('date')(input, format) : '';
    };
}]);