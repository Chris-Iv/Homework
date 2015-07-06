using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace BugTracker.RestServices.Models
{
    using System;

    public class CommentInBugOutputModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }
    }
}