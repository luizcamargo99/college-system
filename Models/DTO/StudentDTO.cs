using System;
using System.Collections.Generic;

namespace MagniUniveristy.Models
{
    public partial class StudentDTO
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<StudentSubjectDTO> StudentSubjects { get; set; }


        public Student Initializer
        {
            set
            {
                this.copyFrom(value);
            }
        }

        public void copyFrom(Student poco)
        {
            if (poco != null)
            {
                this.StudentID = poco.StudentID;
                this.Name = poco.Name;
                this.BirthDate = poco.BirthDate;
            }
        }
    }
}