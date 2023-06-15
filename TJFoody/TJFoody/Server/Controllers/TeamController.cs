using Microsoft.AspNetCore.Mvc;
using TJFoody.Server.Service.TeamService;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpPost]
        [Route("addTeam")]
        public async Task<ActionResult<ServiceResponse<Team>>> addTeam(Team team)
        {
            var result = await _teamService.AddTeamAsync(team);
            return Ok(result);
        }

        [HttpGet]
        [Route("getAllTeam")]
        public async Task<ActionResult<ServiceResponse<List<Seller>>>> getSellers()
        {
            var result = await _teamService.GetTeamsAsync();
            return Ok(result);
        }

        [HttpGet("getTeamByLeaderId/{leaderId}")]
        public async Task<ActionResult<ServiceResponse<List<Team>>>> getTeamByLeaderId(string leaderId)
        {
            var response = await _teamService.GetTeamByLeaderId(leaderId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
