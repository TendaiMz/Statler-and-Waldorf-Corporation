using System.Collections.Generic;
using StatlerWaldorf.TeamService.Models;

namespace StatlerWaldorf.TeamService.Persistence{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetTeams();
        void AddTeam(Team team);
    }
}