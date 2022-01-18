using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagniUniveristy.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
       
    }
}