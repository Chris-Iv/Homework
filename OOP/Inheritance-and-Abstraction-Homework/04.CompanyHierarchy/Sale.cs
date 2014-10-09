using System;

namespace _04.CompanyHierarchy
{
    public class Sale : ISale
    {
        public string ProductName { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }

        public Sale(string productName, string date, int price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }
    }
}
