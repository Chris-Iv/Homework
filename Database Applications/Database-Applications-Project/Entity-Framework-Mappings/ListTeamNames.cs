namespace Entity_Framework_Mappings
{
    using System;
    using System.Linq;

    public class ListTeamNames
    {
        static void Main()
        {
            var context = new FootballEntities();
            var teamNames = context.Teams.Select(t => t.TeamName);

            foreach (var teamName in teamNames)
            {
                Console.WriteLine(teamName);
            }
        }
    }
}