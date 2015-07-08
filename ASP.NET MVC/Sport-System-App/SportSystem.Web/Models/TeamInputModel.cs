using System.ComponentModel.DataAnnotations;

namespace SportSystem.Web.Models
{
    using System;
    using System.Collections.Generic;
    using SportSystem.Data;

    public class TeamInputModel
    {
        [Required(ErrorMessage = "Team name is required.")]
        public string Name { get; set; }

        public string NickName { get; set; }

        public string WebSite { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateFounded { get; set; }

        public static TeamInputModel CreateFromTeam(Team t)
        {
            return new TeamInputModel()
            {
                Name = t.Name,
                NickName = t.NickName,
                WebSite = t.WebSite,
                DateFounded = t.DateFounded
            };
        }
    }
}