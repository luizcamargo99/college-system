using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System.Collections.Generic;

namespace MagniUniveristy
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _subjectRepository;
        private ICourseService _courseService;
        private ITeacherService _teacherService;

        public SubjectService(ISubjectRepository subjectRepository, ICourseService courseService, ITeacherService teacherService)
        {
            _subjectRepository = subjectRepository;
            _courseService = courseService;
            _teacherService = teacherService;
        }

        public List<SubjectDTO> GetSubjects(string query)
        {
            return _subjectRepository.GetSubjects(query);            
        }

        public SubjectModalViewModel GetInfoModal()
        {
            var model = new SubjectModalViewModel()
            {
                Courses = _courseService.GetCourses(string.Empty),
                Teachers = _teacherService.GetTeachers(string.Empty)
            };

            return model;
            
        }

    }
}