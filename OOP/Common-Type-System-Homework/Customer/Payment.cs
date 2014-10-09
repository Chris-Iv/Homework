using System;

namespace Customer
{
    public class Payment
    {
        public string ProductName { get; set; }
        public int Price { get; set; }

        public Payment(string productName, int price)
        {
            this.Price = price;
            this.ProductName = productName;
        }
    }
}
