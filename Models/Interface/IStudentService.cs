using MagniUniveristy.Models.ViewModel;
using System.Collections.Generic;

namespace MagniUniveristy.Models.Interface
{
    public interface IStudentService
    {
        List<StudentViewModel> GetStudentsView(string query);
        List<StudentDTO> GetStudents(string query);
        ValidationViewModel RemoveStudent(Student student, ValidationViewModel validation);
        ValidationViewModel EditStudent(Student student, ValidationViewModel validation);
    }
}
