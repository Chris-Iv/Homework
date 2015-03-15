namespace NewsDb.ConsoleClient
{
    using NewsDb.Data;
    using NewsDb.Models;
    using System;
    using System.Linq;

    public class ConsoleClient
    {
        public static void Main(string[] args)
        {
            var firstContext = new NewsDbContext();
            var secondContext = new NewsDbContext();

            //firstContext.News.Add(new News()
            //    {
            //        Content = "It works"
            //    });
            //firstContext.SaveChanges();

            //var firstNews = firstContext.News.ToList();
            //Console.WriteLine("Application started");

            //foreach (var news in firstNews)
            //{
            //    Console.WriteLine(news.Content);
            //    news.Content = "First " + news.Content;
            //}

            //firstContext.SaveChanges();

            //var secondNews = secondContext.News.ToList();

            //foreach (var news in secondNews)
            //{
            //    news.Content = "Second " + news.Content;
            //}

            //try
            //{
            //    secondContext.SaveChanges();
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Conflict!");
            //    var thirdContext = new NewsDbContext();
            //    var thirdNews = thirdContext.News.ToList();
            //    foreach (var news in thirdNews)
            //    {
            //        news.Content = "Third " + news.Content;
            //    }
            //}

            //Console.WriteLine("Changes successfully saved in the DB.");
        }
    }
}