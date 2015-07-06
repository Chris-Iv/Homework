namespace Export_Leagues_And_Teams_As_Json
{
    using System;
    using System.IO;
    using System.Linq;
    using Entity_Framework_Mappings;
    using Newtonsoft.Json;

    public class ExportLeaguesAndTeamsAsJson
    {
        static void Main()
        {
            var context = new FootballEntities();

            var leaguesQuery = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams
                        .OrderBy(t => t.TeamName)
                        .Select(t => t.TeamName)
                });

            var json = JsonConvert.SerializeObject(leaguesQuery.ToList());
            File.WriteAllText("../../leagues-and-teams.json", json);
        }
    }
}