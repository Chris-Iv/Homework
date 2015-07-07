using System.Linq;
using System.Web.Mvc;
using SportSystem.Data;
using SportSystem.Web.Extensions;
using SportSystem.Web.Models;

namespace SportSystem.Web.Controllers
{
    [Authorize]
    public class TeamsController : BaseController
    {
        
        public ActionResult Details(int id)
        {
            var team = context.Teams
                .Where(t => t.Id == id)
                .Select(TeamViewModel.ViewModel);

            var players = context.Players
                .Where(p => p.Team.Id == id)
                .Select(PlayerViewModel.ViewModel);

            return this.View(new MatchesTeamsPlayersCommentsViewModel()
            {
                Teams = team,
                Players = players
            });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var team = new Team()
                {
                    Name = model.Name,
                    NickName = model.NickName,
                    DateFounded = model.DateFounded,
                    WebSite = model.WebSite
                };

                this.context.Teams.Add(team);
                this.context.SaveChanges();
                this.AddNotification("Team Created", NotificationType.INFO);
                return this.RedirectToRoute("/Teams/Details/" + team.Id);
            }

            return this.View(model);
        }
    }
}