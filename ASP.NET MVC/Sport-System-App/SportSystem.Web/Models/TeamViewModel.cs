namespace SportSystem.Web.Models
{
    using System;
    using System.Linq.Expressions;
    using SportSystem.Data;

    public class TeamViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public string WebSite { get; set; }

        public DateTime DateFounded { get; set; }

        public int Votes { get; set; }

        public static Expression<Func<Team, TeamViewModel>> ViewModel
        {
            get
            {
                return t => new TeamViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    NickName = t.NickName,
                    WebSite = t.WebSite,
                    DateFounded = t.DateFounded,
                    Votes = t.Votes.Count
                };
            }
        }
    }
}