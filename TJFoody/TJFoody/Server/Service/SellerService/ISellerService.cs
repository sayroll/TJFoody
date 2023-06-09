
namespace TJFoody.Server.Service.SellerService
{
    public interface ISellerService
    {
        Task<ServiceResponse<List<Seller>>> GetSellersAsync();
    }
}
