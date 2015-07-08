namespace SportSystem.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public virtual User Author { get; set; }

        public int MatchId { get; set; }

        [Required]
        public virtual Match Match { get; set; }
    }
}
