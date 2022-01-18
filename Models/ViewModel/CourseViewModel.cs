using System.Collections.Generic;

namespace MagniUniveristy.Models.ViewModel
{
    public class CourseViewModel
    {
        public CourseDTO Course { get; set; }
        public int NumberOfSubjects { get; set; }
        public int NumberOfTeachers { get; set; }
        public int NumberOfStudents { get; set; }
    }
}