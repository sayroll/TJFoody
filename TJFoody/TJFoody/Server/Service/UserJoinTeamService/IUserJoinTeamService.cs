using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TJFoody.Server.Service.UserJoinTeamService
{
    public interface IUserJoinTeamService
    {
        Task<ServiceResponse<EntityEntry<UserJoinTeam>>> AddJoinTeamInfo(UserJoinTeam UserJoinTeam);
        Task<ServiceResponse<int>> GetTeamCurrentCount(int? teamId);
        Task<ServiceResponse<List<Team>>> GetTeamByJoined(string userId);
    }
}
