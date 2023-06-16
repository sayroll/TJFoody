namespace TJFoody.Client.Services.UserJoinTeamService
{
    public interface IUserJoinTeamService
    {
        Task<int> GetTeamCurrentCount(int teamId);

        Task<ServiceResponse<UserJoinTeam>> joinTeam(UserJoinTeam userJoinTeam);

        Task<List<Team>> getTeambyJoined(string userId);

        Task<ServiceResponse<List<UserJoinTeam>>> QuitTeam(string userId, int teamId);
        Task<ServiceResponse<List<UserJoinTeam>>> DisbandTeam(int teamId);
        Task<List<string>> getMember(int teamId);
    }
}
