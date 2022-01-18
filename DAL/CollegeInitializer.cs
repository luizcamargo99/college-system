using MagniUniveristy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MagniUniveristy.DAL
{
    public class CollegeInitializer : DropCreateDatabaseIfModelChanges<CollegeContext>
    {
        protected override void Seed(CollegeContext context)
        {
            var courses = new List<Course>
            {
                new Course{CourseID=1,Name="Law"},
                new Course{CourseID=2,Name="Science Computer"}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                 new Teacher{TeacherID=1, Name="Joseffe", BirthDate = DateTime.Today, Salary=1500},
                 new Teacher{TeacherID=2,Name="Peter", BirthDate = DateTime.Today, Salary=2100},
                 new Teacher{TeacherID=3,Name="Pamela", BirthDate = DateTime.Today, Salary=2000},
                 new Teacher{TeacherID=4,Name="Laura", BirthDate = DateTime.Today, Salary=1700}
            };

            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>
            {
                new Subject{SubjectID=1,CourseID=1,Name="Criminal Law", TeacherID=1 },
                new Subject{SubjectID=2,CourseID=1,Name="Tax Law", TeacherID=2 },
                new Subject{SubjectID=3,CourseID=2,Name="Integrated Systems", TeacherID=3 },
                new Subject{SubjectID=4,CourseID=2,Name="Programming Logic", TeacherID=4 }
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student{StudentID=1, Name="Luiz", BirthDate = DateTime.Today},
                new Student{StudentID=2, Name="Mayara", BirthDate = DateTime.Today},
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var studentSubjects = new List<StudentSubject>
            {
                new StudentSubject{SubjectID=1, StudentID=2, Grade=7},
                new StudentSubject{SubjectID=2, StudentID=2, Grade=8},
                new StudentSubject{SubjectID=3, StudentID=1, Grade=9},
                new StudentSubject{SubjectID=4, StudentID=1, Grade=10},
            };

            studentSubjects.ForEach(s => context.StudentSubjects.Add(s));
            context.SaveChanges();


        }
    }
}