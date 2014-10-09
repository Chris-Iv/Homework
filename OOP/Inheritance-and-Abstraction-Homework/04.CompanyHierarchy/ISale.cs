using System;

namespace _04.CompanyHierarchy
{
    public interface ISale
    {
        string ProductName { get; set; }
        string Date { get; set; }
        int Price { get; set; }
    }
}
