namespace Phonebook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        private ICollection<Email> emails;
        private ICollection<Phone> phone;

        public Contact()
        {
            this.Emails = new HashSet<Email>();
            this.Phones = new HashSet<Phone>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        public string Url { get; set; }

        public string Notes { get; set; }
    }
}