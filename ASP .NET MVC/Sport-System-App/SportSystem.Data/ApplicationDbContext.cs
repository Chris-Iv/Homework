using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SportSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new {r.RoleId, r.UserId});

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}