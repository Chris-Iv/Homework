
namespace Phonebook.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Phone
    {
        [Key]
        public int Id { get; set; }

        public string PhoneNumber { get; set; }
    }
}