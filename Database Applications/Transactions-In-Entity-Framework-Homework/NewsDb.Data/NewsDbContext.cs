namespace NewsDb.Data
{
    using NewsDb.Data.Migrations;
    using NewsDb.Models;
    using System;
    using System.Data.Entity;

    public class NewsDbContext : DbContext
    {
        public NewsDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
        }

        public IDbSet<News> News { get; set; }
    }
}
