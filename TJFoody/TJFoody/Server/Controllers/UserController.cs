using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TJFoody.Server.Models;
using TJFoody.Shared;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly infoContext _infoContext;
        public UserController(infoContext infoContext) 
        {
            _infoContext = infoContext;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<ServiceResponse<List<User>>>> GetUser()
        {
            var users = await _infoContext.Users.ToListAsync();
            var response = new ServiceResponse<List<User>>()
            {
                Data = users
            };
            return Ok(response);
        }
    }
}
