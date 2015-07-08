namespace SportSystem.Web.Models
{
    using System;
    using System.Linq.Expressions;
    using SportSystem.Data;

    public class PlayerViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public double Height { get; set; }

        public static Expression<Func<Player, PlayerViewModel>> ViewModel
        {
            get
            {
                return p => new PlayerViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                    Height = p.Height
                };
            }
        }
    }
}