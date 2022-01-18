using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;

namespace MagniUniveristy
{
    public class HomeService : IHomeService
    {
        private ICourseService _courseService;
        private IStudentService _studentService;
        private ITeacherService _teacherService;

        public HomeService(ICourseService courseService, IStudentService studentService, ITeacherService teacherService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _teacherService = teacherService;
        }

        public HomeViewModel GetInfoHome()
        {
            var viewModel = new HomeViewModel()
            {
                Courses = _courseService.GetCourses(string.Empty),
                Students = _studentService.GetStudents(string.Empty),
                WagesPaid = _teacherService.CalculateWagesPaid()
            };

            return viewModel;
        }
    }
}