using System.Linq;
using System.Web.Mvc;
using SportSystem.Web.Models;

namespace SportSystem.Web.Controllers
{
    public class MatchesController : BaseController
    {
        public ActionResult All()
        {
            var matches = context.Matches
                .OrderBy(m => m.MatchDate)
                .Select(MatchViewModel.ViewModel);

            return this.View(new MatchesTeamsPlayersCommentsViewModel()
            {
                Matches = matches
            });
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var match = context.Matches
                .Where(m => m.Id == id)
                .Select(MatchViewModel.ViewModel);

            var comments = context.Comments
                .Where(c => c.Match.Id == id)
                .Select(CommentViewModel.ViewModel);

            return this.View(new MatchesTeamsPlayersCommentsViewModel()
            {
                Matches = match,
                Comments = comments
            });
        }
    }
}