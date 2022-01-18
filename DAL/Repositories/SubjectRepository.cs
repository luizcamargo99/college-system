using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MagniUniveristy.DAL.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(CollegeContext context) : base(context) { }

        public List<SubjectDTO> GetSubjects(string query)
        {
            var subjects = (from item in _context.Subjects
                            where string.IsNullOrEmpty(query) || item.Name.Contains(query)
                            select new SubjectDTO
                            {
                                Initializer = item,

                                Course = (from c in _context.Courses
                                          where item.CourseID == c.CourseID
                                          select new CourseDTO
                                          {
                                              Initializer = c
                                          }).FirstOrDefault(),
                                Teacher = (from t in _context.Teachers
                                          where item.TeacherID == t.TeacherID
                                          select new TeacherDTO
                                          {
                                              Initializer = t,
                                          }).FirstOrDefault()
                            }).ToList();
            
            return subjects;
        }

    }
}