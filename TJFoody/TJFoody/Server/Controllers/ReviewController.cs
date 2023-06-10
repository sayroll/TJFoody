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
    }
}
