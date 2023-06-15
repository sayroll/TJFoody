using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Server.Models;
using TJFoody.Shared;

namespace TJFoody.Server.Service.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly infoContext _context;
        public TeamService(infoContext infoContext)
        {
            _context = infoContext;
        }
        public async Task<ServiceResponse<EntityEntry<Team>>> AddTeamAsync(Team team)
        {
            var response = new ServiceResponse<EntityEntry<Team>>();

            try
            {
                await _context.Teams.AddAsync(team);
                await _context.SaveChangesAsync();

                response.Message = "成功";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "创建队伍时发生错误：" + ex.Message;
            }

            return response;
        }

        async Task<ServiceResponse<List<Team>>> ITeamService.GetTeamsAsync()
        {
            var response = new ServiceResponse<List<Team>>
            {
                Data = await _context.Teams.ToListAsync()
            };
            return response;
        }
    }
}
