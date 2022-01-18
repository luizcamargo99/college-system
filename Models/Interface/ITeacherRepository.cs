using System;
using System.Collections.Generic;

namespace MagniUniveristy.Models.Interface
{
    public interface ITeacherRepository : IBaseRepository<Teacher>, IDisposable
    {
        List<TeacherDTO> GetTeachers(string query);
    }
}
