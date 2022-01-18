using MagniUniveristy.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MagniUniveristy.DAL
{
    public class CollegeContext : DbContext
    {
        public CollegeContext() : base("CollegeContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CollegeContext>());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void Save()
        {
            base.SaveChanges();
        }
    }
}