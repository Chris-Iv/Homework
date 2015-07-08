namespace SportSystem.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public int TeamId { get; set; }

        [Required]
        public Team Team { get; set; }

        public int VoteUserId { get; set; }

        [Required]
        public User VoteUser { get; set; }
    }
}
