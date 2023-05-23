using ELearning.Models.Entities;
using Microsoft.SqlServer.Management.Smo.Agent;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ELearning.Models.Data
{
    internal class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ClassMaster> ClassMasters { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Thesis> Theses { get; set; }
        public DbSet<GradeThesis> GradeTheses { get; set; }

        public SchoolDbContext() : base("name=EducationalPlatformDB")
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>().ToTable("People");
        //    modelBuilder.Entity<Student>().ToTable("Students");
        //    modelBuilder.Entity<Class>().ToTable("Classes");
        //    modelBuilder.Entity<Grade>().ToTable("Grades");
        //    modelBuilder.Entity<Course>().ToTable("Courses");
        //    modelBuilder.Entity<Teacher>().ToTable("Teachers");

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
