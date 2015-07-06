namespace BugTracker.RestServices.Models
{
    using System;
    using BugTracker.Data.Models;

    public class BugOutputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public BugStatus Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}