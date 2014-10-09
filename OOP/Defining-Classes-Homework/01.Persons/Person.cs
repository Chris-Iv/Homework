using System;

namespace _01.Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name is empty!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age must be [1...100]!");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (value != null && !value.Contains("@"))
                {
                    throw new ArgumentException("Ivalid email!");
                }
                else
                {
                    this.email = value;
                }
            }
        }

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Person(string name, int age) : this(name, age, null) { }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                return string.Format("Person name is {0}\nHe is {1} years old.", this.Name, this.Age);
            }
            else
            {
                return string.Format("Person name is {0}\nHe is {1} years old\nand his email is {2}.", this.Name, this.Age, this.Email);
            }
        }
    }
}
