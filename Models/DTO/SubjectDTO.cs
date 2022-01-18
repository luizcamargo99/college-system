using System.Collections.Generic;

namespace MagniUniveristy.Models

{
    public partial class SubjectDTO
    {
        public int SubjectID { get; set; }
        public int CourseID { get; set; }
        public int TeacherID { get; set; }
        public string Name { get; set; }

        public virtual CourseDTO Course { get; set; }
        public virtual TeacherDTO Teacher { get; set; }
        public virtual ICollection<StudentSubjectDTO> StudentSubjects { get; set; }

        public Subject Initializer
        {
            set
            {
                this.copyFrom(value);
            }
        }

        public void copyFrom(Subject poco)
        {
            if (poco != null)
            {
                this.SubjectID = poco.SubjectID;
                this.Name = poco.Name;
                this.TeacherID = poco.TeacherID;
                this.CourseID = poco.CourseID;
            }
        }
    }
}