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


        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<ServiceResponse<List<Cuisine>>>> getCuisines()
        {
            var result = await _cuisineService.GetCuisinesAsync();
            return Ok(result);
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

        [HttpGet("GetCuisineByID/{cuisineId}")]
        public async Task<ActionResult<ServiceResponse<Cuisine>>> GetCuisineByID(int cuisineId)
        {
            var response = await _cuisineService.GetCuisineByIDAsync(cuisineId);
            return Ok(response);
        }

        [HttpPost]
        [Route("modify")]
        public async Task<ActionResult<ServiceResponse<Cuisine>>> modifyCuisine(Cuisine cuisine)
        {
            var result = await _cuisineService.ModifyCuisine(cuisine);
            return Ok(result);
        }

    }
}
