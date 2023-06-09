using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TJFoody.Server.Models;
using TJFoody.Shared;
using TJFoody.Server.Service.UserService;

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
        public async Task<ActionResult<ServiceResponse<User>>> Register(string phone,string password,string name)
        {

            var response = await _userService.Register(phone, password, name);
            return Ok(response);
        }
    }
}
