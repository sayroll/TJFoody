namespace TJFoody.Client.Services.UserJoinTeamService
{
    public interface IUserJoinTeamService
    {
        Task<int> GetTeamCurrentCount(int teamId);

        Task<ServiceResponse<UserJoinTeam>> joinTeam(UserJoinTeam userJoinTeam);

        Task<List<Team>> getTeambyJoined(string userId);
    }
}
