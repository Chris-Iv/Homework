using System.Linq;
using System.Web.Mvc;
using SportSystem.Web.Models;

namespace SportSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var matches = context.Matches
                .OrderBy(m => m.Bets)
                .Take(3)
                .Select(MatchViewModel.ViewModel);

            var teams = context.Teams
                .OrderBy(t => t.Votes)
                .Take(3)
                .Select(TeamViewModel.ViewModel);

            return View(new MatchesTeamsPlayersCommentsViewModel()
            {
                Matches = matches,
                Teams = teams
            });
        }
    }
}