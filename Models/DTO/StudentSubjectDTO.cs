using System;
using System.Collections.Generic;

namespace MagniUniveristy.Models
{
    public partial class StudentSubjectDTO
    {
        public int StudentSubjectID { get; set; }
        public int SubjectID { get; set; }
        public int StudentID { get; set; }
        public float? Grade{ get; set; }

        public virtual SubjectDTO Subject { get; set; }
        public virtual StudentDTO Student { get; set; }


        public StudentSubject Initializer
        {
            set
            {
                this.copyFrom(value);
            }
        }

        public void copyFrom(StudentSubject poco)
        {
            if (poco != null)
            {
                this.StudentSubjectID = poco.StudentSubjectID;
                this.SubjectID = poco.SubjectID;
                this.StudentID = poco.StudentID;
                this.Grade = poco.Grade;                
            }
        }
    }
}