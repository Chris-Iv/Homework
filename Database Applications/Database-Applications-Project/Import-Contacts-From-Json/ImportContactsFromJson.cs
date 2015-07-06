namespace Import_Contacts_From_Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using Phonebook.Data;
    using Phonebook.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class ImportContactsFromJson
    {
        static void Main()
        {
            var context = new PhonebookContext();
            string contactsJson = File.ReadAllText("../../contacts.json");
            var contacts = JArray.Parse(contactsJson);

            foreach (var contact in contacts)
            {
                try
                {
                  ImportContact(contact);
                  Console.WriteLine("Contact {0} imported", contact["name"]);
                }
                catch (Exception ex)
                {
                  Console.WriteLine("Error: Name is required");
                }
            }
        }

        public static void ImportContact(JToken contactObj)
        {
            var context = new PhonebookContext();
            Contact contact = new Contact();

            if (contactObj["name"] == null)
            {
                throw new Exception("Missing contact name");
            }

            contact.Name = contactObj["name"].Value<string>();

            if (contactObj["position"] != null)
            {
                contact.Position = contactObj["position"].Value<string>();
            }

            if (contactObj["company"] != null)
            {
                contact.Company = contactObj["company"].Value<string>();
            }

            if (contactObj["site"] != null)
            {
                contact.Url = contactObj["site"].Value<string>();
            }

            if (contactObj["notes"] != null)
            {
                contact.Notes = contactObj["notes"].Value<string>();
            }

            var emails = contactObj["emails"];
            if (contactObj["emails"] != null)
            {
                foreach (var email in emails)
                {
                    if (email == null)
                    {
                        throw new Exception("Missing email address");
                    }

                    string emailAddress = email.Value<string>();
                    Email newEmail = new Email() { EmailAddress = emailAddress };
                    contact.Emails.Add(newEmail);
                }
            }

            var phones = contactObj["phones"];
            if (contactObj["phones"] != null)
            {
                foreach (var phone in phones)
                {
                    if (phone == null)
                    {
                        throw new Exception("Missing phone number");
                    }

                    string phoneNumber = phone.Value<string>();
                    Phone newPhone = new Phone() { PhoneNumber = phoneNumber };
                    contact.Phones.Add(newPhone);
                }
            }

            context.Contacts.Add(contact);
            context.SaveChanges();
        }
    }
}