using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Server.Models;
using TJFoody.Server.Service.TeamService;
using TJFoody.Shared;

namespace TJFoody.Server.Service.UserJoinTeamService
{
    public class UserJoinTeamService : IUserJoinTeamService
    {
        private readonly infoContext _context;
        private readonly ITeamService _teamService;
        public UserJoinTeamService(infoContext infoContext,ITeamService teamService)
        {
            _context = infoContext;
            _teamService = teamService;
        }

        async public Task<ServiceResponse<List<UserJoinTeam>>> DisbandTeam(int teamId)
        {
            ServiceResponse<List<UserJoinTeam>> response = new ServiceResponse<List<UserJoinTeam>>();

            try
            {
                // Find the team in the Team table
                Team teamToDelete = _context.Teams.FirstOrDefault(t => t.TeamId == teamId);

                if (teamToDelete != null)
                {
                    // Find the UserJoinTeam entries matching the teamId
                    List<UserJoinTeam> entriesToDelete = _context.UserJoinTeams
                        .Where(entry => entry.TeamId == teamId)
                        .ToList();

                    // Remove the UserJoinTeam entries from the context
                    _context.UserJoinTeams.RemoveRange(entriesToDelete);

                    // Remove the team from the context
                    _context.Teams.Remove(teamToDelete);

                    // Save the changes to the database
                    await _context.SaveChangesAsync();

                    response.Data = entriesToDelete;
                    response.Success = true;
                    response.Message = "Team deleted successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Team not found.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error deleting team : " + ex.Message;
            }

            return response;
        }

        async Task<ServiceResponse<EntityEntry<UserJoinTeam>>> IUserJoinTeamService.AddJoinTeamInfo(UserJoinTeam UserJoinTeam)
        {
            var response = new ServiceResponse<EntityEntry<UserJoinTeam>>();
            var count = await _teamService.GetCountByTeamId((int)UserJoinTeam.TeamId);
            IUserJoinTeamService userJoinTeamService = new UserJoinTeamService(_context, _teamService);
            var cur_count = await userJoinTeamService.GetTeamCurrentCount(UserJoinTeam.TeamId);
            
            bool exists = await _context.UserJoinTeams
                .AnyAsync(ujt => ujt.TeamId == UserJoinTeam.TeamId && ujt.UserId == UserJoinTeam.UserId);

            if ( count.Data> cur_count.Data)
            {
                if (!exists)
                {


                    try
                    {
                        await _context.UserJoinTeams.AddAsync(UserJoinTeam);
                        await _context.SaveChangesAsync();

                        response.Message = "成功";
                    }
                    catch (Exception ex)
                    {
                        response.Success = false;
                        response.Message = "加入队伍时发生错误：" + ex.Message;
                    }

                    return response;
                }
                response.Success = false;
                response.Message = "已经在队伍中";
                return response;
            }
            response.Success = false;
            response.Message = "队伍已满";
            return response;
        }

        Task<ServiceResponse<List<string>>> IUserJoinTeamService.GetMember(int teamId)
        {
            ServiceResponse<List<string>> response = new ServiceResponse<List<string>>();

            try
            {
                // Find the userIds that match the teamId in the UserJoinTeam table
                List<string> userIds = _context.UserJoinTeams
                    .Where(entry => entry.TeamId == teamId)
                    .Select(entry => entry.UserId)
                    .ToList();

                response.Data = userIds;
                response.Success = true;
                response.Message = "Member userIds retrieved successfully.";
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error retrieving member userIds: " + ex.Message;
            }

            return Task.FromResult(response);
        }

        async Task<ServiceResponse<List<Team>>> IUserJoinTeamService.GetTeamByJoined(string userId)
        {
            var response = new ServiceResponse<List<Team>>();

            try
            {
                var teamIds = await _context.UserJoinTeams
                    .Where(ujt => ujt.UserId == userId)
                    .Select(ujt => ujt.TeamId)
                    .ToListAsync();

                List<Team> teams = new List<Team>();
                teams = _teamService.GetTeamsAsync().Result.Data;

                List<Team> filteredTeams = teams.Where(t => teamIds.Contains(t.TeamId)).ToList();

                response.Data = filteredTeams;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred while retrieving teams by joined user.";
                // 处理异常，设置适当的错误信息、日志记录等
            }

            return response;
        }

        async Task<ServiceResponse<int>> IUserJoinTeamService.GetTeamCurrentCount(int? teamId)
        {
            var response = new ServiceResponse<int>();
            try
            {
                // 使用您的 DbContext 执行查询
                int count = await _context.UserJoinTeams
                    .Where(ujt => ujt.TeamId == teamId)
                    .CountAsync();

                response.Data = count + 1;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = "An error occurred while retrieving the team count.";
                // 设置其他错误处理逻辑，如记录日志等
            }

            return response;
        }

        async Task<ServiceResponse<List<UserJoinTeam>>> IUserJoinTeamService.QuitTeam(string userId, int teamId)
        {
            ServiceResponse<List<UserJoinTeam>> response = new ServiceResponse<List<UserJoinTeam>>();
            try
            {
                // Find the UserJoinTeam entries matching the userId and teamId
                List<UserJoinTeam> entriesToDelete = _context.UserJoinTeams
                    .Where(entry => entry.UserId == userId && entry.TeamId == teamId)
                    .ToList();

                // Remove the entries from the context
                _context.UserJoinTeams.RemoveRange(entriesToDelete);

                // Save the changes to the database
                await _context.SaveChangesAsync();

                response.Data = entriesToDelete;
                response.Success = true;
                response.Message = "Deleted successfully.";
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error deleting: " + ex.Message;
            }

            return response;
        }
    }
}
