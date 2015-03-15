namespace NewsDb.Data.Migrations
{
    using NewsDb.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<NewsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "NewsDbContext";
        }

        protected override void Seed(NewsDbContext context)
        {
            //context.News.AddOrUpdate(new News()
            //{
            //    Content = "Entity Framework"
            //});

            //context.News.AddOrUpdate(new News()
            //{
            //    Content = "SoftUni Rocks"
            //});

            //context.News.AddOrUpdate(new News()
            //{
            //    Content = "Daily news"
            //});

            //context.News.AddOrUpdate(new News()
            //{
            //    Content = "Something interesting"
            //});

            //context.News.AddOrUpdate(new News()
            //{
            //    Content = "The truth"
            //});

            //context.SaveChanges();
        }
    }
}
