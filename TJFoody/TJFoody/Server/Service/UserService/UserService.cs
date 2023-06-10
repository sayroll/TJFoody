using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using TJFoody.Server.Models;
using TJFoody.Shared;

namespace TJFoody.Server.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly infoContext _infoContext;
        private readonly IConfiguration _configuration;
        public UserService(infoContext infoContext, IConfiguration configuration)
        {
            _infoContext = infoContext;
            _configuration = configuration;

        }

        public async Task<ServiceResponse<string>> Login(User request)
        {
            var response = new ServiceResponse<string>();
            var user = await _infoContext.Users.FirstOrDefaultAsync(u=>u.Phone.Equals(request.Phone));

            if (user == null)
            {
                response.Success = false;
                response.Message = "手机号没有被注册";
            }
            else
            {
                if(user.Password == request.Password)
                {
                    response.Data = CreateToken(request);
                    response.Message = "登陆成功";
                }
                else
                {
                    response.Success = false;
                    response.Message = "密码不正确";
                }
            }
            return response;
        }

        public async Task<ServiceResponse<User>> Register(string phone, string password, string name)
        {
            var response = new ServiceResponse<User>();

            if(await UserExists(phone))
            {
                response.Success = false;
                response.Message = "该手机号已经被注册";
            }
            else
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
                    response.Message = "注册成功";
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "注册时发生错误：" + ex.Message;
                }
            }

            return response;

        }

        public async Task<bool> UserExists(string phone)
        {
            if(await _infoContext.Users.AnyAsync(u => u.Phone.Equals(phone)))
            {
                return true;
            }
            return false;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            { 
                new Claim(ClaimTypes.NameIdentifier, user.Phone),
                new Claim(ClaimTypes.Name, user.Phone)
            };

            //var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
            //GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            //var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //var token = new JwtSecurityToken(
            //    claims:claims,
            //    expires:DateTime.Now.AddDays(1),
            //    signingCredentials:creds);

            //var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            //return jwt;
            return "1";
        }
    }
}
