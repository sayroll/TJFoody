using Microsoft.EntityFrameworkCore;
using TJFoody.Server.Models;
using TJFoody.Shared;

namespace TJFoody.Server.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly infoContext _infoContext;
        public UserService(infoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public async Task<ServiceResponse<User>> Register(string phone, string password, string name)
        {
            var response = new ServiceResponse<User>();

            try
            {
                response.Data = await _infoContext.Users.FindAsync(phone);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "在查找手机号是否被注册过时时发生了错误：" + ex.Message;
            }

            if(response.Data == null)
            {
                User user = new User 
                {
                    Phone = phone,
                    Name = name,
                    Password = password,
                    Avartar = "https://tse4-mm.cn.bing.net/th/id/OIP-C.fCI3bS2q9T3_vsKUMchDsAAAAA?w=210&h=210&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                };
                try 
                {
                    await _infoContext.Users.AddAsync(user);
                    await _infoContext.SaveChangesAsync();
                    response.Data = user;
                    response.Success = true;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "注册时发生错误：" + ex.Message;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "该手机号已经被注册过了";
            }
            return response;
        }
    }
}
