using MagniUniveristy.Models;
using System;
using System.Collections.Generic;

namespace MagniUniveristy.Models.Interface
{
    public interface ICourseRepository : IBaseRepository<Course>, IDisposable
    {
        List<CourseDTO> GetCourses(string query);
    }
}
