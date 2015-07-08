namespace SportSystem.Web.Controllers
{
    using System.Web.Mvc;
    using SportSystem.Data;

    [ValidateInput(false)]
    public class BaseController : Controller
    {
        protected ApplicationDbContext context = new ApplicationDbContext();
    }
}