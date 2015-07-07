namespace SportSystem.Web.Models
{
    using System.Collections.Generic;

    public class MatchesTeamsPlayersCommentsViewModel
    {
        public IEnumerable<MatchViewModel> Matches { get; set; }

        public IEnumerable<TeamViewModel> Teams { get; set; }

        public IEnumerable<PlayerViewModel> Players { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}