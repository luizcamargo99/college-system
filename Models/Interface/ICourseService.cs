using MagniUniveristy.Models.ViewModel;
using System.Collections.Generic;

namespace MagniUniveristy.Models.Interface
{
    public interface ICourseService 
    {
        List<CourseViewModel> GetCoursesView(string query);
        List<CourseDTO> GetCourses(string query);
    }
}
