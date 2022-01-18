using System.Collections.Generic;

namespace MagniUniveristy.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<CourseDTO> Courses { get; set; }
        public decimal WagesPaid { get; set; }
        public List<StudentDTO> Students { get; set; }
    }
}