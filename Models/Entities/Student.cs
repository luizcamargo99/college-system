using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagniUniveristy.Models
{
    public class Student
    {
        public int StudentID { get; set; } 
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
       
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}