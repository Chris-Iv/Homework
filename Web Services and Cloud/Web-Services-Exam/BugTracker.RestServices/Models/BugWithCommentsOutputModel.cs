namespace BugTracker.RestServices.Models
{
    using System;
    using BugTracker.Data.Models;
    using System.Collections.Generic;

    public class BugWithCommentsOutputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<CommentInBugOutputModel> Comments { get; set; }
    }
}