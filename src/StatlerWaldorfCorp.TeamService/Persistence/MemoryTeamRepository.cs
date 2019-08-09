using System.Collections.Generic;
using StatlerWaldorf.TeamService.Models;
using StatlerWaldorf.TeamService.Persistence;

namespace StatlerWaldorfCorp.TeamService.Persistence
{
    public class MemoryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> teams;
        public MemoryTeamRepository()
        {
            if (teams == null)
            {
                teams = new List<Team>();
            }
        }
        public MemoryTeamRepository(ICollection<Team> teams)
        {
        teams = teams;
        }
        public IEnumerable<Team> GetTeams()
        {
            return teams;
        }
        public void AddTeam(Team t)
        {
            teams.Add(t);
        }
    }
}