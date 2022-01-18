using System.Collections.Generic;

namespace MagniUniveristy.Models
{
    public partial class CourseDTO
    {
        public int CourseID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubjectDTO> Subjects { get; set; }


        public Course Initializer
        {
            set
            {
                this.copyFrom(value);
            }
        }

        public void copyFrom(Course poco)
        {
            if (poco != null)
            {
                this.CourseID = poco.CourseID;
                this.Name = poco.Name;
            }
        }
    }
}