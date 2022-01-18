using MagniUniveristy.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace MagniUniveristy.Models.Interface
{
    public interface IStudentRepository : IBaseRepository<Student>, IDisposable
    {
        List<StudentDTO> GetStudents(string query);
        ValidationViewModel RemoveStudentSubject(StudentSubject studentSubject, ValidationViewModel validation);
        ValidationViewModel RemoveStudent(Student student, ValidationViewModel validation);
        ValidationViewModel AddStudentSubject(List<StudentSubject> studentSubject, ValidationViewModel validation);
    }
}
