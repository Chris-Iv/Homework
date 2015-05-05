namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using BugTracker.Data;
    using BugTracker.Data.Models;
    using BugTracker.RestServices.Models;
    using Microsoft.AspNet.Identity;

    public class CommentsController : ApiController
    {
        private BugTrackerDbContext db = new BugTrackerDbContext();

        // GET: api/Comments
        [Route("api/comments")]
        public IHttpActionResult GetComments()
        {
            var comments = db.Comments
                .OrderByDescending(c => c.DateCreated)
                .ThenBy(c => c.Id)
                .Select(c => new CommentOutputModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = (c.Author != null) ? c.Author.UserName : null,
                    DateCreated = c.DateCreated,
                    BugId = c.Bug.Id,
                    BugTitle = c.Bug.Title
                });

            return this.Ok(comments);
        }

        // GET: api/Comments/5
        [Route("api/bugs/{id:int}/comments")]
        public IHttpActionResult GetComment(int id)
        {
            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = db.Comments
                .Where(c => c.Bug.Id == bug.Id)
                .OrderByDescending(c => c.DateCreated)
                .ThenBy(c => c.Id)
                .Select(c => new CommentForABug
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = (c.Author != null) ? c.Author.UserName : null,
                    DateCreated = c.DateCreated
                });

            return this.Ok(comments);
        }

        // POST: api/Comments
        [Route("api/bugs/{id:int}/comments")]
        public IHttpActionResult PostComment(int id, Comment commentData)
        {
            if (commentData == null)
            {
                return this.BadRequest();
            }

            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserId);

            var comment = new Comment
            {
                Text = commentData.Text,
                DateCreated = DateTime.Now,
                Author = currentUser,
                Bug = bug
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            if (comment.Author == null)
            {
                return this.Ok(new { Id = id, Message = "Added anonymous comment for bug #" + bug.Id });
            }

            return this.Ok(new { Id = id, Author = comment.Author.UserName, Message = "User comment added for bug #" + bug.Id });
        }
    }
}