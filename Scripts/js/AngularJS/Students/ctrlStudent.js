angular.module('app').controller('StudentController', ['servStudent', '$uibModal', 'servCourse', 'servShared', function (servStudent, $uibModal, servCourse, servShared) {

    var ctrlStudent = this;

    ctrlStudent.Title = "Students";

    ctrlStudent.Search = function () {
        servStudent.Get(ctrlStudent.Name).then(function (data) {
            ctrlStudent.StudentViewModel = data.response;
        });
    };

    ctrlStudent.DeleteStudent = function (Student) {
        servStudent.Delete(Student).then(function (data) {
            if (data.response.Success) {
                ctrlStudent.Search();
            }
        });
    };

    ctrlStudent.AddStudent = function () {

        servCourse.Get().then(function (data) {

            const parameters = {
                Courses: data.response
            };

            const modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'modalAddEditStudent.html',
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
                    ctrl.Student = {};
                    ctrl.Courses = parameters.Courses;
                    ctrl.SubjectsSelected = {};

                    ctrl.ChangeCourse = function () {
                        ctrl.SubjectsSelected = ctrl.Courses.find(x => x.Course.CourseID == ctrl.CourseID).Course.Subjects;
                    };

                    ctrl.Save = function () {
                        ctrl.Student.StudentSubjects = [];
                        ctrl.SubjectsSelected.forEach(function (item) {
                            let grade = 0;

                            for (var i in item.Grade) {
                                if (item.Grade.hasOwnProperty(i) && typeof (i) !== 'function') {
                                    grade = item.Grade[i];
                                    break;
                                }
                            }
                            const subject = {
                                SubjectID: item.SubjectID,
                                Grade: grade
                            };
                            ctrl.Student.StudentSubjects.push(subject);
                        });

                        servShared.Create(ctrl.Student, "/Student/Create").then(function (data) {
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
                    ctrlStudent.Search();
                }
            }, function () { });

        });
    };


    ctrlStudent.EditStudent = function (item) {

        servCourse.Get().then(function (data) {

            const parameters = {
                Student: item.Student,
                Courses: data.response,
                CourseID: item.CourseID
            };

            const modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'modalAddEditStudent.html',
                controllerAs: 'ctrl',
                backdrop: false,
                bindToController: true,
                size: 'lg',
                resolve: {
                    parameters: function () {
                        return angular.copy(parameters);
                    }
                },
                controller: function (parameters, $uibModalInstance, servStudent) {

                    var ctrl = this;

                    ctrl.Student = parameters.Student;
                    ctrl.Courses = parameters.Courses;
                    ctrl.CourseID = parameters.CourseID;
                    ctrl.SubjectsSelected = ctrl.Student.StudentSubjects;
                    ctrl.Student.BirthDate = new Date(parseInt(ctrl.Student.BirthDate.substr(6)));
                    ctrl.Title = "Edit";

                    ctrl.ChangeCourse = function () {
                        ctrl.SubjectsSelected = ctrl.Courses.find(x => x.Course.CourseID == ctrl.CourseID)?.Course.Subjects;
                    };

                    ctrl.Save = function () {
                        ctrl.Student.StudentSubjects = [];
                        ctrl.SubjectsSelected.forEach(function (item) {
                            let grade = 0;

                            for (var i in item.Grade) {
                                if (item.Grade.hasOwnProperty(i) && typeof (i) !== 'function') {
                                    grade = item.Grade[i];
                                    break;
                                }
                            }
                            const subject = {
                                SubjectID: item.SubjectID,
                                StudentID: ctrl.Student.StudentID,
                                Grade: grade
                            };
                            ctrl.Student.StudentSubjects.push(subject);
                        });

                        servStudent.Edit(ctrl.Student).then(function (data) {
                            $uibModalInstance.close(data.response.Success);
                        });
                    };

                    ctrl.Cancel = function () {
                        $uibModalInstance.close();
                    };

                    ctrl.ChangeCourse();

                    if (ctrl.SubjectsSelected) {
                        for (let i = 0; i < ctrl.SubjectsSelected.length; i++) {
                            const grade = ctrl.Student.StudentSubjects.find(x => x.SubjectID == ctrl.SubjectsSelected[i].SubjectID)?.Grade;
                            ctrl.SubjectsSelected[i].Grade = {};
                            ctrl.SubjectsSelected[i].Grade[i] = grade;
                        }
                    }
                }
            });

            modalInstance.result.then(function (edit) {
                if (edit) {
                    ctrlStudent.Search();
                }
            }, function () { });
        });
    }

    ctrlStudent.ReportCard = function (model) {

        servCourse.Get().then(function (data) {

            const parameters = {
                Student: model.Student,
                CourseName: model.CourseName,
                Courses: data.response,
                CourseID: model.CourseID
            };

            $uibModal.open({
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
                    ctrl.Student = parameters.Student;
                    ctrl.CourseName = parameters.CourseName;
                    ctrl.SubjectsSelected = parameters.Courses.find(x => x.Course.CourseID == parameters.CourseID)?.Course.Subjects;

                    ctrl.Close = function () {
                        $uibModalInstance.close();
                    };

                    if (ctrl.SubjectsSelected) {
                        for (let i = 0; i < ctrl.SubjectsSelected.length; i++) {
                            const grade = ctrl.Student.StudentSubjects.find(x => x.SubjectID == ctrl.SubjectsSelected[i].SubjectID)?.Grade;
                            ctrl.SubjectsSelected[i].Grade = {};
                            ctrl.SubjectsSelected[i].Grade = grade;
                        }
                    }
                }
            });
        });
    }

}]);

