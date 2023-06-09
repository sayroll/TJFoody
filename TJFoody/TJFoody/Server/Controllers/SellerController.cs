using Microsoft.AspNetCore.Mvc;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("controller")]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ServiceResponse<List<Seller>>> getSellers()
        {
            var result = await _sellerService.GetSellersAsync();
            return Ok(result);
        }
    }
}
