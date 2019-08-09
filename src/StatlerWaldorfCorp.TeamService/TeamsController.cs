using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StatlerWaldorf.TeamService.Persistence;

namespace StartlerWaldorf
{
    [Route("[controller]")]
    public class TeamsController:Controller
    {
        private readonly ITeamRepository repository;

        public TeamsController(ITeamRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async virtual Task<IActionResult> GetAllTeams()
        {
            return await Task.Run(()=> this.Ok(repository.GetTeams()));
        }
    }
}