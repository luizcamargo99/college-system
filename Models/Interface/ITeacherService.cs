using System.Collections.Generic;

namespace MagniUniveristy.Models.Interface
{
    public interface ITeacherService
    {
        List<TeacherDTO> GetTeachers(string query);
        decimal CalculateWagesPaid();
    }
}
