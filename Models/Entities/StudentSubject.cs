using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagniUniveristy.Models
{
    public class StudentSubject
    {
        public int StudentSubjectID { get; set; }

        [ForeignKey("Subject")]
        public int SubjectID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        public float? Grade { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}