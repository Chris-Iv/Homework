namespace Export_International_Matches_As_Xml
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Entity_Framework_Mappings;

    public class ExportInternationalMatchesAsXml
    {
        static void Main()
        {
            var context = new FootballEntities();
            var matchesQuery = context.InternationalMatches
                .OrderBy(m => m.MatchDate)
                .ThenBy(m => m.HomeCountry)
                .ThenBy(m => m.AwayCountry)
                .Select(m => new
                {
                    HomeCountry = m.HomeCountry,
                    AwayCountry = m.AwayCountry,
                    Date = m.MatchDate,
                    HomeGoals = m.HomeGoals,
                    AwayGoals = m.AwayGoals,
                    League = m.League
                });

            var xmlRoot = new XElement("matches");

            foreach (var match in matchesQuery)
            {
                var matchXml = new XElement("match");
                if (match.Date != null)
                {
                    DateTime date = match.Date.Value;
                    var hours = date.Hour;
                    var minutes = date.Minute;
                    if (hours == 00 && minutes == 00)
                    {
                        var matchDate = date.ToString("dd-MMM-yyyy");
                        matchXml.Add(new XAttribute("date", matchDate));
                    }
                    else
                    {
                        var matchDate = date.ToString("dd-MMM-yyyy hh:mm");
                        matchXml.Add(new XAttribute("date-time", matchDate));
                    }
                }

                var homeCountryXml = new XElement("home-country", 
                    new XAttribute("code", match.HomeCountry.CountryCode), match.HomeCountry.CountryName);
                matchXml.Add(homeCountryXml);

                var awayCountryXml = new XElement("away-country", 
                    new XAttribute("code", match.AwayCountry.CountryCode), match.AwayCountry.CountryName);
                matchXml.Add(awayCountryXml);

                if (match.HomeGoals != null && match.AwayGoals != null)
                {
                    var score = match.HomeGoals.Value + "-" + match.AwayGoals.Value;
                    var scoreXml = new XElement("score", score);
                    matchXml.Add(scoreXml);
                }

                if (match.League != null)
                {
                    var leagueXml = new XElement("league", match.League.LeagueName);
                    matchXml.Add(leagueXml);
                }

                xmlRoot.Add(matchXml);
            }

            var xmlDoc = new XDocument(xmlRoot);
            xmlDoc.Save("../../international-matches.xml");
        }
    }
}