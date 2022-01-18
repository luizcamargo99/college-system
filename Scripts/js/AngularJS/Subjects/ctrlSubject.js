
angular.module('app').controller('SubjectController', ['servSubject', '$uibModal', 'servShared', function (servSubject, $uibModal, servShared) {

    var ctrlSubject = this;

    ctrlSubject.Title = "Subjects";

    ctrlSubject.Search = function () {
        servSubject.Get(ctrlSubject.Name).then(function (data) {
            ctrlSubject.SubjectsViewModel = data.response;
        });
    };

    ctrlSubject.DeleteSubject = function (subject) {
        servShared.Delete(subject, "/Subject/Delete").then(function (data) {
            if (data.response.Success) {
                ctrlSubject.Search();
            }
        });
    };

    ctrlSubject.AddSubject = function () {

        servSubject.GetInfoModal().then(function (data) {

            const parameters = {
                ViewModel: data.response
            };

            const modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'modalAddEditSubject.html',
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
                    ctrl.Title = "Add";
                    ctrl.Subject = {};
                    ctrl.ViewModel = parameters.ViewModel;


                    ctrl.Save = function () {
                        servShared.Create(ctrl.Subject, "/Subject/Create").then(function (data) {
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
                    ctrlSubject.Search();
                }
            }, function () { });

        });
    };


    ctrlSubject.EditSubject = function (subject) {

        servSubject.GetInfoModal().then(function (data) {

            const parameters = {
                Subject: subject,
                ViewModel: data.response
            };

            const modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'modalAddEditSubject.html',
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

                    ctrl.Subject = parameters.Subject;
                    ctrl.Subject.Teacher = {};
                    ctrl.Subject.Course = {};
                    ctrl.ViewModel = parameters.ViewModel;
                    ctrl.Title = "Edit";

                    ctrl.Save = function () {                      
                        servShared.Edit(ctrl.Subject, "/Subject/Edit").then(function (data) {
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
                    ctrlSubject.Search();
                }
            }, function () { });
        });
    }

    ctrlSubject.TeacherInformation = function (teacher) {

        const parameters = {
            Teacher: teacher
        };

        const modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'modalTeacherInformation.html',
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
                ctrl.Title = "Add";
                ctrl.Teacher = parameters.Teacher;


                ctrl.Close = function () {
                    $uibModalInstance.close();
                };
            }
        });

        modalInstance.result.then(function (create) {
            if (create) {
                ctrlSubject.Search();
            }
        }, function () { });
    };

}]);

