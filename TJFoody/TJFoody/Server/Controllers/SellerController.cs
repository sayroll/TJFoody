using Microsoft.AspNetCore.Mvc;

namespace TJFoody.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<ServiceResponse<List<Seller>>>> getSellers()
        {
            var result = await _sellerService.GetSellersAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<ServiceResponse<Seller>>> addSeller(Seller seller)
        {
            var result = await _sellerService.AddSellerAsync(seller);
            return Ok(result);
        }

        [HttpPost]
        [Route("modify")]
        public async Task<ActionResult<ServiceResponse<Seller>>> modifySeller(Seller seller)
        {
            var result = await _sellerService.ModifySeller(seller);
            return Ok(result);
        }

        [HttpGet("DeleteSeller/{Id}")]
        public async Task<ActionResult<ServiceResponse<Seller>>> DeleteSeller(int Id)
        {
            var response = await _sellerService.DeleteSeller(Id);
            return Ok(response);
        }
    }
}
