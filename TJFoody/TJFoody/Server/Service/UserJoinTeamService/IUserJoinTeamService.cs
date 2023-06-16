using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TJFoody.Server.Service.UserJoinTeamService
{
    public interface IUserJoinTeamService
    {
        Task<ServiceResponse<EntityEntry<UserJoinTeam>>> AddJoinTeamInfo(UserJoinTeam UserJoinTeam);
        Task<ServiceResponse<int>> GetTeamCurrentCount(int? teamId);
        Task<ServiceResponse<List<Team>>> GetTeamByJoined(string userId);

        Task<ServiceResponse<List<UserJoinTeam>>> QuitTeam(string userId,int teamId);

        Task<ServiceResponse<List<UserJoinTeam>>> DisbandTeam(int teamId);
        Task<ServiceResponse<List<string>>> GetMember(int teamId);
    }
}
