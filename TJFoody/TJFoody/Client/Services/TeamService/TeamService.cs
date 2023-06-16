using TJFoody.Shared;

namespace TJFoody.Client.Services.TeamService
{
    public class TeamService:ITeamService
    {
        private readonly HttpClient _http;

        public TeamService(HttpClient http)
        {
            _http = http;
        }

        public List<Team> teams { get; set; } = new List<Team>();

        public async Task GetTeams()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Team>>>("Team/getAllTeam");
            if (result != null && result.Data != null)
                teams = result.Data;
        }

        async Task<ServiceResponse<Team>> ITeamService.addTeam(Team team)
        {
            var response = await _http.PostAsJsonAsync("Team/addTeam", team);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<Team>>();
        }

        async Task<List<Team>> ITeamService.getTeamByLeaderId(string userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Team>>>($"Team/getTeamByLeaderId/{userId}");
            return result.Data;
        }
    }
}
