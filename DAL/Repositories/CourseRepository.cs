using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace MagniUniveristy.DAL.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(CollegeContext context) : base(context) { }

        public List<CourseDTO> GetCourses(string query)
        {
            var courses = (from item in _context.Courses
                           where string.IsNullOrEmpty(query) || item.Name.Contains(query)
                           select new CourseDTO
                           {
                               Initializer = item,

                               Subjects = (from s in _context.Subjects
                                           where item.CourseID == s.CourseID
                                           select new SubjectDTO
                                           {
                                               Initializer = s,                                               
                                           }).ToList(),
                           }).ToList();

            return courses;
        }

    }
}