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

    [RoutePrefix("api/bugs")]
    public class BugsController : ApiController
    {
        private BugTrackerDbContext db = new BugTrackerDbContext();

        // GET: api/Bugs
        public IHttpActionResult GetBugs()
        {
            var bugs = db.Bugs
                .OrderByDescending(b => b.DateCreated)
                .ThenBy(b => b.Id)
                .Select(b => new BugOutputModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.Status,
                    Author = (b.Author != null) ? b.Author.UserName : null,
                    DateCreated = b.DateCreated
                });

            return this.Ok(bugs);
        }

        // GET: api/Bugs/5
        [Route("{id:int}")]
        public IHttpActionResult GetBug(int id)
        {
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return NotFound();
            }

            var comments = db.Comments
                .Where(c => c.Bug.Id == bug.Id)
                .OrderByDescending(c => c.DateCreated)
                .ThenBy(c => c.Id)
                .Select(c => new CommentInBugOutputModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    Author = (c.Author != null) ? c.Author.UserName : null
                });

            var bugOutput = new BugWithCommentsOutputModel
            {
                Id = bug.Id,
                Title = bug.Title,
                Description = bug.Description,
                Status = bug.Status,
                Author = (bug.Author != null) ? bug.Author.UserName : null,
                DateCreated = bug.DateCreated,
                Comments = comments
            };

            return this.Ok(bugOutput);
        }

        // PATCH: api/Bugs/5
        [Route("{id:int}")]
        public IHttpActionResult PatchBug(int id, Bug bugData)
        {
            if (bugData == null)
            {
                return this.BadRequest();
            }

            var bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }
            
            if (bugData.Title != null)
            {
                bug.Title = bugData.Title;
            }

            if (bugData.Description != null)
            {
                bug.Description = bugData.Description;
            }

            if (bugData.Status != bug.Status)
            {
                bug.Status = bugData.Status;
            }

            db.SaveChanges();
            return this.Ok(new { Message = "Bug #" + bug.Id + " patched." });
        }

        // POST: api/Bugs
        public IHttpActionResult PostBug(Bug bugData)
        {
            if (bugData == null)
            {
                return this.BadRequest();
            }

            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserId);

            var bug = new Bug
            {
                Title = bugData.Title,
                Description = bugData.Description,
                Status = BugStatus.Open,
                DateCreated = DateTime.Now,
                Author = currentUser
            };

            db.Bugs.Add(bug);
            db.SaveChanges();

            if (bug.Author == null)
            {
                var anonMessage = new
                {
                    Id = bug.Id,
                    Message = "Anonymous bug submitted."
                };

                return this.CreatedAtRoute("DefaultApi", new { controller = "bugs", anonMessage.Id, anonMessage.Message }, anonMessage);
            }

            var message = new
            {
                Id = bug.Id,
                Author = bug.Author.UserName,
                Message = "User bug submitted."
            };

            return this.CreatedAtRoute("DefaultApi", new 
            { controller = "bugs", id = message.Id, Athor = message.Author, Message = message.Message }, message);
        }

        // DELETE: api/Bugs/5
        [Route("{id:int}")]
        public IHttpActionResult DeleteBug(int id)
        {
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = db.Comments.Where(c => c.Bug.Id == bug.Id);
            foreach (var comment in comments)
            {
                db.Comments.Remove(comment);
            }
            
            db.Bugs.Remove(bug);
            db.SaveChanges();

            return this.Ok(new { Message = "Bug #" + bug.Id + " deleted." });
        }
    }
}