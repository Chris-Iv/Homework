using System;

class PrintCompanyInformation
{
    static void Main()
    {
        Console.WriteLine("Enter company information:");
        Console.WriteLine("Enter company name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter company address:");
        string address = Console.ReadLine();
        Console.WriteLine("Enter company phone number:");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Enter company fax number:");
        string faxNumber = Console.ReadLine();
        Console.WriteLine("Enter company web site:");
        string webSite = Console.ReadLine();
        Console.WriteLine("Enter manager information:");
        Console.WriteLine("Enter manager first name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter manager last name:");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter manager age:");
        string age = Console.ReadLine();
        Console.WriteLine("Enter manager phone number:");
        string managerPhoneNumber = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Company information:");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Address: " + address);
        Console.WriteLine("Phone number: " + phoneNumber);
        Console.WriteLine("Fax number: " + faxNumber);
        Console.WriteLine("Web site: " + webSite);
        Console.WriteLine("Manager information:");
        Console.WriteLine("Name : {0} {1}", firstName, lastName);
        Console.WriteLine("Age:" + age);
        Console.WriteLine("Phone number: " + managerPhoneNumber);
    }
}