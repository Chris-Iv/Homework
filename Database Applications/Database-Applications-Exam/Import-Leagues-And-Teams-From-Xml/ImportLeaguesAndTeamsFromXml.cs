namespace Import_Leagues_And_Teams_From_Xml
{
    using System;
    using System.Linq;
    using System.Text;
    using Entity_Framework_Mappings;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class ImportLeaguesAndTeamsFromXml
    {
        static void Main()
        {
            var context = new FootballEntities();
            var xmlDoc = XDocument.Load("../../leagues-and-teams.xml");
            var leagueNodes = xmlDoc.XPathSelectElements("/leagues-and-teams/league");

            int counter = 0;
            foreach (var leagueNode in leagueNodes)
            {
                counter++;
                Console.WriteLine("Processing league #{0} ...", counter);

                League league = new League();
                if (leagueNode.Descendants("league-name") != null)
                {
                    league.LeagueName = leagueNode.Descendants("league-name").First().Value;
                }

                var leagueExists = context.Leagues.FirstOrDefault(l => l.LeagueName == league.LeagueName);
                if (leagueExists != null)
                {
                    Console.WriteLine("Existing league: {0}", leagueExists.LeagueName);
                }
                else
                {
                    context.Leagues.Add(league);
                    Console.WriteLine("Created league: {0}", league.LeagueName);
                }

                if (leagueNode.Descendants("teams") != null)
                {
                    var teamNodes = leagueNode.XPathSelectElements("teams/team");
                    foreach (var teamNode in teamNodes)
                    {
                        if (teamNode.Attribute("name") == null)
                        {
                            throw new Exception("Invalid team name");
                        }

                        Team team = new Team();
                        team.TeamName = teamNode.Attribute("name").Value;

                        if (teamNode.Attribute("country") != null)
                        {
                            var countryName = teamNode.Attribute("country").Value;
                            var country = context.Countries
                                .FirstOrDefault(c => c.CountryName == countryName);

                            team.Country = country;
                        }
                                                
                        var teamNameExtists = context.Teams.FirstOrDefault(t => t.TeamName == team.TeamName);
                        if (teamNameExtists != null)
                        {
                            var teamExists = teamNameExtists;
                            if (team.Country != null)
                            {
                                teamExists = context.Teams
                                    .FirstOrDefault(t => t.Country == teamNameExtists.Country);
                            }
                            
                            if (teamExists != null)
                            {
                                if (team.Country != null)
                                {
                                    Console.WriteLine("Existing team: {0} ({1})",
                                        team.TeamName, team.Country.CountryName);
                                }
                                else
                                {
                                    Console.WriteLine("Existing team: {0} (no country)", team.TeamName);
                                }
                               
                                Console.WriteLine("Existing team in league: {0} belongs to {1}", 
                                    teamExists.TeamName, teamExists.Leagues.FirstOrDefault().LeagueName);
                            }
                            else
                            {
                                context.Teams.Add(team);

                                if (team.Country != null)
                                {
                                    Console.WriteLine("Created team: {0} ({1})", team.TeamName, team.Country.CountryName);
                                }
                                else
                                {
                                    Console.WriteLine("Created team: {0} (no country)", team.TeamName);
                                }

                                league.Teams.Add(team);
                                Console.WriteLine("Added team to league: {0} to league {1}", team.TeamName, league.LeagueName);
                            }
                        }
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}