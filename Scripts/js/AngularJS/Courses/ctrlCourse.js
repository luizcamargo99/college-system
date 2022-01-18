
angular.module('app').controller('CourseController', ['servCourse', '$uibModal', 'servShared', function (servCourse, $uibModal, servShared) {

    var ctrlCourse = this;

    ctrlCourse.Title = "Courses";

    ctrlCourse.Search = function () {
        servCourse.Get(ctrlCourse.Query).then(function (data) {
            ctrlCourse.CourseViewModel = data.response;
        });
    };

    ctrlCourse.DeleteCourse = function (course) {
        servShared.Delete(course, "/Course/Delete").then(function (data) {
            if (data.response.Success) {
                ctrlCourse.Search();
            }
        }); 
    };

    ctrlCourse.AddCourse = function () {

        const modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'modalAddEditCourse.html',
            controllerAs: 'ctrl',
            backdrop: false,
            bindToController: true,
            size: 'lg',
            controller: function ($uibModalInstance) {

                var ctrl = this;
                ctrl.Title = "Add";
                ctrl.Course = {};


                ctrl.Save = function () {
                    servShared.Create(ctrl.Course, "/Course/Create").then(function (data) {
                        $uibModalInstance.close(data.response.Success);
                    });

                };

                ctrl.Cancel = function () {
                    $uibModalInstance.close();
                };
            }
        });

        modalInstance.result.then(function (create) {
            if (create) {
                ctrlCourse.Search();
            }
        }, function () { });
    };


    ctrlCourse.EditCourse = function (course) {

        const parameters = {
            Course: course
        };       

        const modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'modalAddEditCourse.html',
            controllerAs: 'ctrl',
            backdrop: false,
            bindToController: true,
            size: 'lg',
            resolve: {
                parameters: function () {
                    return angular.copy(parameters);
                }
            },
            controller: function (parameters, $uibModalInstance) {

                var ctrl = this;

                ctrl.Course = parameters.Course;
                ctrl.Title = "Edit";

                ctrl.Save = function () {
                    servShared.Edit(ctrl.Course, "/Course/Edit").then(function (data) {
                        $uibModalInstance.close(data.response.Success);
                    });
                };

                ctrl.Cancel = function () {
                    $uibModalInstance.close();
                };
            }
        });

        modalInstance.result.then(function (edit) {
            if (edit) {
                ctrlCourse.Search();
            }
        }, function () { });
    };

}]);

