using System;
using System.Collections.Generic;

namespace MagniUniveristy.Models
{
    public partial class TeacherDTO
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }

        public virtual ICollection<SubjectDTO> Subjects { get; set; }

        public Teacher Initializer
        {
            set
            {
                this.copyFrom(value);
            }
        }

        public void copyFrom(Teacher poco)
        {
            if (poco != null)
            {
                this.TeacherID = poco.TeacherID;
                this.Name = poco.Name;
                this.BirthDate = poco.BirthDate;
                this.Salary = poco.Salary;
            }
        }

    }
}