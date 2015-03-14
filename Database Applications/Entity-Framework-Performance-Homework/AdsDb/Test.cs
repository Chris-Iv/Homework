namespace AdsDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    public class Test
    {
        public static void Main(string[] args)
        {
            var db = new AdsEntities();

            //Slow variant - Count of queries = 28
            foreach (var ad in db.Ads)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",
                    ad.Title, ad.AdStatus.Status, ad.Category, ad.Town, ad.AspNetUser.Name);
            }


            //Fast variant - Count of queries = 1
            foreach (var ad in db.Ads
                .Include(a => a.AdStatus)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser))
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",
                    ad.Title, ad.AdStatus.Status, ad.Category, ad.Town, ad.AspNetUser.Name);
            }



            //Slow varaint - count of queries = 39
            var adsSlow = db.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .Select(a => new
                {
                    a.Title,
                    a.Category,
                    a.Town,
                    a.Date
                })
                .ToList()
                .OrderBy(a => a.Date);



            //Fast variant - count of queries = 1
            var adsFast = db.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    a.Title,
                    a.Category,
                    a.Town,
                    a.Date
                })
                .ToList();


            //Slow variant - time = ~1.30s
            var startTimeSlow = DateTime.Now;

            var ads = db.Ads.FirstOrDefault();
            Console.WriteLine(ads.Title);

            var endTimeSlow = DateTime.Now;
            Console.WriteLine(endTimeSlow - startTimeSlow);

            //Fast variant - time = ~1.20s
            var startTimeFast = DateTime.Now;

            var adTitle = db.Ads.Select(a => a.Title).FirstOrDefault();
            Console.WriteLine(adTitle);

            var endTimeFast = DateTime.Now;
            Console.WriteLine(endTimeFast - startTimeFast);
        }
    }
}
