using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Server.Service.CuisineService;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuisineController : ControllerBase
    {
        private readonly ICuisineService _cuisineService;

        public CuisineController(ICuisineService cuisineService)
        {
            _cuisineService = cuisineService;
        }

        //[HttpPost]
        //[Route("GetCuisineBySellerID")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Cuisine>>>> GetCuisineBySellerID(int id)
        {
            var response = await _cuisineService.GetCuisineBySellerIDAsync(id);
            return Ok(response);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<ServiceResponse<Cuisine>>> AddCuisine(Cuisine cuisine)
        {
            var response = await _cuisineService.AddCuisineAsync(cuisine);
            return Ok(response);
        }

        //还不能用
        [HttpGet("GetCuisineByID/{cuisineId}")]
        public async Task<ActionResult<ServiceResponse<Cuisine>>> GetCuisineByID(int cuisineId)
        {
            var response = await _cuisineService.GetCuisineByIDAsync(cuisineId);
            return Ok(response);
        }

           

    }
}
