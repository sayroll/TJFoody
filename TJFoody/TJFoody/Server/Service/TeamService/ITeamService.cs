using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TJFoody.Server.Service.TeamService
{
    public interface ITeamService
    {
        Task<ServiceResponse<EntityEntry<Team>>> AddTeamAsync(Team team);
        Task<ServiceResponse<List<Team>>> GetTeamsAsync();
        Task<ServiceResponse<int>> GetCountByTeamId(int teamId);
        Task<ServiceResponse<List<Team>>> GetTeamByLeaderId(string leaderId);
    }
}
