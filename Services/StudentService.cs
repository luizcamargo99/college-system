using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MagniUniveristy
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _studentRepository;
        private ICourseService _courseService;

        public StudentService(IStudentRepository studentRepository, ICourseService courseService)
        {
            _studentRepository = studentRepository;
            _courseService = courseService;
        }

        public List<StudentViewModel> GetStudentsView(string query)
        {
            var viewModelList = new List<StudentViewModel>();

            var students = GetStudents(query);
            var courses = _courseService.GetCourses(string.Empty);

            foreach (var student in students)
            {
                var item = courses.FirstOrDefault(x => x.Subjects.Any(y => y.SubjectID == student.StudentSubjects?.FirstOrDefault()?.SubjectID));
                var viewModel = new StudentViewModel()
                {
                    Student = student,
                    CourseID = item?.CourseID,
                    CourseName = item?.Name == null ? "No linked course" : item?.Name,
                    AverageGrade = CalculateAverageGrade(student)
                };

                viewModelList.Add(viewModel);
            }

            return viewModelList;
        }

        public List<StudentDTO> GetStudents(string query)
        {
            return _studentRepository.GetStudents(query);
        }

        private float CalculateAverageGrade(StudentDTO student)
        {
            float averageGrade = 0;

            foreach (var item in student.StudentSubjects)
            {
                averageGrade += item.Grade.Value;
            }

            return averageGrade == 0 ? averageGrade : averageGrade / student.StudentSubjects.Count();
        }

        public ValidationViewModel EditStudent(Student student, ValidationViewModel validation)
        {
            validation = _studentRepository.RemoveStudentSubject(student.StudentSubjects.FirstOrDefault(), validation);

            if (validation.Success)
            {
                validation = _studentRepository.AddStudentSubject(student.StudentSubjects.ToList(), validation);

                if (validation.Success)
                {
                    _studentRepository.Edit(student, validation);
                }
            }

            return validation;
        }

        public ValidationViewModel RemoveStudent(Student student, ValidationViewModel validation)
        {
            validation = _studentRepository.RemoveStudentSubject(student.StudentSubjects?.FirstOrDefault(), validation);

            if (validation.Success || student.StudentSubjects == null)
            {
                _studentRepository.RemoveStudent(student, validation);
            }

            return validation;
        }
    }
}