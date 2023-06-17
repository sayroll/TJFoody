using System.Collections.Generic;
using TJFoody.Shared;

namespace TJFoody.Client.Services.UserJoinTeamService
{
    public class UserJoinTeamService:IUserJoinTeamService
    {
        private readonly HttpClient _http;

        public UserJoinTeamService(HttpClient http)
        {
            _http = http;
        }

        async Task<ServiceResponse<List<UserJoinTeam>>> IUserJoinTeamService.DisbandTeam(int teamId)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<UserJoinTeam>>>($"UserJoinTeam/DisbandTeam/{teamId}");
            return response;
        }

        async Task<List<string>> IUserJoinTeamService.getMember(int teamId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"UserJoinTeam/getMember/{teamId}");
            return result.Data;
        }

        async Task<List<Team>> IUserJoinTeamService.getTeambyJoined(string userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Team>>>($"UserJoinTeam/getTeamByJoined/{userId}");
            return result.Data;
        }

        async Task<int> IUserJoinTeamService.GetTeamCurrentCount(int teamId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<int>>($"UserJoinTeam/getCurCount/{teamId}");
            return result.Data;
        }

        async Task<ServiceResponse<UserJoinTeam>> IUserJoinTeamService.joinTeam(UserJoinTeam userJoinTeam)
        {
            var response = await _http.PostAsJsonAsync("UserJoinTeam/Join", userJoinTeam);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<UserJoinTeam>>();
        }

        async Task<ServiceResponse<List<UserJoinTeam>>> IUserJoinTeamService.QuitTeam(string userId, int teamId)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List< UserJoinTeam>>> ($"UserJoinTeam/QuitTeam/{userId}/{teamId}");
            return response;
        }
    }
}
