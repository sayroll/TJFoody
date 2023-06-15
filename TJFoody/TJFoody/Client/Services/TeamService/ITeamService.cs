namespace TJFoody.Client.Services.TeamService
{
    public interface ITeamService
    {
        List<Team> teams { get; set; }
        Task GetTeams();

        Task<ServiceResponse<Team>> addTeam(Team team);
    }
}
