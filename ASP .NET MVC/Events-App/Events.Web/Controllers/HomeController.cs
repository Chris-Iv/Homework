using Events.Web.Extensions;

namespace Events.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Events.Web.Models;
    using Microsoft.AspNet.Identity;
    using Events.Data;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var events = this.db.Events
                .OrderBy(e => e.StartDateTime)
                .Where(e => e.IsPublic)
                .Select(EventViewModel.ViewModel);

            var upcomingEvents = events.Where(e => e.StartDateTime > DateTime.Now);
            var passedEvents = events.Where(e => e.StartDateTime <= DateTime.Now);
            return View(new UpcomingPassedEventsViewModel()
            {
                UpcomingEvents = upcomingEvents,
                PassedEvents = passedEvents
            });
        }

        public ActionResult EventDetailsById(int id)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var isAdmin = this.IsAdmin();
            var eventDetails = this.db.Events
                .Where(e => e.Id == id)
                .Where(e => e.IsPublic || isAdmin || (e.AuthorId != null && e.AuthorId == currentUserId))
                .Select(EventDetailsViewModel.ViewModel)
                .FirstOrDefault();

            var isOwner = (eventDetails != null && eventDetails.AuthorId != null &&
                           eventDetails.AuthorId == currentUserId);
            this.ViewBag.CanEdit = isOwner || isAdmin;
            this.ViewBag.isAdmin = isAdmin;

            return this.PartialView("_EventDetails", eventDetails);
        }

        [HttpGet]
        public ActionResult AddComment()
        {
            return this.PartialView("_AddComment");
        }

        [HttpPost]
        public ActionResult AddComment(int id, CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var c = new Comment()
                {
                    Text = model.Text,
                    AuthorId = this.User.Identity.GetUserId(),
                    Date = DateTime.Now,
                    EventId = id
                };

                this.db.Comments.Add(c);
                this.db.SaveChanges();
                this.AddNotification("Comment Added.", NotificationType.INFO);
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        public ActionResult DeleteComment(int id)
        {
            var commentToDelete = this.db.Comments.Where(c => c.Id == id).FirstOrDefault();
            this.db.Comments.Remove(commentToDelete);
            this.db.SaveChanges();
            this.AddNotification("Comment Deleted.", NotificationType.INFO);
            return this.RedirectToAction("Index");
        }
    }
}