using System;

namespace _04.CompanyHierarchy
{
    public class Customer : Person, ICustomer
    {
        public int NetPurchaseAmount { get; set; }

        public Customer(string id, string fistName, string lastName, int netPurchaseAmount)
            : base(id, fistName, lastName)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("{0:N2}", this.NetPurchaseAmount);
        }
    }
}
