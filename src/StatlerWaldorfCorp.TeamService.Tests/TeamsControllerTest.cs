using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using StartlerWaldorf;
using StatlerWaldorf.TeamService.Models;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StatlerWaldorf.TeamService.Persistence;
using StatlerWaldorfCorp.TeamService.Persistence;

namespace StatlerWaldorfCorp.TeamService
{
    public class TeamsControllerTest
    {
        ITeamRepository repo = new  MemoryTeamRepository();
      
        [Fact]
        public async Task QueryTeamListRetrunsCorrectTeams()
        {
            TeamsController controller = new TeamsController(repo);
            List<Team> teams = new List<Team>((IEnumerable<Team>)(await controller.GetAllTeams() as ObjectResult).Value);
            Assert.Equal(teams.Count, 2);
        }
        [Fact]
        public async Task CreateTeamAddsTeamToList()
        {
            TeamsController controller = new TeamsController(repo);
            var teams = (IEnumerable<Team>)
            (await controller.GetAllTeams() as ObjectResult).Value;
            List<Team> original = new List<Team>(teams);

            Team t = new Team("sapmle");
            var result = await controller.CreateTeam(t);
            var newTeamsRaw =
            (IEnumerable<Team>)(await controller.GetAllTeams() as ObjectResult).Value;

            List<Team> newTeams = new List<Team>(newTeamsRaw);
            Assert.Equal(newTeams.Count, original.Count + 1);
            var sampleTeam =
            newTeams.FirstOrDefault(target => target.Name == "sample");
            Assert.NotNull(sampleTeam);


        }
    }
}
