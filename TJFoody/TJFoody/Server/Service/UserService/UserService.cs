﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
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

        public async Task<ServiceResponse<User>> GetUserByPhone(string phone)
        {
            var response = new ServiceResponse<User>();
            var user = await _infoContext.Users.FirstOrDefaultAsync(x => x.Phone.Equals(phone));
            if(user != null)
            {
                response.Data = user;
                response.Message = "找到了";
            }
            else
            {
                response.Success= false;
            }
            return response;
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
                string []avatars = { "https://tse4-mm.cn.bing.net/th/id/OIP-C.fCI3bS2q9T3_vsKUMchDsAAAAA?w=210&h=210&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                                            "https://tse4-mm.cn.bing.net/th/id/OIP-C.fCI3bS2q9T3_vsKUMchDsAAAAA?w=210&h=210&c=7&r=0&o=5&dpr=1.3&pid=1.7",
                                            "https://th.bing.com/th/id/R.1755affb2fb455feb60b1cdc77e49d55?rik=MQyCP8dNYHRm1A&pid=ImgRaw&r=0",
                                            "https://th.bing.com/th/id/R.1c74988f9e9f0ff22363532d9222cecf?rik=dUXsZ0xANtDExQ&pid=ImgRaw&r=0",
                                            "https://th.bing.com/th/id/R.57e393ce4d537f5acc76557fea791ff0?rik=WbZfZn5GHPDjyw&pid=ImgRaw&r=0" };
                int ptr = CppForBlazor.MyAvatar();
                User user = new User
                {
                    Phone = phone,
                    Name = name,
                    Password = password,
                    Avartar = avatars[ptr]
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

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
            GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        async Task<ServiceResponse<User>> IUserService.ModifyUserInfo(User user)
        {
            ServiceResponse<User> response = new ServiceResponse<User>();

            try
            {
                // Find the user in the Users table based on the phone number
                User userToUpdate = _infoContext.Users.FirstOrDefault(u => u.Phone == user.Phone);

                if (userToUpdate != null)
                {
                    // Update the user information
                    userToUpdate.Name = user.Name;
                    userToUpdate.Avartar = user.Avartar;
                    userToUpdate.Password = user.Password;

                    // Save the changes to the database
                    await _infoContext.SaveChangesAsync();

                    response.Data = userToUpdate;
                    response.Success = true;
                    response.Message = "User information updated successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "User not found.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                response.Success = false;
                response.Message = "Error updating user information: " + ex.Message;
            }

            return response;
        }
    }
}
