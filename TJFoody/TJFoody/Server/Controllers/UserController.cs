using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TJFoody.Server.Models;
using TJFoody.Shared;
using TJFoody.Server.Service.UserService;
using System.Runtime.CompilerServices;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ServiceResponse<User>>> Register(User user)
        {

            var response = await _userService.Register(user.Phone, user.Password, user.Name);
            if(response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(User request)
        {
            var response = await _userService.Login(request);
            if(!response.Success) 
            {
                return BadRequest(response);            
            }
            else
            {
                return Ok(response); 
            }
        }

        [HttpPost]
        [Route("modify")]
        public async Task<ActionResult<ServiceResponse<User>>> ModifyUserInfo(User user)
        {
            var response = await _userService.ModifyUserInfo(user);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet("getByPhone/{phone}")]
        public async Task<ActionResult<ServiceResponse<User>>> getUserByPhone(string phone)
        {
            var response = await _userService.GetUserByPhone(phone);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
