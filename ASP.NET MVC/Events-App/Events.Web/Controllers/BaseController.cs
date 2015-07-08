using System.Web.Mvc;
using Events.Data;
using Microsoft.AspNet.Identity;

namespace Events.Web.Controllers
{
    [ValidateInput(false)]
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        public bool IsAdmin()
        {
            var currentUser = this.User.Identity.GetUserId();
            var isAdmin = (currentUser != null && this.User.IsInRole("Administrator"));
            return isAdmin;
        }
    }
}