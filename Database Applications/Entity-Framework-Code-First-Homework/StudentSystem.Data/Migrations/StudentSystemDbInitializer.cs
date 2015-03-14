namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class StudentSystemDbInitializer : DropCreateDatabaseIfModelChanges<StudentSystemDbContext>
    {
        protected override void Seed(StudentSystemDbContext context)
        {
            ICollection<Resource> resources = new List<Resource>();
            ICollection<Course> courses = new List<Course>();
            ICollection<Student> students = new List<Student>();
            ICollection<Homework> homeworks = new List<Homework>();

            Resource eFCFDemo = new Resource
            {
                Id = 1,
                Name = "EFCF StudentSystem Demo",
                Link = "https://github.com/SoftUni/Database-Applications/tree/master/1.%20Entity-Framework",
                ResourceType = ResourceType.Other
            };
            resources.Add(eFCFDemo);

            Resource eFCFPres = new Resource
            {
                Id = 2,
                Name = "EFCF StudentSystem Presentation",
                Link = "https://softuni.bg/downloads/svn/db-apps/March-2015/0.%20Database-Applications-Course-Introduction.pptx",
                ResourceType = ResourceType.Presentation
            };
            resources.Add(eFCFPres);

            Resource eFCFVideo = new Resource
            {
                Id = 3,
                Name = "EFCF StudentSystem Demo",
                Link = "https://softuni.bg/Trainings/Resources/Video/3526/Video-2-March-2015-Vladimir-Georgiev-Database-Applications-Mar-2015",
                ResourceType = ResourceType.Video
            };
            resources.Add(eFCFVideo);

            Resource JSIntroDemo = new Resource
            {
                Id = 4,
                Name = "JS Introduction Demo",
                Link = "https://github.com/SoftUni/JS/tree/master/JSIntro",
                ResourceType = ResourceType.Other
            };
            resources.Add(JSIntroDemo);

            Resource JSIntroPres = new Resource
            {
                Id = 5,
                Name = "JS Introduction Presentation",
                Link = "https://github.com/SoftUni/JS/tree/master/JSIntroPres",
                ResourceType = ResourceType.Other
            };
            resources.Add(JSIntroPres);

            Resource JSIntroVideo = new Resource
            {
                Id = 6,
                Name = "JS Introduction Video",
                Link = "https://github.com/SoftUni/JS/tree/master/JSIntroVideo",
                ResourceType = ResourceType.Other
            };
            resources.Add(JSIntroVideo);

            Course dBAppsCourse = new Course
            {
                Id = 1,
                Name = "Database Applications",
                Description = "Learn to use different databases",
                StartDate = new DateTime(2015, 02, 28),
                EndDate = new DateTime(2015, 03, 29),
                Price = 0m
            };

            Course JSBasicsCourse = new Course
            {
                Id = 2,
                Name = "JavaScript Basics",
                Description = "Basic knowledge on JS",
                StartDate = new DateTime(2014, 02, 28),
                EndDate = new DateTime(2014, 03, 29),
                Price = 50.25m
            };

            Homework eFCFHw = new Homework
            {
                Id = 1,
                Content = "some content",
                ContentType = ContentType.PDF,
                DateAndTime = DateTime.Now,
                Course = dBAppsCourse,
                CourseId = dBAppsCourse.Id
            };

            Homework jSHw = new Homework
            {
                Id = 2,
                Content = "some js content",
                ContentType = ContentType.ZIP,
                DateAndTime = new DateTime(2014, 06, 15),
                Course = JSBasicsCourse,
                CourseId = JSBasicsCourse.Id
            };

            Student gosho = new Student
            {
                Id = 1,
                Name = "Georgi Georgiev",
                RegistrationDate = new DateTime(2014, 05, 05),
                BirthDay = new DateTime(1998, 12, 25),
                PhoneNumber = "6516165165"
            };

            Student pesho = new Student
            {
                Id = 2,
                Name = "Petar Petrov",
                RegistrationDate = new DateTime(2015, 01, 06),
                BirthDay = new DateTime(1989, 12, 25),
                PhoneNumber = "23434534645675678"
            };

            Student minka = new Student
            {
                Id = 3,
                Name = "Minka Mincheva",
                RegistrationDate = new DateTime(2014, 02, 05),
                BirthDay = new DateTime(1978, 12, 25),
                PhoneNumber = "151651516516"
            };

            Student genka = new Student
            {
                Id = 4,
                Name = "Genka Ivanova",
                RegistrationDate = new DateTime(2014, 05, 05),
                BirthDay = new DateTime(1998, 12, 25),
                PhoneNumber = "638735463"
            };

            Student milka = new Student
            {
                Id = 5,
                Name = "Milka Pencheva",
                RegistrationDate = new DateTime(2013, 05, 05),
                BirthDay = new DateTime(1968, 12, 25),
                PhoneNumber = "123456798"
            };

            dBAppsCourse.Resources.Add(eFCFDemo);
            dBAppsCourse.Resources.Add(eFCFPres);
            dBAppsCourse.Resources.Add(eFCFVideo);

            dBAppsCourse.Students.Add(genka);
            dBAppsCourse.Students.Add(pesho);
            dBAppsCourse.Students.Add(milka);

            dBAppsCourse.Homeworks.Add(eFCFHw);

            courses.Add(dBAppsCourse);

            JSBasicsCourse.Resources.Add(JSIntroDemo);
            JSBasicsCourse.Resources.Add(JSIntroPres);
            JSBasicsCourse.Resources.Add(JSIntroVideo);

            JSBasicsCourse.Students.Add(pesho);
            JSBasicsCourse.Students.Add(gosho);
            JSBasicsCourse.Students.Add(milka);

            JSBasicsCourse.Homeworks.Add(jSHw);

            courses.Add(JSBasicsCourse);

            eFCFHw.Student = gosho;
            eFCFHw.StudentId = gosho.Id;

            jSHw.Student = pesho;
            jSHw.StudentId = pesho.Id;

            homeworks.Add(eFCFHw);
            homeworks.Add(jSHw);

            gosho.Courses.Add(JSBasicsCourse);
            students.Add(gosho);

            pesho.Courses.Add(JSBasicsCourse);
            pesho.Courses.Add(dBAppsCourse);
            students.Add(pesho);

            students.Add(minka);

            genka.Courses.Add(dBAppsCourse);
            students.Add(genka);

            milka.Courses.Add(dBAppsCourse);
            milka.Courses.Add(JSBasicsCourse);
            students.Add(milka);

            foreach (Resource resource in resources)
            {
                context.Resources.Add(resource);
            }

            foreach (Course course in courses)
            {
                context.Courses.Add(course);
            }

            foreach (Student student in students)
            {
                context.Students.Add(student);
            }

            foreach (Homework homework in homeworks)
            {
                context.Homeworks.Add(homework);
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
