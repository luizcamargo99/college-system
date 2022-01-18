using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagniUniveristy.Models

{
    public class Subject
    {
        public int SubjectID { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }

        public string Name { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}