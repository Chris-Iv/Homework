using System;
using System.Linq;

namespace SoftUniDbContext
{
    public class DAO
    {
        private static SoftUniEntities db = new SoftUniEntities();

        public static int InsertEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return employee.EmployeeID;
        }

        public static void ModifyEmployee(int employeeId, string propertyName, object newValue)
        {
            Employee employee = db.Employees.Find(employeeId);

            if (employee != null)
            {
                employee.GetType().GetProperty(propertyName).SetValue(employee, newValue);
                db.SaveChanges();
            }
        }

        public static void DeleteEmployee(int employeeId)
        {
            Employee employee = db.Employees.Find(employeeId);

            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }
    }
}