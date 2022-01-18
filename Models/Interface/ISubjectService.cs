using MagniUniveristy.Models.ViewModel;
using System.Collections.Generic;

namespace MagniUniveristy.Models.Interface
{
    public interface ISubjectService
    {
        List<SubjectDTO> GetSubjects(string query);
        SubjectModalViewModel GetInfoModal();
    }
}
