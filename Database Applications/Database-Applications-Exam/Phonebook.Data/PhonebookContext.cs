namespace Phonebook.Data
{
    using System;
    using System.Data.Entity;
    using Phonebook.Models;
    using Phonebook.Data.Migrations;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>());
        }

        public IDbSet<Contact> Contacts { get; set; }

        public IDbSet<Email> Emails { get; set; }

        public IDbSet<Phone> Phones { get; set; }
    }
}