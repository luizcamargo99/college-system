using System.Collections.Generic;

namespace MagniUniveristy.Models.ViewModel
{
    public class StudentViewModel
    {
        public StudentDTO Student { get; set; }
        public int? CourseID { get; set; }
        public string CourseName{ get; set; }
        public float AverageGrade { get; set; }
    }
}