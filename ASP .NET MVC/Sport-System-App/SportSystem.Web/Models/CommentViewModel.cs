using System;
using System.Linq.Expressions;
using SportSystem.Data;

namespace SportSystem.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Author { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> ViewModel
        {
            get
            {
                return c => new CommentViewModel()
                {
                    Id = c.Id,
                    Content = c.Content,
                    DateAndTime = c.DateAndTime,
                    Author = c.Author.UserName
                };
            }
        }
    }
}