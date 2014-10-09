using System;

namespace _02.HumanStudentandWorker
{
    class Worker : Human
    {
        public decimal WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            decimal salary = this.WeekSalary;
            int hours = this.WorkHoursPerDay;
            decimal result = (salary / 7) / hours;
            return result;
        }
    }
}
