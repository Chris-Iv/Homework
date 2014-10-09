using System;

namespace _04.CompanyHierarchy
{
    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public Sale[] Sales { get; set; }

        public SalesEmployee(string id, string firstName, string lastName, int salary, Department department, Sale[] sales)
            : base(id, firstName, lastName, salary, department)
        {
            this.Sales = sales;
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format("\nSales: {0}", this.Sales);
        }
    }
}
