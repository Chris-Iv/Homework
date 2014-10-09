using System;

namespace _04.CompanyHierarchy
{
    public abstract class Person : IPerson
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}, First Name: {1}, Last Name: {2}", this.Id, this.FirstName, this.LastName);
        }
    }
}
