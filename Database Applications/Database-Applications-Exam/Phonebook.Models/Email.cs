
namespace Phonebook.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Email
    {
        [Key]
        public int Id { get; set; }

        public string EmailAddress { get; set; }
    }
}