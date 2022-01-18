using System;
using System.Collections.Generic;

namespace MagniUniveristy.Models.Interface
{
    public interface ISubjectRepository : IBaseRepository<Subject>, IDisposable
    {
        List<SubjectDTO> GetSubjects(string query);
    }
}
