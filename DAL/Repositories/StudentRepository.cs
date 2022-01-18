using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MagniUniveristy.DAL.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(CollegeContext context) : base(context) { }

        public List<StudentDTO> GetStudents(string query)
        {
            var students = (from item in _context.Students
                            where string.IsNullOrEmpty(query) || item.Name.Contains(query)
                            select new StudentDTO
                            {
                                Initializer = item,
                                StudentSubjects = (from ss in _context.StudentSubjects
                                                   where ss.StudentID == item.StudentID
                                                   select new StudentSubjectDTO
                                                   {
                                                       Initializer = ss,
                                                   }).ToList(),
                            }).ToList();

            return students;
        }

        public ValidationViewModel AddStudentSubject(List<StudentSubject> studentSubjects, ValidationViewModel validation)
        {
            try
            {
                foreach(var item in studentSubjects)
                {
                    _context.Set<StudentSubject>().Add(item);
                    _context.SaveChanges();
                }

                validation.Success = true;
            }
            catch (Exception ex)
            {
                validation.Message = ex.Message;
                validation.Success = false;
            }

            return validation;
        }

        public ValidationViewModel RemoveStudentSubject(StudentSubject studentSubjects, ValidationViewModel validation)
        {
            try
            {
                var item = _context.StudentSubjects.Where(x => x.StudentID == studentSubjects.StudentID).ToList();

                foreach (var s in item)
                {
                    _context.Entry(s).State = EntityState.Deleted;
                    _context.Set<StudentSubject>().Remove(s);
                    _context.SaveChanges();
                }

                validation.Success = true;
            }
            catch (Exception ex)
            {
                validation.Message = ex.Message;
                validation.Success = false;
            }

            return validation;
        }

        public ValidationViewModel RemoveStudent(Student student, ValidationViewModel validation)
        {
            try
            {
                var item = _context.Students.FirstOrDefault(x => x.StudentID == student.StudentID);

                _context.Entry(item).State = EntityState.Deleted;
                _context.Set<Student>().Remove(item);
                _context.SaveChanges();

                validation.Success = true;
            }
            catch (Exception ex)
            {
                validation.Message = ex.Message;
                validation.Success = false;
            }

            return validation;
        }

    }
}