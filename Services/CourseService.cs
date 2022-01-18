using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace MagniUniveristy
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;
        private IStudentRepository _studentService;

        public CourseService(ICourseRepository courseRepository, IStudentRepository studentService)
        {
            _courseRepository = courseRepository;
            _studentService = studentService;
        }

        public List<CourseViewModel> GetCoursesView(string query)
        {
            var viewModelList = new List<CourseViewModel>();

            var courses = GetCourses(query);
            var students = _studentService.GetStudents(string.Empty);

            foreach (var course in courses)
            {               
                var viewModel = new CourseViewModel() { 
                
                    Course = course,
                    NumberOfSubjects = course.Subjects.Count(),
                    NumberOfTeachers = course.Subjects.DistinctBy(x => x.TeacherID).Count(),
                    NumberOfStudents = students.Where(x => x.StudentSubjects.Any(y => course.Subjects.Any(w => w.SubjectID == y.SubjectID))).Count()

            };

                viewModelList.Add(viewModel);
            }

            return viewModelList;
        }

        public List<CourseDTO> GetCourses(string query)
        {
            return _courseRepository.GetCourses(query);
        }

    }
}