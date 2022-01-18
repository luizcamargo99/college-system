
angular.module('app').controller('TeacherController', ['servTeacher', '$uibModal', 'servShared', function (servTeacher, $uibModal, servShared) {

    var ctrlTeacher = this;

    ctrlTeacher.Title = "Teachers";

    ctrlTeacher.Search = function () {
        servTeacher.Get(ctrlTeacher.Name).then(function (data) {
            ctrlTeacher.TeacherViewModel = data.response;
        });
    };

    ctrlTeacher.DeleteTeacher = function (teacher) {
        servShared.Delete(teacher, "/Teacher/Delete").then(function (data) {
            if (data.response.Success) {
                ctrlTeacher.Search();
            }
        }); 
    };

    ctrlTeacher.AddTeacher = function () {

        const modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'modalAddEditTeacher.html',
            controllerAs: 'ctrl',
            backdrop: false,
            bindToController: true,
            size: 'lg',
            controller: function ($uibModalInstance) {

                var ctrl = this;
                ctrl.Title = "Add";
                ctrl.Teacher = {};


                ctrl.Save = function () {
                    servShared.Create(ctrl.Teacher, "/Teacher/Create").then(function (data) {
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
                ctrlTeacher.Search();
            }
        }, function () { });
    };


    ctrlTeacher.EditTeacher = function (teacher) {

        const parameters = {
            Teacher: teacher
        };       

        const modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'modalAddEditTeacher.html',
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

                ctrl.Teacher = parameters.Teacher;
                ctrl.Title = "Edit";
                ctrl.Teacher.BirthDate = new Date(parseInt(ctrl.Teacher.BirthDate.substr(6)));

                ctrl.Save = function () {
                    servShared.Edit(ctrl.Teacher, "/Teacher/Edit").then(function (data) {
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
                ctrlTeacher.Search();
            }
        }, function () { });
    };

}]);

