namespace SportSystem.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Bet
    {
        [Key]
        public int Id { get; set; }

        public int MatchId { get; set; }

        [Required]
        public virtual Match Match { get; set; }

        [Required]
        public decimal HomeBet { get; set; }

        [Required]
        public decimal AwayBet { get; set; }

        public int UserId { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}