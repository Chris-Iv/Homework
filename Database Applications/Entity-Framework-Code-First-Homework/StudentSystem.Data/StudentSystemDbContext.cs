namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using StudentSystem.Models;
    using StudentSystem.Data.Migrations;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            Database.SetInitializer<StudentSystemDbContext>(new StudentSystemDbInitializer());
            Database.Initialize(true);
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}
