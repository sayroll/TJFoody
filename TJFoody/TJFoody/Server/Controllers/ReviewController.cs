using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TJFoody.Server.Service.ReviewService;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        [Route("addSellerReview")]
        public async Task<ActionResult<ServiceResponse<SellerReview>>> AddSellerReview(SellerReview sellerReview)
        {
            var response = await _reviewService.AddSellerReview(sellerReview);
            return Ok(response);
        }

        [HttpPost]
        [Route("addCuisineReview")]
        public async Task<ActionResult<ServiceResponse<SellerReview>>> AddCuisineReview(CuisineReview cuisineReview)
        {
            var response = await _reviewService.AddCuisineReview(cuisineReview);
            return Ok(response);
        }

        [HttpGet]
        [Route("get/cuisine")]
        public async Task<ActionResult<ServiceResponse<List<CuisineReview>>>> getAllCuisineReviews()
        {
            var response = await _reviewService.GetCuisineReviews();
            if(response!=null && response.Data!=null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("get/seller")]
        public async Task<ActionResult<ServiceResponse<List<SellerReview>>>> getAllSellerReviews()
        {
            var response = await _reviewService.GetSellerReviews();
            if (response != null && response.Data != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

    }
}
