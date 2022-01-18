using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MagniUniveristy.DAL.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(CollegeContext context) : base(context) { }

        public List<TeacherDTO> GetTeachers(string query)
        {
            var teachers = (from item in _context.Teachers
                            where string.IsNullOrEmpty(query) || item.Name.Contains(query)
                            select new TeacherDTO
                            {
                                Initializer = item,
                                Subjects = (from s in _context.Subjects
                                            where item.TeacherID == s.TeacherID
                                            select new SubjectDTO
                                            {
                                                Initializer = s
                                            }).ToList()
                            }).ToList();

            return teachers;
        }

    }
}