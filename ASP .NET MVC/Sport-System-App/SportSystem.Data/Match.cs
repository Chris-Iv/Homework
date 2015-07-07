namespace SportSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Match
    {
        public Match()
        {
            this.Comments = new HashSet<Comment>();
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int Id { get; set; }

        public int HomeTeamId { get; set; }

        [Required]
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [Required]
        public virtual Team AwayTeam { get; set; }

        [Required]
        public DateTime MatchDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}