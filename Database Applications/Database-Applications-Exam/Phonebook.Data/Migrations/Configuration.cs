namespace Phonebook.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Phonebook.Models;

    public sealed class Configuration : DbMigrationsConfiguration<PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "PhonebookContext";
        }

        protected override void Seed(PhonebookContext context)
        {
            if (!context.Contacts.Any())
            {
                Email peterFirstEmail = new Email() { EmailAddress = "peter@gmail.com" };
                context.Emails.Add(peterFirstEmail);

                Email peterSecondEmail = new Email() { EmailAddress = "peter_ivanov@yahoo.com" };
                context.Emails.Add(peterSecondEmail);

                Phone peterFirstPhone = new Phone() { PhoneNumber = "+359 2 22 22 22" };
                context.Phones.Add(peterFirstPhone);

                Phone peterSecondPhone = new Phone() { PhoneNumber = "+359 88 77 88 99" };
                context.Phones.Add(peterSecondPhone);

                Contact peter = new Contact()
                {
                    Name = "Peter Ivanov",
                    Position = "CTO",
                    Company = "Smart Ideas",
                    Emails = { peterFirstEmail, peterSecondEmail },
                    Phones = { peterFirstPhone, peterSecondPhone },
                    Url = "http://blog.peter.com",
                    Notes = "Friend from school"
                };
                context.Contacts.Add(peter);

                Phone mariaPhone = new Phone() { PhoneNumber = "+359 22 33 44 55" };
                context.Phones.Add(mariaPhone);

                Contact maria = new Contact()
                {
                    Name = "Maria",
                    Phones = { mariaPhone }
                };
                context.Contacts.Add(maria);


                Email angieEmail = new Email() { EmailAddress = "info@angiestanton.com" };
                context.Emails.Add(angieEmail);

                Contact angie = new Contact()
                {
                    Name = "Angie Stanton",
                    Emails = { angieEmail },
                    Url = "http://angiestanton.com"
                };
                context.Contacts.Add(angie);

                context.SaveChanges();
            }
        }
    }
}