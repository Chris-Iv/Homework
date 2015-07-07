namespace SportSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.Votes = new HashSet<Vote>();
            this.Matches = new HashSet<Match>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string NickName { get; set; }

        public string WebSite { get; set; }

        public DateTime DateFounded { get; set; }

        [Required]
        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
