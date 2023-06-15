using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Server.Models;
using TJFoody.Server.Service.UserJoinTeamService;
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

        async Task<ServiceResponse<int>> ITeamService.GetCountByTeamId(int teamId)
        {
            var response = new ServiceResponse<int>();

            try
            {
                int count = (int)await _context.Teams
                    .Where(t => t.TeamId == teamId)
                    .Select(t => t.Count)
                    .FirstOrDefaultAsync();

                response.Data = count;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred while retrieving the team count.";
                // 处理其他错误逻辑，如记录日志等
            }

            return response;
        }

        async Task<ServiceResponse<List<Team>>> ITeamService.GetTeamByLeaderId(string leaderId)
        {
            var response = new ServiceResponse<List<Team>>();

            try
            {
                var teams = await _context.Teams
                    .Where(t => t.LeaderId == leaderId)
                    .ToListAsync();

                response.Data = teams;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred while retrieving teams by leader ID.";
                // 处理异常，设置适当的错误信息、日志记录等
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
