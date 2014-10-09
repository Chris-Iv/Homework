using System;
using System.Collections.Generic;

namespace _04.CompanyHierarchy
{
    class CompanyHierarchy
    {
        static void Main()
        {
            Sale product1 = new Sale("Product1", "02-06-2013", 500);
            Sale product2 = new Sale("Product2", "05-09-2013", 250);

            Sale[] sales = new Sale[2]
            {
                product1,
                product2
            };

            Project project1 = new Project("Project1", "20-08-2014", "detail", ProjectState.Open);
            Project project2 = new Project("Project2", "25-03-2014", "detail", ProjectState.Open);

            Project[] projects = new Project[2]
            {
                project1,
                project2
            };

            Employee gosho = new SalesEmployee("8527", "Pesho", "Peshev", 2500, Department.Sales, sales);
            Employee misho = new Developer("8527", "Pesho", "Peshev", 2500, Department.Production, projects);

            Employee[] workers = new Employee[2] { gosho, misho };

            Employee pesho = new Manager("8527", "Pesho", "Peshev", 2500, Department.Marketing, workers);

            List<Employee> employees = new List<Employee>()
            {
                gosho,
                misho,
                pesho
            };

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
                Console.WriteLine();
            }
        }
    }
}
