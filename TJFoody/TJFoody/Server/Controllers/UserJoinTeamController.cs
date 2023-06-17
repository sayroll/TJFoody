using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using TJFoody.Server.Service.UserJoinTeamService;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserJoinTeamController:ControllerBase
    {
        private readonly IUserJoinTeamService _userJoinTeamService;
        public UserJoinTeamController(IUserJoinTeamService userJoinTeamService)
        {
            _userJoinTeamService = userJoinTeamService;
        }

        [HttpGet("getCurCount/{teamId}")]
        public async Task<ActionResult<ServiceResponse<int>>> GetTeamCurrentCount(int teamId)
        {
            var response = await _userJoinTeamService.GetTeamCurrentCount(teamId);
            return Ok(response);
        }

        [HttpPost]
        [Route("Join")]
        public async Task<ActionResult<ServiceResponse<EntityEntry<UserJoinTeam>>>> AddJoinTeamInfo(UserJoinTeam UserJoinTeam)
        {
            var response = await _userJoinTeamService.AddJoinTeamInfo(UserJoinTeam);
            return Ok(response);
        }

        [HttpGet("getTeamByJoined/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<Team>>>> getTeamByJoined(string userId)
        {
            var response = await _userJoinTeamService.GetTeamByJoined(userId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("getMember/{teamId}")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> GetMember(int teamId)
        {
            var response = await _userJoinTeamService.GetMember(teamId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("QuitTeam/{userId}/{teamId}")]
        public async Task<ActionResult<ServiceResponse<List<UserJoinTeam>>>> QuitTeam(string userId, int teamId)
        {
            var result = await _userJoinTeamService.QuitTeam(userId, teamId);
            return Ok(result);
        }

        [HttpGet("DisbandTeam/{teamId}")]
        public async Task<ActionResult<ServiceResponse<List<UserJoinTeam>>>> DisbandTeam(int teamId)
        {
            var result = await _userJoinTeamService.DisbandTeam(teamId);
            return Ok(result);
        }
    }

}
