using System;
using System.ComponentModel.DataAnnotations;

namespace Events.Web.Models
{
    public class CommentInputModel
    {
        [Required]
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string Author { get; set; }

        public int EventId { get; set; }
    }
}