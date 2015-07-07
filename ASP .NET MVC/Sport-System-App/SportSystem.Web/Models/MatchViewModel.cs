namespace SportSystem.Web.Models
{
    using System;
    using System.Linq.Expressions;
    using SportSystem.Data;

    public class MatchViewModel
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public DateTime MatchDate { get; set; }

        public static Expression<Func<Match, MatchViewModel>> ViewModel
        {
            get
            {
                return m => new MatchViewModel()
                {
                    Id = m.Id,
                    HomeTeam = m.HomeTeam.Name,
                    AwayTeam = m.AwayTeam.Name,
                    MatchDate = m.MatchDate
                };
            }
        }
    }
}