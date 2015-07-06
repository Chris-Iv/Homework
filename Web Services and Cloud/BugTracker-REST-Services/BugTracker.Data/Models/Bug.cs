namespace BugTracker.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        [Key]
        public int Id { get; set; }

        public Bug()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public BugStatus Status { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public virtual User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}