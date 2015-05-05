namespace Phonebook.ConsoleClient
{
    using System;
    using System.Linq;
    using Phonebook.Data;
    using Phonebook.Models;

    public class ListContactsWithPhonesAndEmails
    {
        static void Main()
        {
            var context = new PhonebookContext();
            var contacts = context.Contacts.ToList();
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Name);
                foreach (var phone in contact.Phones)
                {
                    Console.WriteLine(phone.PhoneNumber);
                }

                foreach (var email in contact.Emails)
                {
                    Console.WriteLine(email.EmailAddress);
                }
            }
        }
    }
}
